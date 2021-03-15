using Analogy.Interfaces;
using Analogy.LogViewer.Cryptocurrency.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Analogy.LogViewer.Cryptocurrency.IAnalogy
{
    public class PrimaryFactory : Analogy.LogViewer.Template.PrimaryFactory
    {
        internal static Guid Id { get; } = new Guid("e9792966-3791-49f3-9be2-522fe3852943");

        public override Guid FactoryId { get; set; } = Id;
        public override string Title { get; set; } = "CryptoCurrencies";
        public override IEnumerable<IAnalogyChangeLog> ChangeLog { get; set; } = ChangeLogList.GetChangeLog();
        public override IEnumerable<string> Contributors { get; set; } = new List<string> { "Lior Banai" };
        public override string About { get; set; } = "CryptoCurrencies app for Analogy Log Viewer";//override this
        public override Image SmallImage { get; set; } = Resources.crypto16x16;
        public override Image LargeImage { get; set; } = Resources.crypto32x32;


    }
}
