using System.Data;
using Newtonsoft.Json;

namespace OktaUserMig.Users
{
    class Profile
    {
        public Profile(DataRow dataRow)
        {
            FirstName = "David";
            LastName = "Turner";
            Email = dataRow.ItemArray[3].ToString();
            Login = dataRow.ItemArray[3].ToString();
            MobilePhone = "555-415-1335";
        }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("login")]
        public string Login { get; set; }

        [JsonProperty("mobilePhone")]
        public string MobilePhone { get; set; }
    }
}
