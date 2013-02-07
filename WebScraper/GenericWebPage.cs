using System;
using HtmlAgilityPack;

namespace WebScraper
{
    //Generic page loader
    //Use when the page you want is publicly available
    public class GenericWebPage : IPage
    {
        public HtmlDocument Load(String url)
        {
            return new HtmlWeb().Load(url);
        }
    }
}
