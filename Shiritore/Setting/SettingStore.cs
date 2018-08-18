using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shiritore.GameSystem;

namespace Shiritore.Setting
{
    public class SettingStore
    {
        public static SettingStore SingletonStore = new SettingStore();
        public GameData ShiritoreGameData = new GameData();
    }
}
