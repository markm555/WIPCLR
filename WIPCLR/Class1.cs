using System;
using System.IO;
using System.Net;
using System.Data;
using Microsoft.SqlServer.Server;
using System.Data.SqlTypes;
using System.Text.RegularExpressions;

namespace WIPCLR
{
    public static class CLRGETIP
    {

        [Microsoft.SqlServer.Server.SqlFunction]
        public static SqlString IP()
        {
            //  Create a Regex that accepts all URLs containing the host fragment www.contoso.com.
            Regex myRegex = new Regex(@"http://api\.whatismyip\.com/.*");

            // Create a WebPermission that gives permissions to all the hosts containing the same host fragment.
            WebPermission myWebPermission = new WebPermission(NetworkAccess.Connect, myRegex);

            //Add connect privileges for a www.adventure-works.com.
            myWebPermission.AddPermission(NetworkAccess.Connect, "http://api.whatsmyip.com");

            // Check whether all callers higher in the call stack have been granted the permission.
            myWebPermission.Demand();
            // Create a request for the URL.

            string apikey;
            apikey = "<YourKeyHere>";
            WebRequest request = WebRequest.Create(
              "https://api.whatismyip.com/ip.php?key=" + apikey);
            request.Credentials = CredentialCache.DefaultCredentials;

            WebResponse response = request.GetResponse();

            using (Stream dataStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(dataStream);
                    string responseFromServer = reader.ReadToEnd();
                    return responseFromServer;
                }
        }
    }
}



    

