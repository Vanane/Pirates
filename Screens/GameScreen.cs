using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using FlatRedBall;
using FlatRedBall.Input;
using FlatRedBall.Instructions;
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Graphics;
using FlatRedBall.Graphics.Animation;
using FlatRedBall.Graphics.Particle;
using FlatRedBall.Math.Collision;
using FlatRedBall.Math.Geometry;
using FlatRedBall.Localization;
using FlatRedBall.TileCollisions;
using FlatRedBall.TileEntities;
using FlatRedBall.TileGraphics;
using FlatRedBall.Forms;
using Pirates.Factories;
using Pirates.GumRuntimes.InventoryForms;

using StateInterpolationPlugin;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using Pirates.Entities;
using Pirates.Custom;



namespace Pirates.Screens
{
	public partial class GameScreen
	{
        CollidableVsTileShapeCollectionRelationship<Boat> RelBoatIsland;
        PositionedObjectVsPositionedObjectRelationship<Player, Boat> RelPlayerBoat;
        ListVsListRelationship<Boat, Cannonball> RelBoatCannonball;
        CollidableListVsTileShapeCollectionRelationship<Bullet> RelBulletTerrain;
        CollidableVsTileShapeCollectionRelationship<Player> RelPlayerTerrain;

        PositionedObjectVsListRelationship<WeaponEntity, Skeleton> RelPlayerWeaponEnemies;
    

        Dock NearToADock;
        Action ControlMethod;

        bool IsMainMenuOpened;
        bool IsInventoryOpened;

        PositionedObject EntityToFollowByCam;

        void SetOrthogonalHeight(float newHeight)
        {
            Camera.Main.OrthogonalHeight = newHeight;
            Camera.Main.FixAspectRatioYConstant();
        }

        void CustomInitialize()
		{
            InitializeCamera();
            InitializeUI();
            InitializeCollisionsRelations();
            InitializeInstances();
            InitializeEvents();
            ControlMethod = BoatControls;



            Camera.Main.Tween(SetOrthogonalHeight,
                        from: Camera.Main.OrthogonalHeight * 1.25f,
                        to: Camera.Main.OrthogonalHeight,
                        during: 1,// seconds
                        interpolation: FlatRedBall.Glue.StateInterpolation.InterpolationType.Quadratic,
                        easing: FlatRedBall.Glue.StateInterpolation.Easing.InOut
                        );

            GameScreenGum.MoveToLayer(UIBoatLayerGum);


            SkeletonFactory.CreateNew(250, -250);
        }

        void CustomActivity(bool firstTimeCalled)
        {
            MovingActivity();
            CameraActivity();
            CollisionActivity();
            InterfaceActivity();

            FlatRedBall.Debugging.Debugger.Write(FlatRedBall.Gui.GuiManager.Cursor.WindowOver);
        }

        void CustomDestroy()
		{


		}

        static void CustomLoadStaticContent(string contentManagerName)
        {


        }

        void CameraActivity()
        {
            Camera.Main.X = EntityToFollowByCam.X;
            Camera.Main.Y = EntityToFollowByCam.Y;
        }

        void MovingActivity()
        {
            ControlMethod.Invoke();
        }

        void CollisionActivity()
        {
            DockCollisionActivity();
            PlayerCollisionActivity();
        }


        void DockCollisionActivity()
        {
            NearToADock = null;
            foreach (Dock d in DockList)
            {
                if (d.CircleInstance.CollideAgainst(PlayerBoat.Collision))
                {
                    //!Anchored for hiding the text if the boat is anchored
                    NearToADock = d;

                    if (ControlMethod == BoatControls)
                        d.ShowText();
                    else d.HideText();
                }
                else
                {
                    d.HideText();
                }
            }
        }


        void PlayerCollisionActivity()
        {       
            PlayerInstance.WalkingSpeedModifier = 1f;

            foreach (var tile in HulkCollision.Rectangles)
            {
                if (tile.CollideAgainst(PlayerInstance.Hitbox))
                {
                    PlayerInstance.WalkingSpeedModifier = 1f;
                    return;
                }
            }

            foreach (var tile in DirtCollision.Rectangles)
            {
                if (tile.CollideAgainst(PlayerInstance.Hitbox))
                {
                    PlayerInstance.WalkingSpeedModifier = 1f;
                    return;
                }
            }

            foreach (var tile in SandCollision.Rectangles)
            {
                if (tile.CollideAgainst(PlayerInstance.Hitbox))
                {
                    PlayerInstance.WalkingSpeedModifier = 0.8f;
                    return;
                }
            }

            foreach (var tile in WaterCollision.Rectangles)
            {
                if (tile.CollideAgainst(PlayerInstance.Hitbox))
                {
                    PlayerInstance.WalkingSpeedModifier = 0.5f;
                    return;
                }
            }
        }


