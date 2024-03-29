#pragma checksum "C:\Users\User\Downloads\apbd\tutorial-12-s20873\MovieApp\MovieApp\Client\Shared\IndividualMovie.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5fc5295850f3d18b05128acfb99c13c554a7f729"
// <auto-generated/>
#pragma warning disable 1591
namespace MovieApp.Client.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\User\Downloads\apbd\tutorial-12-s20873\MovieApp\MovieApp\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\Downloads\apbd\tutorial-12-s20873\MovieApp\MovieApp\Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\User\Downloads\apbd\tutorial-12-s20873\MovieApp\MovieApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\User\Downloads\apbd\tutorial-12-s20873\MovieApp\MovieApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\User\Downloads\apbd\tutorial-12-s20873\MovieApp\MovieApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\User\Downloads\apbd\tutorial-12-s20873\MovieApp\MovieApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\User\Downloads\apbd\tutorial-12-s20873\MovieApp\MovieApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\User\Downloads\apbd\tutorial-12-s20873\MovieApp\MovieApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\User\Downloads\apbd\tutorial-12-s20873\MovieApp\MovieApp\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\User\Downloads\apbd\tutorial-12-s20873\MovieApp\MovieApp\Client\_Imports.razor"
using MovieApp.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\User\Downloads\apbd\tutorial-12-s20873\MovieApp\MovieApp\Client\_Imports.razor"
using MovieApp.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\User\Downloads\apbd\tutorial-12-s20873\MovieApp\MovieApp\Client\_Imports.razor"
using MovieApp.Shared.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\User\Downloads\apbd\tutorial-12-s20873\MovieApp\MovieApp\Client\_Imports.razor"
using MovieApp.Client.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\User\Downloads\apbd\tutorial-12-s20873\MovieApp\MovieApp\Client\_Imports.razor"
using BlazorMovies.Client.Repository;

#line default
#line hidden
#nullable disable
    public partial class IndividualMovie : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "individual-movie-container");
            __builder.OpenElement(2, "a");
            __builder.AddAttribute(3, "href", 
#nullable restore
#line 2 "C:\Users\User\Downloads\apbd\tutorial-12-s20873\MovieApp\MovieApp\Client\Shared\IndividualMovie.razor"
             movieURL

#line default
#line hidden
#nullable disable
            );
            __builder.OpenElement(4, "img");
            __builder.AddAttribute(5, "src", 
#nullable restore
#line 3 "C:\Users\User\Downloads\apbd\tutorial-12-s20873\MovieApp\MovieApp\Client\Shared\IndividualMovie.razor"
                   Movie.Poster

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(6, "alt", "Poster");
            __builder.AddAttribute(7, "class", "movie-poster");
            __builder.AddAttribute(8, "style", "width:200px");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(9, "\r\n    ");
            __builder.OpenElement(10, "p");
            __builder.OpenElement(11, "a");
            __builder.AddAttribute(12, "href", 
#nullable restore
#line 5 "C:\Users\User\Downloads\apbd\tutorial-12-s20873\MovieApp\MovieApp\Client\Shared\IndividualMovie.razor"
                movieURL

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(13, 
#nullable restore
#line 5 "C:\Users\User\Downloads\apbd\tutorial-12-s20873\MovieApp\MovieApp\Client\Shared\IndividualMovie.razor"
                          Movie.TitleBrief

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(14, "\r\n    ");
            __builder.OpenElement(15, "div");
            __builder.OpenElement(16, "a");
            __builder.AddAttribute(17, "class", "btn btn-info");
            __builder.AddAttribute(18, "href", "/movies/edit/" + (
#nullable restore
#line 7 "C:\Users\User\Downloads\apbd\tutorial-12-s20873\MovieApp\MovieApp\Client\Shared\IndividualMovie.razor"
                                                    Movie.Id

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(19, "Edit");
            __builder.CloseElement();
            __builder.AddMarkupContent(20, "\r\n        ");
            __builder.OpenElement(21, "button");
            __builder.AddAttribute(22, "type", "button");
            __builder.AddAttribute(23, "class", "btn btn-danger");
            __builder.AddAttribute(24, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 9 "C:\Users\User\Downloads\apbd\tutorial-12-s20873\MovieApp\MovieApp\Client\Shared\IndividualMovie.razor"
                            () => DeleteMovie.InvokeAsync(Movie)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(25, "\r\n            Delete\r\n        ");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 16 "C:\Users\User\Downloads\apbd\tutorial-12-s20873\MovieApp\MovieApp\Client\Shared\IndividualMovie.razor"
       
    [Parameter] public Movie Movie { get; set; }
    [Parameter] public EventCallback<Movie> DeleteMovie { get; set; }
    private string movieURL = string.Empty;

    protected override void OnInitialized()
    {
        movieURL = $"movie/{Movie.Id}";
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
