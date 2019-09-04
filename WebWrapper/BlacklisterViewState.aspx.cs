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
    public partial class BlacklisterViewState : System.Web.UI.Page
    {
        private static string strAppDataPath = Path.Combine(HttpRuntime.AppDomainAppPath, "App_Data");
        private static string strBlacklist3rExePath = String.Format(@"{0}\Blacklist3r\AspDotNetWrapper.exe", strAppDataPath);
        private static string strMachineKeyPath = String.Format(@"{0}\Blacklist3r\MachineKeys.txt", strAppDataPath);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (dropdownAspNetVersion.SelectedIndex == 0)
            {
                labelModifier.Visible = true;
                txtModifier.Visible = true;
                lableTaragetPagePath.Visible = false;
                txtTargetPagePath.Visible = false;
                labelIISPath.Visible = false;
                txtAppPathInIIS.Visible = false;
            }
            else
            {
                labelModifier.Visible = false;
                txtModifier.Visible = false;
                lableTaragetPagePath.Visible = true;
                txtTargetPagePath.Visible = true;
                labelIISPath.Visible = true;
                txtAppPathInIIS.Visible = true;
            }
        }

        protected void dropdownAspNetVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropdownAspNetVersion.SelectedIndex == 0)
            {
                labelModifier.Visible = true;
                txtModifier.Visible = true;
                lableTaragetPagePath.Visible = false;
                txtTargetPagePath.Visible = false;
                labelIISPath.Visible = false;
                txtAppPathInIIS.Visible = false;
            }
            else
            {
                labelModifier.Visible = false;
                txtModifier.Visible = false;
                lableTaragetPagePath.Visible = true;
                txtTargetPagePath.Visible = true;
                labelIISPath.Visible = true;
                txtAppPathInIIS.Visible = true;
            }
        }

        protected void btnDecrypt_Click(object sender, EventArgs e)
        {
            try
            {

                string filePath = String.Format(@"{0}\Blacklist3r\DecryptData{1}.txt", strAppDataPath,
                    (new Random(DateTime.Now.Millisecond)).Next(0, 3000));
                if (dropdownAspNetVersion.SelectedIndex == 0)
                {
                    string argument = "--encrypteddata " + Regex.Replace(txtViewState.Text, "[^A-Za-z0-9/\\+=]", "") +
                                                   " --decrypt" +
                                                   " --valalgo " + Regex.Replace(dropdownValdiationAlgo.Text, "[^A-Za-z0-9]", "") +
                                                   " --decalgo " + Regex.Replace(dropdownDecryptionAlgo.Text, "[^A-Za-z0-9]", "") +
                                                   " --purpose viewstate" +
                                                   " --modifier " + Regex.Replace(txtModifier.Text, "[^A-Za-z0-9]", "") +
                                                   " --outputFile " + filePath +
                                                   " --keypath \"" + strMachineKeyPath + "\" --legacy --macdecode";
                    string consoleOutput = executeCommand(argument);

                    txtDecryptionInfo.Text = File.ReadAllText(filePath);

                    if (File.Exists(filePath))
                        File.Delete(filePath);

                    string filterdArgumentOutput = "--encrypteddata " + Regex.Replace(txtViewState.Text, "[^A-Za-z0-99/\\+=]", "") +
                                           " --decrypt" +
                                           " --valalgo " + Regex.Replace(dropdownValdiationAlgo.Text, "[^A-Za-z0-9]", "") +
                                           " --decalgo " + Regex.Replace(dropdownDecryptionAlgo.Text, "[^A-Za-z0-9]", "") +
                                           " --purpose viewstate" +
                                           " --modifier " + Regex.Replace(txtModifier.Text, "[^A-Za-z0-9]", "") +
                                           " --outputFile DecryptedText.txt" +
                                           " --keypath machineKeys.txt  --legacy --macdecode";
                    lblBlacklisterCommand.Text = "AspDotNetWrapper.exe " + filterdArgumentOutput;
                }
                else
                {
                    string argument = "--encrypteddata " + Regex.Replace(txtViewState.Text, "[^A-Za-z0-9/\\+=]", "") +
                                                   " --decrypt" +
                                                   " --valalgo " + Regex.Replace(dropdownValdiationAlgo.Text, "[^A-Za-z0-9]", "") +
                                                   " --decalgo " + Regex.Replace(dropdownDecryptionAlgo.Text, "[^A-Za-z0-9]", "") +
                                                   " --purpose viewstate" +
                                                   " --IISDirPath " + txtAppPathInIIS.Text +
                                                   " --TargetPagePath " + txtTargetPagePath.Text +
                                                   " --outputFile " + filePath +
                                                   " --keypath \"" + strMachineKeyPath + "\"";
                    string consoleOutput = executeCommand(argument);

                    txtDecryptionInfo.Text = File.ReadAllText(filePath);

                    if (File.Exists(filePath))
                        File.Delete(filePath);

                    string filterdArgumentOutput = "--encrypteddata " + Regex.Replace(txtViewState.Text, "[^A-Za-z0-9/\\+=]", "") +
                                                   " --decrypt" +
                                                   " --valalgo " + Regex.Replace(dropdownValdiationAlgo.Text, "[^A-Za-z0-9]", "") +
                                                   " --decalgo " + Regex.Replace(dropdownDecryptionAlgo.Text, "[^A-Za-z0-9]", "") +
                                                   " --purpose viewstate" +
                                                   " --IISDirPath " + txtAppPathInIIS.Text +
                                                   " --TargetPagePath " + txtTargetPagePath.Text +
                                                   " --outputFile DecryptedText.txt" +
                                                   " --keypath machineKeys.txt";
                    lblBlacklisterCommand.Text = "AspDotNetWrapper.exe " + filterdArgumentOutput;
                }
            }
            catch (Exception exception)
            {
                txtDecryptionInfo.Text = "Invalid option selected";
            }
        }

        private string executeCommand(string commandlineArgument)
        {
            string Output = string.Empty;

            System.Diagnostics.Process pProcess = new System.Diagnostics.Process();

            //strCommand is path and file name of command to run
            pProcess.StartInfo.FileName = strBlacklist3rExePath;

            //strCommandParameters are parameters to pass to program
            pProcess.StartInfo.Arguments = commandlineArgument;

            pProcess.StartInfo.UseShellExecute = false;

            //Set output of program to be written to process output stream
            pProcess.StartInfo.RedirectStandardOutput = true;

            //Start the process
            pProcess.Start();

            //Get program output
            Output = pProcess.StandardOutput.ReadToEnd();

            //Wait for process to finish
            pProcess.WaitForExit();

            return Output;
        }
    }
}