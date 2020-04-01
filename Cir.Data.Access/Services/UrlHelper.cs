using System;
using System.Linq;
using System.Web;

namespace Cir.Data.Access.Services
{
    public class UrlHelper
    {
        private static UrlHelper _instance = null;
        private static readonly object padlock = new object();
        private readonly string _openAnchor = "{{";
        private readonly string _closeAnchor = "}}";
        private UrlHelper() { }

        public static UrlHelper Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (padlock)
                    {
                        _instance = new UrlHelper();
                        return _instance;
                    }
                }
                return _instance;
            }
        }

        public string ReplaceQueryStringAnchors(string url, dynamic dictionaryDataObject)
        {
            try
            {
                while (url.IndexOf(_openAnchor) != -1)
                {
                    var startIndex = url.IndexOf(_openAnchor);
                    var endIndex = url.IndexOf(_closeAnchor);
                    var parameterToReplace = url.Substring(startIndex + 2, endIndex - startIndex - 2);

                    lock (dictionaryDataObject)
                    {
                        var parameterValue = dictionaryDataObject[parameterToReplace] == null ? string.Empty : dictionaryDataObject[parameterToReplace].Value;
                        url = url.Replace(string.Concat(_openAnchor, parameterToReplace, _closeAnchor), Convert.ToString(parameterValue));
                    }
                }
            }
            catch(Exception e)
            {
                throw e;
            }
            return url;
        }
    }
}
