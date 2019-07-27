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
    public partial class Dock : FlatRedBall.PositionedObject, FlatRedBall.Graphics.IDestroyable, FlatRedBall.Performance.IPoolable
    {
        // This is made static so that static lazy-loaded content can access it.
        public static string ContentManagerName { get; set; }
        #if DEBUG
        static bool HasBeenLoadedWithGlobalContentManager = false;
        #endif
        static object mLockObject = new object();
        static System.Collections.Generic.List<string> mRegisteredUnloads = new System.Collections.Generic.List<string>();
        static System.Collections.Generic.List<string> LoadedContentManagers = new System.Collections.Generic.List<string>();
        
        private FlatRedBall.Graphics.Text TextInstance;
        private FlatRedBall.Math.Geometry.Circle mCircleInstance;
        public FlatRedBall.Math.Geometry.Circle CircleInstance
        {
            get
            {
                return mCircleInstance;
            }
            private set
            {
                mCircleInstance = value;
            }
        }
        public int IslandID;
        public event System.EventHandler BoatNearDock;
        public int Index { get; set; }
        public bool Used { get; set; }
        protected FlatRedBall.Graphics.Layer LayerProvidedByContainer = null;
        public Dock () 
        	: this(FlatRedBall.Screens.ScreenManager.CurrentScreen.ContentManagerName, true)
        {
        }
        public Dock (string contentManagerName) 
        	: this(contentManagerName, true)
        {
        }
        public Dock (string contentManagerName, bool addToManagers) 
        	: base()
        {
            ContentManagerName = contentManagerName;
            InitializeEntity(addToManagers);
        }
        protected virtual void InitializeEntity (bool addToManagers) 
        {
            LoadStaticContent(ContentManagerName);
            TextInstance = new FlatRedBall.Graphics.Text();
            TextInstance.Name = "TextInstance";
            mCircleInstance = new FlatRedBall.Math.Geometry.Circle();
            mCircleInstance.Name = "mCircleInstance";
            
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
            FlatRedBall.Graphics.TextManager.AddToLayer(TextInstance, LayerProvidedByContainer);
            if (TextInstance.Font != null)
            {
                TextInstance.SetPixelPerfectScale(LayerProvidedByContainer);
            }
            FlatRedBall.Math.Geometry.ShapeManager.AddToLayer(mCircleInstance, LayerProvidedByContainer);
        }
        public virtual void AddToManagers (FlatRedBall.Graphics.Layer layerToAddTo) 
        {
            LayerProvidedByContainer = layerToAddTo;
            FlatRedBall.SpriteManager.AddPositionedObject(this);
            FlatRedBall.Graphics.TextManager.AddToLayer(TextInstance, LayerProvidedByContainer);
            if (TextInstance.Font != null)
            {
                TextInstance.SetPixelPerfectScale(LayerProvidedByContainer);
            }
            FlatRedBall.Math.Geometry.ShapeManager.AddToLayer(mCircleInstance, LayerProvidedByContainer);
            AddToManagersBottomUp(layerToAddTo);
            CustomInitialize();
        }
        public virtual void Activity () 
        {
            
            CustomActivity();
        }
        public virtual void Destroy () 
        {
            if (Used)
            {
                Factories.DockFactory.MakeUnused(this, false);
            }
            FlatRedBall.SpriteManager.RemovePositionedObject(this);
            
            if (TextInstance != null)
            {
                FlatRedBall.Graphics.TextManager.RemoveTextOneWay(TextInstance);
            }
            if (CircleInstance != null)
            {
                FlatRedBall.Math.Geometry.ShapeManager.RemoveOneWay(CircleInstance);
            }
            CustomDestroy();
        }
        public virtual void PostInitialize () 
        {
            bool oldShapeManagerSuppressAdd = FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue;
            FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = true;
            this.BoatNearDock += OnBoatNearDock;
            if (TextInstance.Parent == null)
            {
                TextInstance.CopyAbsoluteToRelative();
                TextInstance.AttachTo(this, false);
            }
            TextInstance.DisplayText = "Accoster (E)";
            TextInstance.HorizontalAlignment = FlatRedBall.Graphics.HorizontalAlignment.Right;
            TextInstance.VerticalAlignment = FlatRedBall.Graphics.VerticalAlignment.Center;
            TextInstance.Visible = false;
            if (mCircleInstance.Parent == null)
            {
                mCircleInstance.CopyAbsoluteToRelative();
                mCircleInstance.AttachTo(this, false);
            }
            CircleInstance.Radius = 48f;
            CircleInstance.Visible = false;
            FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = oldShapeManagerSuppressAdd;
        }
        public virtual void AddToManagersBottomUp (FlatRedBall.Graphics.Layer layerToAddTo) 
        {
            AssignCustomVariables(false);
        }
        public virtual void RemoveFromManagers () 
        {
            FlatRedBall.SpriteManager.ConvertToManuallyUpdated(this);
            if (TextInstance != null)
            {
                FlatRedBall.Graphics.TextManager.RemoveTextOneWay(TextInstance);
            }
            if (CircleInstance != null)
            {
                FlatRedBall.Math.Geometry.ShapeManager.RemoveOneWay(CircleInstance);
            }
        }
        public virtual void AssignCustomVariables (bool callOnContainedElements) 
        {
            if (callOnContainedElements)
            {
            }
            TextInstance.DisplayText = "Accoster (E)";
            TextInstance.HorizontalAlignment = FlatRedBall.Graphics.HorizontalAlignment.Right;
            TextInstance.VerticalAlignment = FlatRedBall.Graphics.VerticalAlignment.Center;
            TextInstance.Visible = false;
            CircleInstance.Radius = 48f;
            CircleInstance.Visible = false;
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
                        FlatRedBall.FlatRedBallServices.GetContentManagerByName(ContentManagerName).AddUnloadMethod("DockStaticUnload", UnloadStaticContent);
                        mRegisteredUnloads.Add(ContentManagerName);
                    }
                }
            }
            if (registerUnload && ContentManagerName != FlatRedBall.FlatRedBallServices.GlobalContentManager)
            {
                lock (mLockObject)
                {
                    if (!mRegisteredUnloads.Contains(ContentManagerName) && ContentManagerName != FlatRedBall.FlatRedBallServices.GlobalContentManager)
                    {
                        FlatRedBall.FlatRedBallServices.GetContentManagerByName(ContentManagerName).AddUnloadMethod("DockStaticUnload", UnloadStaticContent);
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
            }
        }
        [System.Obsolete("Use GetFile instead")]
        public static object GetStaticMember (string memberName) 
        {
            return null;
        }
        public static object GetFile (string memberName) 
        {
            return null;
        }
        object GetMember (string memberName) 
        {
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
            FlatRedBall.Instructions.InstructionManager.IgnorePausingFor(TextInstance);
            FlatRedBall.Instructions.InstructionManager.IgnorePausingFor(CircleInstance);
        }
        public virtual void MoveToLayer (FlatRedBall.Graphics.Layer layerToMoveTo) 
        {
            var layerToRemoveFrom = LayerProvidedByContainer;
            if (layerToRemoveFrom != null)
            {
                layerToRemoveFrom.Remove(TextInstance);
            }
            FlatRedBall.Graphics.TextManager.AddToLayer(TextInstance, layerToMoveTo);
            if (layerToRemoveFrom != null)
            {
                layerToRemoveFrom.Remove(CircleInstance);
            }
            FlatRedBall.Math.Geometry.ShapeManager.AddToLayer(CircleInstance, layerToMoveTo);
            LayerProvidedByContainer = layerToMoveTo;
        }
    }
}
