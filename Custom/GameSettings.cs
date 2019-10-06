using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

using System.IO;
namespace Pirates.Custom
{
    public static class GameSettings
    {
        public static Settings GetSettings;
        private static string FilePath;

        public const float TerrainDepth = 0;
        public const float GroundLevelSpritesDepth = 5;
        public const float MidAirLevelTerrainDepth = 10;
        public const float AirLevelTerrainDepth = 15;
        public const float GuiDepth = 20;

        public static void Initialize()
        {
            FilePath = "options.txt";

            try
            {
                string file = File.ReadAllText(FilePath);
                GetSettings = JsonConvert.DeserializeObject<Settings>(file);              
            }
            catch (FileNotFoundException e)
            {
                GetSettings = new Settings();
            }
        }

        public static void SaveSettings()
        {
            File.WriteAllText(FilePath, JsonConvert.SerializeObject(GetSettings));
        }



    }


    public class Settings
    {
        public float VolumeLevel;

        public Settings()
        {

        }
    }
}
