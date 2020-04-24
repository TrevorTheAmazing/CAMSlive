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
        Task RenderChart(string chartId, Chart chartToUpdate, bool firstRender);        
    }
}
