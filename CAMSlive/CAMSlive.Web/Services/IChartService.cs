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
        //Task<Chart> UpdateChart(string chartId, Chart chartToUpdate, bool firstRender);
        //Task UpdateChart(string chartId, Chart chartToUpdate);
        //Task RenderChart(Chart chart);
        //Task RenderChart(string chartId, string chartOptions);
        Task RenderChart(string chartId, Chart chartToUpdate, bool firstRender);
        //Task UpdateOptions(Chart chart);
        //Task UpdateOptions(string chartId, string chartOptions);
    }
}
