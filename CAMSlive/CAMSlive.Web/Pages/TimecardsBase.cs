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
        [Inject]
        public IChartService ChartService { get; set; }
        [Inject]
        private IRecordChangeNotificationService TimecardRecChangeNotifyService { get; set; }
        public IEnumerable<Chart> TimecardCharts { get; set; }
        public event RecordChangeDelegate OnChartRecordChanged;// { get; set; }


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

        public async void ChangeChartRecord(object sender, RecordChangeEventArgs args)
        {
            //var chartToUpdate = args.NewChart;
            //if (chartToUpdate != null)

            if (args.NewChart != null)
            {
                await InvokeAsync(() =>
                {
                    OnChartRecordChanged(sender, args);
                    base.StateHasChanged();
                });
            }
        }

        public void Dispose()
        {
            this.TimecardRecChangeNotifyService.OnChartRecordChanged -= this.ChangeChartRecord;
            Dispose();
        }

    }
}
