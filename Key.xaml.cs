using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.WebUtilities;
using Wpf.Ui.Appearance;


namespace EclipseLauncher
{

    /// 
    /// Eclipse Launcher made by ggsplayz ykyk
    /// 
    /// VALID KEY TO TEST IS f6d209ccb6240d88390924dfd447a6a8
    /// 
    /// BTW Do ur own, skidder!!!
    public partial class Key
    {
        public Key()
        {
            InitializeComponent();
            ApplicationThemeManager.Apply(this);
        }

        public static string EnteredKey;
        public static bool RememberToClose;
        private static readonly HttpClient client = new HttpClient();

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://discord.gg/ecl1pse",
                UseShellExecute = true
            });
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(EnteredKey))
            {
                MessageBox.Show("The Key you entered is not valid, please try again.");
                return;
            }

            bool isValid = await CheckKeyAsync(EnteredKey);

            if (isValid)
            {
                this.Hide();

                MainLauncher mainLauncher = new MainLauncher();
                mainLauncher.Show();
            }
            else if (EnteredKey == "f6d209ccb6240d88390924dfd447a6a8")
            {
                MessageBox.Show("The Key you entered is a dev testing key, OK to open a debug instance of the launcher.", "f6d209ccb6240d88390924dfd447a6a8 - Information");

                this.Hide();

                MainLauncher mainLauncher = new MainLauncher();
                mainLauncher.Show();
            }
            else
            {
                MessageBox.Show("The Key you entered is not valid, please try again.");
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            EnteredKey = (sender as TextBox)?.Text;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://bstlar.com/Hb/eks",
                UseShellExecute = true
            });
        }

        private async Task<string> GetUserIpAsync()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("https://api.ipify.org");
                response.EnsureSuccessStatusCode();
                string ip = await response.Content.ReadAsStringAsync();
                return ip;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        private async Task<bool> CheckKeyAsync(string key)
        {
            try
            {
                string userIp = await GetUserIpAsync();
                if (string.IsNullOrEmpty(userIp))
                {
                    return false;
                }

                string url = $"https://bstlar.com/keys/validate/{key}";
                var query = new Dictionary<string, string>()
                {
                    { "ip", userIp }
                };
                var uriWithQuery = QueryHelpers.AddQueryString(url, query);

                var request = new HttpRequestMessage(HttpMethod.Get, uriWithQuery);
                request.Headers.Add("bstk", "PgzlIHfsiZj8h367QH37JC0fTRSdsjuZHZCI");

                HttpResponseMessage response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                var jsonResponse = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseBody);

                return jsonResponse.ContainsKey("valid") && (bool)jsonResponse["valid"];
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void FluentWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
