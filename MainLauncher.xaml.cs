using EclipseLauncher.Pages;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using Wpf.Ui.Appearance;
using Wpf.Ui.Controls;

namespace EclipseLauncher
{

    public partial class MainLauncher
    {
        public MainLauncher()
        {
            InitializeComponent();
            ApplicationThemeManager.Apply(this);
            EclipseLauncher.Discord.StartRPC();
            ContentFrame.Navigate(new Home());
        }

        // UI and Closing
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Proxy.Stop();
            Environment.Exit(0);
            
        }

        private void NavigationView_PaneOpened(NavigationView sender, RoutedEventArgs args)
        {
            ContentFrame.Margin = new Thickness(330, -528, 0, 0);
        }

        private void NavigationView_PaneClosed(NavigationView sender, RoutedEventArgs args)
        {
            ContentFrame.Margin = new Thickness(52, -528, 0, 0);
        }

        private void NavigationViewItem_Click(object sender, RoutedEventArgs e)
        {
            var item = e.OriginalSource as NavigationViewItem; // Ajusta según la implementación real de NavigationViewItem
            if (item != null)
            {
                string tag = item.Tag.ToString();

                switch (tag)
                {
                    case "Home":
                        ContentFrame.Navigate(new Home());
                        break;
                    case "Settings":
                        ContentFrame.Navigate(new Settings());
                        break;
                    // Agrega más casos según sea necesario para más páginas
                    default:
                        break;
                }
            }
        }
    }
}
