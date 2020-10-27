using System.Management;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace Lab2OZI
{
    public static class KeyChecker
    {
        public static bool Check()
        {
            string stringForEncryption = "";
            ManagementObjectSearcher directories = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_OperatingSystem");

            foreach (ManagementObject queryObj in directories.Get())
            {
                stringForEncryption += "SystemDirectory:" + queryObj["SystemDirectory"].ToString();
                stringForEncryption += " WindowsDirectory:" + queryObj["WindowsDirectory"].ToString();
            }

            ManagementObjectSearcher diskInfo = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Volume");

            List<DiskInfo> dInfo = new List<DiskInfo>();
            foreach (ManagementObject queryObj in diskInfo.Get())
            {
                DiskInfo disk = new DiskInfo();
                if (queryObj["DriveLetter"] != null)
                {
                    disk.Letter = queryObj["DriveLetter"].ToString();
                    disk.Capacity = queryObj["Capacity"].ToString();
                    disk.FreeSpace = queryObj["FreeSpace"].ToString();
                    dInfo.Add(disk);
                }
            }
            foreach (var item in dInfo)
            {
                stringForEncryption += " Letter:" + item.Letter + " Capacity:";
                stringForEncryption += item.Capacity.ToString();
            }


            ManagementObjectSearcher screenInfo = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_VideoController");

            List<string> scrHeights = new List<string>();
            foreach (ManagementObject queryObj in screenInfo.Get())
            {
                if (queryObj["CurrentHorizontalResolution"] != null)
                {
                    scrHeights.Add(queryObj["CurrentVerticalResolution"].ToString());
                }
            }
            foreach (var item in scrHeights)
            {
                stringForEncryption += " Height:" + item.ToString();
            }

            ManagementObjectSearcher keyboardsInfo = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Keyboard");

            foreach (ManagementObject queryObj in keyboardsInfo.Get())
            {
                stringForEncryption += " Keyboard:" + queryObj["Name"];
                stringForEncryption += " " + queryObj["Description"];
            }

            #region Encryption & Registry

            var key = "b14ca5898a4e4133bbce2ea2315a1916";
            var encryptedstring = AesOperation.EncryptString(key, stringForEncryption);

            try
            {
                string fromregistry = ReadRegistry();
                if (encryptedstring.SequenceEqual(fromregistry))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            #endregion
        }


        public static void WriteValueToRegistry(string s)
        {
            RegistryKey currentUserKey = Registry.CurrentUser;
            RegistryKey myKey = currentUserKey.CreateSubKey("Bolshoi");
            myKey.SetValue("BolshoiOleksandr", s);
            myKey.Close();
        }
        public static string ReadRegistry()
        {
            try
            {
                RegistryKey currentUserKey = Registry.CurrentUser;
                RegistryKey myKey = currentUserKey.OpenSubKey("Bolshoi", true);

                string data = myKey.GetValue("BolshoiOleksandr").ToString();
                myKey.Close();
                return data;
            }
            catch (NullReferenceException ex)
            {
                return "";
            }

        }
        public static void DeleteKey()
        {
            RegistryKey currentUserKey = Registry.CurrentUser;
            RegistryKey helloKey = currentUserKey.OpenSubKey("Bolshoi", true);
            helloKey.DeleteValue("BolshoiOleksandr");
            currentUserKey.DeleteSubKey("Bolshoi");
        }
    }

    public class DiskInfo
    {
        public object Letter { get; set; }
        public object Capacity { get; set; }
        public object FreeSpace { get; set; }
    }
    public class AesOperation
    {
        public static string EncryptString(string key, string plainText)
        {
            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }
        public static string DecryptString(string key, string cipherText)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
