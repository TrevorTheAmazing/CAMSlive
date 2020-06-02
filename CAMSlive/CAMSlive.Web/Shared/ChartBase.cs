using CAMSlive.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CAMSlive.Web.Shared
{

    public class ChartBase : ComponentBase
    {
        //member variables       
        [Parameter] public string ChartId { get; set; }
        [Parameter] public string ChartOptions { get; set; }
        [Parameter] public string ChartTitle { get; set; }

        //lifecycle methods
        protected override Task OnInitializedAsync()
        {
            if (ChartOptions != null)
            {
                using (JsonDocument document = JsonDocument.Parse(ChartOptions))
                {
                    JsonElement root = document.RootElement;

                    this.ChartTitle = root.GetProperty("noData").GetProperty("text").ToString();
                }
            }
            

            return base.OnInitializedAsync();
        }

        protected override Task OnAfterRenderAsync(bool firstRender)
        {          
            return base.OnAfterRenderAsync(firstRender);
        }

        //member methods

    }
}
