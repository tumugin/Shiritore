using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Shiritore.GameSystem;

namespace Shiritore.Setting
{
    public class SettingStore
    {
        [JsonIgnore] public static SettingStore SingletonStore = new SettingStore();
        public GameData ShiritoreGameData = new GameData();

        public static string getSettingJSON(SettingStore store)
        {
            return JsonConvert.SerializeObject(store, Formatting.Indented,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    TypeNameHandling = TypeNameHandling.Auto
                });
        }

        public static SettingStore loadSettingJSON(string json)
        {
            var desirializer_settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Auto,
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor
            };
            return JsonConvert.DeserializeObject<SettingStore>(json, desirializer_settings);
        }
    }
}