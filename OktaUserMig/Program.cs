using System;
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
            var userJson = JsonConvert.SerializeObject(User);

            var result = OktaInterface.CreateUser(userJson);

            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}