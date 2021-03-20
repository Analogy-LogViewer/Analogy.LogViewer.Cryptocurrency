using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using Analogy.Interfaces.Factories;
using Analogy.LogViewer.Cryptocurrency.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Analogy.LogViewer.Cryptocurrency.IAnalogy
{
    public class DashboardsFactoryFactory : IAnalogyCustomActionsFactory
    {
        public Guid FactoryId { get; set; } = PrimaryFactory.Id;
        public string Title { get; set; } = "Dashboards";
        public IEnumerable<IAnalogyCustomAction> Actions { get; } = new List<IAnalogyCustomAction>
        {
            new Action1(),
        };

        private class Action1 : IAnalogyCustomAction
        {
            public Action Action { get; } = () =>
            {
                try
                {
                    //if (File.Exists(hostingEXE))
                    //{
                    //    Process.Start(hostingEXE);
                    //}
                }
                catch (Exception e)
                {
                    //LogManager.Instance.LogError($"Error starting {hostingEXE}: {e.Message}", nameof(Action1));
                }
            };

            public Guid Id { get; set; } = new Guid("469e1175-2b4f-4fcd-a29c-2014f4eaa09c");
            public Image SmallImage { get; set; } = Resources._3DLine_16x16;
            public Image LargeImage { get; set; } = Resources._3DLine_32x32;
            public string Title { get; set; } = "Real Time Trends";
            public AnalogyCustomActionType Type { get; } = AnalogyCustomActionType.BelongsToProvider;
            public AnalogyToolTip? ToolTip { get; set; }
        }
    }
}
