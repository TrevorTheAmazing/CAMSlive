using CAMSlive.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAMSlive.Web.Shared
{

    public class ChartBase : ComponentBase
    {
        [Inject]
        public IJSRuntime JSRuntime { get; set; }
        [Inject]
        public IChartService ChartService { get; set; }
        [Parameter]
        public string ChartId { get; set; }
        [Parameter]
        public string ChartOptions { get; set; }

        protected override void OnInitialized()
        {
            //base.OnInitialized();
        }

        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }

        protected override void OnParametersSet()
        {
            //timecardRecordChangeService.OnChartRecordChanged += ChartHasChanged;
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

        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            StateHasChanged();
            return base.OnAfterRenderAsync(firstRender);
        }
    }
}
