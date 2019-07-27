#if ANDROID || IOS || DESKTOP_GL
#define REQUIRES_PRIMARY_THREAD_LOADING
#endif
using Color = Microsoft.Xna.Framework.Color;
using System.Linq;
using FlatRedBall.Graphics;
using FlatRedBall.Math;
using FlatRedBall;
using System;
using System.Collections.Generic;
using System.Text;
using FlatRedBall.Math.Geometry;
namespace Pirates.Entities
{
    public partial class Boat : FlatRedBall.PositionedObject, FlatRedBall.Graphics.IDestroyable, FlatRedBall.Math.Geometry.ICollidable
    {
        // This is made static so that static lazy-loaded content can access it.
        public static string ContentManagerName { get; set; }
        #if DEBUG
        static bool HasBeenLoadedWithGlobalContentManager = false;
        #endif
        static object mLockObject = new object();
        static System.Collections.Generic.List<string> mRegisteredUnloads = new System.Collections.Generic.List<string>();
        static System.Collections.Generic.List<string> LoadedContentManagers = new System.Collections.Generic.List<string>();
        protected static Microsoft.Xna.Framework.Graphics.Texture2D BoatSprite;
        protected static Microsoft.Xna.Framework.Graphics.Texture2D AnchorSprite;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect fire;
        
