using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDVirtualCOM2TCP
{
    public partial class FMain : Form
    {
        public FMain()
        {
            InitializeComponent();
            Init_Service_States();
            Init_Inputs();
            Init_Com0Com();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save_Inputs();
        }

        private void Init_Inputs()
        {

            txtIP_Address.Text = Settings.IP_Address;
            txtIP_Port.Text = Settings.IP_Port.ToString();
            txtCOM_num.Text = Settings.COM_num.ToString();
            txtCom0ComDir.Text = Settings.Com0Com_path;
            txtHub4ComDir.Text = Settings.Hub4Com_path;
            txtHub4ComOptions.Text = Settings.Hub4Com_options;
            optHub4Com.Checked = Settings.Bridge_Hub4Com;
            optInterrnalBridge.Checked = !optHub4Com.Checked;
            chkCreateCOM.Checked = Settings.Com0Com_CreateCOM;
            chkLog.Checked = Settings.LogEnabled;
            numService_Delay.Value = Settings.Service_Delay;
        }

        private void Init_Com0Com()
        {
            //Console.WriteLine("Com0Com : " + Com0Com.ExeFileName);
            try
            {
                txtCom0ComState.Text = String.Empty;
                foreach ( string busyname in Com0Com.Busynames()) {
                    if (txtCom0ComState.Text.Length > 0)
                        txtCom0ComState.Text += "\n\r\n\r";
                    txtCom0ComState.Text += busyname;
                    if (Com0Com.CreatedPair_COM == busyname) { 
                        if(Settings.Bridge_Internal)
                            txtCom0ComState.Text += " <=> COM" + (Com0Com.CreatedPair_COMNum + 1).ToString();
                        else
                            txtCom0ComState.Text += " <=> CNB" + Com0Com.CreatedPair_CNC.ToString();
                    }
                }
                picComOk.Visible=true;
                picComAlert.Visible = false;
            }
            catch(Exception ex)
            {
                txtCom0ComState.Text =ex.Message;
                picComOk.Visible = false;
                picComAlert.Visible = true;
            }
        }

        private void Init_Service_States()
        {
            bool serviceExists = false;
            ServiceController sc = new ServiceController(Settings.ServiceName);

            picServiceOk.Visible = false;
            picServiceAlert.Visible = true;

            try
            {
                ServiceControllerStatus status = sc.Status;
                serviceExists = true;

                switch (status)
                {
                    case ServiceControllerStatus.Running:
                        lblServiceState.Text = "Démarré";
                        lnkServiceStart.Enabled = false;
                        lnkServiceRestart.Enabled = true;
                        picServiceOk.Visible = true;
                        picServiceAlert.Visible = false;
                        break;
                    case ServiceControllerStatus.Stopped:
                        lblServiceState.Text = "Arrêté";
                        lnkServiceStart.Enabled = true;
                        lnkServiceRestart.Enabled = false;
                        break;
                    case ServiceControllerStatus.Paused:
                        lblServiceState.Text = "En pause";
                        lnkServiceStart.Enabled = true;
                        lnkServiceRestart.Enabled = false;
                        break;
                    case ServiceControllerStatus.StopPending:
                        lblServiceState.Text = "Arrêt en cours";
                        lnkServiceStart.Enabled = false;
                        lnkServiceRestart.Enabled = false;
                        break;
                    case ServiceControllerStatus.StartPending:
                        lblServiceState.Text = "Démarrage en cours";
                        lnkServiceStart.Enabled = false;
                        lnkServiceRestart.Enabled = false;
                        break;
                    default:
                        lblServiceState.Text = "Statut indéterminé";
                        lnkServiceStart.Enabled = false;
                        lnkServiceRestart.Enabled = false;
                        break;
                }
                lnkServiceStop.Enabled = sc.CanStop;
            }
            catch (Exception)
            {
                lblServiceState.Text = "Service introuvable !";
                lnkServiceStart.Enabled = false;
                lnkServiceRestart.Enabled = false;
                lnkServiceStop.Enabled = false;
            }
            finally
            {
                lnkServiceInstall.Visible = !serviceExists;
                lnkServiceRemove.Visible = serviceExists && lnkServiceStart.Enabled;
                clkServiceState.Enabled = serviceExists;
            }
        }

        private void Save_Inputs()
        {

            Settings.IP_Address = txtIP_Address.Text;
            Settings.IP_Port = int.Parse(txtIP_Port.Text);
            Settings.COM_num = int.Parse(txtCOM_num.Text);
            Settings.Com0Com_CreateCOM=chkCreateCOM.Checked;

            Settings.Com0Com_path =txtCom0ComDir.Text;
            Settings.Hub4Com_path = txtHub4ComDir.Text;
            Settings.Hub4Com_options = txtHub4ComOptions.Text;

            Settings.LogEnabled= chkLog.Checked;

            Settings.Service_Delay = (int)numService_Delay.Value ;

            Settings.Save();
        }

        private void txtIP_Port_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(((TextBox)sender).Text, out int value))
            {
                MessageBox.Show("Le port doit être un nombre entier.");
                ((TextBox)sender).Focus();
            }
        }

        private void lnkServiceStart_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            chkActivate.Checked = false;
            clkServiceState.Enabled = false;
            ServiceController sc = new ServiceController(Settings.ServiceName);

            try
            {
                sc.Start();

                sc.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(30));
                Init_Service_States();
                Init_Com0Com();
            }
            catch (System.ServiceProcess.TimeoutException)
            {
                Init_Service_States();
                lblServiceState.Text = "Timeout lors du démarrage du service";
            }
            catch (Exception ex)
            {
                if(ex.InnerException != null)
                    lblServiceState.Text = ex.InnerException.Message;
                else
                    lblServiceState.Text = ex.Message;
            }
        }

        private void lnkServiceRestart_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clkServiceState.Enabled = false;
            ServiceController sc = new ServiceController(Settings.ServiceName);
            try
            {
                sc.Stop();

                sc.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(20));
                Init_Service_States();
            }
            catch (System.ServiceProcess.TimeoutException)
            {
                Init_Service_States();
                lblServiceState.Text = "Timeout lors de l'arrêt du service";
                return;
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    lblServiceState.Text = ex.InnerException.Message;
                else
                    lblServiceState.Text = ex.Message;
                return;
            }

            try
            {
                sc.Start();

                sc.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(30));
                Init_Service_States();
                Init_Com0Com();
            }
            catch (System.ServiceProcess.TimeoutException)
            {
                Init_Service_States();
                lblServiceState.Text = "Timeout lors du démarrage du service";
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    lblServiceState.Text = ex.InnerException.Message;
                else
                    lblServiceState.Text = ex.Message;
            }
        }

        private void lnkServiceStop_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clkServiceState.Enabled = false;
            ServiceController sc = new ServiceController(Settings.ServiceName);
            try
            {
                sc.Stop();

                sc.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(20));
                Init_Service_States();
                Init_Com0Com();
            }
            catch (System.ServiceProcess.TimeoutException)
            {
                Init_Service_States();
                lblServiceState.Text = "Timeout lors de l'arrêt du service";
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    lblServiceState.Text = ex.InnerException.Message;
                else
                    lblServiceState.Text = ex.Message;
            }
        }

        private void clkServiceState_Tick(object sender, EventArgs e)
        {
            Init_Service_States();
        }

        private void lnkRefreshCom0Com_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Init_Com0Com();
        }

        private void lnkCom0ComRemoveAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (ServiceManager.Status == ServiceControllerStatus.Running)
                {
                    if( MessageBox.Show("Le service est en cours, les ports de communication ne doivent pas être modifiés.", "EDVirtualCOM2TCP"
                            , MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop)
                        == DialogResult.Abort)
                    return;
                }

                EDDebug.Log("call Com0Com.RemoveAll()");
                Com0Com.RemoveAll();
            }
            catch (Exception ex)
            {
                EDDebug.Log(ex.Message);
                MessageBox.Show(ex.Message, "EDVirtualCOM2TCP [Com0Com.RemoveAll]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Init_Com0Com();
        }

        private void lnkCom0ComCreate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (ServiceManager.Status == ServiceControllerStatus.Running)
                {
                    if (MessageBox.Show("Le service est en cours, les ports de communication ne doivent pas être modifiés.", "EDVirtualCOM2TCP"
                            , MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop)
                        == DialogResult.Abort)
                        return;
                }
                EDDebug.Log("call Com0Com.CreatePair()");
                Com0Com.CreatePair();
            }
            catch (Exception ex)
            {
                EDDebug.Log(ex.Message);
                MessageBox.Show(ex.Message, "EDVirtualCOM2TCP [Com0Com.CreatePair]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Init_Com0Com();
        }

        private void chkActivate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkActivate.Checked == true)
            {
                if( ServiceManager.Status==ServiceControllerStatus.Running )
                {
                    if (MessageBox.Show("Le service est en cours. Lui seul peut ouvrir les ports de communication.", "EDVirtualCOM2TCP"
                            , MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop)
                        == DialogResult.Abort)
                    {
                        chkActivate.Checked = false;
                        return;
                    }
                }
                if( Settings.Bridge_Hub4Com)
                    try
                    {
                        EDDebug.Log("call Hub4Com.OpenPorts()");
                        if (!Hub4Com.OpenPorts(OnBridgeProcessExited))
                            chkActivate.Checked = false;
                        else
                            clkOpenPortsCheck_Active = true;
                    }
                    catch (Exception ex)
                    {
                        EDDebug.Log(ex.Message);
                        MessageBox.Show(ex.Message, "EDVirtualCOM2TCP [Hub4Com.OpenPorts]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        chkActivate.Checked = false;
                    }
                else
                    try
                    {
                        EDDebug.Log("call InternalBridge.OpenPorts()");
                        if (!InternalBridge.OpenPorts(OnBridgeProcessExited))
                            chkActivate.Checked = false;
                        else
                            clkOpenPortsCheck_Active = true;
                    }
                    catch (Exception ex)
                    {
                        EDDebug.Log(ex.Message);
                        MessageBox.Show(ex.Message, "EDVirtualCOM2TCP [Hub4Com.OpenPorts]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        chkActivate.Checked = false;
                    }
            }
            else
            {
                EDDebug.Log("call ClosePorts()");

                if (Settings.Bridge_Hub4Com)
                    Hub4Com.ClosePorts();
                else
                    InternalBridge.ClosePorts();
            }

        }

        protected void OnBridgeProcessExited()
        {
            try
            {
                chkActivate.Checked = false;
            }
            catch(Exception ex)
            {
                EDDebug.Log(ex.Message);
            }
        }

        private void FMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(chkActivate.Checked)
                chkActivate.Checked = false;
        }

        private void clkOpenPortsCheck_Tick(object sender, EventArgs e)
        {
            if (clkOpenPortsCheck.Tag == null)
            {
                clkOpenPortsCheck.Tag = 1;
                return;
            }
            clkOpenPortsCheck_Active = false;
            //IsProcessRunning en Thread asynchrone
            bool isProcessRunning;
            if (Settings.Bridge_Hub4Com)
                isProcessRunning = Hub4Com.IsProcessRunning;
            else
                isProcessRunning = InternalBridge.IsProcessRunning;
            if (chkActivate.Checked && !isProcessRunning)
            {
                EDDebug.Log("NOT IsProcessRunning");
                chkActivate.Checked = false;
            }
        }

        private void lnkCom0Com_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            NavigateToUrl(((LinkLabel)sender).Text);
        }

        private void lnkHub4Com_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            NavigateToUrl(((LinkLabel)sender).Text);
        }

        private void NavigateToUrl(string url)
        {
            System.Diagnostics.Process.Start(url);
        }

        private void lnkServiceInstall_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ServiceManager.Create();

            Init_Service_States();
        }

        private void FMain_Load(object sender, EventArgs e)
        {
            lnkServiceRemove.Location = lnkServiceInstall.Location;
            lnkCom0Com.Text = Settings.Com0Com_Download;
            lnkHub4Com.Text = Settings.Hub4Com_Download;
            picServiceAlert.Location= picServiceOk.Location;
            picComAlert.Location=picComOk.Location;
        }

        private void lnkServiceRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clkServiceState.Enabled = false;

            ServiceManager.Delete();

            Init_Service_States();
        }

        private bool clkOpenPortsCheck_Active
        {
            get
            {
                return clkOpenPortsCheck.Enabled;
            }
            set
            {
                if (value)
                    clkOpenPortsCheck.Tag = null;
                clkOpenPortsCheck.Enabled = value;
            }
        }

        private void txtCOM_num_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(((TextBox)sender).Text, out int value))
            {
                MessageBox.Show("Le port doit être un nombre entier.");
                ((TextBox)sender).Focus();
            }
        }

        private void lnkCom0ComOpenG_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Com0Com.OpenGraphic();
        }

        private void chkLog_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void lnkGitHub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            NavigateToUrl(((LinkLabel)sender).Text);
        }

        private void lnkSetup_Download_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            NavigateToUrl(((LinkLabel)sender).Text);
        }
    }


}
