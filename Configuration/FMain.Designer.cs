using System.Drawing;
using System.Windows.Forms;

namespace EDVirtualCOM2TCP
{
    partial class FMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMain));
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.clkServiceState = new System.Windows.Forms.Timer(this.components);
            this.clkOpenPortsCheck = new System.Windows.Forms.Timer(this.components);
            this.tabsCtrl = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.grpCom0Com = new System.Windows.Forms.GroupBox();
            this.btnBrowserHub4ComPath = new System.Windows.Forms.Button();
            this.btnBrowserCom0ComPath = new System.Windows.Forms.Button();
            this.chkCreateCOM = new System.Windows.Forms.CheckBox();
            this.txtHub4ComDir = new System.Windows.Forms.TextBox();
            this.optInterrnalBridge = new System.Windows.Forms.RadioButton();
            this.optHub4Com = new System.Windows.Forms.RadioButton();
            this.picComAlert = new System.Windows.Forms.PictureBox();
            this.lnkCom0ComOpenG = new System.Windows.Forms.LinkLabel();
            this.picComOk = new System.Windows.Forms.PictureBox();
            this.txtCOM_num = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.chkActivate = new System.Windows.Forms.CheckBox();
            this.lnkCom0ComCreate = new System.Windows.Forms.LinkLabel();
            this.lnkCom0ComRemoveAll = new System.Windows.Forms.LinkLabel();
            this.lnkRefreshCom0Com = new System.Windows.Forms.LinkLabel();
            this.txtCom0ComDir = new System.Windows.Forms.TextBox();
            this.lblCom0ComPath = new System.Windows.Forms.Label();
            this.txtCom0ComState = new System.Windows.Forms.TextBox();
            this.grpIP = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIP_Port = new System.Windows.Forms.TextBox();
            this.txtIP_Address = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.boxService = new System.Windows.Forms.GroupBox();
            this.lnkServiceRemove = new System.Windows.Forms.LinkLabel();
            this.lnkServiceInstall = new System.Windows.Forms.LinkLabel();
            this.picServiceAlert = new System.Windows.Forms.PictureBox();
            this.lblServiceState = new System.Windows.Forms.TextBox();
            this.picServiceOk = new System.Windows.Forms.PictureBox();
            this.lnkServiceStop = new System.Windows.Forms.LinkLabel();
            this.lnkServiceRestart = new System.Windows.Forms.LinkLabel();
            this.lnkServiceStart = new System.Windows.Forms.LinkLabel();
            this.tabInstallation = new System.Windows.Forms.TabPage();
            this.label14 = new System.Windows.Forms.Label();
            this.numService_Delay = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lnkSetup_Download = new System.Windows.Forms.LinkLabel();
            this.lnkGitHub = new System.Windows.Forms.LinkLabel();
            this.chkLog = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lnkHub4Com = new System.Windows.Forms.LinkLabel();
            this.lnkCom0Com = new System.Windows.Forms.LinkLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.tabsCtrl.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.grpCom0Com.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picComAlert)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picComOk)).BeginInit();
            this.grpIP.SuspendLayout();
            this.boxService.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picServiceAlert)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picServiceOk)).BeginInit();
            this.tabInstallation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numService_Delay)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(370, 482);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(73, 27);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "&Fermer";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(370, 447);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(73, 29);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "&Enregistrer";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // clkServiceState
            // 
            this.clkServiceState.Interval = 2000;
            this.clkServiceState.Tick += new System.EventHandler(this.clkServiceState_Tick);
            // 
            // clkOpenPortsCheck
            // 
            this.clkOpenPortsCheck.Interval = 1000;
            this.clkOpenPortsCheck.Tick += new System.EventHandler(this.clkOpenPortsCheck_Tick);
            // 
            // tabsCtrl
            // 
            this.tabsCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabsCtrl.Controls.Add(this.tabGeneral);
            this.tabsCtrl.Controls.Add(this.tabInstallation);
            this.tabsCtrl.Location = new System.Drawing.Point(4, 4);
            this.tabsCtrl.Name = "tabsCtrl";
            this.tabsCtrl.SelectedIndex = 0;
            this.tabsCtrl.Size = new System.Drawing.Size(362, 505);
            this.tabsCtrl.TabIndex = 4;
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.grpCom0Com);
            this.tabGeneral.Controls.Add(this.grpIP);
            this.tabGeneral.Controls.Add(this.boxService);
            this.tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneral.Size = new System.Drawing.Size(354, 479);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "Général";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // grpCom0Com
            // 
            this.grpCom0Com.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpCom0Com.Controls.Add(this.btnBrowserHub4ComPath);
            this.grpCom0Com.Controls.Add(this.btnBrowserCom0ComPath);
            this.grpCom0Com.Controls.Add(this.chkCreateCOM);
            this.grpCom0Com.Controls.Add(this.txtHub4ComDir);
            this.grpCom0Com.Controls.Add(this.optInterrnalBridge);
            this.grpCom0Com.Controls.Add(this.optHub4Com);
            this.grpCom0Com.Controls.Add(this.picComAlert);
            this.grpCom0Com.Controls.Add(this.lnkCom0ComOpenG);
            this.grpCom0Com.Controls.Add(this.picComOk);
            this.grpCom0Com.Controls.Add(this.txtCOM_num);
            this.grpCom0Com.Controls.Add(this.label9);
            this.grpCom0Com.Controls.Add(this.chkActivate);
            this.grpCom0Com.Controls.Add(this.lnkCom0ComCreate);
            this.grpCom0Com.Controls.Add(this.lnkCom0ComRemoveAll);
            this.grpCom0Com.Controls.Add(this.lnkRefreshCom0Com);
            this.grpCom0Com.Controls.Add(this.txtCom0ComDir);
            this.grpCom0Com.Controls.Add(this.lblCom0ComPath);
            this.grpCom0Com.Controls.Add(this.txtCom0ComState);
            this.grpCom0Com.Location = new System.Drawing.Point(12, 200);
            this.grpCom0Com.Name = "grpCom0Com";
            this.grpCom0Com.Size = new System.Drawing.Size(322, 273);
            this.grpCom0Com.TabIndex = 6;
            this.grpCom0Com.TabStop = false;
            this.grpCom0Com.Text = "      COMs virtuels et Passerelle";
            // 
            // btnBrowserHub4ComPath
            // 
            this.btnBrowserHub4ComPath.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBrowserHub4ComPath.Location = new System.Drawing.Point(276, 54);
            this.btnBrowserHub4ComPath.Name = "btnBrowserHub4ComPath";
            this.btnBrowserHub4ComPath.Size = new System.Drawing.Size(21, 19);
            this.btnBrowserHub4ComPath.TabIndex = 27;
            this.btnBrowserHub4ComPath.Text = "...";
            this.btnBrowserHub4ComPath.UseVisualStyleBackColor = true;
            this.btnBrowserHub4ComPath.Click += new System.EventHandler(this.btnBrowserHub4ComPath_Click);
            // 
            // btnBrowserCom0ComPath
            // 
            this.btnBrowserCom0ComPath.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBrowserCom0ComPath.Location = new System.Drawing.Point(276, 29);
            this.btnBrowserCom0ComPath.Name = "btnBrowserCom0ComPath";
            this.btnBrowserCom0ComPath.Size = new System.Drawing.Size(21, 19);
            this.btnBrowserCom0ComPath.TabIndex = 26;
            this.btnBrowserCom0ComPath.Text = "...";
            this.btnBrowserCom0ComPath.UseVisualStyleBackColor = true;
            this.btnBrowserCom0ComPath.Click += new System.EventHandler(this.btnBrowserCom0ComPath_Click);
            // 
            // chkCreateCOM
            // 
            this.chkCreateCOM.AutoSize = true;
            this.chkCreateCOM.Location = new System.Drawing.Point(133, 80);
            this.chkCreateCOM.Name = "chkCreateCOM";
            this.chkCreateCOM.Size = new System.Drawing.Size(147, 17);
            this.chkCreateCOM.TabIndex = 25;
            this.chkCreateCOM.Text = "Générer des COM virtuels";
            this.chkCreateCOM.UseVisualStyleBackColor = true;
            this.chkCreateCOM.CheckedChanged += new System.EventHandler(this.chkCreateCOM_CheckedChanged);
            // 
            // txtHub4ComDir
            // 
            this.txtHub4ComDir.Location = new System.Drawing.Point(74, 54);
            this.txtHub4ComDir.Name = "txtHub4ComDir";
            this.txtHub4ComDir.Size = new System.Drawing.Size(199, 20);
            this.txtHub4ComDir.TabIndex = 19;
            this.toolTip1.SetToolTip(this.txtHub4ComDir, "Sous-répertoire ou chemin contenant hub4com.exe");
            // 
            // optInterrnalBridge
            // 
            this.optInterrnalBridge.AutoSize = true;
            this.optInterrnalBridge.Location = new System.Drawing.Point(6, 79);
            this.optInterrnalBridge.Margin = new System.Windows.Forms.Padding(2);
            this.optInterrnalBridge.Name = "optInterrnalBridge";
            this.optInterrnalBridge.Size = new System.Drawing.Size(108, 17);
            this.optInterrnalBridge.TabIndex = 24;
            this.optInterrnalBridge.Text = "Passerelle interne";
            this.optInterrnalBridge.UseVisualStyleBackColor = true;
            this.optInterrnalBridge.CheckedChanged += new System.EventHandler(this.optInterrnalBridge_CheckedChanged);
            // 
            // optHub4Com
            // 
            this.optHub4Com.Location = new System.Drawing.Point(5, 53);
            this.optHub4Com.Margin = new System.Windows.Forms.Padding(2);
            this.optHub4Com.Name = "optHub4Com";
            this.optHub4Com.Size = new System.Drawing.Size(79, 20);
            this.optHub4Com.TabIndex = 23;
            this.optHub4Com.Text = "Hub4Com";
            this.optHub4Com.UseVisualStyleBackColor = true;
            this.optHub4Com.CheckedChanged += new System.EventHandler(this.optHub4Com_CheckedChanged);
            // 
            // picComAlert
            // 
            this.picComAlert.Image = ((System.Drawing.Image)(resources.GetObject("picComAlert.Image")));
            this.picComAlert.Location = new System.Drawing.Point(10, 8);
            this.picComAlert.Name = "picComAlert";
            this.picComAlert.Size = new System.Drawing.Size(19, 20);
            this.picComAlert.TabIndex = 8;
            this.picComAlert.TabStop = false;
            this.picComAlert.Visible = false;
            // 
            // lnkCom0ComOpenG
            // 
            this.lnkCom0ComOpenG.Image = ((System.Drawing.Image)(resources.GetObject("lnkCom0ComOpenG.Image")));
            this.lnkCom0ComOpenG.Location = new System.Drawing.Point(302, 31);
            this.lnkCom0ComOpenG.Name = "lnkCom0ComOpenG";
            this.lnkCom0ComOpenG.Size = new System.Drawing.Size(14, 18);
            this.lnkCom0ComOpenG.TabIndex = 22;
            this.lnkCom0ComOpenG.TabStop = true;
            this.lnkCom0ComOpenG.Text = "......";
            this.lnkCom0ComOpenG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lnkCom0ComOpenG.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCom0ComOpenG_LinkClicked);
            // 
            // picComOk
            // 
            this.picComOk.Image = ((System.Drawing.Image)(resources.GetObject("picComOk.Image")));
            this.picComOk.Location = new System.Drawing.Point(3, 0);
            this.picComOk.Name = "picComOk";
            this.picComOk.Size = new System.Drawing.Size(19, 20);
            this.picComOk.TabIndex = 7;
            this.picComOk.TabStop = false;
            this.picComOk.Visible = false;
            // 
            // txtCOM_num
            // 
            this.txtCOM_num.Location = new System.Drawing.Point(264, 0);
            this.txtCOM_num.Name = "txtCOM_num";
            this.txtCOM_num.Size = new System.Drawing.Size(34, 20);
            this.txtCOM_num.TabIndex = 21;
            this.txtCOM_num.TextChanged += new System.EventHandler(this.txtCOM_num_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label9.Location = new System.Drawing.Point(208, 2);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Port mini :";
            // 
            // chkActivate
            // 
            this.chkActivate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkActivate.AutoSize = true;
            this.chkActivate.Location = new System.Drawing.Point(238, 254);
            this.chkActivate.Name = "chkActivate";
            this.chkActivate.Size = new System.Drawing.Size(59, 17);
            this.chkActivate.TabIndex = 17;
            this.chkActivate.Text = "Activer";
            this.chkActivate.UseVisualStyleBackColor = true;
            this.chkActivate.CheckedChanged += new System.EventHandler(this.chkActivate_CheckedChanged);
            // 
            // lnkCom0ComCreate
            // 
            this.lnkCom0ComCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lnkCom0ComCreate.Image = ((System.Drawing.Image)(resources.GetObject("lnkCom0ComCreate.Image")));
            this.lnkCom0ComCreate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lnkCom0ComCreate.Location = new System.Drawing.Point(86, 250);
            this.lnkCom0ComCreate.Name = "lnkCom0ComCreate";
            this.lnkCom0ComCreate.Size = new System.Drawing.Size(66, 23);
            this.lnkCom0ComCreate.TabIndex = 16;
            this.lnkCom0ComCreate.TabStop = true;
            this.lnkCom0ComCreate.Text = "Générer";
            this.lnkCom0ComCreate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lnkCom0ComCreate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCom0ComCreate_LinkClicked);
            // 
            // lnkCom0ComRemoveAll
            // 
            this.lnkCom0ComRemoveAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lnkCom0ComRemoveAll.Image = ((System.Drawing.Image)(resources.GetObject("lnkCom0ComRemoveAll.Image")));
            this.lnkCom0ComRemoveAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lnkCom0ComRemoveAll.Location = new System.Drawing.Point(10, 250);
            this.lnkCom0ComRemoveAll.Name = "lnkCom0ComRemoveAll";
            this.lnkCom0ComRemoveAll.Size = new System.Drawing.Size(74, 23);
            this.lnkCom0ComRemoveAll.TabIndex = 15;
            this.lnkCom0ComRemoveAll.TabStop = true;
            this.lnkCom0ComRemoveAll.Text = "Supprimer";
            this.lnkCom0ComRemoveAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lnkCom0ComRemoveAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCom0ComRemoveAll_LinkClicked);
            // 
            // lnkRefreshCom0Com
            // 
            this.lnkRefreshCom0Com.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lnkRefreshCom0Com.Image = ((System.Drawing.Image)(resources.GetObject("lnkRefreshCom0Com.Image")));
            this.lnkRefreshCom0Com.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lnkRefreshCom0Com.Location = new System.Drawing.Point(158, 250);
            this.lnkRefreshCom0Com.Name = "lnkRefreshCom0Com";
            this.lnkRefreshCom0Com.Size = new System.Drawing.Size(71, 23);
            this.lnkRefreshCom0Com.TabIndex = 14;
            this.lnkRefreshCom0Com.TabStop = true;
            this.lnkRefreshCom0Com.Text = "Rafraîchir";
            this.lnkRefreshCom0Com.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lnkRefreshCom0Com.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkRefreshCom0Com_LinkClicked);
            // 
            // txtCom0ComDir
            // 
            this.txtCom0ComDir.Location = new System.Drawing.Point(74, 28);
            this.txtCom0ComDir.Name = "txtCom0ComDir";
            this.txtCom0ComDir.Size = new System.Drawing.Size(199, 20);
            this.txtCom0ComDir.TabIndex = 13;
            this.toolTip1.SetToolTip(this.txtCom0ComDir, "Répertoire de l\'installation de com0com");
            // 
            // lblCom0ComPath
            // 
            this.lblCom0ComPath.AutoSize = true;
            this.lblCom0ComPath.Location = new System.Drawing.Point(10, 31);
            this.lblCom0ComPath.Name = "lblCom0ComPath";
            this.lblCom0ComPath.Size = new System.Drawing.Size(61, 13);
            this.lblCom0ComPath.TabIndex = 12;
            this.lblCom0ComPath.Text = "Com0Com :";
            // 
            // txtCom0ComState
            // 
            this.txtCom0ComState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCom0ComState.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtCom0ComState.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCom0ComState.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCom0ComState.Location = new System.Drawing.Point(10, 103);
            this.txtCom0ComState.Multiline = true;
            this.txtCom0ComState.Name = "txtCom0ComState";
            this.txtCom0ComState.ReadOnly = true;
            this.txtCom0ComState.Size = new System.Drawing.Size(288, 144);
            this.txtCom0ComState.TabIndex = 11;
            // 
            // grpIP
            // 
            this.grpIP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpIP.Controls.Add(this.label4);
            this.grpIP.Controls.Add(this.label3);
            this.grpIP.Controls.Add(this.txtIP_Port);
            this.grpIP.Controls.Add(this.txtIP_Address);
            this.grpIP.Controls.Add(this.label2);
            this.grpIP.Controls.Add(this.label1);
            this.grpIP.Location = new System.Drawing.Point(11, 107);
            this.grpIP.Name = "grpIP";
            this.grpIP.Size = new System.Drawing.Size(323, 87);
            this.grpIP.TabIndex = 4;
            this.grpIP.TabStop = false;
            this.grpIP.Text = "Adresse IP";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(169, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "par exple : 23";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(169, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "par exple : 192.168.1.127";
            // 
            // txtIP_Port
            // 
            this.txtIP_Port.Location = new System.Drawing.Point(74, 48);
            this.txtIP_Port.Name = "txtIP_Port";
            this.txtIP_Port.Size = new System.Drawing.Size(34, 20);
            this.txtIP_Port.TabIndex = 3;
            this.txtIP_Port.TextChanged += new System.EventHandler(this.txtIP_Port_TextChanged);
            // 
            // txtIP_Address
            // 
            this.txtIP_Address.Location = new System.Drawing.Point(74, 26);
            this.txtIP_Address.Name = "txtIP_Address";
            this.txtIP_Address.Size = new System.Drawing.Size(86, 20);
            this.txtIP_Address.TabIndex = 2;
            this.txtIP_Address.TextChanged += new System.EventHandler(this.txtIP_Address_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Port :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Adresse :";
            // 
            // boxService
            // 
            this.boxService.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.boxService.Controls.Add(this.lnkServiceRemove);
            this.boxService.Controls.Add(this.lnkServiceInstall);
            this.boxService.Controls.Add(this.picServiceAlert);
            this.boxService.Controls.Add(this.lblServiceState);
            this.boxService.Controls.Add(this.picServiceOk);
            this.boxService.Controls.Add(this.lnkServiceStop);
            this.boxService.Controls.Add(this.lnkServiceRestart);
            this.boxService.Controls.Add(this.lnkServiceStart);
            this.boxService.Location = new System.Drawing.Point(12, 10);
            this.boxService.Name = "boxService";
            this.boxService.Size = new System.Drawing.Size(322, 91);
            this.boxService.TabIndex = 5;
            this.boxService.TabStop = false;
            this.boxService.Text = "     Service";
            // 
            // lnkServiceRemove
            // 
            this.lnkServiceRemove.AutoSize = true;
            this.lnkServiceRemove.LinkColor = System.Drawing.Color.SteelBlue;
            this.lnkServiceRemove.Location = new System.Drawing.Point(266, 58);
            this.lnkServiceRemove.Name = "lnkServiceRemove";
            this.lnkServiceRemove.Size = new System.Drawing.Size(54, 13);
            this.lnkServiceRemove.TabIndex = 12;
            this.lnkServiceRemove.TabStop = true;
            this.lnkServiceRemove.Text = "Supprimer";
            this.lnkServiceRemove.Visible = false;
            this.lnkServiceRemove.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkServiceRemove_LinkClicked);
            // 
            // lnkServiceInstall
            // 
            this.lnkServiceInstall.AutoSize = true;
            this.lnkServiceInstall.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lnkServiceInstall.Location = new System.Drawing.Point(255, 64);
            this.lnkServiceInstall.Name = "lnkServiceInstall";
            this.lnkServiceInstall.Size = new System.Drawing.Size(43, 13);
            this.lnkServiceInstall.TabIndex = 11;
            this.lnkServiceInstall.TabStop = true;
            this.lnkServiceInstall.Text = "Installer";
            this.lnkServiceInstall.Visible = false;
            this.lnkServiceInstall.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkServiceInstall_LinkClicked);
            // 
            // picServiceAlert
            // 
            this.picServiceAlert.Image = ((System.Drawing.Image)(resources.GetObject("picServiceAlert.Image")));
            this.picServiceAlert.Location = new System.Drawing.Point(-1, 19);
            this.picServiceAlert.Name = "picServiceAlert";
            this.picServiceAlert.Size = new System.Drawing.Size(19, 20);
            this.picServiceAlert.TabIndex = 6;
            this.picServiceAlert.TabStop = false;
            this.picServiceAlert.Visible = false;
            // 
            // lblServiceState
            // 
            this.lblServiceState.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblServiceState.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblServiceState.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServiceState.Location = new System.Drawing.Point(20, 23);
            this.lblServiceState.Multiline = true;
            this.lblServiceState.Name = "lblServiceState";
            this.lblServiceState.ReadOnly = true;
            this.lblServiceState.Size = new System.Drawing.Size(278, 32);
            this.lblServiceState.TabIndex = 10;
            // 
            // picServiceOk
            // 
            this.picServiceOk.Image = ((System.Drawing.Image)(resources.GetObject("picServiceOk.Image")));
            this.picServiceOk.Location = new System.Drawing.Point(3, 0);
            this.picServiceOk.Name = "picServiceOk";
            this.picServiceOk.Size = new System.Drawing.Size(19, 20);
            this.picServiceOk.TabIndex = 5;
            this.picServiceOk.TabStop = false;
            this.picServiceOk.Visible = false;
            // 
            // lnkServiceStop
            // 
            this.lnkServiceStop.Image = ((System.Drawing.Image)(resources.GetObject("lnkServiceStop.Image")));
            this.lnkServiceStop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lnkServiceStop.Location = new System.Drawing.Point(180, 63);
            this.lnkServiceStop.Name = "lnkServiceStop";
            this.lnkServiceStop.Size = new System.Drawing.Size(58, 17);
            this.lnkServiceStop.TabIndex = 9;
            this.lnkServiceStop.TabStop = true;
            this.lnkServiceStop.Text = "Arréter";
            this.lnkServiceStop.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lnkServiceStop.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkServiceStop_LinkClicked);
            // 
            // lnkServiceRestart
            // 
            this.lnkServiceRestart.Image = ((System.Drawing.Image)(resources.GetObject("lnkServiceRestart.Image")));
            this.lnkServiceRestart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lnkServiceRestart.Location = new System.Drawing.Point(90, 62);
            this.lnkServiceRestart.Name = "lnkServiceRestart";
            this.lnkServiceRestart.Size = new System.Drawing.Size(80, 17);
            this.lnkServiceRestart.TabIndex = 8;
            this.lnkServiceRestart.TabStop = true;
            this.lnkServiceRestart.Text = "Redémarrer";
            this.lnkServiceRestart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lnkServiceRestart.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkServiceRestart_LinkClicked);
            // 
            // lnkServiceStart
            // 
            this.lnkServiceStart.Image = ((System.Drawing.Image)(resources.GetObject("lnkServiceStart.Image")));
            this.lnkServiceStart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lnkServiceStart.Location = new System.Drawing.Point(17, 57);
            this.lnkServiceStart.Name = "lnkServiceStart";
            this.lnkServiceStart.Size = new System.Drawing.Size(67, 24);
            this.lnkServiceStart.TabIndex = 7;
            this.lnkServiceStart.TabStop = true;
            this.lnkServiceStart.Text = "Démarrer";
            this.lnkServiceStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lnkServiceStart.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkServiceStart_LinkClicked);
            // 
            // tabInstallation
            // 
            this.tabInstallation.Controls.Add(this.label14);
            this.tabInstallation.Controls.Add(this.numService_Delay);
            this.tabInstallation.Controls.Add(this.label13);
            this.tabInstallation.Controls.Add(this.label5);
            this.tabInstallation.Controls.Add(this.label15);
            this.tabInstallation.Controls.Add(this.label12);
            this.tabInstallation.Controls.Add(this.label11);
            this.tabInstallation.Controls.Add(this.lnkSetup_Download);
            this.tabInstallation.Controls.Add(this.lnkGitHub);
            this.tabInstallation.Controls.Add(this.chkLog);
            this.tabInstallation.Controls.Add(this.label6);
            this.tabInstallation.Controls.Add(this.label10);
            this.tabInstallation.Controls.Add(this.label8);
            this.tabInstallation.Controls.Add(this.label7);
            this.tabInstallation.Controls.Add(this.lnkHub4Com);
            this.tabInstallation.Controls.Add(this.lnkCom0Com);
            this.tabInstallation.Location = new System.Drawing.Point(4, 22);
            this.tabInstallation.Name = "tabInstallation";
            this.tabInstallation.Padding = new System.Windows.Forms.Padding(3);
            this.tabInstallation.Size = new System.Drawing.Size(354, 479);
            this.tabInstallation.TabIndex = 1;
            this.tabInstallation.Text = "Installation";
            this.tabInstallation.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(194, 437);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 13);
            this.label14.TabIndex = 9;
            this.label14.Text = "secondes";
            // 
            // numService_Delay
            // 
            this.numService_Delay.Location = new System.Drawing.Point(141, 435);
            this.numService_Delay.Name = "numService_Delay";
            this.numService_Delay.Size = new System.Drawing.Size(45, 20);
            this.numService_Delay.TabIndex = 8;
            this.numService_Delay.ValueChanged += new System.EventHandler(this.numService_Delay_ValueChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(13, 436);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(105, 13);
            this.label13.TabIndex = 7;
            this.label13.Text = "Délai de démarrage :";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(11, 95);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(309, 38);
            this.label12.TabIndex = 6;
            this.label12.Text = "Cette application monopolise Com0Com. Aucune autre application ne peut l\'utiliser" +
    " sur cet ordinateur.";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(11, 142);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(126, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "EDVirtualCOM2TCP :";
            // 
            // lnkSetup_Download
            // 
            this.lnkSetup_Download.AutoSize = true;
            this.lnkSetup_Download.Location = new System.Drawing.Point(11, 173);
            this.lnkSetup_Download.Name = "lnkSetup_Download";
            this.lnkSetup_Download.Size = new System.Drawing.Size(436, 13);
            this.lnkSetup_Download.TabIndex = 4;
            this.lnkSetup_Download.TabStop = true;
            this.lnkSetup_Download.Text = "https://edv.edvariables.net/download/EDVirtualCOM2TCP/EDVirtualCOM2TCP.Setup.msi";
            this.lnkSetup_Download.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSetup_Download_LinkClicked);
            // 
            // lnkGitHub
            // 
            this.lnkGitHub.AutoSize = true;
            this.lnkGitHub.Location = new System.Drawing.Point(11, 156);
            this.lnkGitHub.Name = "lnkGitHub";
            this.lnkGitHub.Size = new System.Drawing.Size(254, 13);
            this.lnkGitHub.TabIndex = 4;
            this.lnkGitHub.TabStop = true;
            this.lnkGitHub.Text = "https://github.com/edvariables/EDVirtualCOM2TCP";
            this.lnkGitHub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkGitHub_LinkClicked);
            // 
            // chkLog
            // 
            this.chkLog.AutoSize = true;
            this.chkLog.Location = new System.Drawing.Point(14, 456);
            this.chkLog.Name = "chkLog";
            this.chkLog.Size = new System.Drawing.Size(54, 17);
            this.chkLog.TabIndex = 3;
            this.chkLog.Text = "Trace";
            this.chkLog.UseVisualStyleBackColor = true;
            this.chkLog.CheckedChanged += new System.EventHandler(this.chkLog_CheckedChanged);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(12, 364);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(309, 46);
            this.label6.TabIndex = 2;
            this.label6.Text = "L\'arrêt ou la désinstallation du service alors que les ports sont utilisés (Burea" +
    "u d\'accès à distance ouvert, par exple) peut provoquer un problème de réinitiali" +
    "sation.";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(13, 219);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(309, 136);
            this.label10.TabIndex = 2;
            this.label10.Text = resources.GetString("label10.Text");
            this.label10.UseMnemonic = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(13, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Hub4Com :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Com0Com :";
            // 
            // lnkHub4Com
            // 
            this.lnkHub4Com.AutoSize = true;
            this.lnkHub4Com.Location = new System.Drawing.Point(12, 72);
            this.lnkHub4Com.Name = "lnkHub4Com";
            this.lnkHub4Com.Size = new System.Drawing.Size(282, 13);
            this.lnkHub4Com.TabIndex = 0;
            this.lnkHub4Com.TabStop = true;
            this.lnkHub4Com.Text = "https://sourceforge.net/projects/com0com/files/hub4com";
            this.lnkHub4Com.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkHub4Com_LinkClicked);
            // 
            // lnkCom0Com
            // 
            this.lnkCom0Com.AutoSize = true;
            this.lnkCom0Com.Location = new System.Drawing.Point(11, 24);
            this.lnkCom0Com.Name = "lnkCom0Com";
            this.lnkCom0Com.Size = new System.Drawing.Size(238, 13);
            this.lnkCom0Com.TabIndex = 0;
            this.lnkCom0Com.TabStop = true;
            this.lnkCom0Com.Text = "https://sourceforge.net/projects/com0com/files/";
            this.lnkCom0Com.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCom0Com_LinkClicked);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(12, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(318, 34);
            this.label5.TabIndex = 6;
            this.label5.Text = "Un problème de compatibilité de la version 3.0 avec Windows 11 devrait vous faire" +
    " choisir la version 2.2";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(13, 196);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(254, 13);
            this.label15.TabIndex = 6;
            this.label15.Text = "Si le Setup ne fonctionne pas, téléchargez le dossier";
            // 
            // FMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(450, 516);
            this.Controls.Add(this.tabsCtrl);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FMain";
            this.Text = "EDVirtualCOM2TCP";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FMain_FormClosing);
            this.Load += new System.EventHandler(this.FMain_Load);
            this.tabsCtrl.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.grpCom0Com.ResumeLayout(false);
            this.grpCom0Com.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picComAlert)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picComOk)).EndInit();
            this.grpIP.ResumeLayout(false);
            this.grpIP.PerformLayout();
            this.boxService.ResumeLayout(false);
            this.boxService.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picServiceAlert)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picServiceOk)).EndInit();
            this.tabInstallation.ResumeLayout(false);
            this.tabInstallation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numService_Delay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnClose;
        private Button btnSave;
        private Timer clkServiceState;
        private Timer clkOpenPortsCheck;
        private TabControl tabsCtrl;
        private TabPage tabGeneral;
        private GroupBox grpIP;
        private Label label4;
        private Label label3;
        private TextBox txtIP_Port;
        private TextBox txtIP_Address;
        private Label label2;
        private Label label1;
        private GroupBox boxService;
        private TextBox lblServiceState;
        private LinkLabel lnkServiceStop;
        private LinkLabel lnkServiceRestart;
        private LinkLabel lnkServiceStart;
        private TabPage tabInstallation;
        private Label label7;
        private LinkLabel lnkCom0Com;
        private Label label8;
        private LinkLabel lnkHub4Com;
        private LinkLabel lnkServiceInstall;
        private LinkLabel lnkServiceRemove;
        private Label label10;
        private CheckBox chkLog;
        private PictureBox picServiceOk;
        private PictureBox picServiceAlert;
        private Label label11;
        private LinkLabel lnkGitHub;
        private Label label12;
        private LinkLabel lnkSetup_Download;
        private Label label13;
        private Label label14;
        private NumericUpDown numService_Delay;
        private GroupBox grpCom0Com;
        private RadioButton optInterrnalBridge;
        private RadioButton optHub4Com;
        private PictureBox picComAlert;
        private LinkLabel lnkCom0ComOpenG;
        private PictureBox picComOk;
        private TextBox txtCOM_num;
        private Label label9;
        private TextBox txtHub4ComDir;
        private CheckBox chkActivate;
        private LinkLabel lnkCom0ComCreate;
        private LinkLabel lnkCom0ComRemoveAll;
        private LinkLabel lnkRefreshCom0Com;
        private TextBox txtCom0ComDir;
        private TextBox txtCom0ComState;
        private CheckBox chkCreateCOM;
        private Label lblCom0ComPath;
        private Label label6;
        private ToolTip toolTip1;
        private Button btnBrowserCom0ComPath;
        private FolderBrowserDialog folderBrowserDialog1;
        private Button btnBrowserHub4ComPath;
        private Label label5;
        private Label label15;
    }
}