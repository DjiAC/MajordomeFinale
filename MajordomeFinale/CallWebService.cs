using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MajordomeFinale
{
    public class CallWebService
    {      
        
        /// <summary>
        /// Calls the web servive of majordome and return its result
        /// </summary>
        /// <param name="login">User's login</param>
        /// <param name="password">User's password</param>
        /// <param name="method">Name of the web method to call</param>
        /// <param name="json">String formated json to send</param>
        public static async Task<string> CallWebServiceMajordome(string login, string password, string method, string json)
        {
            var jsonString = "";

            string url = "http://majordome.co.nf/";

            // Create the request
            var request = (HttpWebRequest)WebRequest.Create(new Uri(url + "?login=" + login + "&password=" + password + "&method=" + method + "&json=" + json));
            request.ContentType = "application/json";
            request.Method = "GET";



            // Send the request to the server and wait for the response:
            using (WebResponse response = await request.GetResponseAsync().ConfigureAwait(false))
            {
                // Get a stream representation of the HTTP web response:
                using (var stream = response.GetResponseStream())
                {
                    var sr = new StreamReader(stream);
                    jsonString = sr.ReadToEnd();
                }
            }
            return jsonString;
        }
    }
}
