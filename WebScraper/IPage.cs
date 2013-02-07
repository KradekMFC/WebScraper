using System;
using HtmlAgilityPack;

namespace WebScraper
{
    interface IPage
    {
        HtmlDocument Load(String url);
    }
}
