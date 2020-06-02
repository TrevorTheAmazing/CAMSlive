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
    public class TimecardsBase : ComponentBase, IRecordChangeNotificationService, IDisposable
    {
        public event RecordChangeDelegate OnChartRecordChanged;

        //member variables
        [Inject]public IChartService ChartService { get; set; }
        [Inject]private IRecordChangeNotificationService TimecardRecChangeNotifyService { get; set; }
        public IEnumerable<Chart> TimecardCharts { get; set; }
        private Chart chartToUpdate = new Chart();
        
        //lifecycle methods
        protected override async Task OnInitializedAsync()
        {
            this.TimecardRecChangeNotifyService.OnChartRecordChanged += this.ChangeChartRecord;
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

        //member methods
        public async void ChangeChartRecord(object sender, RecordChangeEventArgs args)
        {
            if (args.NewChart != null)
            {
                chartToUpdate = await ChartService.GetChart(args.NewChart.ChartId);
                chartToUpdate.ChartOptions = args.NewChart.ChartOptions;
                await InvokeAsync(() =>
                {
                    ChartService.UpdateChart(chartToUpdate.ChartId, chartToUpdate.ChartOptions);
                });
            }
        }

        public void Dispose()
        {
            this.TimecardRecChangeNotifyService.OnChartRecordChanged -= this.ChangeChartRecord;
            //this.TimecardRecChangeNotifyService.Dispose();
        }
    }
}
