using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Conesoft.Website.CDN.TagHelpers;

[HtmlTargetElement("conesoft-html", Attributes = "title, madeby, url")]
public class HtmlHeadTagHelper : TagHelper
{
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        var name = context.AllAttributes.TryGetAttribute("name", out var v0) ? $"{v0.Value}" : "";
        var madeby = context.AllAttributes.TryGetAttribute("madeby", out var v1) ? $"{v1.Value}" : "";
        var url = context.AllAttributes.TryGetAttribute("url", out var v2) ? $"{v2.Value}" : "";
        var title = context.AllAttributes.TryGetAttribute("title", out var v3) ? $"{v3.Value}" : $"{name} by {madeby}";

        var content = (await output.GetChildContentAsync()).GetContent();

        output.TagName = "html";

        output.Attributes.Clear();

        output.Attributes.Add("lang", "en");

        output.Content.Clear();
        output.Content.AppendHtml(HtmlCode(name, title, content));

        SiteWebManifest(name, title, url);

        await base.ProcessAsync(context, output);
    }

    static void SiteWebManifest(string name, string title, string url)
    {
        File.WriteAllText("wwwroot/site.webmanifest", $@"
{{
  ""name"": ""{title}"",
  ""short_name"": ""{name}"",
  ""icons"": [
    {{
      ""src"": ""/site/icons/android-chrome-192x192.png"",
      ""sizes"": ""192x192"",
      ""type"": ""image/png""
    }},
    {{
      ""src"": ""/site/icons/android-chrome-256x256.png"",
      ""sizes"": ""256x256"",
      ""type"": ""image/png""
    }}
  ],
  ""theme_color"": ""#000000"",
  ""background_color"": ""#000000"",
  ""start_url"": ""{url}"",
  ""display"": ""standalone"",
  ""url_handlers"": [
    {{
      ""origin"": ""{url}""
    }}
  ]
}}
");
    }

    static string HtmlCode(string name, string title, string content) => $@"
<head prefix=""og: http://ogp.me/ns#"">
    <meta charset=""utf-8"">

    <link rel=""apple-touch-icon"" sizes=""180x180"" href=""/site/icons/apple-touch-icon.png"">
    <link rel=""icon"" type=""image/png"" sizes=""32x32"" href=""/site/icons/favicon-32x32.png"">
    <link rel=""icon"" type=""image/png"" sizes=""16x16"" href=""/site/icons/favicon-16x16.png"">
    <link rel=""manifest"" href=""/site.webmanifest"">
    <link rel=""shortcut icon"" href=""/site/icons/favicon.ico"">
    <meta name=""apple-mobile-web-app-title"" content=""{title}"">
    <meta name=""application-name"" content=""{title}"">
    <meta name=""theme-color"" content=""#000000"">

    <title>{title}</title>

    <meta name=""description"" content=""{title}"">
    <meta property=""og:type"" content=""website"">
    <meta property=""og:title"" content=""{name}"">
    <meta property=""og:description"" content=""{title}"">
    <meta property=""og:image"" content=""/meta-image.jpg"">

    <meta name=""viewport"" content=""width=device-width"">
    <base href=""~/"">
    <link rel=""stylesheet"" type=""text/css"" href=""/style.min.css?v={Helpers.CalculateMD5("wwwroot/style.min.css")}"">
</head>
<body>
    <header>
        <nav>
            <a class=""active"" aria-current=""page"">⌂</a>
            <a href=""/"">{title}</a>
        </nav>
    </header>
{content}
</body>
";
}