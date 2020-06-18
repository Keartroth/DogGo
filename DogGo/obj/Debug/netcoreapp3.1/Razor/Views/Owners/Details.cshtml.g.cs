#pragma checksum "C:\Users\mecar\workspace\server side\Book Two\DogGo\Doggo\Views\Owners\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ffac2d02bd514058da7f8bec3d083b1a2b967bad"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Owners_Details), @"mvc.1.0.view", @"/Views/Owners/Details.cshtml")]
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
#nullable restore
#line 1 "C:\Users\mecar\workspace\server side\Book Two\DogGo\Doggo\Views\_ViewImports.cshtml"
using DogGo;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\mecar\workspace\server side\Book Two\DogGo\Doggo\Views\_ViewImports.cshtml"
using DogGo.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ffac2d02bd514058da7f8bec3d083b1a2b967bad", @"/Views/Owners/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"12b50fd1f91f777ae09abf39d99992ea9d25da6c", @"/Views/_ViewImports.cshtml")]
    public class Views_Owners_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DogGo.Models.ViewModels.ProfileViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\mecar\workspace\server side\Book Two\DogGo\Doggo\Views\Owners\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div>\r\n    <h1 class=\"mb-4\">");
#nullable restore
#line 8 "C:\Users\mecar\workspace\server side\Book Two\DogGo\Doggo\Views\Owners\Details.cshtml"
                Write(Model.Owner.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h1>

    <section class=""container"">
        <img style=""width:100px;float:left;margin-right:20px""
             src=""https://upload.wikimedia.org/wikipedia/commons/a/a0/Font_Awesome_5_regular_user-circle.svg"" />
        <div>
            <label class=""font-weight-bold"">Address:</label>
            <span>");
#nullable restore
#line 15 "C:\Users\mecar\workspace\server side\Book Two\DogGo\Doggo\Views\Owners\Details.cshtml"
             Write(Model.Owner.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n        </div>\r\n        <div>\r\n            <label class=\"font-weight-bold\">Phone:</label>\r\n            <span>");
#nullable restore
#line 19 "C:\Users\mecar\workspace\server side\Book Two\DogGo\Doggo\Views\Owners\Details.cshtml"
             Write(Model.Owner.Phone);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n        </div>\r\n        <div>\r\n            <label class=\"font-weight-bold\">Email:</label>\r\n            <span>");
#nullable restore
#line 23 "C:\Users\mecar\workspace\server side\Book Two\DogGo\Doggo\Views\Owners\Details.cshtml"
             Write(Model.Owner.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n        </div>\r\n        <div>\r\n            ");
#nullable restore
#line 26 "C:\Users\mecar\workspace\server side\Book Two\DogGo\Doggo\Views\Owners\Details.cshtml"
       Write(Html.ActionLink("Edit", "Edit", new { id = Model.Owner.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </section>\r\n\r\n    <hr class=\"mt-5\" />\r\n    <div class=\"clearfix\"></div>\r\n\r\n    <div class=\"row\">\r\n        <section class=\"col-8 container mt-5\">\r\n            <h1 class=\"text-left\">Dogs</h1>\r\n\r\n            <div class=\"row\">\r\n");
#nullable restore
#line 38 "C:\Users\mecar\workspace\server side\Book Two\DogGo\Doggo\Views\Owners\Details.cshtml"
                 foreach (Dog dog in Model.Dogs)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"card m-4\" style=\"width: 18rem;\">\r\n");
#nullable restore
#line 41 "C:\Users\mecar\workspace\server side\Book Two\DogGo\Doggo\Views\Owners\Details.cshtml"
                         if (String.IsNullOrEmpty(dog.ImageUrl))
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <img src=\"https://cdn.pixabay.com/photo/2018/08/15/13/12/dog-3608037_960_720.jpg\"\r\n                                 class=\"card-img-top\"\r\n                                 alt=\"Doggo\" />\r\n");
#nullable restore
#line 46 "C:\Users\mecar\workspace\server side\Book Two\DogGo\Doggo\Views\Owners\Details.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <img");
            BeginWriteAttribute("src", " src=\"", 1665, "\"", 1684, 1);
#nullable restore
#line 49 "C:\Users\mecar\workspace\server side\Book Two\DogGo\Doggo\Views\Owners\Details.cshtml"
WriteAttributeValue("", 1671, dog.ImageUrl, 1671, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"card-img-top\" alt=\"Doggo\" />\r\n");
#nullable restore
#line 50 "C:\Users\mecar\workspace\server side\Book Two\DogGo\Doggo\Views\Owners\Details.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"card-body\">\r\n                            <div>\r\n                                <label class=\"font-weight-bold\">Name:</label>\r\n                                <span>");
#nullable restore
#line 54 "C:\Users\mecar\workspace\server side\Book Two\DogGo\Doggo\Views\Owners\Details.cshtml"
                                 Write(dog.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                            </div>\r\n                            <div>\r\n                                <label class=\"font-weight-bold\">Breed:</label>\r\n                                <span>");
#nullable restore
#line 58 "C:\Users\mecar\workspace\server side\Book Two\DogGo\Doggo\Views\Owners\Details.cshtml"
                                 Write(dog.Breed);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                            </div>\r\n                            <div>\r\n                                <label class=\"font-weight-bold\">Notes:</label>\r\n                                <p>");
#nullable restore
#line 62 "C:\Users\mecar\workspace\server side\Book Two\DogGo\Doggo\Views\Owners\Details.cshtml"
                              Write(dog.Notes);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 66 "C:\Users\mecar\workspace\server side\Book Two\DogGo\Doggo\Views\Owners\Details.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n        </section>\r\n\r\n        <section class=\"col-lg-4 col-md-8 container mt-5\">\r\n            <h1>Walkers Near Me</h1>\r\n\r\n            <ul class=\"list-group mt-4\">\r\n");
#nullable restore
#line 74 "C:\Users\mecar\workspace\server side\Book Two\DogGo\Doggo\Views\Owners\Details.cshtml"
                 foreach (Walker walker in Model.Walkers)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li class=\"list-group-item disabled\" aria-disabled=\"true\">\r\n                        <img");
            BeginWriteAttribute("src", " src=\"", 2864, "\"", 2886, 1);
#nullable restore
#line 77 "C:\Users\mecar\workspace\server side\Book Two\DogGo\Doggo\Views\Owners\Details.cshtml"
WriteAttributeValue("", 2870, walker.ImageUrl, 2870, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"width:50px\" />\r\n                        <span class=\"font-weight-bold ml-4\">");
#nullable restore
#line 78 "C:\Users\mecar\workspace\server side\Book Two\DogGo\Doggo\Views\Owners\Details.cshtml"
                                                       Write(walker.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                    </li>\r\n");
#nullable restore
#line 80 "C:\Users\mecar\workspace\server side\Book Two\DogGo\Doggo\Views\Owners\Details.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </ul>\r\n        </section>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DogGo.Models.ViewModels.ProfileViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
