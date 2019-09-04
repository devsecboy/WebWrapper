using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebWrapper
{
    public partial class Blacklister : System.Web.UI.Page
    {
        private static string strAppDataPath = Path.Combine(HttpRuntime.AppDomainAppPath, "App_Data");
        private static string strBlacklist3rExePath = String.Format(@"{0}\Blacklist3r\AspDotNetWrapper.exe", strAppDataPath);
        private static string strMachineKeyPath = String.Format(@"{0}\Blacklist3r\MachineKeys.txt", strAppDataPath);

        protected void Page_Load(object sender, EventArgs e)
        {
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

        protected void btnDecrypt_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = String.Format(@"{0}\Blacklist3r\DecryptData{1}.txt", strAppDataPath,
                    (new Random(DateTime.Now.Millisecond)).Next(0, 3000));

                string argument = "--encrypteddata " + Regex.Replace(txtEncryptedCookie.Text, "[^A-Za-z0-9]", "") +
                                               " --decrypt" +
                                               " --valalgo " + Regex.Replace(dropdownValdiationAlgo.Text, "[^A-Za-z0-9]", "") +
                                               " --decalgo " + Regex.Replace(dropdownDecryptionAlgo.Text, "[^A-Za-z0-9]", "") +
                                               " --purpose " + Regex.Replace(dropdownPurpose.Text, "[^A-Za-z]", "") +
                                               " --outputFile \"" + filePath +
                                               "\" --keypath \"" + strMachineKeyPath + "\"";
                string consoleOutput = executeCommand(argument);

                txtPlainTextCookie.Text = File.ReadAllText(filePath);

                if (File.Exists(filePath))
                    File.Delete(filePath);

                string filterdArgumentOutput = "--encrypteddata " + Regex.Replace(txtEncryptedCookie.Text, "[^A-Za-z0-9]", "") +
                                       " --decrypt" +
                                       " --valalgo " + Regex.Replace(dropdownValdiationAlgo.Text, "[^A-Za-z0-9]", "") +
                                       " --decalgo " + Regex.Replace(dropdownDecryptionAlgo.Text, "[^A-Za-z0-9]", "") +
                                       " --purpose " + Regex.Replace(dropdownPurpose.Text, "[^A-Za-z]", "") +
                                       " --outputFile DecryptedText.txt" +
                                       " --keypath machineKeys.txt";
                lblBlacklisterCommand.Text = "AspDotNetWrapper.exe " + filterdArgumentOutput;
            }
            catch (Exception exception)
            {
                txtPlainTextCookie.Text = "Invalid option selected";
            }
        }

        protected void btnSwap_Click(object sender, EventArgs e)
        {
            txtSwapPlainTextCookie.Text = txtPlainTextCookie.Text;
        }

        protected void btnEncrypt_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = String.Format(@"{0}\Blacklist3r\DecryptData{1}.txt", strAppDataPath,
                    (new Random(DateTime.Now.Millisecond)).Next(0, 3000));

                string Data = Regex.Replace(txtSwapPlainTextCookie.Text, "[^A-Za-z0-9\n:=, /@.+]", "");
                File.WriteAllText(filePath, Data);
                txtReEncryptedCookie.Text = executeCommand(" --decryptDataFilePath " + filePath);

                if (File.Exists(filePath))
                    File.Delete(filePath);
                lblBlacklisterCommand.Text = "AspDotNetWrapper.exe  --decryptDataFilePath DecryptedText.txt";
            }
            catch (Exception exception)
            {
                txtReEncryptedCookie.Text = "Invalid option selected";
            }
        }
    }
}