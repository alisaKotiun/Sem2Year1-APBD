#pragma checksum "C:\Users\User\Downloads\apbd\StudentsApp\StudentsApp\Pages\StudentForm.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "39804a7dfa6b35c77eacb6d8880e72bccc790cc0"
// <auto-generated/>
#pragma warning disable 1591
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
    [Microsoft.AspNetCore.Components.RouteAttribute("/students/details/{StudentId:int}")]
    public partial class StudentForm : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h3>Student\'s details</h3>\r\n\r\n");
            __builder.OpenElement(1, "table");
            __builder.OpenElement(2, "tr");
            __builder.AddMarkupContent(3, "<td>First Name: </td>\r\n        ");
            __builder.OpenElement(4, "td");
            __builder.AddContent(5, 
#nullable restore
#line 9 "C:\Users\User\Downloads\apbd\StudentsApp\StudentsApp\Pages\StudentForm.razor"
             student.FirstName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(6, "\r\n        ");
            __builder.AddMarkupContent(7, "<td>Avatar: </td>\r\n        ");
            __builder.OpenElement(8, "td");
            __builder.AddContent(9, 
#nullable restore
#line 11 "C:\Users\User\Downloads\apbd\StudentsApp\StudentsApp\Pages\StudentForm.razor"
             student.Avatar

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(10, "\r\n    ");
            __builder.OpenElement(11, "tr");
            __builder.AddMarkupContent(12, "<td>Last Name: </td>\r\n        ");
            __builder.OpenElement(13, "td");
            __builder.AddContent(14, 
#nullable restore
#line 15 "C:\Users\User\Downloads\apbd\StudentsApp\StudentsApp\Pages\StudentForm.razor"
             student.LastName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(15, "\r\n        <td></td>\r\n        ");
            __builder.OpenElement(16, "td");
            __builder.AddAttribute(17, "rowspan", "3");
            __builder.AddAttribute(18, "valign", "middle");
            __builder.AddAttribute(19, "align", "center");
            __builder.OpenElement(20, "img");
            __builder.AddAttribute(21, "src", 
#nullable restore
#line 17 "C:\Users\User\Downloads\apbd\StudentsApp\StudentsApp\Pages\StudentForm.razor"
                                                                 student.Avatar

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(22, "alt", "Avatar");
            __builder.AddAttribute(23, "width", "100");
            __builder.AddAttribute(24, "height", "100");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(25, "\r\n    ");
            __builder.OpenElement(26, "tr");
            __builder.AddMarkupContent(27, "<td>BirthDate: </td>\r\n        ");
            __builder.OpenElement(28, "td");
            __builder.AddContent(29, 
#nullable restore
#line 21 "C:\Users\User\Downloads\apbd\StudentsApp\StudentsApp\Pages\StudentForm.razor"
             student.BirthDate

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(30, "\r\n    ");
            __builder.OpenElement(31, "tr");
            __builder.AddMarkupContent(32, "<td>Studies: </td>\r\n        ");
            __builder.OpenElement(33, "td");
            __builder.AddContent(34, 
#nullable restore
#line 25 "C:\Users\User\Downloads\apbd\StudentsApp\StudentsApp\Pages\StudentForm.razor"
             student.Studies

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(35, "\r\n    ");
            __builder.OpenElement(36, "tr");
            __builder.OpenElement(37, "td");
            __builder.AddMarkupContent(38, "<br>");
            __builder.OpenElement(39, "button");
            __builder.AddAttribute(40, "style", "color:white; background-color:blue");
            __builder.AddAttribute(41, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 28 "C:\Users\User\Downloads\apbd\StudentsApp\StudentsApp\Pages\StudentForm.razor"
                                                                               () => NavigateFromDetails()

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(42, "Return");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 32 "C:\Users\User\Downloads\apbd\StudentsApp\StudentsApp\Pages\StudentForm.razor"
       
    [Parameter] public int StudentId { get; set; }
    private Student student;

    protected override void OnInitialized()
    {
        student = new StudentsDb().GetStudent(StudentId);
    }

    private void NavigateFromDetails()
    {
        NavigationManager.NavigateTo("students");
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
    }
}
#pragma warning restore 1591
