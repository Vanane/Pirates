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
using Pirates.Factories;

using StateInterpolationPlugin;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using Pirates.Entities;



namespace Pirates.Screens
{
	public partial class GameScreen
	{

        CollidableVsTileShapeCollectionRelationship<Boat> RelBoatIsland;
        PositionedObjectVsPositionedObjectRelationship<Player, Boat> RelPlayerBoat;
        ListVsListRelationship<Boat, Cannonball> RelBoatCannonball;

        Dock NearToADock;
        Action ControlMethod;

        bool MainMenuOpened;

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
            ControlMethod = BoatControls;

            Camera.Main.Tween(SetOrthogonalHeight,
                        from: Camera.Main.OrthogonalHeight * 1.25f,
                        to: Camera.Main.OrthogonalHeight,
                        during: 1,// seconds
                        interpolation: FlatRedBall.Glue.StateInterpolation.InterpolationType.Quadratic,
                        easing: FlatRedBall.Glue.StateInterpolation.Easing.InOut
                        );
        }


        void CustomActivity(bool firstTimeCalled)
        {
            MovingActivity();
            CameraActivity();
            CollisionActivity();
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

            ButtonAddBoat.AttachTo(Camera.Main);
            ButtonAddBoat.RelativeZ = -40; // so that it's "in front" of the camera
            ButtonAddBoat.RelativeX = Camera.Main.OrthogonalWidth / 2.0f - (32 + SpeedMeter.mSpriteInstance.Width / 2);
            ButtonAddBoat.RelativeY = (32 + SpeedMeter.mSpriteInstance.Height / 2);
            ButtonAddBoat.Click += (x) => { if (BoatList.Count < 1) { Boat b = new Boat(); b.Name = "TestBoat"; b.MaxHealth = 100; b.CurrentHealth = 10; b.X = 560; b.Y = -336; BoatList.Add(b); } };

            FlatRedBallServices.IsWindowsCursorVisible = true;
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


        void BoatControls()
        {
            int RotationDirection = 0;

            if(!PlayerBoat.Anchored && !MainMenuOpened)
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
            /*else
            {
                //Sinon, si l'une des touches est appuyée on augmente la vitesse de rotation dans le sens correspondant
                PlayerBoat.RotationZVelocity +=
                    (PlayerBoat.RotationZVelocity < PlayerBoat.MaxRotationSpeed && PlayerBoat.RotationZVelocity > -PlayerBoat.MaxRotationSpeed)
                    ? PlayerBoat.RotationAcceleration * RotationDirection : 0;
                Console.WriteLine(PlayerBoat.RotationZVelocity);
            }*/

            else if (RotationDirection == 1)
            {
                PlayerBoat.RotationZVelocity = Math.Min(PlayerBoat.RotationZVelocity + PlayerBoat.RotationAcceleration, PlayerBoat.MaxRotationSpeed);
            }
            else if (RotationDirection == -1)
            {
                PlayerBoat.RotationZVelocity = Math.Max(PlayerBoat.RotationZVelocity - PlayerBoat.RotationAcceleration, -PlayerBoat.MaxRotationSpeed);
            }


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


        void PlayerControls()
        {
            int HorizontalMovement = 0;
            int VerticalMovement = 0;


            PlayerInstance.Velocity = new Vector3(0,0,0);

           if (InputManager.Keyboard.KeyDown(Keys.Z))
            {
                VerticalMovement = 1;
            }
            else if (InputManager.Keyboard.KeyDown(Keys.S))
            {
                VerticalMovement = -1;
            }

            if (InputManager.Keyboard.KeyDown(Keys.Q))
            {
                HorizontalMovement = -1;
            }
            else if (InputManager.Keyboard.KeyDown(Keys.D))
            {
                HorizontalMovement = 1;
            }

            PlayerInstance.XVelocity = PlayerInstance.WalkingSpeed * PlayerInstance.WalkingSpeedModifier * HorizontalMovement;
            PlayerInstance.YVelocity = PlayerInstance.WalkingSpeed * PlayerInstance.WalkingSpeedModifier * VerticalMovement;

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
        }



        void BoatCollidedWithCannonball(Boat b, Cannonball c)
        {
            b.TakeDamage(c.Damage);
            c.Destroy();
        }
    }
}
