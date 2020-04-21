using CAMSlive.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CAMSlive.Web.Services
{
    public class ChartService : IChartService
    {
        private HttpClient httpClient { get; }
        private IJSRuntime jsRuntime { get; }

        public ChartService(HttpClient httpClient, IJSRuntime jsRuntime)
        {
            this.httpClient = httpClient;
            this.jsRuntime = jsRuntime;
        }        

        public async Task<IEnumerable<Chart>> GetCharts()
        {
            return await httpClient.GetJsonAsync<Chart[]>("api/timecards");
            //throw new NotImplementedException();
        }

        public async Task<Chart> GetChart(string id)
        {
            //throw new NotImplementedException();
            return await httpClient.GetJsonAsync<Chart>($"api/timecards/{id}");
        }

        //public async Task<Chart> UpdateChart(string chartId, Chart chartToUpdate)
        public async Task UpdateChart(string chartId, Chart chartToUpdate)
        {
            //dont need to do this, already have the new values?
            //var result = await httpClient.GetJsonAsync<Chart>($"api/timecards/{chartId}");

            if (chartToUpdate != null)
            {
                //dont update the database... we are here because it has already been updated
                //await httpClient.PutJsonAsync<Chart>($"api/timecards/{result.ChartId}", result);//use chartId instead?
                await UpdateOptions(chartToUpdate);
                //return result;
            }

            //return null;
        }

        public async Task RenderChart(Chart chart)
        {
            if (chart != null)
            {
                await jsRuntime.InvokeVoidAsync("RenderChart", chart.ChartId, chart.ChartOptions);
            }
        }

        public async Task UpdateOptions(Chart chart)
        {
            if (chart != null)
            {
                //var tempOptions = JsonSerializer.Serialize(chart.ChartOptions);
    
                await jsRuntime.InvokeVoidAsync("UpdateOptions", chart.ChartId, chart.ChartOptions);
                //await jsRuntime.InvokeVoidAsync("UpdateChart", chart.ChartId, tempOptions);
            }

            
        }
    }
}