        void ZoomCamera()
        {
            Camera.Main.OrthogonalWidth /= 3;
            Camera.Main.OrthogonalHeight /= 3;
        }

        void DezoomCamera()
        {
            Camera.Main.OrthogonalWidth *= 3;
            Camera.Main.OrthogonalHeight *= 3;
        }

        void InitializeUI()
        {
            SpeedMeter.AttachTo(Camera.Main);
            SpeedMeter.RelativeZ = -40; // so that it's "in front" of the camera
            SpeedMeter.RelativeX = Camera.Main.OrthogonalWidth / 2.0f - (32 + SpeedMeter.mSpriteInstance.Width / 2);
            SpeedMeter.RelativeY = -(Camera.Main.OrthogonalHeight / 2.0f - (32 + SpeedMeter.mSpriteInstance.Height / 2));

            SpeedMeter.SetCaseScale(5, -1, 3, 0);
            SpeedMeter.SetState(PlayerBoat.SpeedScale);


            ButtonPistolClick += (x) =>
            {
                PlayerInstance.EquipItem(Weapon.ExistingWeapons.First(w => w.ItemName == "Pistol"));
            };
            ButtonShotgunClick += (x) =>
            {
                PlayerInstance.AddItemToInventory(Item.ExistingItems.First(y => y.ItemName=="Pistol"));
                PlayerInstance.AddItemToInventory(Item.ExistingItems.First(y => y.ItemName=="Sword"));
            };            

            FlatRedBallServices.IsWindowsCursorVisible = true;

            (InventoryGui.GetGraphicalUiElementByName("TextPlayerName") as GumRuntimes.TextRuntime).Text = PlayerInstance.PlayerName;

            InventoryGui.PlaceCasesInInventoryPanel(PlayerInstance.PlayerInventory.Length, 8);

            InventoryGui.OnItemMovedCase += InventoryGuiOnItemMoved;

            foreach (var box in InventoryBar.GetInventoryBoxList())
            {
                box.Click += InventoryBarOnBoxClicked;
            }
        }

        void InitializeEvents()
        {
            PlayerInstance.ItemAddedToInventory += OnItemAddedToPlayer;
        }


        void InitializeCollisionsRelations()
        {
            //Create a relation between the boat collision and the tiles that form the island.
            TileShapeCollection LayerCollisions = Terrain.Collisions.First(x => x.Name == "Collisions");

            RelBoatIsland = CollisionManager.Self.CreateTileRelationship(
                PlayerBoat, LayerCollisions);

            RelBoatIsland.SetMoveCollision(0, 1);
            
            
            RelPlayerBoat = CollisionManager.Self.CreateRelationship(
                PlayerInstance, PlayerBoat);
            RelPlayerBoat.SetMoveCollision(0, 1);

            RelBoatCannonball = CollisionManager.Self.CreateRelationship(BoatList, CannonballList);
            RelBoatCannonball.SetEventOnlyCollision();
            RelBoatCannonball.CollisionOccurred += BoatCollidedWithCannonball;

            RelBulletTerrain = CollisionManager.Self.CreateTileRelationship(
                BulletList, RockCollision);
            RelBulletTerrain.CollisionOccurred += BulletCollidedWithTerrain;

            RelPlayerTerrain = CollisionManager.Self.CreateTileRelationship(
                PlayerInstance, RockCollision);
            RelPlayerTerrain.SetMoveCollision(1, 0);

            RelPlayerWeaponEnemies = CollisionManager.Self.CreateRelationship(
                PlayerInstance.mWeaponEntity, EnemyList);
            RelPlayerWeaponEnemies.SetEventOnlyCollision();
            RelPlayerWeaponEnemies.CollisionOccurred += PlayerWeaponHitEnemy;


            TileEntityInstantiator.CreateEntitiesFrom(Terrain);
        }

