using Newtonsoft.Json;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Wpf.Ui.Appearance;
using EclipseLauncher;

namespace EclipseLauncher.Pages
{
    /// <summary>
    /// Lógica de interacción para Home.xaml
    /// </summary>
    /// 

    public partial class Home : Page
    {

        Proxy Proxy { get; set; }

        public Home()
        {
            InitializeComponent();
            ApplicationThemeManager.Apply(this);
        }

        private void LaunchBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Account bans with Eclipse often happen so that's why we recommend you to make a brand new alt account. If your main account gets banned, that's simply not on us because we have told you to use an alt account. If you don't know how to make a new alt account, simply head over to https://www.epicgames.com/id/login and create a new account.\n\n CLICK OK TO LAUNCH, CLICK CANCEL TO CLOSE ECLIPSE.", "Warning!", button:MessageBoxButton.OKCancel);
            
            if (result == MessageBoxResult.OK)
            {
                // Proxy = new Proxy();
                // Proxy.Start();
                LaunchFN();
            }
            else if (result == MessageBoxResult.Cancel)
            {
                // Just close lmfao
            }
        }

        private void LaunchFN()
        {
            try
            {
                string uriToLaunch = "com.epicgames.launcher://apps/fn%3A4fe75bbc5a674f4f9b356b5c90567da5%3AFortnite?action=launch&silent=true";

                Process.Start(new ProcessStartInfo
                {
                    FileName = uriToLaunch,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error launching Fortnite: {ex.Message}");
            }
        }
    }
}

