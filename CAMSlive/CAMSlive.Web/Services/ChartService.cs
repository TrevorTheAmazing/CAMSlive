﻿using CAMSlive.Models;
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
        }

        public async Task<Chart> GetChart(string id)
        {
            return await httpClient.GetJsonAsync<Chart>($"api/timecards/{id}");
        }

        public async Task RenderChart(string chartId, Chart chartToRender, bool firstRender)
        {
            if (firstRender)
            {
                await JSRuntime.InvokeAsync<Task>("RenderChart", chartId, chartToRender.ChartOptions);
            }
            else
            {
                //await JSRuntime.InvokeAsync<Task>("RenderChart", chartId, chartToRender.ChartOptions);
                await JSRuntime.InvokeAsync<Task>("UpdateOptions", chartId, chartToRender.ChartOptions);
            }
        }

        public async Task UpdateChart(string chartId, string chartOptions)
        {
            await JSRuntime.InvokeAsync<Task>("UpdateOptions", chartId, chartOptions);
        }
    }
}
