#pragma checksum "D:\[OTUS, Алексей Ягур] Csh ASP.NET Core разработчик  [Части 1-4 из 5] (2021)\BookingCar\BookingCar.WebApp\Views\Account\AllUsers.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "90ae882b628507d19587c467ba6605c34fd50d44"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_AllUsers), @"mvc.1.0.view", @"/Views/Account/AllUsers.cshtml")]
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
#line 1 "D:\[OTUS, Алексей Ягур] Csh ASP.NET Core разработчик  [Части 1-4 из 5] (2021)\BookingCar\BookingCar.WebApp\Views\_ViewImports.cshtml"
using BookingCar.WebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\[OTUS, Алексей Ягур] Csh ASP.NET Core разработчик  [Части 1-4 из 5] (2021)\BookingCar\BookingCar.WebApp\Views\_ViewImports.cshtml"
using BookingCar.WebApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"90ae882b628507d19587c467ba6605c34fd50d44", @"/Views/Account/AllUsers.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9a60ba005c1edde85ec99670f929b73a7d4a845b", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_AllUsers : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<BookingCar.Core.Domain.Employee.User>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\[OTUS, Алексей Ягур] Csh ASP.NET Core разработчик  [Части 1-4 из 5] (2021)\BookingCar\BookingCar.WebApp\Views\Account\AllUsers.cshtml"
  
    Layout = "~/Views/Shared/_Master.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<table class=""table table-hover"" style=""margin-top:35px"">
  <thead class=""thead-light"">
     <tr>
      <th scope=""col"">#</th>
      <th scope=""col"">id</th>
      <th scope=""col"">Имя</th>
      <th scope=""col"">Адрес почты</th>
    </tr>
  </thead>
  
  <tbody>
");
#nullable restore
#line 17 "D:\[OTUS, Алексей Ягур] Csh ASP.NET Core разработчик  [Части 1-4 из 5] (2021)\BookingCar\BookingCar.WebApp\Views\Account\AllUsers.cshtml"
         for(int i = 0; i< @Model.Count(); i ++)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <th scope=\"row\">");
#nullable restore
#line 20 "D:\[OTUS, Алексей Ягур] Csh ASP.NET Core разработчик  [Части 1-4 из 5] (2021)\BookingCar\BookingCar.WebApp\Views\Account\AllUsers.cshtml"
                           Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <td>");
#nullable restore
#line 21 "D:\[OTUS, Алексей Ягур] Csh ASP.NET Core разработчик  [Части 1-4 из 5] (2021)\BookingCar\BookingCar.WebApp\Views\Account\AllUsers.cshtml"
               Write(Model[i].Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 22 "D:\[OTUS, Алексей Ягур] Csh ASP.NET Core разработчик  [Части 1-4 из 5] (2021)\BookingCar\BookingCar.WebApp\Views\Account\AllUsers.cshtml"
               Write(Model[i].Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 23 "D:\[OTUS, Алексей Ягур] Csh ASP.NET Core разработчик  [Части 1-4 из 5] (2021)\BookingCar\BookingCar.WebApp\Views\Account\AllUsers.cshtml"
               Write(Model[i].Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 25 "D:\[OTUS, Алексей Ягур] Csh ASP.NET Core разработчик  [Части 1-4 из 5] (2021)\BookingCar\BookingCar.WebApp\Views\Account\AllUsers.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("  </tbody>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<BookingCar.Core.Domain.Employee.User>> Html { get; private set; }
    }
}
#pragma warning restore 1591
