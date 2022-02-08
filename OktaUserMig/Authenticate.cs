using System.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace OktaUserMig
{
    public class Authenticate
    {
        public Authenticate(DataRow dataRow)
        {
            Username = dataRow.ItemArray[3].ToString();
            Password = "password1";
            AuthOptions = new Options();
        }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("options")]
        public Options AuthOptions { get; set; }
    }

    public class Options
    {
        [JsonProperty("multiOptionalFactorEnroll")]
        public bool MultiOptionalFactorEnroll = false;

        [JsonProperty("warnBeforePasswordExpired")]
        public bool WarnBeforePasswordExpired = false;
    }
}
