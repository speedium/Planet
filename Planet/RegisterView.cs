using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Net.NetworkInformation;
using Microsoft.Win32;

namespace Planet
{
    public partial class RegisterView : Form
    {
        RegistrationValidator validator;
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public RegisterView()
        {
            InitializeComponent();
            validator = new RegistrationValidator();
            tbInstalationId.Text = validator.InstalationId;
            SetLanguage();
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void SetLanguage()
        {
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public bool KontrolaRegistracie()
        {
            try
            {
                RegistryKey registryEnvitechRead = Registry.CurrentUser.OpenSubKey("SOFTWARE\\ENVITech");
                if (registryEnvitechRead != null)
                {
                    Program.RegistrationId = (string)registryEnvitechRead.GetValue(Program.RegistrationSWName);
                    registryEnvitechRead.Close();
                }

                for (int tryCount = 0; ; tryCount++)
                {
                    string registrationId = Program.RegistrationId;
                    tbInstalationId.Text = validator.InstalationId;

                    bool registeredKey = (validator.RegistrationId == registrationId);

                    if (registeredKey)
                    {
                        RegistryKey registryNew = Registry.CurrentUser.CreateSubKey("SOFTWARE\\ENVITech");
                        registryNew.SetValue(Program.RegistrationSWName, registrationId);
                        return true;
                    }
                    if (tryCount >= 3)
                    {
                        return false;
                    }

                    DialogResult dlgResult;
                    dlgResult = ShowDialog();
                    if (dlgResult == DialogResult.Cancel)
                    {
                        return false;
                    }
                }
            }
            finally
            {
            }
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void buttonOK_Click(object sender, EventArgs e)
        {
            Program.RegistrationId = tbRegistrationId.Text;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public class RegistrationValidator
    {
        static string alphaXTab = "PIBWSCLFOYAQUHETJNZDRKVGXM";  // 26 alpha characters in random order
        static string digitXTab = "1935086724";                  // 10 digit characters in random order

        const int RegistrationCodeSize = 16;

        string ProductId;
        string SystemId;
        string RegisteredOrganization;
        string RegisteredOwner;
        int InstalationDateTime;

        byte[] SoftwareCode = new byte[RegistrationCodeSize];
        byte[] SystemCode = new byte[RegistrationCodeSize];
        byte[] InstalationCode = new byte[RegistrationCodeSize];
        byte[] RegistrationCode = new byte[RegistrationCodeSize];

        string SoftwareId;
        public string InstalationId;
        public string RegistrationId;
        bool IgnoreSoftwareId;
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public RegistrationValidator()
        {
            GetSystemInformation();                 // Initialize...

            // Do not invoke CreateAllCodes while setting properties!
            IgnoreSoftwareId = true;
            SoftwareId = "SOFTWARE00010000";       // Name[8]Major[4]Minor[4]

            CreateAllCodes(true);
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        void GetSystemInformation()
        {
            // Find out operating system version...
            OperatingSystem os = Environment.OSVersion;

            // Get system registry values...
            RegistryKey registry = Registry.LocalMachine.OpenSubKey(RegistrationSystemData.CurrentVersion);
            ProductId = (string)registry.GetValue(RegistrationSystemData.ProductId);
            RegisteredOrganization = (string)registry.GetValue(RegistrationSystemData.RegisteredOrganization);
            RegisteredOwner = (string)registry.GetValue(RegistrationSystemData.RegisteredOwner);
            InstalationDateTime = (int)registry.GetValue(RegistrationSystemData.FirstInstallDateTime);
            registry.Close();
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        void InitCodes()
        {
            byte i;
            byte[] key = new byte[4];
            key[0] = (byte)(InstalationDateTime % 256);
            key[1] = (byte)((InstalationDateTime >> 8) % 256);
            key[2] = (byte)((InstalationDateTime >> 16) % 256);
            key[3] = (byte)((InstalationDateTime >> 24) % 256);

            for (i = 0; i < RegistrationCodeSize; i++)
            {
                byte code = key[i % 4];
                SystemCode[i] = code;
                SoftwareCode[i] = code;
                InstalationCode[i] = code;
                RegistrationCode[i] = i;    // Can not depend on system configuration! 
            }
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        string CodeToString(byte[] code)
        {
            char[] text = new char[1024];
            int codeIndex, textIndex = 0;
            int codeSize = code.Length;

            for (codeIndex = 0; codeIndex < codeSize; codeIndex++)
            {
                switch (codeIndex % 4)
                {
                    case 0:
                        if (codeIndex > 0)
                            text[textIndex++] = '-';
                        text[textIndex++] = alphaXTab[code[codeIndex] % 26];
                        break;
                    default:
                        text[textIndex++] = digitXTab[code[codeIndex] % 10];
                        break;
                }
            }

            return new string(text, 0, textIndex);
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        void CreateCode(string key, byte[] code)
        {
            int codeSize = code.Length;
            int keyIndex;
            int keySize = key.Length;

            int carry = 0;
            byte[] keyStr = Encoding.UTF8.GetBytes(key);

            for (keyIndex = 0; keyIndex < keySize; keyIndex++)
            {
                int codeIndex = keyIndex % codeSize;
                carry += code[codeIndex] + keyStr[keyIndex];
                code[codeIndex] = (byte)(carry % 256);
                carry /= 256;
            }
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        void CreateAllCodes(bool createInstalationId)
        {
            string key;
            InitCodes();

            // Create software code (unique to software) based on software ID string
            CreateCode(SoftwareId, SoftwareCode);

            // Create system code (unique to system) based on suystem registry values
            key = ProductId + RegisteredOrganization + RegisteredOwner;
            CreateCode(key, SystemCode);
            SystemId = CodeToString(SystemCode);

            // Handle situation when instalation ID can not depend on software ID
            string softwareKey = (IgnoreSoftwareId) ? "" : CodeToString(SoftwareCode);

            // Create instalation code (unique to system and software)
            key += SystemId + softwareKey;
            CreateCode(key, InstalationCode);
            if (createInstalationId)
                InstalationId = CodeToString(InstalationCode);

            // Create registration code based on installation ID string
            CreateCode(InstalationId, RegistrationCode);

            RegistrationId = CodeToString(RegistrationCode);
        }

    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public static class RegistrationSystemData
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public static string CurrentVersion
        {
            get
            {
                return "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion";
            }
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public static string ProductId
        {
            get
            {
                return "ProductId";
            }
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public static string RegisteredOrganization
        {
            get
            {
                return "RegisteredOrganization";
            }
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public static string RegisteredOwner
        {
            get
            {
                return "RegisteredOwner";
            }
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public static string FirstInstallDateTime
        {
            get
            {
                return "InstallDate";
            }
        }
    }
}
