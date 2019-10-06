using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Microsoft.Xna.Framework.Graphics;
using FlatRedBall;

namespace Pirates.Custom
{
    public class Item : IDisposable
    {
        public static List<Item> ExistingItems;
        private static string FilePath;

        public string ItemName;
        public int ItemID;
        public string SpritePath;


        public static void Initialize()
        {
            FilePath = "Content\\entities\\Item\\items.json";
            try
            {
                string RawFile = File.ReadAllText(FilePath);
                ExistingItems = JsonConvert.DeserializeObject<List<Item>>(RawFile);
            }
            catch (FileNotFoundException e)
            {
                ExistingItems = new List<Item>();
            }
        }

        public Item()
        {

        }

        public Item(Item i)
        {
            this.ItemName = i.ItemName;
            this.ItemID = i.ItemID;
            this.SpritePath = i.SpritePath;
        }

        public Texture2D GetTextureFromStream()
        {
            using (FileStream fileStream = new FileStream(SpritePath, FileMode.Open))
            {
                return Texture2D.FromStream(FlatRedBallServices.GraphicsDevice, fileStream);
            }
        }
        public static Item CloneItem(Item item)
        {
            Item r = null;

            if (item is Weapon)
                r = new Weapon((Weapon)item);

            return r;
        }
        


        public void Dispose()
        {

        }

    }
}
