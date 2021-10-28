#pragma checksum "C:\Users\andre\OneDrive\Documentos\Projects\HtmlParser\Views\Parse\WordsParseResults.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "72ea836d7da2fd2361b450db04787477a0961b12"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Parse_WordsParseResults), @"mvc.1.0.view", @"/Views/Parse/WordsParseResults.cshtml")]
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
#line 1 "C:\Users\andre\OneDrive\Documentos\Projects\HtmlParser\Views\_ViewImports.cshtml"
using HtmlParser;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\andre\OneDrive\Documentos\Projects\HtmlParser\Views\_ViewImports.cshtml"
using HtmlParser.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"72ea836d7da2fd2361b450db04787477a0961b12", @"/Views/Parse/WordsParseResults.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"644277b321359abb245bafe791876daf7fabac40", @"/Views/_ViewImports.cshtml")]
    public class Views_Parse_WordsParseResults : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WordsParseResultsViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\andre\OneDrive\Documentos\Projects\HtmlParser\Views\Parse\WordsParseResults.cshtml"
  
    ViewBag.Title = "Words Parse Result";
    Layout = "~/Views/Shared/_Layout.cshtml";

    int i = 1;


#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<h5 style=""margin: 32px;text-align: center; font-size: 22px; font-weight: bold; "">Words' Ranking and Graph</h5>

<div class=""container-xl"" style=""display: grid; grid-template-columns: repeat(2,1fr);"">
    <table class=""table table-striped"">
        <thead>
            <tr>
                <th>
                    Position
                </th>
                <th>
                    Word
                </th>
                <th>
                    Quantity
                </th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 30 "C:\Users\andre\OneDrive\Documentos\Projects\HtmlParser\Views\Parse\WordsParseResults.cshtml"
             foreach (var item in Model.WordsRanking)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 34 "C:\Users\andre\OneDrive\Documentos\Projects\HtmlParser\Views\Parse\WordsParseResults.cshtml"
                   Write(Html.Raw(i++));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 37 "C:\Users\andre\OneDrive\Documentos\Projects\HtmlParser\Views\Parse\WordsParseResults.cshtml"
                   Write(Html.Raw(@item.Key));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 40 "C:\Users\andre\OneDrive\Documentos\Projects\HtmlParser\Views\Parse\WordsParseResults.cshtml"
                   Write(Html.Raw(@item.Value));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 43 "C:\Users\andre\OneDrive\Documentos\Projects\HtmlParser\Views\Parse\WordsParseResults.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n    <div id=\"chart\" style=\"min-height: 395px; background-color: #f2f2f2;border: solid; border-style: ridge; \"/>\r\n</div>\r\n\r\n");
#nullable restore
#line 49 "C:\Users\andre\OneDrive\Documentos\Projects\HtmlParser\Views\Parse\WordsParseResults.cshtml"
 if (ViewBag.JavaScriptFunction != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <script type=\"text/javascript\">\r\n           ");
#nullable restore
#line 52 "C:\Users\andre\OneDrive\Documentos\Projects\HtmlParser\Views\Parse\WordsParseResults.cshtml"
      Write(Html.Raw(ViewBag.JavaScriptFunction));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </script>\r\n");
#nullable restore
#line 54 "C:\Users\andre\OneDrive\Documentos\Projects\HtmlParser\Views\Parse\WordsParseResults.cshtml"
    
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WordsParseResultsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
