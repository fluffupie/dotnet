using Microsoft.AspNetCore.Razor.TagHelpers;

namespace NorthwindWithPagingExample.TagHelpers;

// Version #1.
[HtmlTargetElement(Attributes = "bold")]
// Version #2.
//[HtmlTargetElement("bold")]
//[HtmlTargetElement(Attributes = "bold")]
public class BoldTagHelper : TagHelper
{
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        // Version #2.
        //if(output.TagName == "bold")
        //{
        //    output.TagName = "strong";
        //    return;
        //}

        output.Attributes.RemoveAll("bold");
        output.PreContent.SetHtmlContent("<strong>");
        output.PostContent.SetHtmlContent("</strong>");
    }
}
