using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using FreeLauncher.Forms;
using Newtonsoft.Json;

namespace FreeLauncher
{
    public class UserManager
    {
        private static string _usersFile;

        [JsonProperty("selectedUsername")]
        public string SelectedUsername;

        [JsonProperty("users")]
        public Dictionary<string, User> Accounts = new Dictionary<string, User>();

        public static UserManager LoadFromFile(string usersFile)
        {
            _usersFile = usersFile;
            if (File.Exists(_usersFile))
                return JsonConvert.DeserializeObject<UserManager>(File.ReadAllText(_usersFile));

            return new UserManager();
        }

        public void Save()
        {
            var jsonText = JsonConvert.SerializeObject(this, Formatting.Indented,
                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            File.WriteAllText(_usersFile, jsonText);
        }
    }
}
