using Analogy.Interfaces;
using System;
using System.Collections.Generic;

namespace Analogy.LogViewer.Cryptocurrency.IAnalogy
{
    public class DataProvidersFactory : LogViewer.Template.DataProvidersFactory
    {
        public override Guid FactoryId { get; set; } = PrimaryFactory.Id;
        public override string Title { get; set; } = "CryptoCurrency for Analogy Log Viewer";
        public override IEnumerable<IAnalogyDataProvider> DataProviders { get; set; } = new List<IAnalogyDataProvider> { new OnlineDataProvider() };
    }
}
