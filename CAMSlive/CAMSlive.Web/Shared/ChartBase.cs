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
        //member variables       
        [Parameter] public string ChartId { get; set; }
        [Parameter] public string ChartOptions { get; set; }
        
        //lifecycle methods
        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }

        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            return base.OnAfterRenderAsync(firstRender);
        }

        //member methods

    }
}
