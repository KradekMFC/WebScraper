using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using HtmlAgilityPack;

namespace WebScraper
{
    //SecureWebPage
    //Use this when you page you want to scrape is behind a login.
    //Call the page with the login's url and the parameters the login uses.
    //Most sites will then send you an authenticated cookie.  SecureWebPage
    //stores the cookie and sends it back with each subsequent using Load,
    //which allows you to load the pages as an authenicated user.
    public class SecureWebPage : IPage
    {
        private CookieAwareWebClient _client;

        public SecureWebPage(String loginUrl, NameValueCollection loginParameters)
            : this(loginUrl, loginParameters, new WebHeaderCollection { { "Content-Type", "application/x-www-form-urlencoded" } })
        {
        }

        public SecureWebPage(String loginUrl, NameValueCollection loginParameters, WebHeaderCollection headers)
        {
            _client = new CookieAwareWebClient();

            //perform the login so our webclient is authenticated
            ServicePointManager.Expect100Continue = false;
            _client.Headers = headers;
            _client.UploadValues(loginUrl, loginParameters);
        }

        //return a url as an HtmlDocument
        public HtmlDocument Load(String url)
        {
            var doc = new HtmlDocument();
            doc.Load(new MemoryStream(_client.DownloadData(url)));
            return doc;
        }
    }
}
