using Microsoft.Win32;
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

namespace RegApp
{
    public partial class Reg : Form
    {
        public Reg()
        {
            InitializeComponent();
            this.Text = this.Text + "【Ver" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() + "】"; 
        }
        private string MD5Key = "QwErTyzU";
        private void button_Reg_Click(object sender, EventArgs e)
        {
            try
            {
                string code = this.textBox_Code.Text;
                if (string.IsNullOrEmpty(code))
                {
                    MessageBox.Show("注册码不正确","提示");                  
                    return;
                }
                string decCode = MD5Help.MD5Decrypt(code, MD5Key);//解密
                if(string.IsNullOrEmpty(decCode))
                {
                    MessageBox.Show("注册码不正确!", "提示");                 
                    return;
                }
                string[] datas = decCode.Split(':');
                if (datas.Length == 3)
                {
                    string day = datas[0];//授权时长，天
                    string guid = datas[1];//机器GUID
                    string date = datas[2];//注册码生成日期

                    if (!string.IsNullOrEmpty(guid))
                    {
                        if (guid == ReadRegistryKey("PCGUID"))//唯一ID正确
                        {

                            //注册码上次生成时间
                            string PCCodeDate = ReadRegistryKey("PCCodeDate");
                            //上次注册码
                            string lastCode = ReadRegistryKey("LastCode");
                            if(!string.IsNullOrEmpty(lastCode))
                            {
                                if(lastCode == code)
                                {
                                    MessageBox.Show("该注册码已使用");
                                    return;
                                }
                            }
                            //注册码生成时间
                            //if(!string.IsNullOrEmpty(PCCodeDate))
                            //{
                            //    DateTime dtCodeDate = Convert.ToDateTime(PCCodeDate);
                            //}
                            int iday = int.Parse(day);
                            string pcdate = DateTime.Now.AddDays(iday).ToString("yyyy-MM-dd");
                            pcdate = MD5Help.MD5Encrypt(pcdate, MD5Key);//写入日期加密
                            SetRegistryKey("PCDate", pcdate);
                            SetRegistryKey("LastCode", code);
                            MessageBox.Show(string.Format("已注册，{0}天后过期！", day));
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            MessageBox.Show("注册码不匹配！");
                            return;
                        }
                    }

                }
            }
            catch
            {
                MessageBox.Show("注册异常", "提示");
            }
        }
        
        /// <summary>
        /// 读取指定数据
        /// </summary>
        /// <param name="subkey"></param>
        /// <returns></returns>
        private string ReadRegistryKey(string subkey)
        {
            try
            {

                RegistryKey key = Registry.CurrentUser;//注册表，本地计算机的配置数据
                RegistryKey software = key.OpenSubKey("software\\clggxxx", true);//这里AppBindingPC是程序名，可以随意取
                if (software == null)
                {
                    software = key.CreateSubKey("software\\clggxxx");//创建目录
                }
                if (software.GetValue(subkey) == null)
                {
                    return "";
                }
                return software.GetValue(subkey).ToString();//读取键值

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private void SetRegistryKey(string subkey, string data)
        {
            try
            {
                RegistryKey key = Registry.CurrentUser;//注册表，本地计算机的配置数据
                RegistryKey software = key.OpenSubKey("software\\clggxxx", true);//这里AppBindingPC是程序名，可以随意取
                if (software == null)
                {
                    software = key.CreateSubKey("software\\clggxxx");//创建目录
                }
                software.SetValue(subkey, data);//创建键值
            }
            catch (Exception ex)
            {
                
            }

        }
        private void button_Cancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.OK == MessageBox.Show("尚未注册，是否取消？", "提示", MessageBoxButtons.OKCancel))
                {
                    this.Close();
                    System.Environment.Exit(0);
                }
                else
                {
                    return;
                }
            }
            catch
            {
                MessageBox.Show("程序发生异常");
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                string strGuid = ReadRegistryKey("PCGUID");

                if(string.IsNullOrEmpty(strGuid))
                {
                    strGuid = Guid.NewGuid().ToString("N");
                    SetRegistryKey("PCGUID", strGuid);
                }
                this.textBox_Guid.Text = strGuid;
            }
            catch
            {

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
