using System;
using System.Linq;
using System.Xml.Linq;

// 6.Write a program to extracts all song titles from catalog.xml, using XDocument and LINQ query.
class ExtractSongTitlesLINQ
{
    static void Main()
    {
        var doc = XDocument.Load("../../../catalogue.xml");
        var result = doc.Descendants("song").Select(s => s.Value);
        foreach (var item in result)
        {
            Console.WriteLine("Song: {0}", item);
        }
    }
}