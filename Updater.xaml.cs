using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows;
using System.Windows.Media.Imaging;
using Wpf.Ui.Appearance;
using WpfAnimatedGif;

namespace EclipseLauncher
{
    /// 
    /// GO TO LN35 AND CHANGE VERSION STRING EVERY UPDATE
    /// 
    public partial class Updater
    {
        public Updater()
        {
            InitializeComponent();
            ApplicationThemeManager.Apply(this);

            //UI

            var gifUri = new Uri("pack://application:,,,/EclipseLauncher;component/Resources/loading.gif");
            var image = new BitmapImage(gifUri);
            ImageBehavior.SetAnimatedSource(gifImage, image);


            // Uncoment when you have set up lines 32 & 33
            // CheckForUpdates();

            DelayAndHide(); // REMOVE THIS LINE WHEN USING UPDATER
        }

        private const string UpdateUrl = "https://api.github.com/repos/ggsplayz/EclipseUpdater/contents/EclipseUpdateInfo.json"; // Just an example! (1.0.0), create a fork or similar in your GitHub.
        private const string GithubToken = "Personal_access_token_here"; // Get a github token from https://github.com/settings/tokens (make sure to grant access to read private repos)

        private async void CheckForUpdates()
        {
            string currentVersion = "1.0.0"; // APP VERSION

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("EclipseLauncher", "1.0"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", GithubToken);

                    var response = await client.GetStringAsync(UpdateUrl);
                    var content = JsonConvert.DeserializeObject<GitHubFileContent>(response);
                    var updateInfo = JsonConvert.DeserializeObject<UpdateInfo[]>(Base64Decode(content.Content));

                    if (updateInfo != null && updateInfo.Length > 0)
                    {
                        var latestVersion = updateInfo[0].EclipseLauncher.LatestVersion;

                        if (IsNewerVersion(latestVersion, currentVersion))
                        {
                            MessageBox.Show($"There is a new version of Eclipse Launcher available, please go to the Discord Server and download the latest version.\n(Version {latestVersion})", "A new version is available!", MessageBoxButton.OK, MessageBoxImage.Information);
                            Environment.Exit(0 );
                        }
                        else
                        {
                            await DelayAndHide();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while checking for updates: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async Task DelayAndHide()
        {
            await Task.Delay(1000);
            this.Hide();
            MainLauncher main = new MainLauncher();
            main.Show();
        }

        private bool IsNewerVersion(string latestVersion, string currentVersion)
        {
            Version latest = new Version(latestVersion);
            Version current = new Version(currentVersion);

            return latest.CompareTo(current) > 0;
        }

        private string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }


        // Otras clases
        public class GitHubFileContent
        {
            public string Content { get; set; }
        }

        public class UpdateInfo
        {
            public EclipseLauncher EclipseLauncher { get; set; }
        }

        public class EclipseLauncher
        {
            public string LatestVersion { get; set; }
        }
    }
}