        private FlatRedBall.Sprite BoatSpriteInstance;
        private FlatRedBall.Math.Geometry.Polygon mHitbox;
        public FlatRedBall.Math.Geometry.Polygon Hitbox
        {
            get
            {
                return mHitbox;
            }
            private set
            {
                mHitbox = value;
            }
        }
        private FlatRedBall.Sprite AnchorSpriteInstance;
        private FlatRedBall.Math.PositionedObjectList<Pirates.Entities.Cannonball> CannonballList;
        public float RotationAcceleration;
        public float MaxRotationSpeed;
        public float MovementSpeed;
        public int SpeedScale = 0;
        public bool Anchored;
        public float MaxHealth;
        public float CurrentHealth;
        public bool IsDead;
        public float TimeBetweenShoot;
        public float LastTimeShot;
        private FlatRedBall.Math.Geometry.ShapeCollection mGeneratedCollision;
        public FlatRedBall.Math.Geometry.ShapeCollection Collision
        {
            get
            {
                return mGeneratedCollision;
            }
        }
        protected FlatRedBall.Graphics.Layer LayerProvidedByContainer = null;
        public Boat () 
        	: this(FlatRedBall.Screens.ScreenManager.CurrentScreen.ContentManagerName, true)
        {
        }
        public Boat (string contentManagerName) 
        	: this(contentManagerName, true)
        {
        }
        public Boat (string contentManagerName, bool addToManagers) 
        	: base()
        {
            ContentManagerName = contentManagerName;
            InitializeEntity(addToManagers);
        }
        protected virtual void InitializeEntity (bool addToManagers) 
        {
            LoadStaticContent(ContentManagerName);
            BoatSpriteInstance = new FlatRedBall.Sprite();
            BoatSpriteInstance.Name = "BoatSpriteInstance";
            mHitbox = new FlatRedBall.Math.Geometry.Polygon();
            mHitbox.Name = "mHitbox";
            AnchorSpriteInstance = new FlatRedBall.Sprite();
            AnchorSpriteInstance.Name = "AnchorSpriteInstance";
            CannonballList = new FlatRedBall.Math.PositionedObjectList<Pirates.Entities.Cannonball>();
            CannonballList.Name = "CannonballList";
            
            PostInitialize();
            if (addToManagers)
            {
                AddToManagers(null);
            }
        }
        public virtual void ReAddToManagers (FlatRedBall.Graphics.Layer layerToAddTo) 
        {
            LayerProvidedByContainer = layerToAddTo;
            FlatRedBall.SpriteManager.AddPositionedObject(this);
            FlatRedBall.SpriteManager.AddToLayer(BoatSpriteInstance, LayerProvidedByContainer);
            FlatRedBall.Math.Geometry.ShapeManager.AddToLayer(mHitbox, LayerProvidedByContainer);
            FlatRedBall.SpriteManager.AddToLayer(AnchorSpriteInstance, LayerProvidedByContainer);
        }
        public virtual void AddToManagers (FlatRedBall.Graphics.Layer layerToAddTo) 
        {
            LayerProvidedByContainer = layerToAddTo;
            FlatRedBall.SpriteManager.AddPositionedObject(this);
            FlatRedBall.SpriteManager.AddToLayer(BoatSpriteInstance, LayerProvidedByContainer);
            FlatRedBall.Math.Geometry.ShapeManager.AddToLayer(mHitbox, LayerProvidedByContainer);
            FlatRedBall.SpriteManager.AddToLayer(AnchorSpriteInstance, LayerProvidedByContainer);
            AddToManagersBottomUp(layerToAddTo);
            CustomInitialize();
        }
        public virtual void Activity () 
        {
            
            for (int i = CannonballList.Count - 1; i > -1; i--)
            {
                if (i < CannonballList.Count)
                {
                    // We do the extra if-check because activity could destroy any number of entities
                    CannonballList[i].Activity();
                }
            }
            CustomActivity();
        }
        public virtual void Destroy () 
        {
            FlatRedBall.SpriteManager.RemovePositionedObject(this);
            
            CannonballList.MakeOneWay();
            if (BoatSpriteInstance != null)
            {
                FlatRedBall.SpriteManager.RemoveSprite(BoatSpriteInstance);
            }
            if (Hitbox != null)
            {
                FlatRedBall.Math.Geometry.ShapeManager.Remove(Hitbox);
            }
            if (AnchorSpriteInstance != null)
            {
                FlatRedBall.SpriteManager.RemoveSprite(AnchorSpriteInstance);
            }
            for (int i = CannonballList.Count - 1; i > -1; i--)
            {
                CannonballList[i].Destroy();
            }
            CannonballList.MakeTwoWay();
            mGeneratedCollision.RemoveFromManagers(clearThis: false);
            CustomDestroy();
        }
        public virtual void PostInitialize () 
        {
            bool oldShapeManagerSuppressAdd = FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue;
            FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = true;
            if (BoatSpriteInstance.Parent == null)
            {
                BoatSpriteInstance.CopyAbsoluteToRelative();
                BoatSpriteInstance.AttachTo(this, false);
            }
            if (BoatSpriteInstance.Parent == null)
            {
                BoatSpriteInstance.X = 0f;
            }
            else
            {
                BoatSpriteInstance.RelativeX = 0f;
            }
            if (BoatSpriteInstance.Parent == null)
            {
                BoatSpriteInstance.Y = 0f;
            }
            else
            {
                BoatSpriteInstance.RelativeY = 0f;
            }
            BoatSpriteInstance.Texture = BoatSprite;
            BoatSpriteInstance.TextureScale = 1f;
            if (mHitbox.Parent == null)
            {
                mHitbox.CopyAbsoluteToRelative();
                mHitbox.AttachTo(this, false);
            }
            Hitbox.Visible = false;
            FlatRedBall.Math.Geometry.Point[] HitboxPoints = new FlatRedBall.Math.Geometry.Point[] {new FlatRedBall.Math.Geometry.Point(13, 32), new FlatRedBall.Math.Geometry.Point(13, -32), new FlatRedBall.Math.Geometry.Point(-13, -32), new FlatRedBall.Math.Geometry.Point(-13, 32), new FlatRedBall.Math.Geometry.Point(13, 32) };
            Hitbox.Points = HitboxPoints;
            if (AnchorSpriteInstance.Parent == null)
            {
                AnchorSpriteInstance.CopyAbsoluteToRelative();
                AnchorSpriteInstance.AttachTo(this, false);
            }
            AnchorSpriteInstance.Texture = AnchorSprite;
            AnchorSpriteInstance.TextureScale = 0.5f;
            AnchorSpriteInstance.Visible = false;
            mGeneratedCollision = new FlatRedBall.Math.Geometry.ShapeCollection();
            mGeneratedCollision.Polygons.AddOneWay(mHitbox);
            FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = oldShapeManagerSuppressAdd;
        }
        public virtual void AddToManagersBottomUp (FlatRedBall.Graphics.Layer layerToAddTo) 
        {
            AssignCustomVariables(false);
        }
        public virtual void RemoveFromManagers () 
        {
            FlatRedBall.SpriteManager.ConvertToManuallyUpdated(this);
            if (BoatSpriteInstance != null)
            {
                FlatRedBall.SpriteManager.RemoveSpriteOneWay(BoatSpriteInstance);
            }
            if (Hitbox != null)
            {
                FlatRedBall.Math.Geometry.ShapeManager.RemoveOneWay(Hitbox);
            }
            if (AnchorSpriteInstance != null)
            {
                FlatRedBall.SpriteManager.RemoveSpriteOneWay(AnchorSpriteInstance);
            }
            for (int i = CannonballList.Count - 1; i > -1; i--)
            {
                CannonballList[i].Destroy();
            }
            mGeneratedCollision.RemoveFromManagers(clearThis: false);
        }
        public virtual void AssignCustomVariables (bool callOnContainedElements) 
        {
            if (callOnContainedElements)
            {
            }
            if (BoatSpriteInstance.Parent == null)
            {
                BoatSpriteInstance.X = 0f;
            }
            else
            {
                BoatSpriteInstance.RelativeX = 0f;
            }
            if (BoatSpriteInstance.Parent == null)
            {
                BoatSpriteInstance.Y = 0f;
            }
            else
            {
                BoatSpriteInstance.RelativeY = 0f;
            }
            BoatSpriteInstance.Texture = BoatSprite;
            BoatSpriteInstance.TextureScale = 1f;
            Hitbox.Visible = false;
            AnchorSpriteInstance.Texture = AnchorSprite;
            AnchorSpriteInstance.TextureScale = 0.5f;
            AnchorSpriteInstance.Visible = false;
            if (Parent == null)
            {
                Z = 15f;
            }
            else if (Parent is FlatRedBall.Camera)
            {
                RelativeZ = 15f - 40.0f;
            }
            else
            {
                RelativeZ = 15f;
            }
            SpeedScale = 0;
        }
        public virtual void ConvertToManuallyUpdated () 
        {
            this.ForceUpdateDependenciesDeep();
            FlatRedBall.SpriteManager.ConvertToManuallyUpdated(this);
            FlatRedBall.SpriteManager.ConvertToManuallyUpdated(BoatSpriteInstance);
            FlatRedBall.SpriteManager.ConvertToManuallyUpdated(AnchorSpriteInstance);
            for (int i = 0; i < CannonballList.Count; i++)
            {
                CannonballList[i].ConvertToManuallyUpdated();
            }
        }
        public static void LoadStaticContent (string contentManagerName) 
        {
            if (string.IsNullOrEmpty(contentManagerName))
            {
                throw new System.ArgumentException("contentManagerName cannot be empty or null");
            }
            ContentManagerName = contentManagerName;
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
            bool registerUnload = false;
            if (LoadedContentManagers.Contains(contentManagerName) == false)
            {
                LoadedContentManagers.Add(contentManagerName);
                lock (mLockObject)
                {
                    if (!mRegisteredUnloads.Contains(ContentManagerName) && ContentManagerName != FlatRedBall.FlatRedBallServices.GlobalContentManager)
                    {
                        FlatRedBall.FlatRedBallServices.GetContentManagerByName(ContentManagerName).AddUnloadMethod("BoatStaticUnload", UnloadStaticContent);
                        mRegisteredUnloads.Add(ContentManagerName);
                    }
                }
                if (!FlatRedBall.FlatRedBallServices.IsLoaded<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/sprites/boatsprite.png", ContentManagerName))
                {
                    registerUnload = true;
                }
                BoatSprite = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/sprites/boatsprite.png", ContentManagerName);
                if (!FlatRedBall.FlatRedBallServices.IsLoaded<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/entities/boat/anchorsprite.png", ContentManagerName))
                {
                    registerUnload = true;
                }
                AnchorSprite = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/entities/boat/anchorsprite.png", ContentManagerName);
                fire = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/boat/fire", ContentManagerName);
            }
            if (registerUnload && ContentManagerName != FlatRedBall.FlatRedBallServices.GlobalContentManager)
            {
                lock (mLockObject)
                {
                    if (!mRegisteredUnloads.Contains(ContentManagerName) && ContentManagerName != FlatRedBall.FlatRedBallServices.GlobalContentManager)
                    {
                        FlatRedBall.FlatRedBallServices.GetContentManagerByName(ContentManagerName).AddUnloadMethod("BoatStaticUnload", UnloadStaticContent);
                        mRegisteredUnloads.Add(ContentManagerName);
                    }
                }
            }
            CustomLoadStaticContent(contentManagerName);
        }
        public static void UnloadStaticContent () 
        {
            if (LoadedContentManagers.Count != 0)
            {
                LoadedContentManagers.RemoveAt(0);
                mRegisteredUnloads.RemoveAt(0);
            }
            if (LoadedContentManagers.Count == 0)
            {
                if (BoatSprite != null)
                {
                    BoatSprite= null;
                }
                if (AnchorSprite != null)
                {
                    AnchorSprite= null;
                }
                if (fire != null)
                {
                    fire= null;
                }
            }
        }
        [System.Obsolete("Use GetFile instead")]
        public static object GetStaticMember (string memberName) 
        {
            switch(memberName)
            {
                case  "BoatSprite":
                    return BoatSprite;
                case  "AnchorSprite":
                    return AnchorSprite;
                case  "fire":
                    return fire;
            }
            return null;
        }
        public static object GetFile (string memberName) 
        {
            switch(memberName)
            {
                case  "BoatSprite":
                    return BoatSprite;
                case  "AnchorSprite":
                    return AnchorSprite;
                case  "fire":
                    return fire;
            }
            return null;
        }
        object GetMember (string memberName) 
        {
            switch(memberName)
            {
                case  "BoatSprite":
                    return BoatSprite;
                case  "AnchorSprite":
                    return AnchorSprite;
                case  "fire":
                    return fire;
            }
            return null;
        }
        protected bool mIsPaused;
        public override void Pause (FlatRedBall.Instructions.InstructionList instructions) 
        {
            base.Pause(instructions);
            mIsPaused = true;
        }
        public virtual void SetToIgnorePausing () 
        {
            FlatRedBall.Instructions.InstructionManager.IgnorePausingFor(this);
            FlatRedBall.Instructions.InstructionManager.IgnorePausingFor(BoatSpriteInstance);
            FlatRedBall.Instructions.InstructionManager.IgnorePausingFor(Hitbox);
            FlatRedBall.Instructions.InstructionManager.IgnorePausingFor(AnchorSpriteInstance);
        }
        public virtual void MoveToLayer (FlatRedBall.Graphics.Layer layerToMoveTo) 
        {
            var layerToRemoveFrom = LayerProvidedByContainer;
            if (layerToRemoveFrom != null)
            {
                layerToRemoveFrom.Remove(BoatSpriteInstance);
            }
            FlatRedBall.SpriteManager.AddToLayer(BoatSpriteInstance, layerToMoveTo);
            if (layerToRemoveFrom != null)
            {
                layerToRemoveFrom.Remove(Hitbox);
            }
            FlatRedBall.Math.Geometry.ShapeManager.AddToLayer(Hitbox, layerToMoveTo);
            if (layerToRemoveFrom != null)
            {
                layerToRemoveFrom.Remove(AnchorSpriteInstance);
            }
            FlatRedBall.SpriteManager.AddToLayer(AnchorSpriteInstance, layerToMoveTo);
            LayerProvidedByContainer = layerToMoveTo;
        }
    }
}
