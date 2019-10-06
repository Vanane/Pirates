using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Pirates.Factories;

using Newtonsoft.Json;
using Microsoft.Xna.Framework;


namespace Pirates.Custom
{
    public class Weapon : Item
    {
        public static List<Weapon> ExistingWeapons;

        private static string FilePath;               

        public float Cooldown;
        public float Damage;
        public float Range;
        public string Type;
        public float HandPositionX;
        public float HandPositionY;

        //Ranged properties
        public int NumberOfBullets;
        public float DelayBetweenBullets;
        public float SpreadAngle;
        public float FlyingSpeed;

        //Melee properties


        public new static void Initialize()
        {
            FilePath = "Content\\entities\\weapon\\weapons.json";
            try
            {
                string RawFile = File.ReadAllText(FilePath);
                ExistingWeapons = JsonConvert.DeserializeObject<List<Weapon>>(RawFile);

                ExistingItems.AddRange(ExistingWeapons);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e);
                ExistingWeapons = new List<Weapon>();
            }
        }

        public Weapon()
        {

        }


        public Weapon(Weapon weapon) : base(weapon)
        {           
            this.Cooldown = weapon.Cooldown;
            this.Damage = weapon.Damage;
            this.DelayBetweenBullets = weapon.DelayBetweenBullets;
            this.FlyingSpeed = weapon.FlyingSpeed;
            this.HandPositionX = weapon.HandPositionX;
            this.HandPositionY = weapon.HandPositionY;
            this.NumberOfBullets = weapon.NumberOfBullets;
            this.Range = weapon.Range;
            this.SpreadAngle = weapon.SpreadAngle;
            this.Type = weapon.Type;
        }
    }
}
