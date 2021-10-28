using System;

namespace HtmlParser.Interfaces
{
    //Service to be registered
    public interface IUtils
    {
        Uri GetAbsoluteUri(Uri uri);
        string SetAbsoluteImagePath(string imageTag, Uri baseUri);
    }
}