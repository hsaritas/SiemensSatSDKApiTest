namespace MyApplication
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SelectNetworkInterface = new System.Windows.Forms.ComboBox();
            this.NetworkInterface = new System.Windows.Forms.Label();
            this.CloseApplication = new System.Windows.Forms.Button();
            this.InsertDeviceIpAddress = new System.Windows.Forms.TextBox();
            this.DeviceIpAddressLabel = new System.Windows.Forms.Label();
            this.InsertDevice = new System.Windows.Forms.Button();
            this.DeviceNameLabel = new System.Windows.Forms.Label();
            this.DeviceArticleNumberLabel = new System.Windows.Forms.Label();
            this.OperatingModeLabel = new System.Windows.Forms.Label();
            this.DeviceName = new System.Windows.Forms.Label();
            this.ArticleNumber = new System.Windows.Forms.Label();
            this.OperatingMode = new System.Windows.Forms.Label();
            this.RunButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.ChangeIpSuite = new System.Windows.Forms.Button();
            this.IpLabel = new System.Windows.Forms.Label();
            this.SuiteIp = new System.Windows.Forms.TextBox();
            this.SnLabel = new System.Windows.Forms.Label();
            this.SuiteSn = new System.Windows.Forms.TextBox();
            this.GwLabel = new System.Windows.Forms.Label();
            this.SuiteGw = new System.Windows.Forms.TextBox();
            this.SetProfinetName = new System.Windows.Forms.Button();
            this.ProfinetNameLabel = new System.Windows.Forms.Label();
            this.ProfinetName = new System.Windows.Forms.TextBox();
            this.ResetToFactoryDefaults = new System.Windows.Forms.Button();
            this.FirmwareUpdate = new System.Windows.Forms.GroupBox();
            this.UpdateFirmware = new System.Windows.Forms.Button();
            this.BrowseUpdateFile = new System.Windows.Forms.Button();
            this.UpdateFileName = new System.Windows.Forms.Label();
            this.UpdateFileNameLabel = new System.Windows.Forms.Label();
            this.FirmwareVersion = new System.Windows.Forms.Label();
            this.VersionLabel = new System.Windows.Forms.Label();
            this.BackupRestore = new System.Windows.Forms.GroupBox();
            this.Restore = new System.Windows.Forms.Button();
            this.BrFileLabel = new System.Windows.Forms.Label();
            this.Backup = new System.Windows.Forms.Button();
            this.BrFile = new System.Windows.Forms.Label();
            this.ShowCertificate = new System.Windows.Forms.Button();
            this.TrustTLSCertLabel = new System.Windows.Forms.Label();
            this.TrustTLSCertificate = new System.Windows.Forms.ComboBox();
            this.ConfigurationDataProtectionLabel = new System.Windows.Forms.Label();
            this.CdpSet = new System.Windows.Forms.Button();
            this.CdpDelete = new System.Windows.Forms.Button();
            this.ConfigurationDataPwLabel = new System.Windows.Forms.Label();
            this.CdpPW = new System.Windows.Forms.TextBox();
            this.CdpGroup = new System.Windows.Forms.GroupBox();
            this.CdpStatus = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.FirmwareUpdate.SuspendLayout();
            this.BackupRestore.SuspendLayout();
            this.CdpGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // SelectNetworkInterface
            // 
            this.SelectNetworkInterface.FormattingEnabled = true;
            this.SelectNetworkInterface.Location = new System.Drawing.Point(122, 22);
            this.SelectNetworkInterface.Name = "SelectNetworkInterface";
            this.SelectNetworkInterface.Size = new System.Drawing.Size(453, 21);
            this.SelectNetworkInterface.TabIndex = 0;
            this.SelectNetworkInterface.SelectedIndexChanged += new System.EventHandler(this.SelectNetworkInterface_SelectedIndexChanged);
            // 
            // NetworkInterface
            // 
            this.NetworkInterface.AutoSize = true;
            this.NetworkInterface.Location = new System.Drawing.Point(21, 25);
            this.NetworkInterface.Name = "NetworkInterface";
            this.NetworkInterface.Size = new System.Drawing.Size(95, 13);
            this.NetworkInterface.TabIndex = 1;
            this.NetworkInterface.Text = "Network Interface:";
            // 
            // CloseApplication
            // 
            this.CloseApplication.Location = new System.Drawing.Point(758, 509);
            this.CloseApplication.Name = "CloseApplication";
            this.CloseApplication.Size = new System.Drawing.Size(75, 23);
            this.CloseApplication.TabIndex = 2;
            this.CloseApplication.Text = "Close";
            this.CloseApplication.UseVisualStyleBackColor = true;
            this.CloseApplication.Click += new System.EventHandler(this.CloseApplication_Click);
            // 
            // InsertDeviceIpAddress
            // 
            this.InsertDeviceIpAddress.Location = new System.Drawing.Point(122, 56);
            this.InsertDeviceIpAddress.Name = "InsertDeviceIpAddress";
            this.InsertDeviceIpAddress.Size = new System.Drawing.Size(121, 20);
            this.InsertDeviceIpAddress.TabIndex = 3;
            this.InsertDeviceIpAddress.Text = "192.168.142.232";
            // 
            // DeviceIpAddressLabel
            // 
            this.DeviceIpAddressLabel.AutoSize = true;
            this.DeviceIpAddressLabel.Location = new System.Drawing.Point(55, 59);
            this.DeviceIpAddressLabel.Name = "DeviceIpAddressLabel";
            this.DeviceIpAddressLabel.Size = new System.Drawing.Size(61, 13);
            this.DeviceIpAddressLabel.TabIndex = 4;
            this.DeviceIpAddressLabel.Text = "IP Address:";
            // 
            // InsertDevice
            // 
            this.InsertDevice.Location = new System.Drawing.Point(249, 54);
            this.InsertDevice.Name = "InsertDevice";
            this.InsertDevice.Size = new System.Drawing.Size(82, 23);
            this.InsertDevice.TabIndex = 5;
            this.InsertDevice.Text = "Insert Device";
            this.InsertDevice.UseVisualStyleBackColor = true;
            this.InsertDevice.Click += new System.EventHandler(this.InsertDevice_Click);
            // 
            // DeviceNameLabel
            // 
            this.DeviceNameLabel.AutoSize = true;
            this.DeviceNameLabel.Location = new System.Drawing.Point(72, 130);
            this.DeviceNameLabel.Name = "DeviceNameLabel";
            this.DeviceNameLabel.Size = new System.Drawing.Size(44, 13);
            this.DeviceNameLabel.TabIndex = 6;
            this.DeviceNameLabel.Text = "Device:";
            // 
            // DeviceArticleNumberLabel
            // 
            this.DeviceArticleNumberLabel.AutoSize = true;
            this.DeviceArticleNumberLabel.Location = new System.Drawing.Point(38, 158);
            this.DeviceArticleNumberLabel.Name = "DeviceArticleNumberLabel";
            this.DeviceArticleNumberLabel.Size = new System.Drawing.Size(79, 13);
            this.DeviceArticleNumberLabel.TabIndex = 7;
            this.DeviceArticleNumberLabel.Text = "Article Number:";
            // 
            // OperatingModeLabel
            // 
            this.OperatingModeLabel.AutoSize = true;
            this.OperatingModeLabel.Location = new System.Drawing.Point(30, 184);
            this.OperatingModeLabel.Name = "OperatingModeLabel";
            this.OperatingModeLabel.Size = new System.Drawing.Size(86, 13);
            this.OperatingModeLabel.TabIndex = 8;
            this.OperatingModeLabel.Text = "Operating Mode:";
            // 
            // DeviceName
            // 
            this.DeviceName.Location = new System.Drawing.Point(119, 130);
            this.DeviceName.Name = "DeviceName";
            this.DeviceName.Size = new System.Drawing.Size(200, 13);
            this.DeviceName.TabIndex = 9;
            // 
            // ArticleNumber
            // 
            this.ArticleNumber.Location = new System.Drawing.Point(119, 158);
            this.ArticleNumber.Name = "ArticleNumber";
            this.ArticleNumber.Size = new System.Drawing.Size(200, 13);
            this.ArticleNumber.TabIndex = 10;
            // 
            // OperatingMode
            // 
            this.OperatingMode.Location = new System.Drawing.Point(118, 184);
            this.OperatingMode.Name = "OperatingMode";
            this.OperatingMode.Size = new System.Drawing.Size(50, 13);
            this.OperatingMode.TabIndex = 11;
            // 
            // RunButton
            // 
            this.RunButton.Location = new System.Drawing.Point(230, 179);
            this.RunButton.Name = "RunButton";
            this.RunButton.Size = new System.Drawing.Size(75, 23);
            this.RunButton.TabIndex = 12;
            this.RunButton.Text = "RUN";
            this.RunButton.UseVisualStyleBackColor = true;
            this.RunButton.Click += new System.EventHandler(this.RunButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(311, 179);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(75, 23);
            this.StopButton.TabIndex = 13;
            this.StopButton.Text = "STOP";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // ChangeIpSuite
            // 
            this.ChangeIpSuite.Location = new System.Drawing.Point(249, 221);
            this.ChangeIpSuite.Name = "ChangeIpSuite";
            this.ChangeIpSuite.Size = new System.Drawing.Size(105, 23);
            this.ChangeIpSuite.TabIndex = 16;
            this.ChangeIpSuite.Text = "Change";
            this.ChangeIpSuite.UseVisualStyleBackColor = true;
            this.ChangeIpSuite.Click += new System.EventHandler(this.ChangeIpSuite_Click);
            // 
            // IpLabel
            // 
            this.IpLabel.AutoSize = true;
            this.IpLabel.Location = new System.Drawing.Point(93, 226);
            this.IpLabel.Name = "IpLabel";
            this.IpLabel.Size = new System.Drawing.Size(20, 13);
            this.IpLabel.TabIndex = 15;
            this.IpLabel.Text = "IP:";
            // 
            // SuiteIp
            // 
            this.SuiteIp.Location = new System.Drawing.Point(121, 223);
            this.SuiteIp.Name = "SuiteIp";
            this.SuiteIp.Size = new System.Drawing.Size(100, 20);
            this.SuiteIp.TabIndex = 14;
            // 
            // SnLabel
            // 
            this.SnLabel.AutoSize = true;
            this.SnLabel.Location = new System.Drawing.Point(70, 252);
            this.SnLabel.Name = "SnLabel";
            this.SnLabel.Size = new System.Drawing.Size(44, 13);
            this.SnLabel.TabIndex = 18;
            this.SnLabel.Text = "Subnet:";
            // 
            // SuiteSn
            // 
            this.SuiteSn.Location = new System.Drawing.Point(121, 249);
            this.SuiteSn.Name = "SuiteSn";
            this.SuiteSn.Size = new System.Drawing.Size(100, 20);
            this.SuiteSn.TabIndex = 17;
            // 
            // GwLabel
            // 
            this.GwLabel.AutoSize = true;
            this.GwLabel.Location = new System.Drawing.Point(62, 278);
            this.GwLabel.Name = "GwLabel";
            this.GwLabel.Size = new System.Drawing.Size(52, 13);
            this.GwLabel.TabIndex = 20;
            this.GwLabel.Text = "Gateway:";
            // 
            // SuiteGw
            // 
            this.SuiteGw.Location = new System.Drawing.Point(121, 275);
            this.SuiteGw.Name = "SuiteGw";
            this.SuiteGw.Size = new System.Drawing.Size(100, 20);
            this.SuiteGw.TabIndex = 19;
            // 
            // SetProfinetName
            // 
            this.SetProfinetName.Location = new System.Drawing.Point(774, 224);
            this.SetProfinetName.Name = "SetProfinetName";
            this.SetProfinetName.Size = new System.Drawing.Size(45, 23);
            this.SetProfinetName.TabIndex = 23;
            this.SetProfinetName.Text = "Set";
            this.SetProfinetName.UseVisualStyleBackColor = true;
            this.SetProfinetName.Click += new System.EventHandler(this.SetProfinetName_Click);
            // 
            // ProfinetNameLabel
            // 
            this.ProfinetNameLabel.AutoSize = true;
            this.ProfinetNameLabel.Location = new System.Drawing.Point(441, 229);
            this.ProfinetNameLabel.Name = "ProfinetNameLabel";
            this.ProfinetNameLabel.Size = new System.Drawing.Size(95, 13);
            this.ProfinetNameLabel.TabIndex = 22;
            this.ProfinetNameLabel.Text = "PROFINET Name:";
            // 
            // ProfinetName
            // 
            this.ProfinetName.Location = new System.Drawing.Point(553, 226);
            this.ProfinetName.Name = "ProfinetName";
            this.ProfinetName.Size = new System.Drawing.Size(204, 20);
            this.ProfinetName.TabIndex = 21;
            // 
            // ResetToFactoryDefaults
            // 
            this.ResetToFactoryDefaults.Location = new System.Drawing.Point(121, 310);
            this.ResetToFactoryDefaults.Name = "ResetToFactoryDefaults";
            this.ResetToFactoryDefaults.Size = new System.Drawing.Size(168, 23);
            this.ResetToFactoryDefaults.TabIndex = 24;
            this.ResetToFactoryDefaults.Text = "Reset to Factory Defaults";
            this.ResetToFactoryDefaults.UseVisualStyleBackColor = true;
            this.ResetToFactoryDefaults.Click += new System.EventHandler(this.ResetToFactoryDefaults_Click);
            // 
            // FirmwareUpdate
            // 
            this.FirmwareUpdate.Controls.Add(this.UpdateFirmware);
            this.FirmwareUpdate.Controls.Add(this.BrowseUpdateFile);
            this.FirmwareUpdate.Controls.Add(this.UpdateFileName);
            this.FirmwareUpdate.Controls.Add(this.UpdateFileNameLabel);
            this.FirmwareUpdate.Controls.Add(this.FirmwareVersion);
            this.FirmwareUpdate.Controls.Add(this.VersionLabel);
            this.FirmwareUpdate.Location = new System.Drawing.Point(31, 366);
            this.FirmwareUpdate.Name = "FirmwareUpdate";
            this.FirmwareUpdate.Size = new System.Drawing.Size(385, 120);
            this.FirmwareUpdate.TabIndex = 25;
            this.FirmwareUpdate.TabStop = false;
            this.FirmwareUpdate.Text = "Firmware Update";
            // 
            // UpdateFirmware
            // 
            this.UpdateFirmware.Location = new System.Drawing.Point(21, 81);
            this.UpdateFirmware.Name = "UpdateFirmware";
            this.UpdateFirmware.Size = new System.Drawing.Size(105, 23);
            this.UpdateFirmware.TabIndex = 26;
            this.UpdateFirmware.Text = "Update";
            this.UpdateFirmware.UseVisualStyleBackColor = true;
            this.UpdateFirmware.Click += new System.EventHandler(this.UpdateFirmware_Click);
            // 
            // BrowseUpdateFile
            // 
            this.BrowseUpdateFile.Location = new System.Drawing.Point(346, 50);
            this.BrowseUpdateFile.Name = "BrowseUpdateFile";
            this.BrowseUpdateFile.Size = new System.Drawing.Size(28, 23);
            this.BrowseUpdateFile.TabIndex = 26;
            this.BrowseUpdateFile.Text = "...";
            this.BrowseUpdateFile.UseVisualStyleBackColor = true;
            this.BrowseUpdateFile.Click += new System.EventHandler(this.BrowseUpdateFile_Click);
            // 
            // UpdateFileName
            // 
            this.UpdateFileName.Location = new System.Drawing.Point(65, 55);
            this.UpdateFileName.Name = "UpdateFileName";
            this.UpdateFileName.Size = new System.Drawing.Size(275, 13);
            this.UpdateFileName.TabIndex = 29;
            this.UpdateFileName.Text = "<Browse to select a file>";
            // 
            // UpdateFileNameLabel
            // 
            this.UpdateFileNameLabel.AutoSize = true;
            this.UpdateFileNameLabel.Location = new System.Drawing.Point(18, 55);
            this.UpdateFileNameLabel.Name = "UpdateFileNameLabel";
            this.UpdateFileNameLabel.Size = new System.Drawing.Size(26, 13);
            this.UpdateFileNameLabel.TabIndex = 28;
            this.UpdateFileNameLabel.Text = "File:";
            // 
            // FirmwareVersion
            // 
            this.FirmwareVersion.Location = new System.Drawing.Point(65, 30);
            this.FirmwareVersion.Name = "FirmwareVersion";
            this.FirmwareVersion.Size = new System.Drawing.Size(115, 13);
            this.FirmwareVersion.TabIndex = 27;
            // 
            // VersionLabel
            // 
            this.VersionLabel.AutoSize = true;
            this.VersionLabel.Location = new System.Drawing.Point(18, 30);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(45, 13);
            this.VersionLabel.TabIndex = 26;
            this.VersionLabel.Text = "Version:";
            // 
            // BackupRestore
            // 
            this.BackupRestore.Controls.Add(this.Restore);
            this.BackupRestore.Controls.Add(this.BrFileLabel);
            this.BackupRestore.Controls.Add(this.Backup);
            this.BackupRestore.Controls.Add(this.BrFile);
            this.BackupRestore.Location = new System.Drawing.Point(433, 366);
            this.BackupRestore.Name = "BackupRestore";
            this.BackupRestore.Size = new System.Drawing.Size(406, 120);
            this.BackupRestore.TabIndex = 30;
            this.BackupRestore.TabStop = false;
            this.BackupRestore.Text = "Backup / Restore";
            // 
            // Restore
            // 
            this.Restore.Location = new System.Drawing.Point(281, 81);
            this.Restore.Name = "Restore";
            this.Restore.Size = new System.Drawing.Size(105, 23);
            this.Restore.TabIndex = 31;
            this.Restore.Text = "Restore";
            this.Restore.UseVisualStyleBackColor = true;
            this.Restore.Click += new System.EventHandler(this.Restore_Click);
            // 
            // BrFileLabel
            // 
            this.BrFileLabel.AutoSize = true;
            this.BrFileLabel.Location = new System.Drawing.Point(13, 55);
            this.BrFileLabel.Name = "BrFileLabel";
            this.BrFileLabel.Size = new System.Drawing.Size(26, 13);
            this.BrFileLabel.TabIndex = 30;
            this.BrFileLabel.Text = "File:";
            // 
            // Backup
            // 
            this.Backup.Location = new System.Drawing.Point(16, 81);
            this.Backup.Name = "Backup";
            this.Backup.Size = new System.Drawing.Size(105, 23);
            this.Backup.TabIndex = 26;
            this.Backup.Text = "Backup";
            this.Backup.UseVisualStyleBackColor = true;
            this.Backup.Click += new System.EventHandler(this.Backup_Click);
            // 
            // BrFile
            // 
            this.BrFile.Location = new System.Drawing.Point(45, 55);
            this.BrFile.Name = "BrFile";
            this.BrFile.Size = new System.Drawing.Size(355, 13);
            this.BrFile.TabIndex = 29;
            // 
            // ShowCertificate
            // 
            this.ShowCertificate.Location = new System.Drawing.Point(249, 88);
            this.ShowCertificate.Name = "ShowCertificate";
            this.ShowCertificate.Size = new System.Drawing.Size(47, 23);
            this.ShowCertificate.TabIndex = 31;
            this.ShowCertificate.Text = "Show";
            this.ShowCertificate.UseVisualStyleBackColor = true;
            this.ShowCertificate.Click += new System.EventHandler(this.Certificate_Click);
            // 
            // TrustTLSCertLabel
            // 
            this.TrustTLSCertLabel.AutoSize = true;
            this.TrustTLSCertLabel.Location = new System.Drawing.Point(9, 92);
            this.TrustTLSCertLabel.Name = "TrustTLSCertLabel";
            this.TrustTLSCertLabel.Size = new System.Drawing.Size(107, 13);
            this.TrustTLSCertLabel.TabIndex = 32;
            this.TrustTLSCertLabel.Text = "Trust TLS Certificate:";
            // 
            // TrustTLSCertificate
            // 
            this.TrustTLSCertificate.FormattingEnabled = true;
            this.TrustTLSCertificate.Items.AddRange(new object[] {
            "Never",
            "Always",
            "Selection needed"});
            this.TrustTLSCertificate.Location = new System.Drawing.Point(122, 89);
            this.TrustTLSCertificate.Name = "TrustTLSCertificate";
            this.TrustTLSCertificate.Size = new System.Drawing.Size(121, 21);
            this.TrustTLSCertificate.TabIndex = 33;
            this.TrustTLSCertificate.SelectedIndexChanged += new System.EventHandler(this.TrustTLSCertificate_SelectedIndexChanged);
            // 
            // ConfigurationDataProtectionLabel
            // 
            this.ConfigurationDataProtectionLabel.AutoSize = true;
            this.ConfigurationDataProtectionLabel.Location = new System.Drawing.Point(50, 30);
            this.ConfigurationDataProtectionLabel.Name = "ConfigurationDataProtectionLabel";
            this.ConfigurationDataProtectionLabel.Size = new System.Drawing.Size(91, 13);
            this.ConfigurationDataProtectionLabel.TabIndex = 34;
            this.ConfigurationDataProtectionLabel.Text = "Protection Status:";
            // 
            // CdpSet
            // 
            this.CdpSet.Location = new System.Drawing.Point(276, 52);
            this.CdpSet.Name = "CdpSet";
            this.CdpSet.Size = new System.Drawing.Size(41, 23);
            this.CdpSet.TabIndex = 35;
            this.CdpSet.Text = "Set";
            this.CdpSet.UseVisualStyleBackColor = true;
            this.CdpSet.Click += new System.EventHandler(this.SetConfigDataPW_Click);
            // 
            // CdpDelete
            // 
            this.CdpDelete.Location = new System.Drawing.Point(323, 52);
            this.CdpDelete.Name = "CdpDelete";
            this.CdpDelete.Size = new System.Drawing.Size(47, 23);
            this.CdpDelete.TabIndex = 36;
            this.CdpDelete.Text = "Delete";
            this.CdpDelete.UseVisualStyleBackColor = true;
            this.CdpDelete.Click += new System.EventHandler(this.DeleteConfigDataPW_Click);
            // 
            // ConfigurationDataPwLabel
            // 
            this.ConfigurationDataPwLabel.AutoSize = true;
            this.ConfigurationDataPwLabel.Location = new System.Drawing.Point(34, 57);
            this.ConfigurationDataPwLabel.Name = "ConfigurationDataPwLabel";
            this.ConfigurationDataPwLabel.Size = new System.Drawing.Size(107, 13);
            this.ConfigurationDataPwLabel.TabIndex = 37;
            this.ConfigurationDataPwLabel.Text = "Protection Password:";
            // 
            // CdpPW
            // 
            this.CdpPW.Location = new System.Drawing.Point(150, 54);
            this.CdpPW.Name = "CdpPW";
            this.CdpPW.PasswordChar = '*';
            this.CdpPW.Size = new System.Drawing.Size(120, 20);
            this.CdpPW.TabIndex = 39;
            this.CdpPW.Text = "Dyg06*-ds";
            // 
            // CdpGroup
            // 
            this.CdpGroup.Controls.Add(this.CdpStatus);
            this.CdpGroup.Controls.Add(this.CdpPW);
            this.CdpGroup.Controls.Add(this.ConfigurationDataPwLabel);
            this.CdpGroup.Controls.Add(this.CdpDelete);
            this.CdpGroup.Controls.Add(this.CdpSet);
            this.CdpGroup.Controls.Add(this.ConfigurationDataProtectionLabel);
            this.CdpGroup.Location = new System.Drawing.Point(433, 70);
            this.CdpGroup.Name = "CdpGroup";
            this.CdpGroup.Size = new System.Drawing.Size(406, 101);
            this.CdpGroup.TabIndex = 40;
            this.CdpGroup.TabStop = false;
            this.CdpGroup.Text = "Configuration Data Protection";
            // 
            // CdpStatus
            // 
            this.CdpStatus.Location = new System.Drawing.Point(147, 31);
            this.CdpStatus.Name = "CdpStatus";
            this.CdpStatus.Size = new System.Drawing.Size(228, 19);
            this.CdpStatus.TabIndex = 41;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(744, 310);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 41;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(852, 544);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CdpGroup);
            this.Controls.Add(this.TrustTLSCertificate);
            this.Controls.Add(this.TrustTLSCertLabel);
            this.Controls.Add(this.ShowCertificate);
            this.Controls.Add(this.BackupRestore);
            this.Controls.Add(this.FirmwareUpdate);
            this.Controls.Add(this.ResetToFactoryDefaults);
            this.Controls.Add(this.SetProfinetName);
            this.Controls.Add(this.ProfinetNameLabel);
            this.Controls.Add(this.ProfinetName);
            this.Controls.Add(this.GwLabel);
            this.Controls.Add(this.SuiteGw);
            this.Controls.Add(this.SnLabel);
            this.Controls.Add(this.SuiteSn);
            this.Controls.Add(this.ChangeIpSuite);
            this.Controls.Add(this.IpLabel);
            this.Controls.Add(this.SuiteIp);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.RunButton);
            this.Controls.Add(this.OperatingMode);
            this.Controls.Add(this.ArticleNumber);
            this.Controls.Add(this.DeviceName);
            this.Controls.Add(this.OperatingModeLabel);
            this.Controls.Add(this.DeviceArticleNumberLabel);
            this.Controls.Add(this.DeviceNameLabel);
            this.Controls.Add(this.InsertDevice);
            this.Controls.Add(this.DeviceIpAddressLabel);
            this.Controls.Add(this.InsertDeviceIpAddress);
            this.Controls.Add(this.CloseApplication);
            this.Controls.Add(this.NetworkInterface);
            this.Controls.Add(this.SelectNetworkInterface);
            this.Name = "Form1";
            this.Text = "My Application";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FirmwareUpdate.ResumeLayout(false);
            this.FirmwareUpdate.PerformLayout();
            this.BackupRestore.ResumeLayout(false);
            this.BackupRestore.PerformLayout();
            this.CdpGroup.ResumeLayout(false);
            this.CdpGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox SelectNetworkInterface;
        private System.Windows.Forms.Label NetworkInterface;
        private System.Windows.Forms.Button CloseApplication;
        private System.Windows.Forms.TextBox InsertDeviceIpAddress;
        private System.Windows.Forms.Label DeviceIpAddressLabel;
        private System.Windows.Forms.Button InsertDevice;
        private System.Windows.Forms.Label DeviceNameLabel;
        private System.Windows.Forms.Label DeviceArticleNumberLabel;
        private System.Windows.Forms.Label OperatingModeLabel;
        private System.Windows.Forms.Label DeviceName;
        private System.Windows.Forms.Label ArticleNumber;
        private System.Windows.Forms.Label OperatingMode;
        private System.Windows.Forms.Button RunButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Button ChangeIpSuite;
        private System.Windows.Forms.Label IpLabel;
        private System.Windows.Forms.TextBox SuiteIp;
        private System.Windows.Forms.Label SnLabel;
        private System.Windows.Forms.TextBox SuiteSn;
        private System.Windows.Forms.Label GwLabel;
        private System.Windows.Forms.TextBox SuiteGw;
        private System.Windows.Forms.Button SetProfinetName;
        private System.Windows.Forms.Label ProfinetNameLabel;
        private System.Windows.Forms.TextBox ProfinetName;
        private System.Windows.Forms.Button ResetToFactoryDefaults;
        private System.Windows.Forms.GroupBox FirmwareUpdate;
        private System.Windows.Forms.Label FirmwareVersion;
        private System.Windows.Forms.Label VersionLabel;
        private System.Windows.Forms.Button BrowseUpdateFile;
        private System.Windows.Forms.Label UpdateFileName;
        private System.Windows.Forms.Label UpdateFileNameLabel;
        private System.Windows.Forms.Button UpdateFirmware;
        private System.Windows.Forms.GroupBox BackupRestore;
        private System.Windows.Forms.Button Restore;
        private System.Windows.Forms.Label BrFileLabel;
        private System.Windows.Forms.Button Backup;
        private System.Windows.Forms.Label BrFile;
        private System.Windows.Forms.Button ShowCertificate;
        private System.Windows.Forms.Label TrustTLSCertLabel;
        private System.Windows.Forms.ComboBox TrustTLSCertificate;
        private System.Windows.Forms.Label ConfigurationDataProtectionLabel;
        private System.Windows.Forms.Button CdpSet;
        private System.Windows.Forms.Button CdpDelete;
        private System.Windows.Forms.Label ConfigurationDataPwLabel;
        private System.Windows.Forms.TextBox CdpPW;
        private System.Windows.Forms.GroupBox CdpGroup;
        private System.Windows.Forms.Label CdpStatus;
        private System.Windows.Forms.Button button1;
    }
}

