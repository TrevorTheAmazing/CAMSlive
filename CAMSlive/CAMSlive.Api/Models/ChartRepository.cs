using CAMSlive.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAMSlive.Api.Models
{
    public class ChartRepository : IChartRepository
    {
        private readonly AppDbContext appDbContext;
        public ChartRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<IEnumerable<Chart>> GetCharts()
        {
            return await appDbContext.TimecardCharts.ToListAsync();
        }

        public async Task<Chart> GetChart(string chartId)
        {
            return await appDbContext.TimecardCharts.FirstOrDefaultAsync(c => c.ChartId == chartId);
        }

        public async Task<Chart> UpdateChart(Chart chart)
        {
            //throw new NotImplementedException();
            var result = await appDbContext.TimecardCharts
                    .FirstOrDefaultAsync(c => c.ChartId == chart.ChartId);
            if (result != null)
            {
                result.ChartId = chart.ChartId;
                result.ChartOptions = chart.ChartOptions;

                await appDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public Task<Chart> AddChart(Chart chart)
        {
            throw new NotImplementedException();
        }

        public void DeleteChart(string chartId)
        {
            throw new NotImplementedException();
        }
    }
}
