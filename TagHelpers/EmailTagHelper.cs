using Microsoft.AspNetCore.Razor.TagHelpers;

namespace NorthwindWithPagingExample.TagHelpers;

// See here for more information:
// https://learn.microsoft.com/en-au/aspnet/core/mvc/views/tag-helpers/authoring?view=aspnetcore-10.0

public class EmailTagHelper : TagHelper
{
    // Version #1.
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "a"; // Replaces <email> with <a> tag
    }

    // Version #2.
    //private const string EmailDomain = "contoso.com";

    //// Can be passed via <email mail-to="..." />. 
    //// PascalCase gets translated into kebab-case.
    //public string MailTo { get; set; }

    //public override void Process(TagHelperContext context, TagHelperOutput output)
    //{
    //    output.TagName = "a"; // Replaces <email> with <a> tag
    //
    //    var address = MailTo + "@" + EmailDomain;
    //    output.Attributes.SetAttribute("href", "mailto:" + address);
    //    output.Content.SetContent(address);
    //}

    // Version #3.
    //private const string EmailDomain = "contoso.com";

    //public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    //{
    //    output.TagName = "a"; // Replaces <email> with <a> tag
    //
    //    var content = await output.GetChildContentAsync();
    //
    //    var target = content.GetContent() + "@" + EmailDomain;
    //    output.Attributes.SetAttribute("href", "mailto:" + target);
    //    output.Content.SetContent(target);
    //}
}
