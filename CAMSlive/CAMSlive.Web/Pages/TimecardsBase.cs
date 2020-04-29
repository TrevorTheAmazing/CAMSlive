using CAMSlive.Models;
using CAMSlive.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CAMSlive.Web.Pages
{
    public class TimecardsBase : ComponentBase
    {
        //member variables
        [Inject]
        public IChartService ChartService { get; set; }
        public IEnumerable<Chart> TimecardCharts { get; set; }
        
        //lifecycle methods
        protected override async Task OnInitializedAsync()
        {
            TimecardCharts = (await ChartService.GetCharts()).ToList();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (TimecardCharts != null)
            {
                foreach (var chart in TimecardCharts)
                {
                    await ChartService.RenderChart(chart.ChartId, chart, true);
                }                
            }
        }
    }
}
