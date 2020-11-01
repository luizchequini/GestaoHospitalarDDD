using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Web_GestaoHospitalar.Extentions.TagHelpers
{
    public class EmailTagHelper : TagHelper
    {
        public string Dominio { get; set; } = "chequini.com.br";
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            var prefixo = await output.GetChildContentAsync();
            var meuemail = prefixo.GetContent() + "@" + Dominio;
            output.Attributes.SetAttribute("href", "mailto:" + meuemail);
            output.Content.SetContent(meuemail);
        }
    }
}