        void InitializeInstances()
        {
            PlayerInstance.Visible = false;            
        }

        void InitializeCamera()
        {
            EntityToFollowByCam = PlayerBoat;
        }


        private void BoatCollidedWithCannonball(Boat b, Cannonball c)
        {
            b.TakeDamage(c.Damage);
            c.Destroy();
        }


        private void BulletCollidedWithTerrain(Bullet b, TileShapeCollection Tiles)
        {
            b.HitTheTerrain();
        }

        private void PlayerWeaponHitEnemy(WeaponEntity weapon, Skeleton enemy)
        {
            if(PlayerInstance.IsAttacking)
                enemy.ReceiveDamage(PlayerInstance.GetEquippedWeapon().Damage);
        }


        /* * * * * * * * * *
         * PARTIE CONTROLS *
         * * * * * * * * * */

        void PlayerControls()
        {
            int HorizontalMovement = 0;
            int VerticalMovement = 0;

            PlayerInstance.Velocity = new Vector3(0, 0, 0);

            bool HoveringUI = false;
            foreach (var v in GameScreenGum.ContainedElements)
            {
                if (v.HasCursorOver(FlatRedBall.Gui.GuiManager.Cursor))
                {
                    HoveringUI = true;
                    break;
                }
            }

            if (InputManager.Keyboard.KeyPushed(Keys.Tab))
            {
                ToggleInventory();
            }

            if (InputManager.Mouse.ButtonPushed(FlatRedBall.Input.Mouse.MouseButtons.LeftButton))
            {
                if (!HoveringUI)
                {
                    //Vector between the Cursor position, relative to world, and the player.
                    Vector2 PlayerToMouse = new Vector2(
                        InputManager.Mouse.WorldXAt(0), InputManager.Mouse.WorldYAt(0)) - new Vector2(PlayerInstance.Position.X, PlayerInstance.Position.Y);

                    //We then normalize (reduce the length to 1 but keeping the direction)
                    PlayerToMouse.Normalize();

                    //Tell the player to attack. Player class will determine wether it's ok or not
                    PlayerInstance.Attack(PlayerToMouse);
                }
            }

            if (InputManager.Keyboard.KeyDown(Keys.Z))
                PlayerInstance.MoveUp();
            else if (InputManager.Keyboard.KeyDown(Keys.S))
                PlayerInstance.MoveDown();

            if (InputManager.Keyboard.KeyDown(Keys.Q))
                PlayerInstance.MoveLeft();
            else if (InputManager.Keyboard.KeyDown(Keys.D))
                PlayerInstance.MoveRight();


            if (InputManager.Keyboard.KeyPushed(Keys.E))
            {
                if (Vector3.Distance(PlayerInstance.Position, PlayerBoat.Position) < 32)
                {
                    PlayerInstance.Visible = false;
                    DezoomCamera();
                    ControlMethod = BoatControls;
                    EntityToFollowByCam = PlayerBoat;
                }
            }

            InventoryBarControls();
        }

        private void InventoryBarControls()
        {
            if (InputManager.Keyboard.KeyPushed(Keys.D1))
            {
                InventoryBar.SetSelectedItemCase(0);
                PlayerInstance.EquipItem(InventoryBar.GetSelectedItem());
            }
            else if (InputManager.Keyboard.KeyPushed(Keys.D2))
            {
                InventoryBar.SetSelectedItemCase(1);
                PlayerInstance.EquipItem(InventoryBar.GetSelectedItem());
            }
            else if (InputManager.Keyboard.KeyPushed(Keys.D3))
            {
                InventoryBar.SetSelectedItemCase(2);
                PlayerInstance.EquipItem(InventoryBar.GetSelectedItem());
            }
            else if (InputManager.Keyboard.KeyPushed(Keys.D4))
            {
                InventoryBar.SetSelectedItemCase(3);
                PlayerInstance.EquipItem(InventoryBar.GetSelectedItem());
            }
        }


