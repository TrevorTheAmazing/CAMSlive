#pragma checksum "C:\Users\Trevor\Desktop\fresh\CAMSlive\CAMSlive\CAMSlive\CAMSlive\CAMSlive\CAMSlive.Web\Pages\Index.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5641e631ecf0f38d32e1d2d20465dde8eb3618b8"
// <auto-generated/>
#pragma warning disable 1591
namespace CAMSlive.Web.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\Trevor\Desktop\fresh\CAMSlive\CAMSlive\CAMSlive\CAMSlive\CAMSlive\CAMSlive.Web\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Trevor\Desktop\fresh\CAMSlive\CAMSlive\CAMSlive\CAMSlive\CAMSlive\CAMSlive.Web\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Trevor\Desktop\fresh\CAMSlive\CAMSlive\CAMSlive\CAMSlive\CAMSlive\CAMSlive.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Trevor\Desktop\fresh\CAMSlive\CAMSlive\CAMSlive\CAMSlive\CAMSlive\CAMSlive.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Trevor\Desktop\fresh\CAMSlive\CAMSlive\CAMSlive\CAMSlive\CAMSlive\CAMSlive.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Trevor\Desktop\fresh\CAMSlive\CAMSlive\CAMSlive\CAMSlive\CAMSlive\CAMSlive.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Trevor\Desktop\fresh\CAMSlive\CAMSlive\CAMSlive\CAMSlive\CAMSlive\CAMSlive.Web\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Trevor\Desktop\fresh\CAMSlive\CAMSlive\CAMSlive\CAMSlive\CAMSlive\CAMSlive.Web\_Imports.razor"
using CAMSlive.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Trevor\Desktop\fresh\CAMSlive\CAMSlive\CAMSlive\CAMSlive\CAMSlive\CAMSlive.Web\_Imports.razor"
using CAMSlive.Web.Shared;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Index : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, @"<div class=""banner"">


        <div class=""clouds"">
            <img src=""../images/cloud1.png"" style=""--i:1;"">
            <img src=""../images/cloud2.png"" style=""--i:2;"">
            <img src=""../images/cloud3.png"" style=""--i:3;"">
            <img src=""../images/cloud4.png"" style=""--i:4;"">
            <img src=""../images/cloud5.png"" style=""--i:5;"">
        </div>
    </div>");
        }
        #pragma warning restore 1998
#nullable restore
#line 19 "C:\Users\Trevor\Desktop\fresh\CAMSlive\CAMSlive\CAMSlive\CAMSlive\CAMSlive\CAMSlive.Web\Pages\Index.razor"

    private void HandleClick()
    {
        NavigationManager.NavigateTo("timecards", true);
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
    }
}
#pragma warning restore 1591
