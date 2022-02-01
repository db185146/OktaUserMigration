using System.Data;
using Newtonsoft.Json;

namespace OktaUserMig.Users
{
    public class Hash
    {
        public Hash(DataRow dataRow)
        {
            Algorithm = "BCRYPT";
            WorkFactor = 10;
            Salt = "???";
            Value = dataRow.ItemArray[4].ToString();
        }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("salt")]
        public string Salt { get; set; }

        [JsonProperty("workFactor")]
        public int WorkFactor { get; set; }

        [JsonProperty("algorithm")]
        public string Algorithm { get; set; }
    }
}
