using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net.Http.Formatting;
using System.Runtime.CompilerServices;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.SelfHost;
using System.Windows.Forms;
using Siemens.Automation.AutomationTool.API;

namespace MyApplication
{
    public partial class Form1 : Form
    {
        // NOTE:  Some operations such as backup/restore or firmware update can take an extended amount of time,
        // causing your applicatio to think it is deadlocked.  This can be resolved by unchecking the ContextSwitchdeadlock
        // event in visual studio.

        // Global variables
        // These variables are used across many functions and best kept here

        // Chapter 1
        public Network Net = new Network();             // Provides access to the network

        public IProfinetDeviceCollection Devices;       // Contains the devices present on the network
        public ICPU CurrentCPU;                         // The current CPU we are working with

        // Chapter 5
        public String UpdateFilePath = String.Empty;    // The path to the directory containing the firmware update files

        // Chapter 6
        public String BrFilespec = String.Empty;        // The current path/name for CPU backup

        // These are the various window names used in the application.
        // Ideally, these should be saveed as resources in the project
        private const String WnamMyApp = "My Application";

        private const String WnamSetNet = "Select Network Interface";
        private const String WnamInsDev = "Insert Device";
        private const String WnamTrustCert = "Trust TLS Certificate";
        private const String WnamGoRun = "Go to RUN";
        private const String WnamGoStop = "Go to STOP";
        private const String WnamChangeIp = "Change IP SUITE";
        private const String WnamChangeProfi = "Change PROFINET Name";
        private const String WnamResetFactory = "Reset to Factory Defaults";
        private const String WnamUpdateFirmware = "Update Firmware";
        private const String WnamBackupRestore = "Backup / Restore";

