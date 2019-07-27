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
    public partial class Player : FlatRedBall.PositionedObject, FlatRedBall.Graphics.IDestroyable, FlatRedBall.Graphics.IVisible, FlatRedBall.Math.Geometry.ICollidable
    {
        // This is made static so that static lazy-loaded content can access it.
        public static string ContentManagerName { get; set; }
        #if DEBUG
        static bool HasBeenLoadedWithGlobalContentManager = false;
        #endif
        static object mLockObject = new object();
        static System.Collections.Generic.List<string> mRegisteredUnloads = new System.Collections.Generic.List<string>();
        static System.Collections.Generic.List<string> LoadedContentManagers = new System.Collections.Generic.List<string>();
        protected static Microsoft.Xna.Framework.Graphics.Texture2D PlayerSprite;
        protected static FlatRedBall.Graphics.Animation.AnimationChainList PlayerAnimationFile;
        
        private FlatRedBall.Sprite SpriteInstance;
        private FlatRedBall.Graphics.Text TextInstance;
        private FlatRedBall.Math.Geometry.AxisAlignedRectangle mHitbox;
        public FlatRedBall.Math.Geometry.AxisAlignedRectangle Hitbox
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
        public float WalkingSpeed;
        public float WalkingSpeedModifier;
        public event System.EventHandler BeforeVisibleSet;
        public event System.EventHandler AfterVisibleSet;
        protected bool mVisible = true;
        public virtual bool Visible
        {
            get
            {
                return mVisible;
            }
            set
            {
                if (BeforeVisibleSet != null)
                {
                    BeforeVisibleSet(this, null);
                }
                mVisible = value;
                if (AfterVisibleSet != null)
                {
                    AfterVisibleSet(this, null);
                }
            }
        }
        public bool IgnoresParentVisibility { get; set; }
        public bool AbsoluteVisible
        {
            get
            {
                return Visible && (Parent == null || IgnoresParentVisibility || Parent is FlatRedBall.Graphics.IVisible == false || (Parent as FlatRedBall.Graphics.IVisible).AbsoluteVisible);
            }
        }
        FlatRedBall.Graphics.IVisible FlatRedBall.Graphics.IVisible.Parent
        {
            get
            {
                if (this.Parent != null && this.Parent is FlatRedBall.Graphics.IVisible)
                {
                    return this.Parent as FlatRedBall.Graphics.IVisible;
                }
                else
                {
                    return null;
                }
            }
        }
        private FlatRedBall.Math.Geometry.ShapeCollection mGeneratedCollision;
        public FlatRedBall.Math.Geometry.ShapeCollection Collision
        {
            get
            {
                return mGeneratedCollision;
            }
        }
        protected FlatRedBall.Graphics.Layer LayerProvidedByContainer = null;
        public Player () 
        	: this(FlatRedBall.Screens.ScreenManager.CurrentScreen.ContentManagerName, true)
        {
        }
        public Player (string contentManagerName) 
        	: this(contentManagerName, true)
        {
        }
        public Player (string contentManagerName, bool addToManagers) 
        	: base()
        {
            ContentManagerName = contentManagerName;
            InitializeEntity(addToManagers);
        }
        protected virtual void InitializeEntity (bool addToManagers) 
        {
            LoadStaticContent(ContentManagerName);
            SpriteInstance = new FlatRedBall.Sprite();
            SpriteInstance.Name = "SpriteInstance";
            TextInstance = new FlatRedBall.Graphics.Text();
            TextInstance.Name = "TextInstance";
            mHitbox = new FlatRedBall.Math.Geometry.AxisAlignedRectangle();
            mHitbox.Name = "mHitbox";
            
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
            FlatRedBall.SpriteManager.AddToLayer(SpriteInstance, LayerProvidedByContainer);
            FlatRedBall.Graphics.TextManager.AddToLayer(TextInstance, LayerProvidedByContainer);
            if (TextInstance.Font != null)
            {
                TextInstance.SetPixelPerfectScale(LayerProvidedByContainer);
            }
            FlatRedBall.Math.Geometry.ShapeManager.AddToLayer(mHitbox, LayerProvidedByContainer);
        }
        public virtual void AddToManagers (FlatRedBall.Graphics.Layer layerToAddTo) 
        {
            LayerProvidedByContainer = layerToAddTo;
            FlatRedBall.SpriteManager.AddPositionedObject(this);
            FlatRedBall.SpriteManager.AddToLayer(SpriteInstance, LayerProvidedByContainer);
            FlatRedBall.Graphics.TextManager.AddToLayer(TextInstance, LayerProvidedByContainer);
            if (TextInstance.Font != null)
            {
                TextInstance.SetPixelPerfectScale(LayerProvidedByContainer);
            }
            FlatRedBall.Math.Geometry.ShapeManager.AddToLayer(mHitbox, LayerProvidedByContainer);
            AddToManagersBottomUp(layerToAddTo);
            CustomInitialize();
        }
        public virtual void Activity () 
        {
            
            CustomActivity();
        }
        public virtual void Destroy () 
        {
            FlatRedBall.SpriteManager.RemovePositionedObject(this);
            
            if (SpriteInstance != null)
            {
                FlatRedBall.SpriteManager.RemoveSprite(SpriteInstance);
            }
            if (TextInstance != null)
            {
                FlatRedBall.Graphics.TextManager.RemoveText(TextInstance);
            }
            if (Hitbox != null)
            {
                FlatRedBall.Math.Geometry.ShapeManager.Remove(Hitbox);
            }
            mGeneratedCollision.RemoveFromManagers(clearThis: false);
            CustomDestroy();
        }
        public virtual void PostInitialize () 
        {
            bool oldShapeManagerSuppressAdd = FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue;
            FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = true;
            if (SpriteInstance.Parent == null)
            {
                SpriteInstance.CopyAbsoluteToRelative();
                SpriteInstance.AttachTo(this, false);
            }
            if (SpriteInstance.Parent == null)
            {
                SpriteInstance.Z = 10f;
            }
            else
            {
                SpriteInstance.RelativeZ = 10f;
            }
            SpriteInstance.Texture = null;
            SpriteInstance.TextureScale = 0.75f;
            SpriteInstance.AnimationChains = PlayerAnimationFile;
            SpriteInstance.CurrentChainName = "Idle";
            if (TextInstance.Parent == null)
            {
                TextInstance.CopyAbsoluteToRelative();
                TextInstance.AttachTo(this, false);
            }
            TextInstance.DisplayText = "Player";
            TextInstance.HorizontalAlignment = FlatRedBall.Graphics.HorizontalAlignment.Center;
            if (TextInstance.Parent == null)
            {
                TextInstance.Y = 32f;
            }
            else
            {
                TextInstance.RelativeY = 32f;
            }
            if (mHitbox.Parent == null)
            {
                mHitbox.CopyAbsoluteToRelative();
                mHitbox.AttachTo(this, false);
            }
            if (Hitbox.Parent == null)
            {
                Hitbox.Z = 15f;
            }
            else
            {
                Hitbox.RelativeZ = 15f;
            }
            Hitbox.Width = 32f;
            Hitbox.Height = 32f;
            Hitbox.Visible = false;
            Hitbox.RepositionDirections = FlatRedBall.Math.Geometry.RepositionDirections.All;
            mGeneratedCollision = new FlatRedBall.Math.Geometry.ShapeCollection();
            mGeneratedCollision.AxisAlignedRectangles.AddOneWay(mHitbox);
            FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = oldShapeManagerSuppressAdd;
        }
        public virtual void AddToManagersBottomUp (FlatRedBall.Graphics.Layer layerToAddTo) 
        {
            AssignCustomVariables(false);
        }
        public virtual void RemoveFromManagers () 
        {
            FlatRedBall.SpriteManager.ConvertToManuallyUpdated(this);
            if (SpriteInstance != null)
            {
                FlatRedBall.SpriteManager.RemoveSpriteOneWay(SpriteInstance);
            }
            if (TextInstance != null)
            {
                FlatRedBall.Graphics.TextManager.RemoveTextOneWay(TextInstance);
            }
            if (Hitbox != null)
            {
                FlatRedBall.Math.Geometry.ShapeManager.RemoveOneWay(Hitbox);
            }
            mGeneratedCollision.RemoveFromManagers(clearThis: false);
        }
        public virtual void AssignCustomVariables (bool callOnContainedElements) 
        {
            if (callOnContainedElements)
            {
            }
            if (SpriteInstance.Parent == null)
            {
                SpriteInstance.Z = 10f;
            }
            else
            {
                SpriteInstance.RelativeZ = 10f;
            }
            SpriteInstance.Texture = null;
            SpriteInstance.TextureScale = 0.75f;
            SpriteInstance.AnimationChains = PlayerAnimationFile;
            SpriteInstance.CurrentChainName = "Idle";
            TextInstance.DisplayText = "Player";
            TextInstance.HorizontalAlignment = FlatRedBall.Graphics.HorizontalAlignment.Center;
            if (TextInstance.Parent == null)
            {
                TextInstance.Y = 32f;
            }
            else
            {
                TextInstance.RelativeY = 32f;
            }
            if (Hitbox.Parent == null)
            {
                Hitbox.Z = 15f;
            }
            else
            {
                Hitbox.RelativeZ = 15f;
            }
            Hitbox.Width = 32f;
            Hitbox.Height = 32f;
            Hitbox.Visible = false;
            Hitbox.RepositionDirections = FlatRedBall.Math.Geometry.RepositionDirections.All;
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
        }
        public virtual void ConvertToManuallyUpdated () 
        {
            this.ForceUpdateDependenciesDeep();
            FlatRedBall.SpriteManager.ConvertToManuallyUpdated(this);
            FlatRedBall.SpriteManager.ConvertToManuallyUpdated(SpriteInstance);
            FlatRedBall.Graphics.TextManager.ConvertToManuallyUpdated(TextInstance);
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
                        FlatRedBall.FlatRedBallServices.GetContentManagerByName(ContentManagerName).AddUnloadMethod("PlayerStaticUnload", UnloadStaticContent);
                        mRegisteredUnloads.Add(ContentManagerName);
                    }
                }
                if (!FlatRedBall.FlatRedBallServices.IsLoaded<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/entities/player/playersprite.png", ContentManagerName))
                {
                    registerUnload = true;
                }
                PlayerSprite = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/entities/player/playersprite.png", ContentManagerName);
                if (!FlatRedBall.FlatRedBallServices.IsLoaded<FlatRedBall.Graphics.Animation.AnimationChainList>(@"content/entities/player/playeranimationfile.achx", ContentManagerName))
                {
                    registerUnload = true;
                }
                PlayerAnimationFile = FlatRedBall.FlatRedBallServices.Load<FlatRedBall.Graphics.Animation.AnimationChainList>(@"content/entities/player/playeranimationfile.achx", ContentManagerName);
            }
            if (registerUnload && ContentManagerName != FlatRedBall.FlatRedBallServices.GlobalContentManager)
            {
                lock (mLockObject)
                {
                    if (!mRegisteredUnloads.Contains(ContentManagerName) && ContentManagerName != FlatRedBall.FlatRedBallServices.GlobalContentManager)
                    {
                        FlatRedBall.FlatRedBallServices.GetContentManagerByName(ContentManagerName).AddUnloadMethod("PlayerStaticUnload", UnloadStaticContent);
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
                if (PlayerSprite != null)
                {
                    PlayerSprite= null;
                }
                if (PlayerAnimationFile != null)
                {
                    PlayerAnimationFile= null;
                }
            }
        }
        [System.Obsolete("Use GetFile instead")]
        public static object GetStaticMember (string memberName) 
        {
            switch(memberName)
            {
                case  "PlayerSprite":
                    return PlayerSprite;
                case  "PlayerAnimationFile":
                    return PlayerAnimationFile;
            }
            return null;
        }
        public static object GetFile (string memberName) 
        {
            switch(memberName)
            {
                case  "PlayerSprite":
                    return PlayerSprite;
                case  "PlayerAnimationFile":
                    return PlayerAnimationFile;
            }
            return null;
        }
        object GetMember (string memberName) 
        {
            switch(memberName)
            {
                case  "PlayerSprite":
                    return PlayerSprite;
                case  "PlayerAnimationFile":
                    return PlayerAnimationFile;
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
            FlatRedBall.Instructions.InstructionManager.IgnorePausingFor(SpriteInstance);
            FlatRedBall.Instructions.InstructionManager.IgnorePausingFor(TextInstance);
            FlatRedBall.Instructions.InstructionManager.IgnorePausingFor(Hitbox);
        }
        public virtual void MoveToLayer (FlatRedBall.Graphics.Layer layerToMoveTo) 
        {
            var layerToRemoveFrom = LayerProvidedByContainer;
            if (layerToRemoveFrom != null)
            {
                layerToRemoveFrom.Remove(SpriteInstance);
            }
            FlatRedBall.SpriteManager.AddToLayer(SpriteInstance, layerToMoveTo);
            if (layerToRemoveFrom != null)
            {
                layerToRemoveFrom.Remove(TextInstance);
            }
            FlatRedBall.Graphics.TextManager.AddToLayer(TextInstance, layerToMoveTo);
            if (layerToRemoveFrom != null)
            {
                layerToRemoveFrom.Remove(Hitbox);
            }
            FlatRedBall.Math.Geometry.ShapeManager.AddToLayer(Hitbox, layerToMoveTo);
            LayerProvidedByContainer = layerToMoveTo;
        }
    }
    public static class PlayerExtensionMethods
    {
        public static void SetVisible (this FlatRedBall.Math.PositionedObjectList<Player> list, bool value) 
        {
            int count = list.Count;
            for (int i = 0; i < count; i++)
            {
                list[i].Visible = value;
            }
        }
    }
}
