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
        [Parameter]
        public ElementReference ChartRef { get; set; }

        public event RecordChangeDelegate OnChartRecordChanged;// { get; set; }
        //[Parameter]
        //public EventCallback<Task> OnChangeChartRecord { get; set; }//OnChangeChartRecord

        public async override Task SetParametersAsync(ParameterView parameters)
        {//1,
            //this.ChartId = ChartId;
            //this.ChartOptions = ChartOptions;
            //return base.SetParametersAsync(parameters);
            await base.SetParametersAsync(parameters);//!//
        }

        protected override void OnInitialized()
        {//2,
            base.OnInitialized();
        }

        protected override Task OnInitializedAsync()
        {//3,
            //this.ChartId = ChartId;
            //this.ChartOptions = ChartOptions;

            this.TimecardRecChangeNotifyService.OnChartRecordChanged += this.ChangeChartRecord;
            //OnChartRecordChanged = this.ChangeChartRecord;
            return base.OnInitializedAsync();
        }

        protected override Task OnParametersSetAsync()
        {//4,
            return base.OnParametersSetAsync();
        }

        protected override void OnAfterRender(bool firstRender)
        {//5,
            base.OnAfterRender(firstRender);
        }
        protected override Task OnAfterRenderAsync(bool firstRender)
        {//6, MAKE THE CALL TO CHARTSERVICE HERE!
            if (!firstRender)
            {
                StateHasChanged();
            }
            return base.OnAfterRenderAsync(firstRender);
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
                        ChartService.UpdateChart(this.ChartId, this.ChartOptions);
                        //ChartService.UpdateChart(this.ChartId, this.ChartOptions);
                        //this.StateHasChanged();
                        StateHasChanged();
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
