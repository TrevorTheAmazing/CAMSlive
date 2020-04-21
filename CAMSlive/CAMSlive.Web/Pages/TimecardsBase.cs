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
    public class TimecardsBase : ComponentBase, IDisposable, IRecordChangeNotificationService
    {
        [Inject]
        public IChartService ChartService { get; set; }
        [Inject]
        private IRecordChangeNotificationService TimecardRecChangeNotifyService { get; set; }
        public IEnumerable<Chart> TimecardCharts { get; set; }

        public event RecordChangeDelegate OnChartRecordChanged;


        protected override void OnInitialized()
        {
            this.TimecardRecChangeNotifyService.OnChartRecordChanged += this.ChartRecordChanged;
            //base.OnInitialized();
        }

        protected override async Task OnInitializedAsync()
        {
            //LoadTimecardCharts();
            TimecardCharts = (await ChartService.GetCharts()).ToList();
            //return base.OnInitializedAsync();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (TimecardCharts != null)
            {
                foreach (var chart in TimecardCharts)
                {
                    await ChartService.RenderChart(chart);
                }
            }
        }

        public async void ChartRecordChanged(object sender, RecordChangeEventArgs args)
        {
            TimecardCharts = (await ChartService.GetCharts());
            var tempChart = TimecardCharts.FirstOrDefault(c => c.ChartId == args.NewChart.ChartId);
            if (tempChart != null)
            {
                var chartToUpdate = (await ChartService.GetChart(tempChart.ChartId));
                
                //DO I ALREADY HAVE NEW VALUES HERE?
                //chartToUpdate.ChartOptions = args.NewChart.ChartOptions;
                
                //ChartService.UpdateChart(chartToUpdate.ChartId, chartToUpdate);

                await InvokeAsync(() =>
                {
                    ChartService.UpdateChart(chartToUpdate.ChartId, chartToUpdate);
                    //    //this.OnChartUpdated(chartToUpdate);
                    //    //ChartService.UpdateChart(chartToUpdate.ChartId, chartToUpdate);
                    //    JSRuntime.InvokeVoidAsync("UpdateChart", chartToUpdate.ChartId, chartToUpdate.ChartOptions);
                    //    //OnChartUpdated(chartToUpdate);
                    //    //JSRuntime.InvokeVoidAsync("UpdateChart", chartToUpdate.ChartId, chartToUpdate.ChartOptions);                        
                    //base.StateHasChanged();

                    //base.StateHasChanged();
                });
                //StateHasChanged();

            }
        }

        public void Dispose()
        {
            this.TimecardRecChangeNotifyService.OnChartRecordChanged -= this.ChartRecordChanged;
            Dispose();
        }
    }
}
