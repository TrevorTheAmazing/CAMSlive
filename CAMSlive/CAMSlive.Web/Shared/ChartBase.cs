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
        public RenderFragment ChildContent { get; set; }
        //[Parameter]
        //public EventCallback<RecordChangeDelegate> OnChartRecordChanged { get; set; }
        public event RecordChangeDelegate OnChartRecordChanged;// { get; set; }

        //public Chart chartToUpdate { get; set; } = new Chart();


        protected override void OnInitialized()
        {
            //this.ChartId = ChartId;
            //this.ChartOptions = ChartOptions;
            //base.OnInitialized();
        }

        protected override Task OnInitializedAsync()
        {
            //this.ChartId = ChartId;
            //this.ChartOptions = ChartOptions;

            this.TimecardRecChangeNotifyService.OnChartRecordChanged += this.ChangeChartRecord;
            return base.OnInitializedAsync();
        }

        //public async EventCallback<RecordChangeDelegate> ChartRecordHasChanged(object sender, RecordChangeEventArgs args)
        public async void ChangeChartRecord(object sender, RecordChangeEventArgs args)
        {
            //TimecardCharts = (await ChartService.GetCharts());
            //var chartToUpdate = TimecardCharts.FirstOrDefault(c => c.ChartId == args.NewChart.ChartId);
            var chartToUpdate = args.NewChart;
            if (chartToUpdate != null)
            {

                await InvokeAsync(() =>
                    {
                        //ChartService.UpdateChart(chartToUpdate.ChartId, chartToUpdate.ChartOptions);

                        ChartService.RenderChart(chartToUpdate.ChartId, chartToUpdate, false);
                        StateHasChanged();
                    });
            }
        }

        public void Dispose()
        {
            this.TimecardRecChangeNotifyService.OnChartRecordChanged -= this.ChangeChartRecord;
            Dispose();
        }

        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            //StateHasChanged();
            //chartToUpdate.ChartId = ChartId;
            //chartToUpdate.ChartOptions = ChartOptions;
            //ChartService.RenderChart(ChartId, firstRender);

            return base.OnAfterRenderAsync(firstRender);
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
        }

        protected override Task OnParametersSetAsync()
        {
            return base.OnParametersSetAsync();
        }

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
        }
    }
}