        void BoatControls()
        {
            int RotationDirection = 0;

            if (!PlayerBoat.Anchored && !IsMainMenuOpened)
            {
                if (InputManager.Keyboard.KeyDown(Keys.Left))
                    RotationDirection = 1;

                else if (InputManager.Keyboard.KeyDown(Keys.Right))
                    RotationDirection = -1;

                if (InputManager.Keyboard.KeyPushed(Keys.Up))
                    PlayerBoat.SpeedScale = Math.Min(PlayerBoat.SpeedScale + 1, 3);

                else if (InputManager.Keyboard.KeyPushed(Keys.Down))
                    PlayerBoat.SpeedScale = Math.Max(PlayerBoat.SpeedScale - 1, -1);
            }

            PlayerBoat.Velocity = PlayerBoat.RotationMatrix.Up * PlayerBoat.MovementSpeed * PlayerBoat.SpeedScale;


            if (RotationDirection == 0)
            {
                //Si aucun bouton de direction n'est appuyé, on diminue la rotation du bateau en fonction du signe du nombre.
                //Si la vitesse de rotation est inférieure à la vitesse d'accélération, alors on stoppe tout simplement le bateau,
                //Pour éviter que ça ne fasse un effet yoyo : Avec une accel. de 0.1, si le bateau est à 0.05, on le mettra à -0.05, 
                //Puis à nouveau à 0.05, etc.

                PlayerBoat.RotationZVelocity =
                    (Math.Abs(PlayerBoat.RotationZVelocity) > PlayerBoat.RotationAcceleration)
                    ? PlayerBoat.RotationZVelocity - PlayerBoat.RotationAcceleration * Math.Sign(PlayerBoat.RotationZVelocity) : 0;
            }

            //Sinon, si l'une des touches est appuyée on augmente la vitesse de rotation dans le sens correspondant
            else if (RotationDirection == 1)
            {
                PlayerBoat.RotationZVelocity = Math.Min(PlayerBoat.RotationZVelocity + PlayerBoat.RotationAcceleration, PlayerBoat.MaxRotationSpeed);
            }
            else if (RotationDirection == -1)
            {
                PlayerBoat.RotationZVelocity = Math.Max(PlayerBoat.RotationZVelocity - PlayerBoat.RotationAcceleration, -PlayerBoat.MaxRotationSpeed);
            }

            if (InputManager.Keyboard.KeyPushed(Keys.S))
                PlayerBoat.SwitchSide();

            if (InputManager.Keyboard.KeyPushed(Keys.Space))
            {
                PlayerBoat.FireCannonball();
            }

            else if (InputManager.Keyboard.KeyPushed(Keys.E))
            {
                if (NearToADock != null)
                {
                    ControlMethod = PlayerControls;

                    PlayerInstance.X = NearToADock.X;
                    PlayerInstance.Y = NearToADock.Y;
                    PlayerInstance.Visible = true;
                    EntityToFollowByCam = PlayerInstance;
                    PlayerBoat.Anchor();

                    ZoomCamera();
                }
            }
            if (InputManager.Keyboard.KeyPushed(Keys.A))
            {
                if (PlayerBoat.Anchored) PlayerBoat.UnAnchor(); else PlayerBoat.Anchor();
            }

            SpeedMeter.SetState(PlayerBoat.SpeedScale);
        }

        private void InterfaceActivity()
        {
            if (IsInventoryOpened)
            {
                InventoryGui.RefreshHeldItem();
            }

        }



        private void ToggleInventory()
        {
            InventoryGui.SetVisibility(!InventoryGui.GetVisibility());
            InventoryBar.SetVisibility(!InventoryGui.GetVisibility());

            IsInventoryOpened = InventoryGui.GetVisibility();
            InventoryGui.DisplayItemsOnUI(PlayerInstance.PlayerInventory);
            InventoryBar.SetAllItems(InventoryGui.GetInventoryBar().GetAllItems());
        }

        private void InventoryGuiOnItemMoved(object o, ItemMovedCaseEventArgs e)
        {
            PlayerInstance.SwitchItemsByIndex(e.PreviousBox.BoxIndex, e.NewBox.BoxIndex);
        }

        private void InventoryBarOnBoxClicked(FlatRedBall.Gui.IWindow sender)
        {
            InventoryBar.SetSelectedItemCase((InventoryBoxRuntime)sender);
        }

        private void OnItemAddedToPlayer(object o, ItemAddedEventArgs e)
        {
            InventoryGui.DisplayItemsOnUI(((Player)o).PlayerInventory);
        }



    }
}
