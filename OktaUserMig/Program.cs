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
            User = new User(DataAccess.LoadUserInfo("1"));
            var result = OktaInterface.CreateUser(JsonConvert.SerializeObject(User));
            Console.WriteLine($"Create user result\n{result}");

            result = OktaInterface.AuthenticateUser(JsonConvert.SerializeObject(new Authenticate(DataAccess.LoadUserInfo("1"))));
            Console.WriteLine($"\n\nAuthenticate result\n{result}");
            Console.ReadLine();
        }
    }
}