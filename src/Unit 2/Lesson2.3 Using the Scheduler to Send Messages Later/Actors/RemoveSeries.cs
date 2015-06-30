using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChartApp.Actors
{
    public partial class ChartingActor : ReceiveActor
    {
        /// <summary>
        /// Remove an existing <see cref="Series"/> from the chart
        /// </summary>
        public class RemoveSeries
        {
            public RemoveSeries(string seriesName)
            {
                SeriesName = seriesName;
            }

            public string SeriesName { get; private set; }
        }
    }
}
