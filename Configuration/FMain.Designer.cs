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
            this.lnkCom0ComOpenG = new System.Windows.Forms.LinkLabel();
            this.txtCOM_num = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtHub4ComOptions = new System.Windows.Forms.TextBox();
            this.txtHub4ComDir = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkHub4Com = new System.Windows.Forms.CheckBox();
            this.lnkCom0ComCreate = new System.Windows.Forms.LinkLabel();
            this.lnkCom0ComRemoveAll = new System.Windows.Forms.LinkLabel();
            this.lnkRefreshCom0Com = new System.Windows.Forms.LinkLabel();
            this.txtCom0ComDir = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
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
            this.lblServiceState = new System.Windows.Forms.TextBox();
            this.lnkServiceStop = new System.Windows.Forms.LinkLabel();
            this.lnkServiceRestart = new System.Windows.Forms.LinkLabel();
            this.lnkServiceStart = new System.Windows.Forms.LinkLabel();
            this.tabInstallation = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lnkHub4Com = new System.Windows.Forms.LinkLabel();
            this.lnkCom0Com = new System.Windows.Forms.LinkLabel();
            this.chkLog = new System.Windows.Forms.CheckBox();
            this.picServiceOk = new System.Windows.Forms.PictureBox();
            this.picServiceAlert = new System.Windows.Forms.PictureBox();
            this.picComAlert = new System.Windows.Forms.PictureBox();
            this.picComOk = new System.Windows.Forms.PictureBox();
            this.tabsCtrl.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.grpCom0Com.SuspendLayout();
            this.grpIP.SuspendLayout();
            this.boxService.SuspendLayout();
            this.tabInstallation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picServiceOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picServiceAlert)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picComAlert)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picComOk)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(354, 447);
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
            this.btnSave.Location = new System.Drawing.Point(355, 412);
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
            this.tabsCtrl.Size = new System.Drawing.Size(344, 472);
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
            this.tabGeneral.Size = new System.Drawing.Size(336, 446);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "Général";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // grpCom0Com
            // 
            this.grpCom0Com.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpCom0Com.Controls.Add(this.lnkCom0ComOpenG);
            this.grpCom0Com.Controls.Add(this.txtCOM_num);
            this.grpCom0Com.Controls.Add(this.label9);
            this.grpCom0Com.Controls.Add(this.txtHub4ComOptions);
            this.grpCom0Com.Controls.Add(this.txtHub4ComDir);
            this.grpCom0Com.Controls.Add(this.label6);
            this.grpCom0Com.Controls.Add(this.chkHub4Com);
            this.grpCom0Com.Controls.Add(this.lnkCom0ComCreate);
            this.grpCom0Com.Controls.Add(this.lnkCom0ComRemoveAll);
            this.grpCom0Com.Controls.Add(this.lnkRefreshCom0Com);
            this.grpCom0Com.Controls.Add(this.txtCom0ComDir);
            this.grpCom0Com.Controls.Add(this.label5);
            this.grpCom0Com.Controls.Add(this.txtCom0ComState);
            this.grpCom0Com.Location = new System.Drawing.Point(12, 200);
            this.grpCom0Com.Name = "grpCom0Com";
            this.grpCom0Com.Size = new System.Drawing.Size(322, 242);
            this.grpCom0Com.TabIndex = 6;
            this.grpCom0Com.TabStop = false;
            this.grpCom0Com.Text = "Com0Com et Hub4Com";
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
            // txtCOM_num
            // 
            this.txtCOM_num.Location = new System.Drawing.Point(264, 4);
            this.txtCOM_num.Name = "txtCOM_num";
            this.txtCOM_num.Size = new System.Drawing.Size(34, 20);
            this.txtCOM_num.TabIndex = 21;
            this.txtCOM_num.TextChanged += new System.EventHandler(this.txtCOM_num_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label9.Location = new System.Drawing.Point(208, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Port mini :";
            // 
            // txtHub4ComOptions
            // 
            this.txtHub4ComOptions.AcceptsReturn = true;
            this.txtHub4ComOptions.Location = new System.Drawing.Point(67, 80);
            this.txtHub4ComOptions.Multiline = true;
            this.txtHub4ComOptions.Name = "txtHub4ComOptions";
            this.txtHub4ComOptions.Size = new System.Drawing.Size(229, 56);
            this.txtHub4ComOptions.TabIndex = 19;
            // 
            // txtHub4ComDir
            // 
            this.txtHub4ComDir.Location = new System.Drawing.Point(67, 54);
            this.txtHub4ComDir.Name = "txtHub4ComDir";
            this.txtHub4ComDir.Size = new System.Drawing.Size(229, 20);
            this.txtHub4ComDir.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Hub4Com :";
            // 
            // chkHub4Com
            // 
            this.chkHub4Com.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkHub4Com.AutoSize = true;
            this.chkHub4Com.Location = new System.Drawing.Point(238, 223);
            this.chkHub4Com.Name = "chkHub4Com";
            this.chkHub4Com.Size = new System.Drawing.Size(59, 17);
            this.chkHub4Com.TabIndex = 17;
            this.chkHub4Com.Text = "Activer";
            this.chkHub4Com.UseVisualStyleBackColor = true;
            this.chkHub4Com.CheckedChanged += new System.EventHandler(this.chkHub4Com_CheckedChanged);
            // 
            // lnkCom0ComCreate
            // 
            this.lnkCom0ComCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lnkCom0ComCreate.Image = ((System.Drawing.Image)(resources.GetObject("lnkCom0ComCreate.Image")));
            this.lnkCom0ComCreate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lnkCom0ComCreate.Location = new System.Drawing.Point(86, 219);
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
            this.lnkCom0ComRemoveAll.Location = new System.Drawing.Point(10, 219);
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
            this.lnkRefreshCom0Com.Location = new System.Drawing.Point(158, 219);
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
            this.txtCom0ComDir.Location = new System.Drawing.Point(67, 28);
            this.txtCom0ComDir.Name = "txtCom0ComDir";
            this.txtCom0ComDir.Size = new System.Drawing.Size(229, 20);
            this.txtCom0ComDir.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Chemin :";
            // 
            // txtCom0ComState
            // 
            this.txtCom0ComState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCom0ComState.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtCom0ComState.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCom0ComState.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCom0ComState.Location = new System.Drawing.Point(10, 142);
            this.txtCom0ComState.Multiline = true;
            this.txtCom0ComState.Name = "txtCom0ComState";
            this.txtCom0ComState.ReadOnly = true;
            this.txtCom0ComState.Size = new System.Drawing.Size(283, 74);
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
            this.boxService.Controls.Add(this.lblServiceState);
            this.boxService.Controls.Add(this.lnkServiceStop);
            this.boxService.Controls.Add(this.lnkServiceRestart);
            this.boxService.Controls.Add(this.lnkServiceStart);
            this.boxService.Location = new System.Drawing.Point(12, 10);
            this.boxService.Name = "boxService";
            this.boxService.Size = new System.Drawing.Size(322, 91);
            this.boxService.TabIndex = 5;
            this.boxService.TabStop = false;
            this.boxService.Text = "Service";
            // 
            // lnkServiceRemove
            // 
            this.lnkServiceRemove.AutoSize = true;
            this.lnkServiceRemove.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
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
            this.tabInstallation.Controls.Add(this.chkLog);
            this.tabInstallation.Controls.Add(this.label10);
            this.tabInstallation.Controls.Add(this.label8);
            this.tabInstallation.Controls.Add(this.label7);
            this.tabInstallation.Controls.Add(this.lnkHub4Com);
            this.tabInstallation.Controls.Add(this.lnkCom0Com);
            this.tabInstallation.Location = new System.Drawing.Point(4, 22);
            this.tabInstallation.Name = "tabInstallation";
            this.tabInstallation.Padding = new System.Windows.Forms.Padding(3);
            this.tabInstallation.Size = new System.Drawing.Size(336, 446);
            this.tabInstallation.TabIndex = 1;
            this.tabInstallation.Text = "Installation";
            this.tabInstallation.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(13, 109);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(309, 58);
            this.label10.TabIndex = 2;
            this.label10.Text = "L\'arrêt ou la désinstallation du service alors que les ports sont utilisés (Burea" +
    "u d\'accès à distance ouvert, par exple) peut provoquer un problème de réinitiali" +
    "sation.";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Hub4Com :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
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
            this.lnkCom0Com.Location = new System.Drawing.Point(11, 36);
            this.lnkCom0Com.Name = "lnkCom0Com";
            this.lnkCom0Com.Size = new System.Drawing.Size(314, 13);
            this.lnkCom0Com.TabIndex = 0;
            this.lnkCom0Com.TabStop = true;
            this.lnkCom0Com.Text = "https://sourceforge.net/projects/com0com/files/latest/download";
            this.lnkCom0Com.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCom0Com_LinkClicked);
            // 
            // chkLog
            // 
            this.chkLog.AutoSize = true;
            this.chkLog.Location = new System.Drawing.Point(14, 421);
            this.chkLog.Name = "chkLog";
            this.chkLog.Size = new System.Drawing.Size(54, 17);
            this.chkLog.TabIndex = 3;
            this.chkLog.Text = "Trace";
            this.chkLog.UseVisualStyleBackColor = true;
            this.chkLog.CheckedChanged += new System.EventHandler(this.chkLog_CheckedChanged);
            // 
            // picServiceOk
            // 
            this.picServiceOk.Image = ((System.Drawing.Image)(resources.GetObject("picServiceOk.Image")));
            this.picServiceOk.Location = new System.Drawing.Point(365, 36);
            this.picServiceOk.Name = "picServiceOk";
            this.picServiceOk.Size = new System.Drawing.Size(19, 20);
            this.picServiceOk.TabIndex = 5;
            this.picServiceOk.TabStop = false;
            this.picServiceOk.Visible = false;
            // 
            // picServiceAlert
            // 
            this.picServiceAlert.Image = ((System.Drawing.Image)(resources.GetObject("picServiceAlert.Image")));
            this.picServiceAlert.Location = new System.Drawing.Point(365, 59);
            this.picServiceAlert.Name = "picServiceAlert";
            this.picServiceAlert.Size = new System.Drawing.Size(19, 20);
            this.picServiceAlert.TabIndex = 6;
            this.picServiceAlert.TabStop = false;
            this.picServiceAlert.Visible = false;
            // 
            // picComAlert
            // 
            this.picComAlert.Image = ((System.Drawing.Image)(resources.GetObject("picComAlert.Image")));
            this.picComAlert.Location = new System.Drawing.Point(365, 257);
            this.picComAlert.Name = "picComAlert";
            this.picComAlert.Size = new System.Drawing.Size(19, 20);
            this.picComAlert.TabIndex = 8;
            this.picComAlert.TabStop = false;
            this.picComAlert.Visible = false;
            // 
            // picComOk
            // 
            this.picComOk.Image = ((System.Drawing.Image)(resources.GetObject("picComOk.Image")));
            this.picComOk.Location = new System.Drawing.Point(365, 234);
            this.picComOk.Name = "picComOk";
            this.picComOk.Size = new System.Drawing.Size(19, 20);
            this.picComOk.TabIndex = 7;
            this.picComOk.TabStop = false;
            this.picComOk.Visible = false;
            // 
            // FMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(436, 482);
            this.Controls.Add(this.picComAlert);
            this.Controls.Add(this.picComOk);
            this.Controls.Add(this.picServiceAlert);
            this.Controls.Add(this.picServiceOk);
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
            this.grpIP.ResumeLayout(false);
            this.grpIP.PerformLayout();
            this.boxService.ResumeLayout(false);
            this.boxService.PerformLayout();
            this.tabInstallation.ResumeLayout(false);
            this.tabInstallation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picServiceOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picServiceAlert)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picComAlert)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picComOk)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnClose;
        private Button btnSave;
        private Timer clkServiceState;
        private Timer clkOpenPortsCheck;
        private TabControl tabsCtrl;
        private TabPage tabGeneral;
        private GroupBox grpCom0Com;
        private TextBox txtHub4ComOptions;
        private TextBox txtHub4ComDir;
        private Label label6;
        private CheckBox chkHub4Com;
        private LinkLabel lnkCom0ComCreate;
        private LinkLabel lnkCom0ComRemoveAll;
        private LinkLabel lnkRefreshCom0Com;
        private TextBox txtCom0ComDir;
        private Label label5;
        private TextBox txtCom0ComState;
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
        private TextBox txtCOM_num;
        private Label label9;
        private Label label10;
        private LinkLabel lnkCom0ComOpenG;
        private CheckBox chkLog;
        private PictureBox picServiceOk;
        private PictureBox picServiceAlert;
        private PictureBox picComAlert;
        private PictureBox picComOk;
    }
}