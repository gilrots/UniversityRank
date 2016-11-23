using LinkedInChecker.View;
using System;
using System.IO;
using System.Net;
using System.Web;

namespace LinkedInChecker.Analyze
{

    /// <summary>
    /// Talks with the spell checker api
    /// </summary>
    public  class SpellCheckerService
    {
        #region Const
        public const string SPELL_KEY = "4456fbbe43d0492aa6e51f11232c9ddf";

        #endregion

        #region Properties
        public int response_error;
        #endregion

        #region Methods
        /// <summary>
        /// Requests spell check on a text
        /// </summary>
        /// <param name="txt">Text to check</param>
        /// <returns>if the progress was succeed</returns>
        public bool MakeRequest(string txt)
        {

            var queryString = HttpUtility.ParseQueryString(string.Empty);
            
            // Request parameters
            queryString["text"] = txt;
            queryString["mode"] = "spell";
            queryString["mkt"] = "en-us";
            var uri = "https://api.cognitive.microsoft.com/bing/v5.0/spellcheck/?" + queryString;

        
            var mRequest = (HttpWebRequest)WebRequest.Create(uri);
            mRequest.Headers.Add("Ocp-Apim-Subscription-Key", SPELL_KEY);
            mRequest.Method = "GET";
            try
            {
                var response = mRequest.GetResponse();
                var sr = new StreamReader(response.GetResponseStream());
                var str = sr.ReadToEnd();
                response_error = str.Split(new string[] { "token" }, StringSplitOptions.None).Length - 1;
                return true;
            }
            catch (Exception e)
            {
                new ServiceException();
                return false;
            }

        }
        #endregion

    }
}