        public Form1()
        {
            try
            {
                InitializeComponent();

                // In the constructor, some initialization is required
                // The following code queries for the network interfaces available on the PC
                // and populates the network interfaces list box

                // Collection to contain found network interfaces
                List<string> networkInterfaces;

                // QueryNetworkInterfaceCards examines the host computer and returns a list of network interfaces found
                if (!Net.QueryNetworkInterfaceCards(out networkInterfaces).Succeeded)
                    DisplayErrorMsg("Could not find any network interfaces", WnamMyApp);

                // The list of network interfaces found is added to the collection in the ComboBox so the user can select his desired interface
                foreach (string nic in networkInterfaces)
                    SelectNetworkInterface.Items.Add(nic);

                // Initialize all displayed CPU status information to default (empty) state
                ClearCPUStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// When the user inserts a device, there are a number of operations that must be performed, the most significant of which are:
        /// 1. The address of the device must be read from the control, parsed, and converted to a UINT
        /// 2. The network must be scanned to populate the devices collection
        /// 3. The device collection must be cleared and the new device inserted
        /// 4. Information about the inserted device must be read from the device
        /// 5. Information about this application must be displayed to the user
        /// </summary>
        public void InsertDevice_Click(object sender, EventArgs e)
        {
            // Remove the current CPU (if present)
            // Set displayed CPU status to "Not defined"
            CurrentCPU = null;
            ClearCPUStatus();

            // Parse the user entered IP address and validate it is correct
            // '255.255.255.255' is returned on error
            uint ipAddress = ParseIP(InsertDeviceIpAddress.Text);
            if (ipAddress == 0xffffffff)
            {
                DisplayErrorMsg("Invalid IP address specified", WnamInsDev);
                return;
            }

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                // Initialize the device collection with the devices found on the network

                Devices = Network.GetEmptyCollection();

                IProfinetDevice insertedDevice;
                IScanErrorCollection insertErrorCollection = Devices.InsertDeviceByIP(ipAddress, out insertedDevice);
                if (!insertErrorCollection.Succeeded)
                {
                    DisplayErrorMsg("Device could not be inserted into the project", WnamInsDev);
                }
                // Refresh the new device with information from the actual physical device
                var device = Devices[0];

                // Verify the device is a CPU type.  Error if it is not
                if (Devices[0].Family != DeviceFamily.CPU1200 && Devices[0].Family != DeviceFamily.ET200S)
                {
                    DisplayErrorMsg("Speified device is not a CPU", WnamInsDev);
                    return;
                }

                // Device is a CPU, cast it as such and update display status
                CurrentCPU = Devices[0] as ICPU;

                TrustTLSCertificate.SelectedItem = "Selection needed";

                var pwdResult = CurrentCPU.SetPassword(new EncryptedString(CdpPW.Text));
                var refreshStatus = Devices[0].RefreshStatus();
                if (!refreshStatus.Succeeded)
                {
                    DisplayErrorMsg($"Device could not be found on the network[{refreshStatus.Error.ToString()}]", WnamInsDev);
                    //return;
                }

                UpdateCPUStatus();
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        /// <summary>
        /// Simple function to close down the application.  There is no special teardown needed, upon exit, the API will cleanup.
        /// </summary>
        private void CloseApplication_Click(object sender, EventArgs e)
        {
            // Chapter 1
            Application.Exit();
        }

        /// <summary>
        /// When the user clicks in the SelectNetworkInterface and selects one of the interfaces
        /// on his computer, this selection is passed to the API to indicate the users selection.
        /// This interface will be used for all subsequent operations.
        /// </summary>
        private void SelectNetworkInterface_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Net.SetCurrentNetworkInterface((string)SelectNetworkInterface.SelectedItem).Succeeded)
                DisplayErrorMsg("Selected network interface could not be set", WnamSetNet);
        }

        /// <summary>
        /// The request to go to run is performed by a single method call on the current CPU object.  When finished
        /// the new CPU mode must be displayed to the user.
        /// </summary>
        private void RunButton_Click(object sender, EventArgs e)
        {
            if (!CpuDefined(WnamGoRun)) return;

            Cursor.Current = Cursors.WaitCursor;

            // The selected flag must be set on the current cpu object before the operation can be performed
            CurrentCPU.Selected = true;

            // Set the operating state to Run
            if (!CurrentCPU.SetOperatingState(OperatingStateREQ.Run).Succeeded)
                DisplayErrorMsg("Could not place the device into RUN mode", WnamGoRun);

            Cursor.Current = Cursors.Default;

            // Update CPU status to reflect the change in operating mode
            UpdateCPUStatus();
        }

        /// <summary>
        /// The request to go to stop is performed by a single method call on the current CPU object.  When finished
        /// the new CPU mode must be displayed to the user.
        /// </summary>
        private void StopButton_Click(object sender, EventArgs e)
        {
            if (!CpuDefined(WnamGoStop))
                return;

            Cursor.Current = Cursors.WaitCursor;

            // The selected flag must be set before the operation can be performed
            CurrentCPU.Selected = true;

            // Set the operating state to stop
            var tmp = CurrentCPU.SetOperatingState(OperatingStateREQ.Stop);
            if (!CurrentCPU.SetOperatingState(OperatingStateREQ.Stop).Succeeded)
                DisplayErrorMsg("Could not place the device into STOP mode", WnamGoStop);

            Cursor.Current = Cursors.Default;

            // update CPU status to reflect the change in operating mode
            UpdateCPUStatus();
        }

        /// <summary>
        /// The Change IP suite will change the IP address, subnet mask, and the gateway address.  All of these are modified within
        /// the same method call.  The user will enter all three of these as text, each must be parsed and passed as UINT values.
        /// </summary>
        private void ChangeIpSuite_Click(object sender, EventArgs e)
        {
            if (!CpuDefined(WnamChangeIp))
                return;

            // Pull the IP, SN, and GW from their respective controls and convert them to UINT
            uint newIp = ParseIP(SuiteIp.Text);
            uint newSn = ParseIP(SuiteSn.Text);
            uint newGw = ParseIP(SuiteGw.Text);

            // If any value returned error, do not attempt to set the new values
            if (newIp == 0xffffffff || newSn == 0xffffffff || newGw == 0xffffffff)
            {
                DisplayErrorMsg("Invalid IP, Subnet, or Gateway address specified", WnamChangeIp);
                return;
            }

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                var ipResult = CurrentCPU.SetIP(newIp, newSn, newGw);
                // Set the new IP suite
                if (!ipResult.Succeeded)
                {
                    DisplayErrorMsg($"Could not set IP address-{ipResult.Error}", WnamChangeIp);
                    return;
                }

                InsertDeviceIpAddress.Text = SuiteIp.Text;

                // If we changed the IP address of the device, then we need to remove the old device and reinsert
                //the device again with it's changed address.  We will cheat and call the insert device button click method.
                InsertDevice_Click(sender, e);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        /// <summary>
        /// When the user selects to change the Profinet name, the name is pulled from the control and passed to the
        /// SetProfiName directly.
        /// Please note, there are a few conditions required to successfully set the name:
        /// 1. The CPU must be configured to allow this
        /// 2. A valid Profinet name must be specified
        /// </summary>
        private void SetProfinetName_Click(object sender, EventArgs e)
        {
            if (!CpuDefined(WnamChangeProfi))
                return;

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                // Set the Profinet name
                if (!CurrentCPU.SetProfinetName(ProfinetName.Text).Succeeded)
                {
                    DisplayErrorMsg("Could not set new PROFINET Name", WnamChangeProfi);
                }

                // refresh the application with the new profinet name
                UpdateCPUStatus();
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        /// <summary>
        /// This code resets the device to factory defaults state.  When operating on a safety device such as an S7-1200F CPU, additional actions
        /// are requred.
        /// A safety operation should implement a diverse check so that the user cannot accidentally perform the operation, this is done by the
        /// setting of a second flag: 'SelectedConfirmed'
        /// In this example, the SelectedConfirmed flag is set based upon user response to an "Are You Sure?" message box.
        /// </summary>
        private void ResetToFactoryDefaults_Click(object sender, EventArgs e)
        {
            if (!CpuDefined(WnamResetFactory))
                return;

            // Set the selected flag
            CurrentCPU.Selected = true;

            // Default the SelectedConfirmed to false, the operation will not be performed if this flag is false
            CurrentCPU.SelectedConfirmed = false;

            // This dialog alerts the user that a safety operation and asks for confirmation.
            // If the user confirms, the flag is set.  If not, the flag remains unset and an immediate return is executed.
            // This adds diversity and further garuntees that a safety operation cannot accidentally be performed.
            if (MessageBox.Show("Reset to Factory Defaults is a safety relevant operation, do you wish to continue?",
                    WnamResetFactory, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                CurrentCPU.SelectedConfirmed = true;
            }
            else
            {
                return;
            }

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                // Perform the operation
                if (!CurrentCPU.ResetToFactoryDefaults().Succeeded)
                {
                    DisplayErrorMsg("Could not reset the device to factory defaults", WnamResetFactory);
                }

                // Now that the device has been reset, it must be re-read and all displayed information about the device be updated for the user
                CurrentCPU.RefreshStatus();
                UpdateCPUStatus();
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        /// <summary>
        /// The UpdateFirmware method will attempt to update the firmware of the current device.  This is a three part operation:
        /// 1. The user specified firmware update file is validated against the current device
        /// 2. The firmware is updated on the device
        /// 3. The device is read and new status is displayed to the user
        /// </summary>
        private void UpdateFirmware_Click(object sender, EventArgs e)
        {
            if (!CpuDefined(WnamUpdateFirmware))
                return;

            // The device must be selected
            CurrentCPU.Selected = true;

            // Verify the user specified firmware file is valid for the current device
            if (!CurrentCPU.SetFirmwareFile(UpdateFilePath).Succeeded)
            {
                DisplayErrorMsg("Firmware file is not valid for selected device", WnamUpdateFirmware);
                return;
            }

            Cursor.Current = Cursors.WaitCursor;
            try
            {
                // Update the firmware of the device
                if (!CurrentCPU.FirmwareUpdate(CurrentCPU.ID, true).Succeeded)
                {
                    DisplayErrorMsg("Firmware update operation failed", WnamUpdateFirmware);
                }

                // Re-read the device and display new device status to the user
                CurrentCPU.RefreshStatus();
                UpdateCPUStatus();
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        /// <summary>
        /// The BrowseUpdateFile will assist the user in selecting the desired update file.
        /// This is a simple browser control that will by default display only update files (.upd)
        /// </summary>
        private void BrowseUpdateFile_Click(object sender, EventArgs e)
        {
            // Tutorial and example both use this method as is: Chapter 5
            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
                openFileDialog1.InitialDirectory = @"%userprofile%\documents";
                openFileDialog1.Filter = "Upd Files (*.upd)|*.upd|All files (*.*)|*.*";
                openFileDialog1.FilterIndex = 2;
                openFileDialog1.RestoreDirectory = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    UpdateFilePath = openFileDialog1.FileName;
                    UpdateFileName.Text = openFileDialog1.SafeFileName;
                }
            }
        }

        /// <summary>
        /// The Backup method will create a backup of the current device.  This backup contains hardware configuration and program information
        /// stored in a single backup file.
        /// When completed, the backup file will be placed in the current users documents folder, the file name will be a combination
        /// of the device name and MAC address
        /// </summary>
        private void Backup_Click(object sender, EventArgs e)
        {
            if (!CpuDefined(WnamBackupRestore))
                return;

            Cursor.Current = Cursors.WaitCursor;
            try
            {
                // Generate the backup file pathspec.  If it already exists, delete it
                BrFilespec = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\" + CurrentCPU.Name +
                             " " + CurrentCPU.MACString.Replace(':', '-') + ".s7pbkp";

                if (File.Exists(BrFilespec))
                    File.Delete(BrFilespec);

                CurrentCPU.Selected = true;

                // Perform the backup, this can take a while on larger devices
                var backupResult = CurrentCPU.Backup(BrFilespec);
                if (!backupResult.Succeeded)
                {
                    DisplayErrorMsg("Backup operation failed", WnamBackupRestore);
                    return;
                }

                BrFile.Text = BrFilespec;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        /// <summary>
        /// The Restore method will restore the device to the state contained within a previously made backup.
        /// Restore is a safety relevant operation, confirmation is required.  Please reference the Reset to Factory Defaults method
        /// for the philosophy behind confirmation and diverse checking.
        /// Upon successful restore, the new state of the device will be read and updated for the user
        /// </summary>
        private void Restore_Click(object sender, EventArgs e)
        {
            if (!CpuDefined(WnamBackupRestore))
                return;

            CurrentCPU.Selected = true;

            // Safety relevant section, confirmation and diverse checking should be implemented
            CurrentCPU.SelectedConfirmed = false;
            if (MessageBox.Show("Restore is a safety relevant operation, do you wish to continue?",
                    WnamBackupRestore, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                CurrentCPU.SelectedConfirmed = true;
            }
            else
            {
                return;
            }

            try
            {
                // verify that the fie to be restored is valid for the current device
                if (!CurrentCPU.SetBackupFile(BrFilespec).Succeeded)
                {
                    DisplayErrorMsg("Invalid backup file specified", WnamBackupRestore);
                    return;
                }

                Cursor.Current = Cursors.WaitCursor;

                // Perform the restore operation, this can take a long time on larger devices
                var restoreResult = CurrentCPU.Restore();
                if (!restoreResult.Succeeded)
                {
                    DisplayErrorMsg("Restore operation failed", WnamBackupRestore);
                }

                // Restore has finished, now reread the device ...
                var pwdResult = CurrentCPU.SetPassword(new EncryptedString(CdpPW.Text));
                var refreshResult = CurrentCPU.RefreshStatus();
                if (!refreshResult.Succeeded)
                {
                    DisplayErrorMsg("Device could not be refreshed after restore", WnamBackupRestore);
                }

                // ... and update the user visible information
                UpdateCPUStatus();
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        #region Helper Methods

        // Contained here are common helper methods used by multiple operations

        /// <summary>
        /// ParseIP is a simple method that will convert a text based xxx.xxx.xxx.xxx IPv4 address to a UINT.
        /// Please be aware this method performs an endianess switch.
        /// </summary>
        /// <param name="StrNetParm">Text based IPv4 address</param>
        /// <returns></returns>
        private uint ParseIP(string StrNetParm)
        {
            try
            {
                System.Net.IPAddress ip = System.Net.IPAddress.Parse(StrNetParm);
                byte[] bytes = ip.GetAddressBytes();
                Array.Reverse(bytes);
                return BitConverter.ToUInt32(bytes, 0);
            }
            catch (Exception e)
            {
                return 0xffffffff;
            }
        }

        /// <summary>
        /// UpdateCPUStatus will refresh all controls and labels in the application.  This method is to be called whenever
        /// an operation changes the CPU.
        /// </summary>
        private void UpdateCPUStatus()
        {
            // Chapter 1:
            DeviceName.Text = CurrentCPU.Name;
            ArticleNumber.Text = CurrentCPU.ArticleNumber;
            OperatingMode.Text = CurrentCPU.OperatingMode == OperatingState.Run ? "RUN" : "STOP";

            // Chapter 2:
            if (CurrentCPU.IPString.StartsWith("X"))
                SuiteIp.Text = CurrentCPU.IPString.Substring(4);
            else
                SuiteIp.Text = CurrentCPU.IPString;

            SuiteSn.Text = CurrentCPU.SubnetMaskString;
            SuiteGw.Text = CurrentCPU.DefaultGatewayString;

            // Chapter 3:
            ProfinetName.Text = CurrentCPU.ProfinetConvertedName;

            // Chapter 5:
            FirmwareVersion.Text = CurrentCPU.FirmwareVersion;

            // Security 6":
            CdpStatus.Text = CurrentCPU.ConfigurationProtectionData.ToString();
        }

        /// <summary>
        /// ClearCPUStatus will clear all controls and labels in the application.
        /// </summary>
        private void ClearCPUStatus()
        {
            // Chapter 1:
            DeviceName.Text = string.Empty;
            ArticleNumber.Text = string.Empty;
            OperatingMode.Text = string.Empty;

            // Chapter 2:
            SuiteIp.Text = string.Empty;
            SuiteSn.Text = string.Empty;
            SuiteGw.Text = string.Empty;

            // Chapter 3:
            ProfinetName.Text = string.Empty;

            // Chapter 5:
            FirmwareVersion.Text = string.Empty;

            // Chapter 6:
            BrFile.Text = string.Empty;
        }

        /// <summary>
        /// CpuDefined is a method that will examine the Current CPU to determine if it is valid.
        /// Many operations in this application require that the current CPU be defined.  This method provides a
        /// mechanism to check this and to display a message to the user when he attempts an operation on an undefined
        /// CPU
        /// </summary>
        /// <param name="strOp">This is the calling method.  In the event of error, it is used to set the title of the mesage box. </param>
        /// <returns></returns>
        private bool CpuDefined(string strOp)
        {
            if (CurrentCPU == null)
            {
                MessageBox.Show("ERROR: No CPU is selected", strOp, MessageBoxButtons.OK);
                return false;
            }

            return true;
        }

        /// <summary>
        /// DisplayErrorMsg displays error messages for the application.  There are many possible errors that may occur, this
        /// method collects display of error messages into one place, thereby providing a common look and feel for the messages.
        /// </summary>
        /// <param name="msg">The message to be displayed</param>
        /// <param name="winNam">The name of the calling function, this is used to set the message box title</param>
        private void DisplayErrorMsg(string msg, string winNam)
        {
            MessageBox.Show("ERROR: " + msg, winNam, MessageBoxButtons.OK);
        }

        #endregion Helper Methods

        private void Certificate_Click(object sender, EventArgs e)
        {
            CurrentCPU.CertificateStore.ShowDialog();
        }

        private void TrustTLSCertificate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((string)TrustTLSCertificate.SelectedItem == "Always")
                CurrentCPU.SetTrustCertificateStore(TrustCertificateType.Always);
            else if ((string)TrustTLSCertificate.SelectedItem == "Never")
                CurrentCPU.SetTrustCertificateStore(TrustCertificateType.Never);
            else
                CurrentCPU.SetTrustCertificateStore(TrustCertificateType.SelectionNeeded);
        }

        private void SetConfigDataPW_Click(object sender, EventArgs e)
        {
            var result = CurrentCPU.SetConfigurationDataProtectionPassword(new EncryptedString(CdpPW.Text));
            result = CurrentCPU.SetPassword(new EncryptedString(CdpPW.Text));
            UpdateCPUStatus();
        }

        private void DeleteConfigDataPW_Click(object sender, EventArgs e)
        {
            CurrentCPU.DeleteConfigurationDataProtectionPassword();
            UpdateCPUStatus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var config = new HttpSelfHostConfiguration("http://localhost:8091/");
                config.Formatters.Clear();
                config.Formatters.Add(new JsonMediaTypeFormatter());
                config.Routes.MapHttpRoute(
                    "API Default", "api/{controller}/{id}",
                    new { id = RouteParameter.Optional });

                HttpSelfHostServer server = new HttpSelfHostServer(config);

                server.OpenAsync().Wait();
                Console.WriteLine("Press Enter to quit.");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}