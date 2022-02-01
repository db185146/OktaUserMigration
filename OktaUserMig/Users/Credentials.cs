using System.Data;
using Newtonsoft.Json;

namespace OktaUserMig.Users
{
    public class Credentials
    {
        public Credentials(DataRow dataRow)
        {
            Password = new Password(dataRow);
        }

        [JsonProperty("password")]
        public Password Password { get; set; }
    }

}
