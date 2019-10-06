using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using FlatRedBall;
using FlatRedBall.Input;
using FlatRedBall.Instructions;
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Graphics.Animation;
using FlatRedBall.Graphics.Particle;
using FlatRedBall.Math.Geometry;
using FlatRedBall.Instructions.Interpolation;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Pirates.Custom;
using Pirates.Factories;

namespace Pirates.Entities
{
	public partial class Player
	{
        /// <summary>
        /// Initialization logic which is execute only one time for this Entity (unless the Entity is pooled).
        /// This method is called when the Entity is added to managers. Entities which are instantiated but not
        /// added to managers will not have this method called.
        /// </summary>

        public Item[] PlayerInventory; //Items in the player's own inventory

        public Item EquippedItem;

        public WeaponEntity mWeaponEntity { get { return this.WeaponInstance; } }

        public Action<Vector2> AttackMethod;

        public bool IsAttacking;

        public EventHandler<ItemAddedEventArgs> ItemAddedToInventory;

        private void CustomInitialize()
		{
            IsAttacking = false;
            this.Z = Custom.GameSettings.GroundLevelSpritesDepth;
            PlayerInventory = new Item[32];

            SpriteInstance.CurrentChainName = "Idle";
            Hitbox.Width = SpriteInstance.Width;
            Hitbox.Height = SpriteInstance.Height;
        }

        private void CustomActivity()
		{
            if (Velocity == new Microsoft.Xna.Framework.Vector3(0, 0, 0))
                SpriteInstance.CurrentChainName = "Idle";

            if (!IsAttacking)
            {
                RotateWeapon();
            }
        }

        private void CustomDestroy()
		{


		}

        private static void CustomLoadStaticContent(string contentManagerName)
        {


        }

        public void MoveUp()
        {
            SpriteInstance.CurrentChainName = "WalkUp";
            this.YVelocity = this.WalkingSpeed * this.WalkingSpeedModifier;
        }

        public void MoveDown()
        {
            SpriteInstance.CurrentChainName = "WalkDown";
            this.YVelocity = -(this.WalkingSpeed * this.WalkingSpeedModifier);
        }

        public void MoveLeft()
        {
            SpriteInstance.CurrentChainName = "WalkLeft";
            this.XVelocity = -(this.WalkingSpeed * this.WalkingSpeedModifier);
        }

        public void MoveRight()
        {
            SpriteInstance.CurrentChainName = "WalkRight";
            this.XVelocity = this.WalkingSpeed * this.WalkingSpeedModifier;
        }

        public Item GetEquippedItem()
        {
            return EquippedItem;
        }

        public Weapon GetEquippedWeapon()
        {
            if (EquippedItem is Weapon weapon)
                return weapon;
            else return null;
        }

        public void EquipItem(Item item)
        {
            if(item != null)
            {
                if (item is Weapon WeaponItem)
                {
                    EquipWeapon(WeaponItem);
                }
                Console.WriteLine("debug : " + (item is Weapon) + " (player.cs 118)");
            }
        }

        public void EquipWeapon(Weapon w)
        {
            EquippedItem = w;

            using (FileStream fileStream = new FileStream(w.SpritePath, FileMode.Open))
            {
                Texture2D t = Texture2D.FromStream(FlatRedBallServices.GraphicsDevice, fileStream);
                WeaponInstance.SetTexture(t);
            }

            using (Weapon EquippedWeapon = ((Weapon)EquippedItem))
            {
                WeaponInstance.RelativePosition = new Vector3(this.HandPositionX - EquippedWeapon.HandPositionX, this.HandPositionY + EquippedWeapon.HandPositionY, this.Z);

                switch (EquippedWeapon.Type)
                {
                    case "Melee":
                        {
                            AttackMethod = AttackMeelee;
                            break;
                        }
                    case "Ranged":
                        {
                            AttackMethod = AttackRanged;
                            break;
                        }
                }
            }
        }


        private void RotateWeapon()
        {
            Vector2 AngleCoor = new Vector2(
                FlatRedBall.Gui.GuiManager.Cursor.WorldXAt(0), FlatRedBall.Gui.GuiManager.Cursor.WorldYAt(0)) -
                new Vector2(this.X, this.Y);

            AngleCoor.Normalize();

            if (AngleCoor.X != Double.NaN && AngleCoor.Y != Double.NaN)
            {
                FlatRedBall.Debugging.Debugger.Write(AngleCoor.X + " " + AngleCoor.Y);

                if (AngleCoor.X == -1 && AngleCoor.Y == 0)
                    WeaponInstance.RelativeRotationZ = 0;
                else
                    WeaponInstance.RelativeRotationZ = (float)(Math.PI + Math.Acos(AngleCoor.X) * Math.Sign(Math.Asin(AngleCoor.Y)));

                WeaponInstance.RelativeX = AngleCoor.X * WeaponInstance.SpriteInstance.Width;
                WeaponInstance.RelativeY = AngleCoor.Y * WeaponInstance.SpriteInstance.Height;

                if (WeaponInstance.RelativeRotationZ > Math.PI / 2 && WeaponInstance.RelativeRotationZ < 3 * Math.PI / 2)
                {
                    WeaponInstance.SpriteInstance.FlipVertical = true;
                }
                else WeaponInstance.SpriteInstance.FlipVertical = false;
            }
        }

