using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO.Compression;
using System.Media;

namespace Ashes_Wind___Launcher
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

    {
        public MainWindow()
        {
            InitializeComponent();

            double screenHeight = SystemParameters.FullPrimaryScreenHeight;
            double screenWidth = SystemParameters.FullPrimaryScreenWidth;


            this.Top = (screenHeight - this.Height) / 0x00000002;
            this.Left = (screenWidth - this.Width) / 0x00000002;

            text1.Visibility = Visibility.Collapsed;
            text2.Visibility = Visibility.Collapsed;
            vk_aw.Visibility = Visibility.Collapsed;
            vk_ct.Visibility = Visibility.Collapsed;
            _in.Visibility = Visibility.Collapsed;
            fb.Visibility = Visibility.Collapsed;
            CT.Visibility = Visibility.Collapsed;
            tw.Visibility = Visibility.Collapsed;
            back.Visibility = Visibility.Collapsed;
            yt.Visibility = Visibility.Collapsed;
            tosite.Visibility = Visibility.Collapsed;
            arrow_1.Visibility = Visibility.Collapsed;
            arrow_2.Visibility = Visibility.Collapsed;
            arrow_3.Visibility = Visibility.Collapsed;
            arrow_4.Visibility = Visibility.Collapsed;
            arrow_5.Visibility = Visibility.Collapsed;
            graph_high.Visibility = Visibility.Collapsed;
            graph_low.Visibility = Visibility.Collapsed;
            graph_med.Visibility = Visibility.Collapsed;
            graph_ultra.Visibility = Visibility.Collapsed;
            openmw.Visibility = Visibility.Collapsed;
            progress.Visibility = Visibility.Collapsed;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
            Process.Start(AppDomain.CurrentDomain.BaseDirectory + @"start.cmd");
        }

        private void Button_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Logo.Visibility = Visibility.Collapsed;
            btn1.Visibility = Visibility.Collapsed;
            btn2.Visibility = Visibility.Collapsed;
            btn3.Visibility = Visibility.Collapsed;
            btn4.Visibility = Visibility.Collapsed;
            btn5.Visibility = Visibility.Collapsed;

            text1.Visibility = Visibility.Visible;
            text2.Visibility = Visibility.Visible;
            vk_aw.Visibility = Visibility.Visible;
            vk_ct.Visibility = Visibility.Visible;
            _in.Visibility = Visibility.Visible;
            fb.Visibility = Visibility.Visible;
            CT.Visibility = Visibility.Visible;
            tw.Visibility = Visibility.Visible;
            back.Visibility = Visibility.Visible;
            yt.Visibility = Visibility.Visible;
            tosite.Visibility = Visibility.Visible;

        }

        WebClient request = new WebClient();
        Stopwatch sw = new Stopwatch();
        void webClient_DownloadProgressChanged(object sender, System.Net.DownloadProgressChangedEventArgs e)
        {
            try
            {
                if (progress.Value != e.ProgressPercentage)
                    progress.Value = e.ProgressPercentage;
            }
            catch (Exception ex)
            {
             
            }
        }

        void webClient_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            progress.Value = 100;
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            progress.Visibility = Visibility.Visible;
            string zip_path = AppDomain.CurrentDomain.BaseDirectory + @"Data Files.zip";
            string extractzipPath = AppDomain.CurrentDomain.BaseDirectory + @"Data Files/";
            string inputfilepath = AppDomain.CurrentDomain.BaseDirectory + @"Data Files.zip";
            string inputcmdpath = AppDomain.CurrentDomain.BaseDirectory + @"start.cmd";
            string ftphost = "185.242.86.60";
            string ftpfilepath = "/Civitatum-Team/Ashes-Wind/Updates/Data Files.zip";
            string ftpcmdpath = "/Civitatum-Team/Ashes-Wind/Updates/start.cmd";
            string ftpfullpath = "ftp://" + ftphost + ftpfilepath;
            string ftpfullcmdpath = "ftp://" + ftphost + ftpcmdpath;

            //void progressbar(object sender, DownloadProgressChangedEventArgs e)
            //{
            //    double bytesIn = double.Parse(e.BytesReceived.ToString());
            //    double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
            //    double percentage = bytesIn / totalBytes * 100;

            //    progress.Value = int.Parse(Math.Truncate(percentage).ToString());

            //}

            //void progressbar_end(object sender, AsyncCompletedEventArgs e)
            //{
            //    progress.Visibility = Visibility.Collapsed;
            //}

             
                request.Credentials = new NetworkCredential("player", "c1v1tatum_T");
                byte[] fileData = request.DownloadData(ftpfullpath);
                byte[] cmdData = request.DownloadData(ftpfullcmdpath);

                using (FileStream file = File.Create(inputfilepath))
                {
                    file.Write(fileData, 0, fileData.Length);
                    file.Close();
                }
                using (FileStream file = File.Create(inputcmdpath))
                {
                    file.Write(cmdData, 0, cmdData.Length);
                    file.Close();
                }

            

            File.Delete(AppDomain.CurrentDomain.BaseDirectory + @"start.cmd");
            File.Delete(AppDomain.CurrentDomain.BaseDirectory + @"/Data Files/Master.esp");
            File.Delete(AppDomain.CurrentDomain.BaseDirectory + @"/Data Files/module1.esp");
            File.Delete(AppDomain.CurrentDomain.BaseDirectory + @"/Data Files/module2.esp");
            File.Delete(AppDomain.CurrentDomain.BaseDirectory + @"/Data Files/module3.esp");
            File.Delete(AppDomain.CurrentDomain.BaseDirectory + @"/Data Files/module4.esp");
            File.Delete(AppDomain.CurrentDomain.BaseDirectory + @"/Data Files/module5.esp");
            File.Delete(AppDomain.CurrentDomain.BaseDirectory + @"/Data Files/module6.esp");
            File.Delete(AppDomain.CurrentDomain.BaseDirectory + @"/Data Files/Real_Mining.bsa");
            File.Delete(AppDomain.CurrentDomain.BaseDirectory + @"/Data Files/Master.esp");
            File.Delete(AppDomain.CurrentDomain.BaseDirectory + @"/Data Files/Ashes Wind.esm");
            File.Delete(AppDomain.CurrentDomain.BaseDirectory + @"/Data Files/Ashes Wind.bsa");

            ZipFile.ExtractToDirectory(zip_path, extractzipPath);

            File.Delete(AppDomain.CurrentDomain.BaseDirectory + @"Data Files.zip");

            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            sw.Start();

            progress.Visibility = Visibility.Collapsed;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

            btn1.Visibility = Visibility.Collapsed;
            btn2.Visibility = Visibility.Collapsed;
            btn3.Visibility = Visibility.Collapsed;
            btn4.Visibility = Visibility.Collapsed;
            btn5.Visibility = Visibility.Collapsed;

            back.Visibility = Visibility.Visible;
            graph_high.Visibility = Visibility.Visible;
            graph_low.Visibility = Visibility.Visible;
            graph_med.Visibility = Visibility.Visible;
            graph_ultra.Visibility = Visibility.Visible;
            openmw.Visibility = Visibility.Visible;



        }

        private void vk_ct_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Process.Start("https://vk.com/civitatum.team");
        }

        private void fb_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Process.Start("https://www.facebook.com/groups/civitatumteamofficial");
        }

        private void tw_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Process.Start("https://twitter.com/CivitatumT");
        }

        private void _in_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Process.Start("https://www.instagram.com/civitatumteam_official/");
        }

        private void vk_aw_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Process.Start("https://vk.com/ashes.wind");
        }

        private void CT_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Process.Start("https://civitatumteam.com/ashes-wind");
        }

        private void yt_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Process.Start("https://www.youtube.com/channel/UCU_lHXPzT15yo_3uOSExV9g");
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            Logo.Visibility = Visibility.Visible;
            btn1.Visibility = Visibility.Visible;
            btn2.Visibility = Visibility.Visible;
            btn3.Visibility = Visibility.Visible;
            btn4.Visibility = Visibility.Visible;
            btn5.Visibility = Visibility.Visible;

            text1.Visibility = Visibility.Collapsed;
            text2.Visibility = Visibility.Collapsed;
            vk_aw.Visibility = Visibility.Collapsed;
            vk_ct.Visibility = Visibility.Collapsed;
            _in.Visibility = Visibility.Collapsed;
            fb.Visibility = Visibility.Collapsed;
            CT.Visibility = Visibility.Collapsed;
            tw.Visibility = Visibility.Collapsed;
            back.Visibility = Visibility.Collapsed;
            yt.Visibility = Visibility.Collapsed;
            tosite.Visibility = Visibility.Collapsed;
            arrow_1.Visibility = Visibility.Collapsed;
            arrow_2.Visibility = Visibility.Collapsed;
            arrow_3.Visibility = Visibility.Collapsed;
            arrow_4.Visibility = Visibility.Collapsed;
            arrow_5.Visibility = Visibility.Collapsed;
            graph_high.Visibility = Visibility.Collapsed;
            graph_low.Visibility = Visibility.Collapsed;
            graph_med.Visibility = Visibility.Collapsed;
            graph_ultra.Visibility = Visibility.Collapsed;
            openmw.Visibility = Visibility.Collapsed;
        }

        private void feedback_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Process.Start("https://civitatumteam.com/feedback");
        }

        private void graph_high_MouseLeave(object sender, MouseEventArgs e)
        {
            arrow_3.Visibility = Visibility.Collapsed;
        }

        private void graph_high_MouseMove(object sender, MouseEventArgs e)
        {
            arrow_3.Visibility = Visibility.Visible;
        }

        private void graph_ultra_MouseLeave(object sender, MouseEventArgs e)
        {
            arrow_4.Visibility = Visibility.Collapsed;
        }

        private void graph_ultra_MouseMove(object sender, MouseEventArgs e)
        {
            arrow_4.Visibility = Visibility.Visible;
        }

        private void graph_med_MouseLeave(object sender, MouseEventArgs e)
        {
            arrow_2.Visibility = Visibility.Collapsed;
        }

        private void graph_med_MouseMove(object sender, MouseEventArgs e)
        {
            arrow_2.Visibility = Visibility.Visible;
        }

        private void graph_low_MouseLeave(object sender, MouseEventArgs e)
        {
            arrow_1.Visibility = Visibility.Collapsed;
            //text_low.Visibility = Visibility.Collapsed;
        }

        private void graph_low_MouseMove(object sender, MouseEventArgs e)
        {
            arrow_1.Visibility = Visibility.Visible;
           //text_low.Visibility = Visibility.Visible;
        }

        private void graph_low_Click(object sender, RoutedEventArgs e)
        {
            File.Copy(AppDomain.CurrentDomain.BaseDirectory + @"tes3mp/settings-default-low.cfg", AppDomain.CurrentDomain.BaseDirectory + @"tes3mp/settings-default.cfg", true);
        }

        private void graph_med_Click(object sender, RoutedEventArgs e)
        {
            File.Copy(AppDomain.CurrentDomain.BaseDirectory + @"tes3mp/settings-default-medium.cfg", AppDomain.CurrentDomain.BaseDirectory + @"tes3mp/settings-default.cfg", true);
        }

        private void graph_high_Click(object sender, RoutedEventArgs e)
        {
            File.Copy(AppDomain.CurrentDomain.BaseDirectory + @"tes3mp/settings-default-high.cfg", AppDomain.CurrentDomain.BaseDirectory + @"tes3mp/settings-default.cfg", true);
        }

        private void graph_ultra_Click(object sender, RoutedEventArgs e)
        {
            File.Copy(AppDomain.CurrentDomain.BaseDirectory + @"tes3mp/settings-default-ultra.cfg", AppDomain.CurrentDomain.BaseDirectory + @"tes3mp/settings-default.cfg", true);
        }

        private void openmw_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(AppDomain.CurrentDomain.BaseDirectory + @"tes3mp/openmw-launcher.exe");
        }

        private void openmw_MouseLeave(object sender, MouseEventArgs e)
        {
            arrow_5.Visibility = Visibility.Collapsed;
        }

        private void openmw_MouseMove(object sender, MouseEventArgs e)
        {
            arrow_5.Visibility = Visibility.Visible;
        }
    }
}
