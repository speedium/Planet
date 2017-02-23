using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace Planet
{
    static class Program
    {
        public static string RegistrationSWName = "RegistrationPlanetId";
        public static string RegistrationId = "";
        static private bool useConsole = false;
        /////////////////////////////////
        /////////////////////////////////
        [DllImport("kernel32.dll")]
        static private extern bool AllocConsole();
        public static bool isDevelopment = false;
        /////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public static void SaveStringToBinaryWriter(ref BinaryWriter bw, ref string stringWriteIn, bool canBeEmpty)
        {

            if (canBeEmpty == false)
            {
                if (stringWriteIn == null || stringWriteIn == "")
                {
                    stringWriteIn = " ";
                }
            }

            byte[] ecryptBytes = EcryptString(stringWriteIn);
            bw.Write(ecryptBytes.Length);
            bw.Write(ecryptBytes);

        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public static string DecryptBytes(byte[] inputBytes)
        {
            //return stringIn;
            //funkcia odkoduje string
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            //byte[] inputBytes = encoding.GetBytes(stringIn);

            byte[] key = encoding.GetBytes("ENVITECH");
            SymmetricAlgorithm alg = new DESCryptoServiceProvider();

            alg.Key = key;
            alg.IV = key;

            ICryptoTransform decrypt = alg.CreateDecryptor();
            byte[] decryptBytes =
            decrypt.TransformFinalBlock(inputBytes, 0, inputBytes.Length);

            string decryptString = encoding.GetString(decryptBytes);

            return decryptString;

        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public static string LoadStringFromBinaryReader(ref BinaryReader br)
        {

            int length = br.ReadInt32();
            byte[] bytes = br.ReadBytes(length);
            //string stringRead = new string(strChar);

            string stringReadOut = DecryptBytes(bytes);

            return stringReadOut;

        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public static byte[] EcryptString(string stringIn)
        {

            //return stringIn;
            //funkcia zakoduje string
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            byte[] inputBytes = encoding.GetBytes(stringIn);

            byte[] key = encoding.GetBytes("ENVITECH");
            SymmetricAlgorithm alg = new DESCryptoServiceProvider();

            alg.Key = key;
            alg.IV = key;

            ICryptoTransform ecrypt = alg.CreateEncryptor();
            byte[] ecryptBytes =
            ecrypt.TransformFinalBlock(inputBytes, 0, stringIn.Length);

            //string ecryptString = encoding.GetString(ecryptBytes);

            return ecryptBytes;

        }
        /////////////////////////////////
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
#if DEBUG
           // isDevelopment = true;
#endif

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            RegisterView fr = new RegisterView();

            if (fr.KontrolaRegistracie())
            {
                Application.Run(new MainForm());
            }

        }
        /////////////////////////////////
        /////////////////////////////////
        static public void InitConsole()
        {
            useConsole = true;
            AllocConsole();
        }
        /////////////////////////////////
        /////////////////////////////////
        static public void Console_WriteLine(string str)
        {
            if (!useConsole) { return; }
            Console.WriteLine(str);
        }
        /////////////////////////////////
        /////////////////////////////////
    }
}
