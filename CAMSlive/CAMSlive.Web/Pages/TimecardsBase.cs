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
        [Inject]
        public IChartService ChartService { get; set; }
        public IEnumerable<Chart> TimecardCharts { get; set; }

        protected override void OnInitialized()
        {
            //base.OnInitialized();
        }

        protected override async Task OnInitializedAsync()
        {
            //LoadTimecardCharts();
            TimecardCharts = (await ChartService.GetCharts()).ToList();
            //return base.OnInitializedAsync();
        }

        //protected override async Task OnAfterRenderAsync(bool firstRender)
        //{
        //    if (TimecardCharts != null)
        //    {
        //        foreach (var chart in TimecardCharts)
        //        {
        //            var optionsToSend = new
        //            {
        //                series = new int[] { 44, 55, 13, 33 },
        //                chart = new { width = 380, type = "donut" },
        //                dataLabels = new { enabled = false },
        //                responsive = new object[] { new { breakpoint = 480, options = new { chart = new { width = 200 }, legend = new { show = false } } } },
        //                legend = new { position = "right", offsetY = 0, height = 230 }
        //            };

        //            await JSRuntime.InvokeVoidAsync("RenderChart", chart.ChartId, optionsToSend);
        //        }
        //    }

        //    await base.OnAfterRenderAsync(firstRender);
        //}

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (TimecardCharts != null)
            {
                foreach (var chart in TimecardCharts)
                {
                    await ChartService.RenderChart(chart);
                }
            }
            await base.OnAfterRenderAsync(firstRender);
        }
    }
}
