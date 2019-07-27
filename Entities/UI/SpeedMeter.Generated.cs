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
namespace Pirates.Entities.UI
{
    public partial class SpeedMeter : FlatRedBall.PositionedObject, FlatRedBall.Graphics.IDestroyable
    {
        // This is made static so that static lazy-loaded content can access it.
        public static string ContentManagerName { get; set; }
        #if DEBUG
        static bool HasBeenLoadedWithGlobalContentManager = false;
        #endif
        static object mLockObject = new object();
        static System.Collections.Generic.List<string> mRegisteredUnloads = new System.Collections.Generic.List<string>();
        static System.Collections.Generic.List<string> LoadedContentManagers = new System.Collections.Generic.List<string>();
        protected static Microsoft.Xna.Framework.Graphics.Texture2D SpeedMeterSprite;
        protected static Microsoft.Xna.Framework.Graphics.Texture2D SpeedMeterStateSprite;
        
        private FlatRedBall.Sprite SpeedMeterSpriteInstance;
        private FlatRedBall.Sprite StateSpriteInstance;
        public int State;
        public int MaxState;
        protected FlatRedBall.Graphics.Layer LayerProvidedByContainer = null;
        public SpeedMeter () 
        	: this(FlatRedBall.Screens.ScreenManager.CurrentScreen.ContentManagerName, true)
        {
        }
        public SpeedMeter (string contentManagerName) 
        	: this(contentManagerName, true)
        {
        }
        public SpeedMeter (string contentManagerName, bool addToManagers) 
        	: base()
        {
            ContentManagerName = contentManagerName;
            InitializeEntity(addToManagers);
        }
        protected virtual void InitializeEntity (bool addToManagers) 
        {
            LoadStaticContent(ContentManagerName);
            SpeedMeterSpriteInstance = new FlatRedBall.Sprite();
            SpeedMeterSpriteInstance.Name = "SpeedMeterSpriteInstance";
            StateSpriteInstance = new FlatRedBall.Sprite();
            StateSpriteInstance.Name = "StateSpriteInstance";
            
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
            FlatRedBall.SpriteManager.AddToLayer(SpeedMeterSpriteInstance, LayerProvidedByContainer);
            FlatRedBall.SpriteManager.AddToLayer(StateSpriteInstance, LayerProvidedByContainer);
        }
        public virtual void AddToManagers (FlatRedBall.Graphics.Layer layerToAddTo) 
        {
            LayerProvidedByContainer = layerToAddTo;
            FlatRedBall.SpriteManager.AddPositionedObject(this);
            FlatRedBall.SpriteManager.AddToLayer(SpeedMeterSpriteInstance, LayerProvidedByContainer);
            FlatRedBall.SpriteManager.AddToLayer(StateSpriteInstance, LayerProvidedByContainer);
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
            
            if (SpeedMeterSpriteInstance != null)
            {
                FlatRedBall.SpriteManager.RemoveSprite(SpeedMeterSpriteInstance);
            }
            if (StateSpriteInstance != null)
            {
                FlatRedBall.SpriteManager.RemoveSprite(StateSpriteInstance);
            }
            CustomDestroy();
        }
        public virtual void PostInitialize () 
        {
            bool oldShapeManagerSuppressAdd = FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue;
            FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = true;
            if (SpeedMeterSpriteInstance.Parent == null)
            {
                SpeedMeterSpriteInstance.CopyAbsoluteToRelative();
                SpeedMeterSpriteInstance.AttachTo(this, false);
            }
            if (SpeedMeterSpriteInstance.Parent == null)
            {
                SpeedMeterSpriteInstance.Z = 15f;
            }
            else
            {
                SpeedMeterSpriteInstance.RelativeZ = 15f;
            }
            SpeedMeterSpriteInstance.Texture = SpeedMeterSprite;
            SpeedMeterSpriteInstance.TextureScale = 1f;
            if (StateSpriteInstance.Parent == null)
            {
                StateSpriteInstance.CopyAbsoluteToRelative();
                StateSpriteInstance.AttachTo(this, false);
            }
            if (StateSpriteInstance.Parent == null)
            {
                StateSpriteInstance.Z = 15f;
            }
            else
            {
                StateSpriteInstance.RelativeZ = 15f;
            }
            StateSpriteInstance.Texture = SpeedMeterStateSprite;
            StateSpriteInstance.TextureScale = 1f;
            FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = oldShapeManagerSuppressAdd;
        }
        public virtual void AddToManagersBottomUp (FlatRedBall.Graphics.Layer layerToAddTo) 
        {
            AssignCustomVariables(false);
        }
        public virtual void RemoveFromManagers () 
        {
            FlatRedBall.SpriteManager.ConvertToManuallyUpdated(this);
            if (SpeedMeterSpriteInstance != null)
            {
                FlatRedBall.SpriteManager.RemoveSpriteOneWay(SpeedMeterSpriteInstance);
            }
            if (StateSpriteInstance != null)
            {
                FlatRedBall.SpriteManager.RemoveSpriteOneWay(StateSpriteInstance);
            }
        }
        public virtual void AssignCustomVariables (bool callOnContainedElements) 
        {
            if (callOnContainedElements)
            {
            }
            if (SpeedMeterSpriteInstance.Parent == null)
            {
                SpeedMeterSpriteInstance.Z = 15f;
            }
            else
            {
                SpeedMeterSpriteInstance.RelativeZ = 15f;
            }
            SpeedMeterSpriteInstance.Texture = SpeedMeterSprite;
            SpeedMeterSpriteInstance.TextureScale = 1f;
            if (StateSpriteInstance.Parent == null)
            {
                StateSpriteInstance.Z = 15f;
            }
            else
            {
                StateSpriteInstance.RelativeZ = 15f;
            }
            StateSpriteInstance.Texture = SpeedMeterStateSprite;
            StateSpriteInstance.TextureScale = 1f;
            if (Parent == null)
            {
                Z = 20f;
            }
            else if (Parent is FlatRedBall.Camera)
            {
                RelativeZ = 20f - 40.0f;
            }
            else
            {
                RelativeZ = 20f;
            }
        }
        public virtual void ConvertToManuallyUpdated () 
        {
            this.ForceUpdateDependenciesDeep();
            FlatRedBall.SpriteManager.ConvertToManuallyUpdated(this);
            FlatRedBall.SpriteManager.ConvertToManuallyUpdated(SpeedMeterSpriteInstance);
            FlatRedBall.SpriteManager.ConvertToManuallyUpdated(StateSpriteInstance);
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
                        FlatRedBall.FlatRedBallServices.GetContentManagerByName(ContentManagerName).AddUnloadMethod("SpeedMeterStaticUnload", UnloadStaticContent);
                        mRegisteredUnloads.Add(ContentManagerName);
                    }
                }
                if (!FlatRedBall.FlatRedBallServices.IsLoaded<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/entities/ui/speedmeter/speedmetersprite.png", ContentManagerName))
                {
                    registerUnload = true;
                }
                SpeedMeterSprite = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/entities/ui/speedmeter/speedmetersprite.png", ContentManagerName);
                if (!FlatRedBall.FlatRedBallServices.IsLoaded<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/entities/ui/speedmeter/speedmeterstatesprite.png", ContentManagerName))
                {
                    registerUnload = true;
                }
                SpeedMeterStateSprite = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/entities/ui/speedmeter/speedmeterstatesprite.png", ContentManagerName);
            }
            if (registerUnload && ContentManagerName != FlatRedBall.FlatRedBallServices.GlobalContentManager)
            {
                lock (mLockObject)
                {
                    if (!mRegisteredUnloads.Contains(ContentManagerName) && ContentManagerName != FlatRedBall.FlatRedBallServices.GlobalContentManager)
                    {
                        FlatRedBall.FlatRedBallServices.GetContentManagerByName(ContentManagerName).AddUnloadMethod("SpeedMeterStaticUnload", UnloadStaticContent);
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
                if (SpeedMeterSprite != null)
                {
                    SpeedMeterSprite= null;
                }
                if (SpeedMeterStateSprite != null)
                {
                    SpeedMeterStateSprite= null;
                }
            }
        }
        [System.Obsolete("Use GetFile instead")]
        public static object GetStaticMember (string memberName) 
        {
            switch(memberName)
            {
                case  "SpeedMeterSprite":
                    return SpeedMeterSprite;
                case  "SpeedMeterStateSprite":
                    return SpeedMeterStateSprite;
            }
            return null;
        }
        public static object GetFile (string memberName) 
        {
            switch(memberName)
            {
                case  "SpeedMeterSprite":
                    return SpeedMeterSprite;
                case  "SpeedMeterStateSprite":
                    return SpeedMeterStateSprite;
            }
            return null;
        }
        object GetMember (string memberName) 
        {
            switch(memberName)
            {
                case  "SpeedMeterSprite":
                    return SpeedMeterSprite;
                case  "SpeedMeterStateSprite":
                    return SpeedMeterStateSprite;
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
            FlatRedBall.Instructions.InstructionManager.IgnorePausingFor(SpeedMeterSpriteInstance);
            FlatRedBall.Instructions.InstructionManager.IgnorePausingFor(StateSpriteInstance);
        }
        public virtual void MoveToLayer (FlatRedBall.Graphics.Layer layerToMoveTo) 
        {
            var layerToRemoveFrom = LayerProvidedByContainer;
            if (layerToRemoveFrom != null)
            {
                layerToRemoveFrom.Remove(SpeedMeterSpriteInstance);
            }
            FlatRedBall.SpriteManager.AddToLayer(SpeedMeterSpriteInstance, layerToMoveTo);
            if (layerToRemoveFrom != null)
            {
                layerToRemoveFrom.Remove(StateSpriteInstance);
            }
            FlatRedBall.SpriteManager.AddToLayer(StateSpriteInstance, layerToMoveTo);
            LayerProvidedByContainer = layerToMoveTo;
        }
    }
}
