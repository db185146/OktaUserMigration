using System.Data;
using Newtonsoft.Json;

namespace OktaUserMig.Users
{
    public class Hash
    {
        public Hash(DataRow dataRow)
        {
            Algorithm = "BCRYPT";
            WorkFactor = 12;
            Salt = "sGXv3cxpsh0i8qdicSzvs.";
            Value = "ZB.ctMIgWHPM.Je6xzSjRVeF39YqyMC";
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
