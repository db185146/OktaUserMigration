using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OktaUserMig.Users
{
    class User
    {
        public User(DataRow dataRow)
        {
            Profile = new Profile(dataRow);
        }

        [JsonProperty("profile")]
        public Profile Profile { get; set; }
    }
}
