using CAMSlive.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAMSlive.Web.Services
{
    public interface IChartService
    {
        Task <IEnumerable<Chart>> GetCharts();
        Task<Chart> GetChart(string id);
        //Task<Chart> UpdateChart(string chartId, Chart chartToUpdate);
        Task UpdateChart(string chartId, Chart chartToUpdate);
        Task RenderChart(Chart chart);
        Task UpdateOptions(Chart chart);
    }
}
