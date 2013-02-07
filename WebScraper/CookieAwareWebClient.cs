using System;
using System.Net;

namespace WebScraper
{
    //Lifted straight from http://couldbedone.blogspot.com/2007/08/webclient-handling-cookies.html    
    public class CookieAwareWebClient : WebClient
    {
        private CookieContainer m_container = new CookieContainer();

        protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest request = base.GetWebRequest(address);
            if (request is HttpWebRequest)
            {
                (request as HttpWebRequest).CookieContainer = m_container;
            }
            return request;
        }
    }
}
