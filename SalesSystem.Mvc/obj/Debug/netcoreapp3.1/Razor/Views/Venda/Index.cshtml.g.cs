#pragma checksum "C:\Users\andrei\source\repos\MyProjects\SalesSystem\SalesSystem.Mvc\Views\Venda\Index.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "b049dabb45dd4adf8634ce11ea99bfeb65e85a1020eb710e72fb80c90986ccb4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Venda_Index), @"mvc.1.0.view", @"/Views/Venda/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\andrei\source\repos\MyProjects\SalesSystem\SalesSystem.Mvc\Views\_ViewImports.cshtml"
using SalesSystem.Mvc;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\andrei\source\repos\MyProjects\SalesSystem\SalesSystem.Mvc\Views\_ViewImports.cshtml"
using SalesSystem.Mvc.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"b049dabb45dd4adf8634ce11ea99bfeb65e85a1020eb710e72fb80c90986ccb4", @"/Views/Venda/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"598cf9611eedda94d5b1f1482ed233c6791fd3be427603611506e06366bff328", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Venda_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<SalesSystem.WebApi.Model.VendaModel>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("role", new global::Microsoft.AspNetCore.Html.HtmlString("button"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Venda", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\andrei\source\repos\MyProjects\SalesSystem\SalesSystem.Mvc\Views\Venda\Index.cshtml"
  
    ViewData["Title"] = "Vendas";

#line default
#line hidden
#nullable disable
            WriteLiteral("<meta charset=\"utf-8\" />\r\n\r\n<div class=\"cotainer\">\r\n    <div class=\"row justify-content-center\">\r\n        <div>\r\n            <div class=\"text-center\">\r\n\r\n                <div class=\"d-grid gap-2 d-md-flex justify-context-md-start\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b049dabb45dd4adf8634ce11ea99bfeb65e85a1020eb710e72fb80c90986ccb45812", async() => {
                WriteLiteral("Registrar venda");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n                <br />\r\n                <br />\r\n\r\n");
#nullable restore
#line 19 "C:\Users\andrei\source\repos\MyProjects\SalesSystem\SalesSystem.Mvc\Views\Venda\Index.cshtml"
                 if (TempData["MensagemSucesso"] != null)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"alert alert-success\" role=\"alert\">\r\n                        <button type=\"button\" class=\"btn btn-danger btn-sm close-alert\" arial-label=\"Close\">X</button>\r\n                        ");
#nullable restore
#line 23 "C:\Users\andrei\source\repos\MyProjects\SalesSystem\SalesSystem.Mvc\Views\Venda\Index.cshtml"
                   Write(TempData["MensagemSucesso"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n");
#nullable restore
#line 25 "C:\Users\andrei\source\repos\MyProjects\SalesSystem\SalesSystem.Mvc\Views\Venda\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                <h4 class=""display-4"">Lista de Vendas</h4>

                <table class=""table text-center"">
                    <thead>
                        <tr>
                            <th scope=""col"">Código</th>
                            <th scope=""col"">Produto</th>
                            <th scope=""col"">Cliente</th>
                            <th scope=""col"">Data Venda</th>
                            <th scope=""col"">Quantidade</th>
                            <th scope=""col"">Valor Total</th>
                            <th scope=""col"">Descrição</th>
                            <th scope=""col"">Desconto</th>
                        </tr>
                    </thead>
                    <tbody>

");
#nullable restore
#line 44 "C:\Users\andrei\source\repos\MyProjects\SalesSystem\SalesSystem.Mvc\Views\Venda\Index.cshtml"
                         if (Model != null && Model.Any())
                        {
                            foreach (var venda in Model)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <th scope=\"row\">");
#nullable restore
#line 49 "C:\Users\andrei\source\repos\MyProjects\SalesSystem\SalesSystem.Mvc\Views\Venda\Index.cshtml"
                                               Write(venda.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                    <td>");
#nullable restore
#line 50 "C:\Users\andrei\source\repos\MyProjects\SalesSystem\SalesSystem.Mvc\Views\Venda\Index.cshtml"
                                   Write(venda.Produto.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 51 "C:\Users\andrei\source\repos\MyProjects\SalesSystem\SalesSystem.Mvc\Views\Venda\Index.cshtml"
                                   Write(venda.Cliente.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 52 "C:\Users\andrei\source\repos\MyProjects\SalesSystem\SalesSystem.Mvc\Views\Venda\Index.cshtml"
                                   Write(venda.DataVenda.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 53 "C:\Users\andrei\source\repos\MyProjects\SalesSystem\SalesSystem.Mvc\Views\Venda\Index.cshtml"
                                   Write(venda.QuantidadeProduto);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>R$ ");
#nullable restore
#line 54 "C:\Users\andrei\source\repos\MyProjects\SalesSystem\SalesSystem.Mvc\Views\Venda\Index.cshtml"
                                      Write(venda.ValorTotal);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 55 "C:\Users\andrei\source\repos\MyProjects\SalesSystem\SalesSystem.Mvc\Views\Venda\Index.cshtml"
                                   Write(venda.Descricao);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 56 "C:\Users\andrei\source\repos\MyProjects\SalesSystem\SalesSystem.Mvc\Views\Venda\Index.cshtml"
                                     if (venda.Desconto != null)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <td>R$ ");
#nullable restore
#line 58 "C:\Users\andrei\source\repos\MyProjects\SalesSystem\SalesSystem.Mvc\Views\Venda\Index.cshtml"
                                          Write(venda.Desconto);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 59 "C:\Users\andrei\source\repos\MyProjects\SalesSystem\SalesSystem.Mvc\Views\Venda\Index.cshtml"
                                    }
                                    else
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <td></td>\r\n");
#nullable restore
#line 63 "C:\Users\andrei\source\repos\MyProjects\SalesSystem\SalesSystem.Mvc\Views\Venda\Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <td>\r\n                                        <div class=\"btn-group\" role=\"group\">\r\n                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b049dabb45dd4adf8634ce11ea99bfeb65e85a1020eb710e72fb80c90986ccb413358", async() => {
                WriteLiteral("Excluir");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 66 "C:\Users\andrei\source\repos\MyProjects\SalesSystem\SalesSystem.Mvc\Views\Venda\Index.cshtml"
                                                                                                                                 WriteLiteral(venda.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                        </div>\r\n                                    </td>\r\n                                </tr>\r\n");
#nullable restore
#line 70 "C:\Users\andrei\source\repos\MyProjects\SalesSystem\SalesSystem.Mvc\Views\Venda\Index.cshtml"
                            }
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </tbody>\r\n                </table>\r\n\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<SalesSystem.WebApi.Model.VendaModel>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