        /*METHODES D'ATTAQUE*/

        public void Attack(Vector2 Direction)
        {
            if (EquippedItem != null && EquippedItem is Weapon)
                AttackMethod.Invoke(Direction);
        }

        private void AttackMeelee(Vector2 Direction)
        {
            if (((Weapon)EquippedItem).Cooldown < FlatRedBall.Screens.ScreenManager.CurrentScreen.PauseAdjustedSecondsSince(LastShotTime))
            {
                LastShotTime = (float)FlatRedBall.Screens.ScreenManager.CurrentScreen.PauseAdjustedCurrentTime;

                IsAttacking = true;

                var StartingPos = WeaponInstance.RelativePosition;

                WeaponInstance.RelativeVelocity = -100 * WeaponInstance.RotationMatrix.Right;

                this.Call(() =>
                WeaponInstance.RelativeVelocity = 100 * WeaponInstance.RotationMatrix.Right
                ).After(0.10);

                this.Call(() =>
                {
                    WeaponInstance.RelativeXVelocity = 0;
                    WeaponInstance.RelativePosition = StartingPos;
                    IsAttacking = false;
                }
                ).After(0.20);

            }
        }

        private void AttackRanged(Vector2 Direction)
        {
            using (Weapon EquippedWeapon = ((Weapon)EquippedItem))
            {
                if (EquippedWeapon.Cooldown < FlatRedBall.Screens.ScreenManager.CurrentScreen.PauseAdjustedSecondsSince(LastShotTime))
                {
                    LastShotTime = (float)FlatRedBall.Screens.ScreenManager.CurrentScreen.PauseAdjustedCurrentTime;
                    for (int i = 0; i < EquippedWeapon.NumberOfBullets; i++)
                    {
                        if (EquippedWeapon.DelayBetweenBullets == 0 || i == 0)
                        {
                            CreateBullet(Direction);
                        }
                        else
                        {
                            this.Call(() => CreateBullet(Direction)).After(EquippedWeapon.DelayBetweenBullets * i);
                        }
                    }
                }                
            }
        }

        private void CreateBullet(Vector2 Direction)
        {
            using (Weapon EquippedWeapon = ((Weapon)EquippedItem))
            {

                float MaxAngle = (float)(EquippedWeapon.SpreadAngle / 2 / (180 / Math.PI));

                float RandomAngle = FlatRedBallServices.Random.Between(-MaxAngle / 2, MaxAngle / 2);

                Vector2 NewDirection = Maths.RotateVector(Direction, RandomAngle);

                var b = BulletFactory.CreateNew();

                b.Damage = EquippedWeapon.Damage;
                b.FlyingSpeed = EquippedWeapon.FlyingSpeed;
                b.Range = EquippedWeapon.Range;

                b.SetTrajectory(WeaponInstance.X, WeaponInstance.Y, NewDirection);
            }
        }

        /*METHODES D'INVENTAIRE*/

        public bool AddItemToInventory(Item item)
        {
            bool Added = false;
            int i = 0;
            ItemAddedEventArgs Args;

            for (i = 0; i < PlayerInventory.Length; i++)
            {
                if (PlayerInventory[i] == null)
                {
                    PlayerInventory[i] = item;
                    Added = true;
                    break;
                }
            }

            if (Added)
            {
                Args = new ItemAddedEventArgs();
                Args.Index = i;
                Args.Item = item;
                ItemAddedToInventory.Invoke(this, Args);
            }

            return Added;
        }

        public void SwitchItemsByIndex(int FirstIndex, int SecondIndex)
        {
            using(Item Placeholder = Item.CloneItem(PlayerInventory[FirstIndex]))
            {
                PlayerInventory[SecondIndex] = Item.CloneItem(PlayerInventory[FirstIndex]);
                PlayerInventory[FirstIndex] = null;
                Console.WriteLine("Debug : " + FirstIndex + " " + SecondIndex + "(player.cs 296)");
                //TODO : Quand  onswitch d'item ça supprime l'ancien emplacement.
            }
        }

    }

    public class ItemAddedEventArgs : EventArgs
    {
        public Custom.Item Item;
        public int Index;    
    }
}
