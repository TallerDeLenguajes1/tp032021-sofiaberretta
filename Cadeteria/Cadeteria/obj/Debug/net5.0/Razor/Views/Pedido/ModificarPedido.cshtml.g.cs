#pragma checksum "C:\Users\Alumno\Desktop\tp032021-sofiaberretta\Cadeteria\Cadeteria\Views\Pedido\ModificarPedido.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2dcbada1d8a0d0ab881d6f0bbedd52a4f4299453"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Pedido_ModificarPedido), @"mvc.1.0.view", @"/Views/Pedido/ModificarPedido.cshtml")]
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
#line 1 "C:\Users\Alumno\Desktop\tp032021-sofiaberretta\Cadeteria\Cadeteria\Views\_ViewImports.cshtml"
using Cadeteria;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Alumno\Desktop\tp032021-sofiaberretta\Cadeteria\Cadeteria\Views\_ViewImports.cshtml"
using Cadeteria.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2dcbada1d8a0d0ab881d6f0bbedd52a4f4299453", @"/Views/Pedido/ModificarPedido.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"24a6f75a6dcf0b59f6785fd49281fd35a55eca0a", @"/Views/_ViewImports.cshtml")]
    public class Views_Pedido_ModificarPedido : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Pedidos>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Pedido", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "cambiarDatosPedido", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("row g-3"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Alumno\Desktop\tp032021-sofiaberretta\Cadeteria\Cadeteria\Views\Pedido\ModificarPedido.cshtml"
  
    ViewData["Title"] = "Modificar Pedido";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h1 class=\"display-4\">Modificar datos del Pedido ");
#nullable restore
#line 7 "C:\Users\Alumno\Desktop\tp032021-sofiaberretta\Cadeteria\Cadeteria\Views\Pedido\ModificarPedido.cshtml"
                                                Write(Model.NumeroPedido);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2dcbada1d8a0d0ab881d6f0bbedd52a4f42994535321", async() => {
                WriteLiteral("\r\n        <input type=\"hidden\" class=\"form-control\" id=\"numPedido\" name=\"numPedido\"");
                BeginWriteAttribute("value", " value=\"", 355, "\"", 382, 1);
#nullable restore
#line 9 "C:\Users\Alumno\Desktop\tp032021-sofiaberretta\Cadeteria\Cadeteria\Views\Pedido\ModificarPedido.cshtml"
WriteAttributeValue("", 363, Model.NumeroPedido, 363, 19, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" required>\r\n        <div class=\"col-12\">\r\n            <label for=\"obs\" class=\"form-label\">Observaciones</label>\r\n            <input type=\"text\" class=\"form-control\" id=\"obs\" name=\"obs\"");
                BeginWriteAttribute("value", " value=\"", 567, "\"", 595, 1);
#nullable restore
#line 12 "C:\Users\Alumno\Desktop\tp032021-sofiaberretta\Cadeteria\Cadeteria\Views\Pedido\ModificarPedido.cshtml"
WriteAttributeValue("", 575, Model.Observaciones, 575, 20, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" required>\r\n        </div>\r\n        <div class=\"col-md-6\">\r\n            <label for=\"nombre\" class=\"form-label\">Nombre cliente</label>\r\n            <input type=\"text\" class=\"form-control\" id=\"nombre\" name=\"nombreC\"");
                BeginWriteAttribute("value", " value=\"", 809, "\"", 838, 1);
#nullable restore
#line 16 "C:\Users\Alumno\Desktop\tp032021-sofiaberretta\Cadeteria\Cadeteria\Views\Pedido\ModificarPedido.cshtml"
WriteAttributeValue("", 817, Model.Cliente.Nombre, 817, 21, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" required>\r\n        </div>\r\n        <div class=\"col-md-6\">\r\n            <label for=\"id\" class=\"form-label\">DNI/CUIT cliente</label>\r\n            <input type=\"text\" class=\"form-control\" id=\"id\" name=\"idC\"");
                BeginWriteAttribute("value", " value=\"", 1042, "\"", 1067, 1);
#nullable restore
#line 20 "C:\Users\Alumno\Desktop\tp032021-sofiaberretta\Cadeteria\Cadeteria\Views\Pedido\ModificarPedido.cshtml"
WriteAttributeValue("", 1050, Model.Cliente.Id, 1050, 17, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" required>\r\n        </div>\r\n        <div class=\"col-md-6\">\r\n            <label for=\"direc\" class=\"form-label\">Direccion cliente</label>\r\n            <input type=\"text\" class=\"form-control\" id=\"direc\" name=\"direcC\"");
                BeginWriteAttribute("value", " value=\"", 1281, "\"", 1313, 1);
#nullable restore
#line 24 "C:\Users\Alumno\Desktop\tp032021-sofiaberretta\Cadeteria\Cadeteria\Views\Pedido\ModificarPedido.cshtml"
WriteAttributeValue("", 1289, Model.Cliente.Direccion, 1289, 24, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" required>\r\n        </div>\r\n        <div class=\"col-md-6\">\r\n            <label for=\"tel\" class=\"form-label\">Telefono cliente</label>\r\n            <input type=\"text\" class=\"form-control\" id=\"tel\" name=\"telC\" placeholder=\"+54 381-5123123\"");
                BeginWriteAttribute("value", " value=\"", 1550, "\"", 1581, 1);
#nullable restore
#line 28 "C:\Users\Alumno\Desktop\tp032021-sofiaberretta\Cadeteria\Cadeteria\Views\Pedido\ModificarPedido.cshtml"
WriteAttributeValue("", 1558, Model.Cliente.Telefono, 1558, 23, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" required>\r\n        </div>\r\n        <div class=\"col-md-4\">\r\n            <label for=\"estado\" class=\"form-label\">Estado pedido</label>\r\n            <select id=\"estado\" name=\"estado\" class=\"form-select\">\r\n");
#nullable restore
#line 33 "C:\Users\Alumno\Desktop\tp032021-sofiaberretta\Cadeteria\Cadeteria\Views\Pedido\ModificarPedido.cshtml"
                 if (Model.Estado == "Pendiente")
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2dcbada1d8a0d0ab881d6f0bbedd52a4f42994539799", async() => {
                    WriteLiteral("Pendiente");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2dcbada1d8a0d0ab881d6f0bbedd52a4f429945311159", async() => {
                    WriteLiteral("Entregado");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 37 "C:\Users\Alumno\Desktop\tp032021-sofiaberretta\Cadeteria\Cadeteria\Views\Pedido\ModificarPedido.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2dcbada1d8a0d0ab881d6f0bbedd52a4f429945312476", async() => {
                    WriteLiteral("Pendiente");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2dcbada1d8a0d0ab881d6f0bbedd52a4f429945313514", async() => {
                    WriteLiteral("Entregado");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 42 "C:\Users\Alumno\Desktop\tp032021-sofiaberretta\Cadeteria\Cadeteria\Views\Pedido\ModificarPedido.cshtml"
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("            </select>\r\n        </div>\r\n        <div class=\"col-12\">\r\n            <button type=\"submit\" class=\"btn btn-success\">Modificar</button>\r\n        </div>\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Pedidos> Html { get; private set; }
    }
}
#pragma warning restore 1591
