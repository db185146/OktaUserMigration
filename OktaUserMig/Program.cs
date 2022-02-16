using System;
using Newtonsoft.Json;
using OktaUserMig.Users;

namespace OktaUserMig
{
    class Program
    {
       
        static void Main(string[] args)
        {
            var result = OktaInterface.CreateUser(JsonConvert.SerializeObject(new User(DataAccess.LoadUserInfo("1"))));
            Console.WriteLine($"Create user result\n{result}");

            result = OktaInterface.AuthenticateUser(JsonConvert.SerializeObject(new Authenticate(DataAccess.LoadUserInfo("1"))));
            Console.WriteLine($"\n\nAuthenticate result\n{result}");
            Console.ReadLine();
        }
    }
}