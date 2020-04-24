using CAMSlive.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAMSlive.Web.Shared
{

    public class ChartBase : ComponentBase, IRecordChangeNotificationService, IDisposable
    {
        [Inject]
        public IChartService ChartService { get; set; }
        [Inject]
        private IRecordChangeNotificationService TimecardRecChangeNotifyService { get; set; }
        [Parameter]
        public string ChartId { get; set; }
        [Parameter]
        public string ChartOptions { get; set; }
        [CascadingParameter]
        public RenderFragment ChildContent { get; set; }
        
        public event RecordChangeDelegate OnChartRecordChanged;// { get; set; }


        protected override Task OnInitializedAsync()
        {
            //this.ChartId = ChartId;
            //this.ChartOptions = ChartOptions;

            this.TimecardRecChangeNotifyService.OnChartRecordChanged += this.ChangeChartRecord;
            return base.OnInitializedAsync();
        }
        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            return base.OnAfterRenderAsync(firstRender);
        }

        public async void ChangeChartRecord(object sender, RecordChangeEventArgs args)
        {
            var chartToUpdate = args.NewChart;
            if (chartToUpdate != null)
            {
                await InvokeAsync(() =>
                    {
                        ChartService.RenderChart(chartToUpdate.ChartId, chartToUpdate, false);
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
