// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace StudentsApp.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\User\Downloads\apbd\StudentsApp\StudentsApp\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\Downloads\apbd\StudentsApp\StudentsApp\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\User\Downloads\apbd\StudentsApp\StudentsApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\User\Downloads\apbd\StudentsApp\StudentsApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\User\Downloads\apbd\StudentsApp\StudentsApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\User\Downloads\apbd\StudentsApp\StudentsApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\User\Downloads\apbd\StudentsApp\StudentsApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\User\Downloads\apbd\StudentsApp\StudentsApp\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\User\Downloads\apbd\StudentsApp\StudentsApp\_Imports.razor"
using StudentsApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\User\Downloads\apbd\StudentsApp\StudentsApp\_Imports.razor"
using StudentsApp.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\User\Downloads\apbd\StudentsApp\StudentsApp\_Imports.razor"
using StudentsApp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\User\Downloads\apbd\StudentsApp\StudentsApp\_Imports.razor"
using StudentsApp.Service;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/students")]
    public partial class Students : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 41 "C:\Users\User\Downloads\apbd\StudentsApp\StudentsApp\Pages\Students.razor"
 
    private StudentsDb _students;
    protected override void OnInitialized()
    {
        _students = new StudentsDb();
    }

    private void SortStudents(string collumnName)
    {
        _students.SortStudents(collumnName);
    }

    private async Task Delete(int id)
    {
        var confirmed = await js.InvokeAsync<bool>("confirm", "Do you want to delete a student?");
        _students.DeleteStudent(id, confirmed);
    }

    private void NavigateToDetails(int id)
    {
        NavigationManager.NavigateTo($"students/details/{id}");
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime js { get; set; }
    }
}
#pragma warning restore 1591