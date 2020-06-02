using CAMSlive.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CAMSlive.Web.Shared
{

    public class ChartBase : ComponentBase, IRecordChangeNotificationService, IDisposable
    //public class ChartBase : ComponentBase
    {
        public event RecordChangeDelegate OnChartRecordChanged;

        //member variables       
        [Parameter] public string ChartId { get; set; }
        [Parameter] public string ChartOptions { get; set; }
        [Parameter] public string ChartTitle { get; set; }
        [Parameter] public string NotificationStyle { get; set; }
        [Inject] private IRecordChangeNotificationService TimecardRecChangeNotifyService { get; set; }
        private string Coordinates { get; set; }


        //lifecycle methods
        protected override void OnInitialized()
        {
            this.NotificationStyle = "display: none;";
            this.TimecardRecChangeNotifyService.OnChartRecordChanged += this.SetNotification;
            base.OnInitialized();
        }
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
            StateHasChanged();            
            return base.OnAfterRenderAsync(firstRender);
        }

        protected override Task OnParametersSetAsync()
        {
            this.StateHasChanged();   
            return base.OnParametersSetAsync();
        }

        public async void ClearNotificationOnHover(EventArgs e)
        {
            if (NotificationStyle != "display: none;")
            {
                NotificationStyle = "display: none;";
                StateHasChanged();
            }
        }

        protected void Explode(MouseEventArgs e)
        {
            Coordinates = $"X = {e.ClientX} Y = {e.ClientY}";
        }

        //member methods
        public async void SetNotification(object sender, RecordChangeEventArgs args)
        {
            if (args.NewChart.ChartId == this.ChartId)
            {
                this.NotificationStyle = "display: inline-flex;";   
            }
        }

        public void Dispose()
        {
            this.TimecardRecChangeNotifyService.OnChartRecordChanged -= this.SetNotification;
            //this.TimecardRecChangeNotifyService.Dispose();
        }
    }
}
