using CAMSlive.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAMSlive.Api.Models
{
    public interface IChartRepository
    {
        //dont mess
        Task<IEnumerable<Chart>> GetCharts();
        Task<Chart> GetChart(string chartId);
        Task<Chart> AddChart(Chart chart);
        Task<Chart> UpdateChart(Chart chart);
        void DeleteChart(string chartId);

    }
}
