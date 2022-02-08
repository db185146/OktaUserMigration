using System.IO;
using System.Net;

namespace OktaUserMig
{
    class OktaInterface
    {
        private static string Workspace = "ncrcmcguinea-admin.okta.com/";

        public static string CreateUser(string userJson)
        {
            return SendRequest(userJson, $"https://{Workspace}/api/v1/users?activate=true");
        }

        public static string AuthenticateUser(string userJson)
        {
            return SendRequest(userJson, $"https://{Workspace}/api/v1/authn");
        }

        private static string SendRequest(string userJson, string requestUriString)
        {
            var request = (HttpWebRequest)WebRequest.Create(requestUriString);
            request.Method = "POST";
            request.Accept = "application/json";
            request.ContentType = "application/json";
            request.Headers.Add("Authorization", "SSWS 00Jj03FldOKLZpwm4Lf-uhUoejZRqsBFqsfzTMCULa");
            request.ContentLength = userJson.Length;
            using (var writer = new StreamWriter(request.GetRequestStream()))
            {
                writer.Write(userJson);
            }

            var response = request.GetResponse();
            var result = ReadResponse(response);
            return result;
        }

        private static string ReadResponse(WebResponse response)
        {
            string result;

            if (response == null)
            {
                return string.Empty;
            }

            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }
    }
}
