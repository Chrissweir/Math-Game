using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Math_Game.Common
{
    public class Common
    {
        public static int HighScore, GameMode, Speed;

        public static void SaveSettings(string key, string contents)
        {
            ApplicationData.Current.LocalSettings.Values[key] = contents;
        }

        public static string LoadSettings(string key)
        {
            var settings = ApplicationData.Current.LocalSettings;
            return settings.Values.ContainsKey(key) ? settings.Values[key] as string : String.Empty;
        }
    }
}
