#pragma checksum "D:\[OTUS, Алексей Ягур] Csh ASP.NET Core разработчик  [Части 1-4 из 5] (2021)\BookingCar\BookingCar.WebApp\Views\Account\Profile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3c278ec14d4b928165fb0d6751a1e120153cda41"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_Profile), @"mvc.1.0.view", @"/Views/Account/Profile.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3c278ec14d4b928165fb0d6751a1e120153cda41", @"/Views/Account/Profile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9a60ba005c1edde85ec99670f929b73a7d4a845b", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_Profile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BookingCar.Core.Domain.ViewModels.UserViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\[OTUS, Алексей Ягур] Csh ASP.NET Core разработчик  [Части 1-4 из 5] (2021)\BookingCar\BookingCar.WebApp\Views\Account\Profile.cshtml"
  
    Layout = "~/Views/Shared/_Master.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"alert alert-light\" role=\"alert\" style=\"margin-top: 100px\">\r\n    <h3>Личные данные</h3>\r\n    <hr />\r\n    <p>Имя: ");
#nullable restore
#line 10 "D:\[OTUS, Алексей Ягур] Csh ASP.NET Core разработчик  [Части 1-4 из 5] (2021)\BookingCar\BookingCar.WebApp\Views\Account\Profile.cshtml"
       Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    <p>Адрес почты: ");
#nullable restore
#line 11 "D:\[OTUS, Алексей Ягур] Csh ASP.NET Core разработчик  [Части 1-4 из 5] (2021)\BookingCar\BookingCar.WebApp\Views\Account\Profile.cshtml"
               Write(Model.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BookingCar.Core.Domain.ViewModels.UserViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591