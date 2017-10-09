using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace AutoUpdate
{
    public partial class UploadForm : Form
    {
        public UploadForm()
        {
            InitializeComponent();
        }

        private string serverIP = "";
        private string serverVersion = "";
        private string nowVersion = "";
        private string programName = "";
        private string nameExe = "";
        private string fileNamePath = "";

        private delegate void OutputDelegate(string appendText);
        private delegate void ProgressDelegate(int current, int total);
        private DynWebService dws;
        private void UploadForm_Load(object sender, EventArgs e)
        {
            #region 读配置档案 MCS逻辑
            //<configure>
            //<FACTORY_NO>D</FACTORY_NO>
            //<PRINT_TYPE>C</PRINT_TYPE>
            //<Server ID="0" TYPE="IP">
            //  <ServerName>172.21.128.66</ServerName>
            //  <Version>8.1.1.5</Version>
            //  <Server_Version>8.1.1.5</Server_Version>
            //  <Version_Key>物料管理系統</Version_Key>
            //</Server>
            //<configure>

            //string xmlPath = Application.StartupPath + "\\INI\\setting.xml";

            //XmlDocument xml = new XmlDocument();
            //xml.Load(xmlPath);
            //string ServerName = xml.SelectSingleNode("//configure/Server[@ID='" + "0" + "']/ServerName").InnerText.ToString();
            //Key_Ver = xml.SelectSingleNode("//configure/Server[@ID='" + "0" + "']/Version_Key").InnerText.ToString();
            //sVersion = xml.SelectSingleNode("//configure/Server[@ID='" + "0" + "']/Server_Version").InnerText.ToString();
            //sFile_Name_Path = Key_Ver + "\\" + Key_Ver + sVersion;
            //sIP = ServerName;
            #endregion

            //读取新配置档版本 新逻辑
            //<?xml version="1.0" encoding="utf-8" ?>
            //<configure>
            //  <ServerIP>localhost:2236</ServerIP>
            //  <ServerVersion>17.9.25.1</ServerVersion>
            //  <NowVersion>17.9.9.1</NowVersion>
            //  <ProgramName>NCT</ProgramName>
            //  <NameExe>NCT_CTMS.exe</NameExe>
            //</configure>

            string xmlPath = Application.StartupPath + "\\AutoUpdateXml.xml";

            XmlDocument xml = new XmlDocument();
            xml.Load(xmlPath);
            serverIP = xml.SelectSingleNode("//configure/ServerIP").InnerText.ToString();
            serverVersion = xml.SelectSingleNode("//configure/ServerVersion").InnerText.ToString();
            nowVersion = xml.SelectSingleNode("//configure/NowVersion").InnerText.ToString();
            programName = xml.SelectSingleNode("//configure/ProgramName").InnerText.ToString();
            nameExe = xml.SelectSingleNode("//configure/NameExe").InnerText.ToString();
            fileNamePath = programName + "\\" + programName + serverVersion;
            dws = new DynWebService(serverIP);

            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer1.Stop();
            CheckDownLoad();
            Application.Exit();
        }

        private void CheckDownLoad()
        {

            object[] updateFiles = dws.GetAllUpdateInfosCompressed(fileNamePath);

            //如果未发现最新版本 直接打开源程序
            if (updateFiles == null)
            {
                MessageBox.Show("服务器上不存在" + serverVersion + "版本!");

                ProcessStartInfo psiStart = new ProcessStartInfo();
                if (File.Exists(Application.StartupPath + "\\" + nameExe))
                {
                    psiStart.FileName = Application.StartupPath + "\\" + nameExe;
                    psiStart.UseShellExecute = true;
                    psiStart.WorkingDirectory = Application.StartupPath;
                }
                else 
                {
                    psiStart.FileName = Application.StartupPath;
                    psiStart.UseShellExecute = true;
                    psiStart.WorkingDirectory = Application.StartupPath;
                }
                Process.Start(psiStart);

                return;
            }

            #region 验证主程序 已注释
            //foreach (object o in updateFiles)
            //{
            //    WS_Update.UpdateInfos updateInfo = (WS_Update.UpdateInfos)o;

            //    //验证主程序
            //    if (updateInfo.filepath.ToUpper() == "\\" + nameExe.ToUpper())
            //    {
            //        if (!File.Exists(Application.StartupPath + updateInfo.filepath)
            //            || File.GetCreationTimeUtc(Application.StartupPath + updateInfo.filepath) < updateInfo.time.ToUniversalTime())
            //        {
            //            WS_Update.UpdateInfos updateInfo2 = dws.GetFileCompressed(fileNamePath, updateInfo.filepath);

            //            using (FileStream fs = File.Create(Application.StartupPath + updateInfo.filepath))
            //            {
            //                fs.Write(updateInfo2.bin, 0, (int)updateInfo2.bin.Length);
            //            }
            //            File.SetCreationTimeUtc(Application.StartupPath + updateInfo.filepath, updateInfo2.time.AddMinutes(5));

            //            bChang = true;
            //        }
            //    }
            //}
            #endregion

            //是否更新
            bool bChang = false;
            if (!nowVersion.Equals(serverVersion))
            {
                bChang = true;
            }

            if (bChang)
            {
                UpdateData(updateFiles);

                #region
                string xmlPath = Application.StartupPath + "\\AutoUpdateXml.xml";

                XmlDocument xml = new XmlDocument();
                xml.Load(xmlPath);

                xml.SelectSingleNode("//configure/NowVersion").InnerText = serverVersion;
                xml.Save(xmlPath);
                #endregion
            }

            //如果设置主程序有误，打开文件夹，若无误直接打开执行程序
            ProcessStartInfo psi = new ProcessStartInfo();
            if (File.Exists(Application.StartupPath + "\\" + nameExe))
            {
                psi.FileName = Application.StartupPath + "\\" + nameExe;
                psi.UseShellExecute = true;
                psi.WorkingDirectory = Application.StartupPath;
            }
            else 
            {
                psi.FileName = Application.StartupPath;
                psi.UseShellExecute = true;
                psi.WorkingDirectory = Application.StartupPath;
            }
            Process.Start(psi);
        }

        private void UpdateData(object[] updateFiles)
        {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.txtOutput.Text += "正在寻找最新的版本文件... \r\n";
            txtOutput.SelectionStart = txtOutput.Text.Length;
            Application.DoEvents();

            #region update core

            //已经验证
            //object[] UpDates = dws.GetAllUpdateInfosCompressed(fileNamePath);

            //if (UpDates == null)
            //{
            //    MessageBox.Show("没有找到最新的版本文件 !");
            //    return;
            //}

            Do(updateFiles, Application.StartupPath, serverVersion);

            #endregion

            this.Cursor = System.Windows.Forms.Cursors.Default;
        }

        #region Do
        public void Do(object[] updates, string StartupPath, string version)
        {
            int total = GetNumberToUpdate(updates, StartupPath);
            int currentfilenumber = 0;

            try
            {
                UpdateProgress(0, total);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\r\n" + ex.StackTrace);
            }

            foreach (object o in updates)
            {
                WS_Update.UpdateInfos updateInfo = (WS_Update.UpdateInfos)o;

                if (NeedUpdate(StartupPath, updateInfo))
                {
                    UpdateText("正在下载：'" + updateInfo.filepath + "'... \r\n");
                    Thread.Sleep(500);
                    try
                    {
                        dws.Timeout = (1000 * 60) * 15;

                        WS_Update.UpdateInfos updateInfo2 = dws.GetFileCompressed(fileNamePath, updateInfo.filepath);

                        string fullpath = StartupPath + updateInfo.filepath;

                        string fullpathwofilename = fullpath.Replace(System.IO.Path.GetFileName(fullpath), "");
                        try
                        {
                            Directory.CreateDirectory(fullpathwofilename);
                        }
                        catch
                        {

                        }

                        if (updateInfo2.bin != null && updateInfo2.bin.Length > 0)
                        {
                            using (FileStream fs = File.Create(StartupPath + updateInfo.filepath))
                            {
                                fs.Write(updateInfo2.bin, 0, (int)updateInfo2.bin.Length);
                            }
                            File.SetCreationTimeUtc(StartupPath + updateInfo.filepath, updateInfo2.time.ToUniversalTime().AddMinutes(5));
                        }

                        UpdateText("更新文件：'" + updateInfo.filepath +"'..." + " \r\n");
                        Thread.Sleep(500);
                        UpdateText("更新成功！时间："+ updateInfo.time.ToUniversalTime()+" \r\n");
                        Thread.Sleep(500);

                        try
                        {
                            currentfilenumber += 1;
                            UpdateProgress(currentfilenumber, total);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message + "\r\n" + ex.StackTrace);
                        }

                    }
                    catch (Exception ex)
                    {
                        UpdateText("Non fatal error : " + ex.Message + " \r\n");
                    }
                }
            }

            UpdateText("\r\n更新完成！ \r\n");
            Thread.Sleep(1000);
            try
            {
                UpdateProgress(total, total);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\r\n" + ex.StackTrace);
            }
        }
        #endregion

        public int GetNumberToUpdate(object[] updates, string StartupPath)
        {
            int total = 0;

            foreach (object o in updates)
            {
                WS_Update.UpdateInfos updateInfo = (WS_Update.UpdateInfos)o;

                if (NeedUpdate(StartupPath, updateInfo))
                {
                    total += 1;
                }
            }

            return total;
        }

        private static bool NeedUpdate(string startupPath, WS_Update.UpdateInfos updateInfo)
        {
            bool needUpdate = false;

            string filePath = Path.Combine(startupPath, updateInfo.filepath);
            DateTime creationTime = File.GetCreationTimeUtc(filePath);

            if (!File.Exists(filePath) || IsFileTypeMustUpdate(filePath))
            {
                needUpdate = true;
            }
            else
            {
                if (creationTime < updateInfo.time.ToUniversalTime())
                {
                    needUpdate = true;
                }
            }

            return needUpdate;
        }

        private static bool IsFileTypeMustUpdate(string filePath)
        {
            bool isFileTypeMustUpdate = false;
            List<string> fileExtensions = new List<string> { "", ".exe", ".dll" };

            string fileExtension = Path.GetExtension(filePath);
            if (fileExtensions.Contains(fileExtension))
            {
                isFileTypeMustUpdate = true;
            }

            return isFileTypeMustUpdate;
        }

        private void UpdateText(string appendText)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new OutputDelegate(UpdateText), new object[] { appendText });
            }
            else
            {
                this.txtOutput.Text += appendText;
                txtOutput.SelectionStart = txtOutput.Text.Length;
                txtOutput.ScrollToCaret();
            }
        }

        private void UpdateProgress(int current, int total)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new ProgressDelegate(UpdateProgress), new object[] { current, total });
            }
            else
            {
                this.progressBar.Value = current;
                this.progressBar.Maximum = total;
            }
        }
    }
}
