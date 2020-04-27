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
        //[Parameter]

        public event RecordChangeDelegate OnChartRecordChanged;// { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        protected override Task OnInitializedAsync()
        {
            this.ChartId = ChartId;
            this.ChartOptions = ChartOptions;

            this.TimecardRecChangeNotifyService.OnChartRecordChanged += this.ChangeChartRecord;
            return base.OnInitializedAsync();
        }

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
        }
        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            return base.OnAfterRenderAsync(firstRender);
        }

        public override Task SetParametersAsync(ParameterView parameters)
        {
            return base.SetParametersAsync(parameters);
        }
        protected override Task OnParametersSetAsync()
        {
            return base.OnParametersSetAsync();
        }

        public async void ChangeChartRecord(object sender, RecordChangeEventArgs args)
        {
            //var chartToUpdate = args.NewChart;
            //if (chartToUpdate != null)

            if (args.NewChart != null)
            {
                this.ChartOptions = args.NewChart.ChartOptions;
                await InvokeAsync(() =>
                    {
                        //ChartService.UpdateChart(chartToUpdate.ChartId, chartToUpdate, false);
                        ChartService.UpdateChart(this.ChartId, this.ChartOptions);
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
