using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using Analogy.LogViewer.Cryptocurrency.Properties;
using Analogy.LogViewer.Template.Managers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;

namespace Analogy.LogViewer.Cryptocurrency.IAnalogy
{
    public class LocalBuyHistory : IAnalogySingleFileDataProvider
    {
        public bool DisableFilePoolingOption { get; } = true;
        public string FileNamePath { get; set; } = "AnalogyCryptoCurrencyLocalBuyHistory.json";

        public IEnumerable<string> HideColumns()
        {
            return new List<string>(0);
        }

        public Guid Id { get; set; } = new Guid("360b920c-9f1d-47c2-9515-580c9a23cdaa");
        public Image? LargeImage { get; set; } = Resources.Reading_32x32;
        public Image? SmallImage { get; set; } = Resources.Reading_16x16;
        public string OptionalTitle { get; set; } = " Local saved History";
        public bool UseCustomColors { get; set; } = false;
        public AnalogyToolTip? ToolTip { get; set; }

        public IEnumerable<(string originalHeader, string replacementHeader)> GetReplacementHeaders()
            => Array.Empty<(string, string)>();

        public (Color backgroundColor, Color foregroundColor) GetColorForMessage(IAnalogyLogMessage logMessage)
            => (Color.Empty, Color.Empty);

        public Task InitializeDataProviderAsync(IAnalogyLogger logger)
        {
            LogManager.Instance.SetLogger(logger);
            return Task.CompletedTask;
        }
        public void MessageOpened(AnalogyLogMessage message)
        {
            //nop
        }

        public async Task<IEnumerable<AnalogyLogMessage>> Process(CancellationToken token, ILogMessageCreatedHandler messagesHandler)
        {
            List<AnalogyLogMessage> history = new List<AnalogyLogMessage>(0);
            //EventViewerLogLoader logLoader = new EventViewerLogLoader(token);
            //var messages = await logLoader.ReadFromFile(FileNamePath, messagesHandler).ConfigureAwait(false);
            return history;
        }
    }
}
