#if ANDROID || IOS || DESKTOP_GL
#define REQUIRES_PRIMARY_THREAD_LOADING
#endif
using Color = Microsoft.Xna.Framework.Color;
using System.Linq;
using FlatRedBall;
using System;
using System.Collections.Generic;
using System.Text;
using FlatRedBall.Math;
using FlatRedBall.Graphics;
using Pirates.Entities.UI;
namespace Pirates.Screens
{
    public partial class GameScreen : FlatRedBall.Screens.Screen
    {
        #if DEBUG
        static bool HasBeenLoadedWithGlobalContentManager = false;
        #endif
        protected static FlatRedBall.TileGraphics.LayeredTileMap Terrain;
        protected static Gum.Wireframe.GraphicalUiElement GameScreenGum;
        
        private Pirates.Entities.Boat PlayerBoat;
        private FlatRedBall.Math.PositionedObjectList<Pirates.Entities.Boat> BoatList;
        private FlatRedBall.Math.PositionedObjectList<Pirates.Entities.Dock> DockList;
        private Pirates.Entities.Player PlayerInstance;
        private FlatRedBall.Graphics.Layer UIBoatLayer;
        private FlatRedBall.TileCollisions.TileShapeCollection SandCollision;
        private FlatRedBall.TileCollisions.TileShapeCollection WaterCollision;
        private FlatRedBall.TileCollisions.TileShapeCollection DirtCollision;
        private FlatRedBall.TileCollisions.TileShapeCollection HulkCollision;
        private FlatRedBall.TileCollisions.TileShapeCollection RockCollision;
        private FlatRedBall.Math.PositionedObjectList<Pirates.Entities.Cannonball> CannonballList;
        private Pirates.Entities.UI.Button ButtonAddBoat;
        private Pirates.Entities.UI.SpeedMeter SpeedMeter;
        private FlatRedBall.Math.PositionedObjectList<Pirates.Entities.Animations.Explosion> ExplosionList;
        protected global::RenderingLibrary.Graphics.Layer UIBoatLayerGum;
        public GameScreen () 
        	: base ("GameScreen")
        {
        }
        public override void Initialize (bool addToManagers) 
        {
            LoadStaticContent(ContentManagerName);
            PlayerBoat = new Pirates.Entities.Boat(ContentManagerName, false);
            PlayerBoat.Name = "PlayerBoat";
            BoatList = new FlatRedBall.Math.PositionedObjectList<Pirates.Entities.Boat>();
            BoatList.Name = "BoatList";
            DockList = new FlatRedBall.Math.PositionedObjectList<Pirates.Entities.Dock>();
            DockList.Name = "DockList";
            PlayerInstance = new Pirates.Entities.Player(ContentManagerName, false);
            PlayerInstance.Name = "PlayerInstance";
            UIBoatLayer = new FlatRedBall.Graphics.Layer();
            UIBoatLayer.Name = "UIBoatLayer";
            SandCollision = new FlatRedBall.TileCollisions.TileShapeCollection();
            SandCollision.Name = "SandCollision";
            WaterCollision = new FlatRedBall.TileCollisions.TileShapeCollection();
            WaterCollision.Name = "WaterCollision";
            DirtCollision = new FlatRedBall.TileCollisions.TileShapeCollection();
            DirtCollision.Name = "DirtCollision";
            HulkCollision = new FlatRedBall.TileCollisions.TileShapeCollection();
            HulkCollision.Name = "HulkCollision";
            RockCollision = new FlatRedBall.TileCollisions.TileShapeCollection();
            RockCollision.Name = "RockCollision";
            CannonballList = new FlatRedBall.Math.PositionedObjectList<Pirates.Entities.Cannonball>();
            CannonballList.Name = "CannonballList";
            ButtonAddBoat = new Pirates.Entities.UI.Button(ContentManagerName, false);
            ButtonAddBoat.Name = "ButtonAddBoat";
            SpeedMeter = new Pirates.Entities.UI.SpeedMeter(ContentManagerName, false);
            SpeedMeter.Name = "SpeedMeter";
            ExplosionList = new FlatRedBall.Math.PositionedObjectList<Pirates.Entities.Animations.Explosion>();
            ExplosionList.Name = "ExplosionList";
            // normally we wait to set variables until after the object is created, but in this case if the
            // TileShapeCollection doesn't have its Visible set before creating the tiles, it can result in
            // really bad performance issues, as shapes will be made visible, then invisible. Really bad perf!
            SandCollision.Visible = false;
            FlatRedBall.TileCollisions.TileShapeCollectionLayeredTileMapExtensions.AddCollisionFromTilesWithType(SandCollision, Terrain, "Sand");
            // normally we wait to set variables until after the object is created, but in this case if the
            // TileShapeCollection doesn't have its Visible set before creating the tiles, it can result in
            // really bad performance issues, as shapes will be made visible, then invisible. Really bad perf!
            WaterCollision.Visible = false;
            FlatRedBall.TileCollisions.TileShapeCollectionLayeredTileMapExtensions.AddCollisionFromTilesWithType(WaterCollision, Terrain, "Water");
            // normally we wait to set variables until after the object is created, but in this case if the
            // TileShapeCollection doesn't have its Visible set before creating the tiles, it can result in
            // really bad performance issues, as shapes will be made visible, then invisible. Really bad perf!
            DirtCollision.Visible = false;
            FlatRedBall.TileCollisions.TileShapeCollectionLayeredTileMapExtensions.AddCollisionFromTilesWithType(DirtCollision, Terrain, "Dirt");
            // normally we wait to set variables until after the object is created, but in this case if the
            // TileShapeCollection doesn't have its Visible set before creating the tiles, it can result in
            // really bad performance issues, as shapes will be made visible, then invisible. Really bad perf!
            HulkCollision.Visible = false;
            FlatRedBall.TileCollisions.TileShapeCollectionLayeredTileMapExtensions.AddCollisionFromTilesWithType(HulkCollision, Terrain, "Hulk");
            // normally we wait to set variables until after the object is created, but in this case if the
            // TileShapeCollection doesn't have its Visible set before creating the tiles, it can result in
            // really bad performance issues, as shapes will be made visible, then invisible. Really bad perf!
            RockCollision.Visible = false;
            FlatRedBall.TileCollisions.TileShapeCollectionLayeredTileMapExtensions.AddCollisionFromTilesWithType(RockCollision, Terrain, "Hulk");
            
            
            PostInitialize();
            base.Initialize(addToManagers);
            if (addToManagers)
            {
                AddToManagers();
            }
        }
        public override void AddToManagers () 
        {
            Terrain.AddToManagers(mLayer);
            GameScreenGum.AddToManagers();FlatRedBall.FlatRedBallServices.GraphicsOptions.SizeOrOrientationChanged += RefreshLayoutInternal;
            FlatRedBall.SpriteManager.AddLayer(UIBoatLayer);
            UIBoatLayerGum = RenderingLibrary.SystemManagers.Default.Renderer.AddLayer();
            UIBoatLayerGum.Name = "UIBoatLayerGum";
            FlatRedBall.Gum.GumIdb.Self.AddGumLayerToFrbLayer(UIBoatLayerGum, UIBoatLayer);
            Factories.DockFactory.Initialize(ContentManagerName);
            Factories.CannonballFactory.Initialize(ContentManagerName);
            Factories.ExplosionFactory.Initialize(ContentManagerName);
            Factories.DockFactory.AddList(DockList);
            Factories.CannonballFactory.AddList(CannonballList);
            Factories.ExplosionFactory.AddList(ExplosionList);
            PlayerBoat.AddToManagers(mLayer);
            PlayerInstance.AddToManagers(mLayer);
            ButtonAddBoat.AddToManagers(UIBoatLayer);
            SpeedMeter.AddToManagers(UIBoatLayer);
            base.AddToManagers();
            AddToManagersBottomUp();
            CustomInitialize();
        }
        public override void Activity (bool firstTimeCalled) 
        {
            if (!IsPaused)
            {
                
                PlayerBoat.Activity();
                for (int i = BoatList.Count - 1; i > -1; i--)
                {
                    if (i < BoatList.Count)
                    {
                        // We do the extra if-check because activity could destroy any number of entities
                        BoatList[i].Activity();
                    }
                }
                for (int i = DockList.Count - 1; i > -1; i--)
                {
                    if (i < DockList.Count)
                    {
                        // We do the extra if-check because activity could destroy any number of entities
                        DockList[i].Activity();
                    }
                }
                PlayerInstance.Activity();
                for (int i = CannonballList.Count - 1; i > -1; i--)
                {
                    if (i < CannonballList.Count)
                    {
                        // We do the extra if-check because activity could destroy any number of entities
                        CannonballList[i].Activity();
                    }
                }
                ButtonAddBoat.Activity();
                SpeedMeter.Activity();
                for (int i = ExplosionList.Count - 1; i > -1; i--)
                {
                    if (i < ExplosionList.Count)
                    {
                        // We do the extra if-check because activity could destroy any number of entities
                        ExplosionList[i].Activity();
                    }
                }
            }
            else
            {
            }
            base.Activity(firstTimeCalled);
            if (!IsActivityFinished)
            {
                CustomActivity(firstTimeCalled);
            }
        }
        public override void Destroy () 
        {
            base.Destroy();
            Factories.DockFactory.Destroy();
            Factories.CannonballFactory.Destroy();
            Factories.ExplosionFactory.Destroy();
            Terrain.Destroy();
            Terrain = null;
            GameScreenGum.RemoveFromManagers();
            GameScreenGum = null;
            
            BoatList.MakeOneWay();
            DockList.MakeOneWay();
            CannonballList.MakeOneWay();
            ExplosionList.MakeOneWay();
            if (PlayerBoat != null)
            {
                PlayerBoat.Destroy();
                PlayerBoat.Detach();
            }
            for (int i = BoatList.Count - 1; i > -1; i--)
            {
                BoatList[i].Destroy();
            }
            for (int i = DockList.Count - 1; i > -1; i--)
            {
                DockList[i].Destroy();
            }
            if (PlayerInstance != null)
            {
                PlayerInstance.Destroy();
                PlayerInstance.Detach();
            }
            if (UIBoatLayer != null)
            {
                FlatRedBall.SpriteManager.RemoveLayer(UIBoatLayer);
            }
            if (SandCollision != null)
            {
                SandCollision.Visible = false;
            }
            if (WaterCollision != null)
            {
                WaterCollision.Visible = false;
            }
            if (DirtCollision != null)
            {
                DirtCollision.Visible = false;
            }
            if (HulkCollision != null)
            {
                HulkCollision.Visible = false;
            }
            if (RockCollision != null)
            {
                RockCollision.Visible = false;
            }
            for (int i = CannonballList.Count - 1; i > -1; i--)
            {
                CannonballList[i].Destroy();
            }
            if (ButtonAddBoat != null)
            {
                ButtonAddBoat.Destroy();
                ButtonAddBoat.Detach();
            }
            if (SpeedMeter != null)
            {
                SpeedMeter.Destroy();
                SpeedMeter.Detach();
            }
            for (int i = ExplosionList.Count - 1; i > -1; i--)
            {
                ExplosionList[i].Destroy();
            }
            BoatList.MakeTwoWay();
            DockList.MakeTwoWay();
            CannonballList.MakeTwoWay();
            ExplosionList.MakeTwoWay();
            FlatRedBall.Math.Collision.CollisionManager.Self.Relationships.Clear();
            CustomDestroy();
        }
        public virtual void PostInitialize () 
        {
            bool oldShapeManagerSuppressAdd = FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue;
            FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = true;
            if (PlayerBoat.Parent == null)
            {
                PlayerBoat.X = 300f;
            }
            else
            {
                PlayerBoat.RelativeX = 300f;
            }
            if (PlayerBoat.Parent == null)
            {
                PlayerBoat.Y = -300f;
            }
            else
            {
                PlayerBoat.RelativeY = -300f;
            }
            if (PlayerBoat.Parent == null)
            {
                PlayerBoat.Z = 10f;
            }
            else
            {
                PlayerBoat.RelativeZ = 10f;
            }
            PlayerBoat.RotationAcceleration = 0.025f;
            PlayerBoat.MaxRotationSpeed = 1f;
            PlayerBoat.MovementSpeed = 33f;
            PlayerBoat.MaxHealth = 250f;
            PlayerBoat.CurrentHealth = 250f;
            PlayerBoat.TimeBetweenShoot = 1f;
            PlayerBoat.LastTimeShot = 0f;
            if (PlayerInstance.Parent == null)
            {
                PlayerInstance.Z = 10f;
            }
            else
            {
                PlayerInstance.RelativeZ = 10f;
            }
            PlayerInstance.WalkingSpeed = 25f;
            PlayerInstance.WalkingSpeedModifier = 1f;
            SandCollision.Visible = false;
            WaterCollision.Visible = false;
            DirtCollision.Visible = false;
            HulkCollision.Visible = false;
            RockCollision.Visible = false;
            if (ButtonAddBoat.Parent == null)
            {
                ButtonAddBoat.Z = 20f;
            }
            else
            {
                ButtonAddBoat.RelativeZ = 20f;
            }
            ButtonAddBoat.Text = "Ajouter un bateau";
            SpeedMeter.MaxState = 5;
            FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = oldShapeManagerSuppressAdd;
        }
        public virtual void AddToManagersBottomUp () 
        {
            CameraSetup.ResetCamera(SpriteManager.Camera);
            AssignCustomVariables(false);
        }
        public virtual void RemoveFromManagers () 
        {
            PlayerBoat.RemoveFromManagers();
            for (int i = BoatList.Count - 1; i > -1; i--)
            {
                BoatList[i].Destroy();
            }
            for (int i = DockList.Count - 1; i > -1; i--)
            {
                DockList[i].Destroy();
            }
            PlayerInstance.RemoveFromManagers();
            if (UIBoatLayer != null)
            {
                FlatRedBall.SpriteManager.RemoveLayer(UIBoatLayer);
            }
            if (SandCollision != null)
            {
                SandCollision.Visible = false;
            }
            if (WaterCollision != null)
            {
                WaterCollision.Visible = false;
            }
            if (DirtCollision != null)
            {
                DirtCollision.Visible = false;
            }
            if (HulkCollision != null)
            {
                HulkCollision.Visible = false;
            }
            if (RockCollision != null)
            {
                RockCollision.Visible = false;
            }
            for (int i = CannonballList.Count - 1; i > -1; i--)
            {
                CannonballList[i].Destroy();
            }
            ButtonAddBoat.RemoveFromManagers();
            SpeedMeter.RemoveFromManagers();
            for (int i = ExplosionList.Count - 1; i > -1; i--)
            {
                ExplosionList[i].Destroy();
            }
        }
        public virtual void AssignCustomVariables (bool callOnContainedElements) 
        {
            if (callOnContainedElements)
            {
                PlayerBoat.AssignCustomVariables(true);
                PlayerInstance.AssignCustomVariables(true);
                ButtonAddBoat.AssignCustomVariables(true);
                SpeedMeter.AssignCustomVariables(true);
            }
            if (PlayerBoat.Parent == null)
            {
                PlayerBoat.X = 300f;
            }
            else
            {
                PlayerBoat.RelativeX = 300f;
            }
            if (PlayerBoat.Parent == null)
            {
                PlayerBoat.Y = -300f;
            }
            else
            {
                PlayerBoat.RelativeY = -300f;
            }
            if (PlayerBoat.Parent == null)
            {
                PlayerBoat.Z = 10f;
            }
            else
            {
                PlayerBoat.RelativeZ = 10f;
            }
            PlayerBoat.RotationAcceleration = 0.025f;
            PlayerBoat.MaxRotationSpeed = 1f;
            PlayerBoat.MovementSpeed = 33f;
            PlayerBoat.MaxHealth = 250f;
            PlayerBoat.CurrentHealth = 250f;
            PlayerBoat.TimeBetweenShoot = 1f;
            PlayerBoat.LastTimeShot = 0f;
            if (PlayerInstance.Parent == null)
            {
                PlayerInstance.Z = 10f;
            }
            else
            {
                PlayerInstance.RelativeZ = 10f;
            }
            PlayerInstance.WalkingSpeed = 25f;
            PlayerInstance.WalkingSpeedModifier = 1f;
            SandCollision.Visible = false;
            WaterCollision.Visible = false;
            DirtCollision.Visible = false;
            HulkCollision.Visible = false;
            RockCollision.Visible = false;
            if (ButtonAddBoat.Parent == null)
            {
                ButtonAddBoat.Z = 20f;
            }
            else
            {
                ButtonAddBoat.RelativeZ = 20f;
            }
            ButtonAddBoat.Text = "Ajouter un bateau";
            SpeedMeter.MaxState = 5;
        }
        public virtual void ConvertToManuallyUpdated () 
        {
            PlayerBoat.ConvertToManuallyUpdated();
            for (int i = 0; i < BoatList.Count; i++)
            {
                BoatList[i].ConvertToManuallyUpdated();
            }
            for (int i = 0; i < DockList.Count; i++)
            {
                DockList[i].ConvertToManuallyUpdated();
            }
            PlayerInstance.ConvertToManuallyUpdated();
            for (int i = 0; i < CannonballList.Count; i++)
            {
                CannonballList[i].ConvertToManuallyUpdated();
            }
            ButtonAddBoat.ConvertToManuallyUpdated();
            SpeedMeter.ConvertToManuallyUpdated();
            for (int i = 0; i < ExplosionList.Count; i++)
            {
                ExplosionList[i].ConvertToManuallyUpdated();
            }
        }
        public static void LoadStaticContent (string contentManagerName) 
        {
            if (string.IsNullOrEmpty(contentManagerName))
            {
                throw new System.ArgumentException("contentManagerName cannot be empty or null");
            }
            // Set the content manager for Gum
            var contentManagerWrapper = new FlatRedBall.Gum.ContentManagerWrapper();
            contentManagerWrapper.ContentManagerName = contentManagerName;
            RenderingLibrary.Content.LoaderManager.Self.ContentLoader = contentManagerWrapper;
            // Access the GumProject just in case it's async loaded
            var throwaway = GlobalContent.GumProject;
            #if DEBUG
            if (contentManagerName == FlatRedBall.FlatRedBallServices.GlobalContentManager)
            {
                HasBeenLoadedWithGlobalContentManager = true;
            }
            else if (HasBeenLoadedWithGlobalContentManager)
            {
                throw new System.Exception("This type has been loaded with a Global content manager, then loaded with a non-global.  This can lead to a lot of bugs");
            }
            #endif
            Terrain = FlatRedBall.TileGraphics.LayeredTileMap.FromTiledMapSave("content/screens/gamescreen/terrain.tmx", contentManagerName);
            FlatRedBall.Gum.GumIdb.UpdateDisplayToMainFrbCamera();GameScreenGum = GumRuntime.ElementSaveExtensions.CreateGueForElement( Gum.Managers.ObjectFinder.Self.GetScreen(FlatRedBall.IO.FileManager.RemoveExtension(FlatRedBall.IO.FileManager.RemovePath("content/gumproject/screens/gamescreengum.gusx"))), true);
            Pirates.Entities.Boat.LoadStaticContent(contentManagerName);
            Pirates.Entities.Player.LoadStaticContent(contentManagerName);
            Pirates.Entities.UI.Button.LoadStaticContent(contentManagerName);
            Pirates.Entities.UI.SpeedMeter.LoadStaticContent(contentManagerName);
            CustomLoadStaticContent(contentManagerName);
        }
        public override void PauseThisScreen () 
        {
            StateInterpolationPlugin.TweenerManager.Self.Pause();
            base.PauseThisScreen();
        }
        public override void UnpauseThisScreen () 
        {
            StateInterpolationPlugin.TweenerManager.Self.Unpause();
            base.UnpauseThisScreen();
        }
        [System.Obsolete("Use GetFile instead")]
        public static object GetStaticMember (string memberName) 
        {
            switch(memberName)
            {
                case  "Terrain":
                    return Terrain;
                case  "GameScreenGum":
                    return GameScreenGum;
            }
            return null;
        }
        public static object GetFile (string memberName) 
        {
            switch(memberName)
            {
                case  "Terrain":
                    return Terrain;
                case  "GameScreenGum":
                    return GameScreenGum;
            }
            return null;
        }
        object GetMember (string memberName) 
        {
            switch(memberName)
            {
                case  "Terrain":
                    return Terrain;
                case  "GameScreenGum":
                    return GameScreenGum;
            }
            return null;
        }
        private void RefreshLayoutInternal (object sender, EventArgs e) 
        {
            GameScreenGum.UpdateLayout();
        }
    }
}