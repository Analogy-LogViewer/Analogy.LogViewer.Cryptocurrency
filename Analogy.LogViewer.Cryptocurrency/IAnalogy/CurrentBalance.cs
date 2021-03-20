using Analogy.Interfaces;
using Analogy.LogViewer.Cryptocurrency.Properties;
using System;
using System.Drawing;
using System.Threading.Tasks;

namespace Analogy.LogViewer.Cryptocurrency.IAnalogy
{
    public class CurrentBalance : Analogy.LogViewer.Template.OnlineDataProvider
    {
        public override Guid Id { get; set; } = new Guid("f5693263-0b41-4582-b841-71cb12f316e4");
        public override string OptionalTitle { get; set; } = "Current Balance";
        public override async Task<bool> CanStartReceiving() => await Task.FromResult(true);
        public override Image ConnectedLargeImage { get; set; } = Resources.GradientPurpleDataBar_32x32;
        public override Image ConnectedSmallImage { get; set; } = Resources.GradientPurpleDataBar_16x16;
        public override Image DisconnectedLargeImage { get; set; } = Resources.GradientPurpleDataBar_32x32;
        public override Image DisconnectedSmallImage { get; set; } = Resources.GradientPurpleDataBar_16x16;

        public override async Task InitializeDataProviderAsync(IAnalogyLogger logger)
        {
            await base.InitializeDataProviderAsync(logger);
            //httpClient = new HttpClient { BaseAddress = new Uri(UserSettingsManager.UserSettings.Settings.Address) };
            //httpClient.DefaultRequestHeaders.Add("User-Agent", "Analogy Affirmations");
            //httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //OnlineFetcher = new Timer(UserSettingsManager.UserSettings.Settings.CheckInterval);

            //OnlineFetcher.Elapsed += async (s, e) =>
            //{
            //    HttpResponseMessage response = await httpClient.GetAsync("/");
            //    response.EnsureSuccessStatusCode();
            //    var resp = await response.Content.ReadAsStringAsync();
            //    AffirmationData affirmation = JsonConvert.DeserializeObject<AffirmationData>(resp);
            //    AnalogyLogMessage m = new AnalogyInformationMessage(affirmation.affirmation, UserSettingsManager.UserSettings.Settings.Address);
            //    MessageReady(this, new AnalogyLogMessageArgs(m, Environment.MachineName, "Example", Id));
            //};

        }
        public override Task StartReceiving()
        {
            // OnlineFetcher?.Start();
            return Task.CompletedTask;
        }

        public override Task StopReceiving()
        {
            //OnlineFetcher?.Stop();
            return Task.CompletedTask;
        }

    }
}

