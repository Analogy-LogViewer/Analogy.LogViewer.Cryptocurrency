using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analogy.LogViewer.Cryptocurrency.IAnalogy
{
    public class LastDayPlotting : IAnalogyPlotting
    {
        public event EventHandler<AnalogyPlottingPointData> OnNewPointData;
        public Guid Id { get; set; } = new Guid("a8b4be6d-2cff-48ac-90f6-477d36271e84");
        public Guid FactoryId { get; set; } = PrimaryFactory.Id;
        public string Title { get; set; } = "24 hours Data";
        int counter = 0;

        private Timer OnlineFetcher { get; set; }
        private HttpClient httpClient { get; set; }
        private DataEntry[]? LastData { get; set; }
        private List<string> Names { get; set; }

        public async Task InitializePlottingAsync(IAnalogyLogger logger)
        {
            Names = new List<string>()
            {
                "ETHBTC",
            };
            httpClient = new HttpClient { BaseAddress = new Uri("https://api.binance.com") };
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Analogy.LogViewer.Cryptocurrency");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            LastData = await GetData();
            OnlineFetcher = new Timer();
            OnlineFetcher.Interval = 5000;
            OnlineFetcher.Tick += GetData_Tick;
            OnlineFetcher.Enabled = false;
        }


        private async Task<DataEntry[]> GetData()
        {
            HttpResponseMessage response = await httpClient.GetAsync("/api/v3/ticker/24hr");
            response.EnsureSuccessStatusCode();
            var resp = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<DataEntry[]>(resp);
            return data;
        }
        public Task StartPlotting()
        {
            OnlineFetcher.Enabled = true;
            return Task.CompletedTask;
        }
        public Task StopPlotting()
        {
            OnlineFetcher.Enabled = false;
            return Task.CompletedTask;
        }

        public IEnumerable<(string SeriesName, AnalogyPlottingSeriesType SeriesViewType)> GetChartSeries()
        {

            if (LastData != null)
                foreach (var data in LastData.Take(10))
                {
                    yield return (data.symbol, AnalogyPlottingSeriesType.Line);
                }
        }

        private async void GetData_Tick(object sender, EventArgs e)
        {
            var now = DateTime.Now;
            LastData = await GetData();
            foreach (var data in LastData.Take(10))
            {
                AnalogyPlottingPointData d1 = new AnalogyPlottingPointData(data.symbol, double.Parse(data.priceChangePercent), now);
                OnNewPointData?.Invoke(this, d1);
            }
            counter++;
        }
    }
}