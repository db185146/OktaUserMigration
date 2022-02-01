using System.Data;
using Newtonsoft.Json;

namespace OktaUserMig.Users
{
    public class Password
    {
        public Password(DataRow dataRow)
        {
            Hash = new Hash(dataRow);
        }

        [JsonProperty("hash")]
        public Hash Hash { get; set; }
    }

}
