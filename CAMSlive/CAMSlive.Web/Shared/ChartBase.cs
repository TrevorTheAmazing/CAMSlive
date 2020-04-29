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
        //member variables
        public event RecordChangeDelegate OnChartRecordChanged;
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
        
        //lifecycle methods
        protected override Task OnInitializedAsync()
        {
            this.TimecardRecChangeNotifyService.OnChartRecordChanged += this.ChangeChartRecord;
            return base.OnInitializedAsync();
        }

        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            if (!firstRender)
            {
                StateHasChanged();
            }
            return base.OnAfterRenderAsync(firstRender);
        }

        //member methods
        public async void ChangeChartRecord(object sender, RecordChangeEventArgs args)
        {
            if (args.NewChart != null)
            {
                this.ChartOptions = args.NewChart.ChartOptions;
                await InvokeAsync(() =>
                    {
                        ChartService.UpdateChart(this.ChartId, this.ChartOptions);
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
