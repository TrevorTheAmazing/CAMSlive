using CAMSlive.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAMSlive.Web.Services
{

    public delegate void RecordChangeDelegate(object sender, RecordChangeEventArgs args);
    public class RecordChangeEventArgs : EventArgs
    {
        public Chart NewChart { get; }
        public Chart OldChart { get; }
        public RecordChangeEventArgs(Chart newChart, Chart oldChart)
        {
            this.NewChart = newChart;
            this.OldChart = oldChart;
        }
    }
    public interface IRecordChangeNotificationService
    {
        public event RecordChangeDelegate OnChartRecordChanged;
    }

}
