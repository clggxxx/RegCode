using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace CreateRegCode
{
    public partial class CreateRegCode : Form
    {
        public CreateRegCode()
        {
            InitializeComponent();
            this.Text = this.Text + "【Ver" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() + "】";
        }
        private string MD5Key = "QwErTyzU";
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_Create_Click(object sender, EventArgs e)
        {
            try
            {
                this.textBox_code.Text = "";

                string day = this.textBox_day.Text;
                string guid = this.textBox_guid.Text;
                if (string.IsNullOrEmpty(day) || string.IsNullOrEmpty(guid))
                {
                    MessageBox.Show("参数不正确");
                    return;
                }
                int iday = int.Parse(day);
                string code = string.Format("{0}:{1}:{2}", iday, guid, DateTime.Now.ToString("yyyy-MM-dd"));
                string strKey = MD5Help.MD5Encrypt(code, MD5Key);
                if(string.IsNullOrEmpty(strKey))
                {
                    MessageBox.Show("生成失败");
                    return;
                }
                else
                {
                    this.textBox_code.Text = strKey;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }


    public class MD5Help
    {
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="pToEncrypt"></param>
        /// <param name="sKey"></param>
        /// <returns></returns>
        public static string MD5Encrypt(string pToEncrypt, string sKey)
        {
            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] inputByteArray = Encoding.Default.GetBytes(pToEncrypt);
                des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
                des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                StringBuilder ret = new StringBuilder();
                foreach (byte b in ms.ToArray())
                {
                    ret.AppendFormat("{0:X2}", b);
                }
                ret.ToString();
                return ret.ToString();
            }
            catch
            {
                return "";
            }


        }

        /// <summary>
        /// MD5解密
        /// </summary>
        /// <param name="pToDecrypt"></param>
        /// <param name="sKey"></param>
        /// <returns></returns>
        public static string MD5Decrypt(string pToDecrypt, string sKey)
        {
            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();

                byte[] inputByteArray = new byte[pToDecrypt.Length / 2];
                for (int x = 0; x < pToDecrypt.Length / 2; x++)
                {
                    int i = (Convert.ToInt32(pToDecrypt.Substring(x * 2, 2), 16));
                    inputByteArray[x] = (byte)i;
                }

                des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
                des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();

                StringBuilder ret = new StringBuilder();

                return System.Text.Encoding.Default.GetString(ms.ToArray());
            }
            catch
            {
                return "";
            }

        }
    }
}
