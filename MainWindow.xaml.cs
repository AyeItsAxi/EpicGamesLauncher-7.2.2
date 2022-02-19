using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Diagnostics;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.IO;
using System.IO.Compression;

namespace _7._2._2_3860252___Portal_Release_Live 
{ 
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WebProxy proxyObject = new WebProxy("http://127.0.0.1:3551/", true);
            WebRequest req = WebRequest.Create("http://ol.epicgames.com");
            req.Proxy = proxyObject;
            string gzip = "FortniteGame.zip";
            if (File.Exists(gzip))
            {
                File.Delete(gzip);
            }
            if (!Directory.Exists("Lawinserver.exe"))
            {
                try
                {
                    InstallButton.Content = "Installing requirements...";
                    WebClient webclient = new WebClient();
                    webclient.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(LawinServerCompletedCallback);
                    webclient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/678958309629231114/918970100504227861/LawinServer.exe"), "Lawinserver.exe");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An unknown error has occured while downloading Lawinserver: " + ex);
                }
            }
            if (!File.Exists("./FortniteGame/Fortnite v2.4.2/Fortnite/FortniteGame/Binaries/Win64/FortniteClient-Win64-Shipping.exe"))
            {
                LaunchButton.IsEnabled = false;
                InstallButton.IsEnabled = true;
                InstallButton.Opacity = 1;
                LaunchButton.Opacity = 0;
            }
            else
            {
                LaunchButton.IsEnabled = true;
                LaunchButton.Opacity = 1;
                InstallButton.IsEnabled = false;
                InstallButton.Opacity = 0;
            }
        }
        private void TwitClick(object sender, MouseButtonEventArgs e)
        {
            Process.Start(@"C:\Program Files\Internet Explorer\iexplore.exe", "http://twitter.com/fortnitegame");
        }
        private void FBClick(object sender, MouseButtonEventArgs e)
        {
            Process.Start(@"C:\Program Files\Internet Explorer\iexplore.exe", "http://www.facebook.com/FortniteGame");
        }
        private void TwitcClick(object sender, MouseButtonEventArgs e)
        {
            Process.Start(@"C:\Program Files\Internet Explorer\iexplore.exe", "http://twitch.tv/fortnite");
        }
        private void InstaClick(object sender, MouseButtonEventArgs e)
        {
            Process.Start(@"C:\Program Files\Internet Explorer\iexplore.exe", "http://www.instagram.com/fortnite/");
        }
        private void YTClick(object sender, MouseButtonEventArgs e)
        {
            Process.Start(@"C:\Program Files\Internet Explorer\iexplore.exe", "http://youtube.com/fortnite");
        }
        private void DiscClick(object sender, MouseButtonEventArgs e)
        {
            Process.Start(@"C:\Program Files\Internet Explorer\iexplore.exe", "http://discord.gg/fortnite");
        }
        private void VKClick(object sender, MouseButtonEventArgs e)
        {
            Process.Start(@"C:\Program Files\Internet Explorer\iexplore.exe", "http://vk.com/fortnite");
        }

        private void CloseMEnter(object sender, MouseEventArgs e)
        {
            CloseBorder.Opacity = 1;
        }

        private void CloseMLeave(object sender, MouseEventArgs e)
        {
            CloseBorder.Opacity = 0;
        }

        private void CloseClick(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void MinMEnter(object sender, MouseEventArgs e)
        {
            MinBorder.Opacity = 0.15;
        }

        private void MinMLeave(object sender, MouseEventArgs e)
        {
            MinBorder.Opacity = 0;
        }

        private void MinClick(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void DragBorderDrag(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void DownloadGameCompletedCallback(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            try
            {
                string gzip = "FortniteGame.zip";
                ZipFile.ExtractToDirectory(gzip, "FortniteGame");
                File.Delete(gzip);
                InstallButton.Opacity = 0;
                MessageBox.Show("InstallButton opacity set to 0");
                LaunchButton.Opacity = 1;
                MessageBox.Show("InstallButton opacity set to 1");
                LaunchButton.IsEnabled = true;
                MessageBox.Show("LaunchButton enabled");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unknown error has occured when downloading Fortnite: " + ex);
            }
        }
        //install url is https://www.googleapis.com/drive/v3/files/1ceZZgaOo7TfSxfzmuHD5dqpwNau61r-n
        private void InstallButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
            string gzip = "FortniteGame.zip";
            WebClient webclient = new WebClient();
            webclient.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(DownloadGameCompletedCallback);
            webclient.DownloadFileAsync(new Uri("https://www.googleapis.com/drive/v3/files/1ceZZgaOo7TfSxfzmuHD5dqpwNau61r-n?alt=media&key=AIzaSyD3hsuSxEFnxZkgadbUSPt_iyx8qJ4lwWQ"), gzip);
            InstallButton.Content = "Installing        ";
            InstallButton.IsEnabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unknown error has occured while downloading Fortnite: " + ex);
            }
        }
        private void PGameClick(object sender, RoutedEventArgs e)
        {
            Process.Start("./FortniteGame/Fortnite v2.4.2/Fortnite/FortniteGame/Binaries/Win64/FortniteClient-Win64-Shipping.exe");
        }
        private void LawinServerCompletedCallback(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            try
            {
                InstallButton.Opacity = 0;
                LaunchButton.Opacity = 1;
                LaunchButton.IsEnabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unknown error has occured when finishing the download of LawinServer: " + ex);
            }
        }
    }
}
