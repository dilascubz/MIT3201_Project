using System;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Microsoft.VisualBasic; // Install-Package Microsoft.VisualBasic
using DALMPRS;

namespace BLLMPRS
{
    public  class BLLGroupAccess
    {
        private DALGroupAccess objGroupAccessDAL;

        public BLLGroupAccess()
        {
            objGroupAccessDAL = new DALGroupAccess();
        }

        public DataSet SelectAllUserGroups()
        {
            return objGroupAccessDAL.SelectAllUserGroups();
        }

        public DataSet SelectTasksByGroup(string strGroup)
        {
            return objGroupAccessDAL.SelectTasksByGroup(strGroup);
        }

        public DataSet CheckUserGroupExists(string strGroup)
        {
            return objGroupAccessDAL.CheckUserGroupExists(strGroup);
        }

        public int InsertGroupAccess(string strGroupName, string strTaskName, int nSequence)
        {
            return objGroupAccessDAL.InsertGroupAccess(strGroupName, strTaskName, nSequence);
        }

        public int DeleteGroupAccess(string strGroupName)
        {
            return objGroupAccessDAL.DeleteGroupAccess(strGroupName);
            return 1;
        }

        public int InsertGroup(string strGroupName)
        {
            return objGroupAccessDAL.InsertGroup(strGroupName);
        }

        public string EncryptString(string strText, string strEncrKey)
        {
            var byKey = Array.Empty<byte>();
            var IV = new byte[] { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
            try
            {
                byKey = Encoding.UTF8.GetBytes(Strings.Left(strEncrKey, 8));
                var des = new DESCryptoServiceProvider();
                var inputByteArray = Encoding.UTF8.GetBytes(strText);
                var ms = new MemoryStream();
                var cs = new CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                return Convert.ToBase64String(ms.ToArray());
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        // ******************************************************************************************************
        // This is used to decrypt a string********************************************************************
        public string DecryptString(string strText, string sDecrKey)
        {
            var byKey = Array.Empty<byte>();
            var IV = new byte[] { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
            var inputByteArray = new byte[strText.Length + 1];
            try
            {
                byKey = Encoding.UTF8.GetBytes(Strings.Left(sDecrKey, 8));
                var des = new DESCryptoServiceProvider();
                inputByteArray = Convert.FromBase64String(strText);
                var ms = new MemoryStream();
                var cs = new CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                var encoding = Encoding.UTF8;
                return encoding.GetString(ms.ToArray());
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}