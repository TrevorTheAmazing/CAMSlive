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
        private IJSRuntime JSRuntime { get; }

        public ChartService(HttpClient httpClient, IJSRuntime jsRuntime)
        {
            this.httpClient = httpClient;
            this.JSRuntime = jsRuntime;
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
                //await JSRuntime.InvokeVoidAsync("RenderChart", chart.ChartId, chart.ChartOptions);
                await JSRuntime.InvokeVoidAsync("RenderChart", chart.ChartId, chart.ChartOptions);
            }
        }

        public async Task UpdateOptions(Chart chart)
        {
            if (chart != null)
            {
                //HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
                //httpRequestMessage.Method = new HttpMethod("GET");
                //httpRequestMessage.RequestUri = new Uri("https://localhost:44341/api/timecards");
                //httpRequestMessage.Content = new StringContent(JsonSerializer.Serialize(chart.ChartOptions));
                //httpRequestMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                //var response = await httpClient.SendAsync(httpRequestMessage);

                //var responseStatusCode = response.StatusCode;
                //var responseBody = await response.Content.ReadAsStringAsync();

                //if (responseStatusCode.ToString() == "OK")
                //{
                //    await JSRuntime.InvokeAsync<Task>("UpdateOptions", chart.ChartId, chart.ChartOptions);
                //}

                
                //var tempOptions = JsonSerializer.Serialize(chart.ChartOptions);
                //await JSRuntime.InvokeVoidAsync("UpdateChart", chart.ChartId, tempOptions);
            }            
        }
    }
}
