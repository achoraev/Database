using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class EntryPoint
{
    private const string RssFeedUrl = @"http://forums.academy.telerik.com/feed/qa.rss";
    private const string RssFilePath = @"../../rss.xml";
    private const string JsonFilePath = @"../../rss.json";
    private const string HtmlFilePath = @"../../index.html";

    public static void Main()
    {
        // 2. Download the content of the feed programmatically
        // You can use WebClient.DownloadFile()
       
        Console.WriteLine("Downloading RSS...");
        using (var webClient = new WebClient())
        {
            webClient.DownloadFile(RssFeedUrl, RssFilePath);
        }

        // 3. Parse the XML from the feed to JSON
        var rssXML = XElement.Load(RssFilePath);
        string json = JsonConvert.SerializeXNode(rssXML, Newtonsoft.Json.Formatting.Indented);
        FileUtils.CreateFile(JsonFilePath, json);

        // 4. Using LINQ-to-JSON select all the question titles and print them to the console

        var jsonObj = JObject.Parse(json);
        var titles = jsonObj["rss"]["channel"]["item"].Select(i => i["title"]);
        Console.WriteLine(string.Join(Environment.NewLine, titles));

        // 5. Parse the JSON string to POCO
        var itemsJson = jsonObj["rss"]["channel"]["item"].ToString();
        var items = JsonConvert.DeserializeObject<Item[]>(itemsJson);

        // 6. Using the parsed objects create a HTML page that lists all questions from the RSS their categories and a link to the question's page

        CreateHtmlPage(items);
    }

    private static void CreateHtmlPage(IEnumerable<Item> items)
    {
        var htmlGenerator = new HtmlGenerator();
        string html = htmlGenerator.GenerateHtml(items);
        FileUtils.CreateFile(HtmlFilePath, html);

        Console.WriteLine("Html page saved to <{0}>", HtmlFilePath);
    }
}