using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

// 3.Implement the previous task using XPath.
class ExtractWithXPath
{
    private static string filePath = "../../../catalogue.xml";

    static void Main()
    {
        XmlDocument document = new XmlDocument();
        document.Load(filePath);

        string XPathQuery = "catalogue/album/artist";

        XmlNodeList artistNames = document.SelectNodes(XPathQuery);

        var result = artistNames.OfType<XmlElement>().GroupBy(e => e.InnerText).ToDictionary(gr => gr.Key, gr => gr.Count());

        foreach (var res in result)
        {
            Console.WriteLine("{0} - {1} albums.", res.Key, res.Value);
        }
    }
}