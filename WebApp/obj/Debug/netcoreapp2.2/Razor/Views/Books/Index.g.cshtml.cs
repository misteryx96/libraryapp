#pragma checksum "C:\Users\Giomlly\source\repos\LibraryApp\WebApp\Views\Books\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "40430e5f6239e5168f3c93f0ca45a00e4f58ee6c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Books_Index), @"mvc.1.0.view", @"/Views/Books/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Books/Index.cshtml", typeof(AspNetCore.Views_Books_Index))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\Giomlly\source\repos\LibraryApp\WebApp\Views\_ViewImports.cshtml"
using WebApp;

#line default
#line hidden
#line 2 "C:\Users\Giomlly\source\repos\LibraryApp\WebApp\Views\_ViewImports.cshtml"
using WebApp.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"40430e5f6239e5168f3c93f0ca45a00e4f58ee6c", @"/Views/Books/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fc48f17eb9bac3476d8060730298bf398eb2fa5e", @"/Views/_ViewImports.cshtml")]
    public class Views_Books_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Application.DTO.BookDto>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(45, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Giomlly\source\repos\LibraryApp\WebApp\Views\Books\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(135, 29, true);
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n<p>\r\n    ");
            EndContext();
            BeginContext(164, 37, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "40430e5f6239e5168f3c93f0ca45a00e4f58ee6c3815", async() => {
                BeginContext(187, 10, true);
                WriteLiteral("Create New");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(201, 92, true);
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(294, 38, false);
#line 17 "C:\Users\Giomlly\source\repos\LibraryApp\WebApp\Views\Books\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
            EndContext();
            BeginContext(332, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(388, 41, false);
#line 20 "C:\Users\Giomlly\source\repos\LibraryApp\WebApp\Views\Books\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Title));

#line default
#line hidden
            EndContext();
            BeginContext(429, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(485, 42, false);
#line 23 "C:\Users\Giomlly\source\repos\LibraryApp\WebApp\Views\Books\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Writer));

#line default
#line hidden
            EndContext();
            BeginContext(527, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(583, 46, false);
#line 26 "C:\Users\Giomlly\source\repos\LibraryApp\WebApp\Views\Books\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.BookGenres));

#line default
#line hidden
            EndContext();
            BeginContext(629, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(685, 47, false);
#line 29 "C:\Users\Giomlly\source\repos\LibraryApp\WebApp\Views\Books\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Description));

#line default
#line hidden
            EndContext();
            BeginContext(732, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(788, 50, false);
#line 32 "C:\Users\Giomlly\source\repos\LibraryApp\WebApp\Views\Books\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.AvailableCount));

#line default
#line hidden
            EndContext();
            BeginContext(838, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(894, 41, false);
#line 35 "C:\Users\Giomlly\source\repos\LibraryApp\WebApp\Views\Books\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Count));

#line default
#line hidden
            EndContext();
            BeginContext(935, 86, true);
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 41 "C:\Users\Giomlly\source\repos\LibraryApp\WebApp\Views\Books\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
            BeginContext(1053, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1102, 37, false);
#line 44 "C:\Users\Giomlly\source\repos\LibraryApp\WebApp\Views\Books\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Id));

#line default
#line hidden
            EndContext();
            BeginContext(1139, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1195, 40, false);
#line 47 "C:\Users\Giomlly\source\repos\LibraryApp\WebApp\Views\Books\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Title));

#line default
#line hidden
            EndContext();
            BeginContext(1235, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1291, 41, false);
#line 50 "C:\Users\Giomlly\source\repos\LibraryApp\WebApp\Views\Books\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Writer));

#line default
#line hidden
            EndContext();
            BeginContext(1332, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1388, 45, false);
#line 53 "C:\Users\Giomlly\source\repos\LibraryApp\WebApp\Views\Books\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.BookGenres));

#line default
#line hidden
            EndContext();
            BeginContext(1433, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1489, 46, false);
#line 56 "C:\Users\Giomlly\source\repos\LibraryApp\WebApp\Views\Books\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Description));

#line default
#line hidden
            EndContext();
            BeginContext(1535, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1591, 49, false);
#line 59 "C:\Users\Giomlly\source\repos\LibraryApp\WebApp\Views\Books\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.AvailableCount));

#line default
#line hidden
            EndContext();
            BeginContext(1640, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1696, 40, false);
#line 62 "C:\Users\Giomlly\source\repos\LibraryApp\WebApp\Views\Books\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Count));

#line default
#line hidden
            EndContext();
            BeginContext(1736, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1792, 53, false);
#line 65 "C:\Users\Giomlly\source\repos\LibraryApp\WebApp\Views\Books\Index.cshtml"
           Write(Html.ActionLink("Edit", "Edit", new {  id=item.Id  }));

#line default
#line hidden
            EndContext();
            BeginContext(1845, 20, true);
            WriteLiteral(" |\r\n                ");
            EndContext();
            BeginContext(1866, 59, false);
#line 66 "C:\Users\Giomlly\source\repos\LibraryApp\WebApp\Views\Books\Index.cshtml"
           Write(Html.ActionLink("Details", "Details", new {  id=item.Id  }));

#line default
#line hidden
            EndContext();
            BeginContext(1925, 20, true);
            WriteLiteral(" |\r\n                ");
            EndContext();
            BeginContext(1946, 56, false);
#line 67 "C:\Users\Giomlly\source\repos\LibraryApp\WebApp\Views\Books\Index.cshtml"
           Write(Html.ActionLink("Delete", "Delete", new { id=item.Id  }));

#line default
#line hidden
            EndContext();
            BeginContext(2002, 36, true);
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 70 "C:\Users\Giomlly\source\repos\LibraryApp\WebApp\Views\Books\Index.cshtml"
}

#line default
#line hidden
            BeginContext(2041, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Application.DTO.BookDto>> Html { get; private set; }
    }
}
#pragma warning restore 1591
