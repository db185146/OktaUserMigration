using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using OktaUserMig.Users;

namespace OktaUserMig
{
    class Program
    {
        [JsonProperty("profile")]
        private static User User;

        static void Main(string[] args)
        {
            var maxUniqueId = DataAccess.GetHighestUniqueUserId();
            var user = DataAccess.LoadUserInfo("1");

            User = new User(user);
            var serializeObject = JsonConvert.SerializeObject(User);

            var request = (HttpWebRequest)WebRequest.Create(@"https://ncrcmcguinea-admin.okta.com//api/v1/users?activate=false");
            request.Method = "POST";
            request.Accept = "application/json";
            request.ContentType = "application/json";
            request.Headers.Add("Authorization", "SSWS 00Jj03FldOKLZpwm4Lf-uhUoejZRqsBFqsfzTMCULa");
            request.ContentLength = serializeObject.Length;
            using (var writer = new StreamWriter(request.GetRequestStream()))
            {
                writer.Write(serializeObject);
            }

            var response = request.GetResponse();
            Console.WriteLine(ReadResponse(response));

            Console.WriteLine($"{user} {maxUniqueId}");
            Console.ReadLine();
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