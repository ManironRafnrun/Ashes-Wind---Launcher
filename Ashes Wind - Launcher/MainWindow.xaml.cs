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

            //VisualBrush vb = new VisualBrush();
            //MediaElement me = new MediaElement();
            //me.Source = new Uri("Композиция 1.mp4");
            //vb.Visual = me;


            //LayoutRoot.Background = vb;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Process.Start(AppDomain.CurrentDomain.BaseDirectory + @"Morrowind Launcher.exe");
        }

        private void Button_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Image Logo = new Image(); //img = new x();
            Logo.Visibility = Visibility.Collapsed;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
                WebClient wc = new WebClient();
                string urlesp = "https://github.com/ManironRafnrun/Ashes-Wind/blob/master/Browser.zip";
                string save_path = @"temp\";
                wc.DownloadFile(urlesp, save_path);
                string extractPath = AppDomain.CurrentDomain.BaseDirectory + @"Data Files\";
                string zip_path = AppDomain.CurrentDomain.BaseDirectory + @"temp\Browser.zip";

                ZipFile.ExtractToDirectory(zip_path, extractPath);

        }
    }
}
