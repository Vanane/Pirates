#if ANDROID || IOS || DESKTOP_GL
#define REQUIRES_PRIMARY_THREAD_LOADING
#endif
using Color = Microsoft.Xna.Framework.Color;
using System.Linq;
using FlatRedBall.Graphics;
using FlatRedBall.Math;
using FlatRedBall.Gui;
using FlatRedBall;
using System;
using System.Collections.Generic;
using System.Text;
namespace Pirates.Entities.UI
{
    public partial class Button : FlatRedBall.PositionedObject, FlatRedBall.Graphics.IDestroyable, FlatRedBall.Graphics.IVisible, FlatRedBall.Gui.IWindow, FlatRedBall.Gui.IClickable
    {
        // This is made static so that static lazy-loaded content can access it.
        public static string ContentManagerName { get; set; }
        #if DEBUG
        static bool HasBeenLoadedWithGlobalContentManager = false;
        #endif
        static object mLockObject = new object();
        static System.Collections.Generic.List<string> mRegisteredUnloads = new System.Collections.Generic.List<string>();
        static System.Collections.Generic.List<string> LoadedContentManagers = new System.Collections.Generic.List<string>();
        
        private FlatRedBall.Sprite SpriteInstance;
        private FlatRedBall.Graphics.Text TextInstance;
        public string Text = "Button";
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
        protected FlatRedBall.Graphics.Layer LayerProvidedByContainer = null;
        public Button () 
        	: this(FlatRedBall.Screens.ScreenManager.CurrentScreen.ContentManagerName, true)
        {
        }
        public Button (string contentManagerName) 
        	: this(contentManagerName, true)
        {
        }
        public Button (string contentManagerName, bool addToManagers) 
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
            this.Click += CallLosePush;
            this.RollOff += CallLosePush;
            
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
            FlatRedBall.Gui.GuiManager.AddWindow(this);
            FlatRedBall.SpriteManager.AddToLayer(SpriteInstance, LayerProvidedByContainer);
            FlatRedBall.Graphics.TextManager.AddToLayer(TextInstance, LayerProvidedByContainer);
            if (TextInstance.Font != null)
            {
                TextInstance.SetPixelPerfectScale(LayerProvidedByContainer);
            }
        }
        public virtual void AddToManagers (FlatRedBall.Graphics.Layer layerToAddTo) 
        {
            LayerProvidedByContainer = layerToAddTo;
            FlatRedBall.SpriteManager.AddPositionedObject(this);
            FlatRedBall.Gui.GuiManager.AddWindow(this);
            FlatRedBall.SpriteManager.AddToLayer(SpriteInstance, LayerProvidedByContainer);
            FlatRedBall.Graphics.TextManager.AddToLayer(TextInstance, LayerProvidedByContainer);
            if (TextInstance.Font != null)
            {
                TextInstance.SetPixelPerfectScale(LayerProvidedByContainer);
            }
            AddToManagersBottomUp(layerToAddTo);
            CustomInitialize();
        }
        public virtual void Activity () 
        {
            mIsPaused = false;
            
            CustomActivity();
        }
        public virtual void Destroy () 
        {
            FlatRedBall.SpriteManager.RemovePositionedObject(this);
            FlatRedBall.Gui.GuiManager.RemoveWindow(this);
            
            if (SpriteInstance != null)
            {
                FlatRedBall.SpriteManager.RemoveSprite(SpriteInstance);
            }
            if (TextInstance != null)
            {
                FlatRedBall.Graphics.TextManager.RemoveText(TextInstance);
            }
            CustomDestroy();
        }
        public virtual void PostInitialize () 
        {
            bool oldShapeManagerSuppressAdd = FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue;
            FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = true;
            this.Click += OnClick;
            if (SpriteInstance.Parent == null)
            {
                SpriteInstance.CopyAbsoluteToRelative();
                SpriteInstance.AttachTo(this, false);
            }
            SpriteInstance.TextureScale = 1f;
            SpriteInstance.Red = 0.1f;
            SpriteInstance.Green = 0.1f;
            SpriteInstance.Blue = 0.1f;
            if (TextInstance.Parent == null)
            {
                TextInstance.CopyAbsoluteToRelative();
                TextInstance.AttachTo(this, false);
            }
            if (TextInstance.Parent == null)
            {
                TextInstance.Z = 5f;
            }
            else
            {
                TextInstance.RelativeZ = 5f;
            }
            TextInstance.AdjustPositionForPixelPerfectDrawing = false;
            FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = oldShapeManagerSuppressAdd;
        }
        public virtual void AddToManagersBottomUp (FlatRedBall.Graphics.Layer layerToAddTo) 
        {
            AssignCustomVariables(false);
        }
        public virtual void RemoveFromManagers () 
        {
            FlatRedBall.SpriteManager.ConvertToManuallyUpdated(this);
            FlatRedBall.Gui.GuiManager.RemoveWindow(this);
            if (SpriteInstance != null)
            {
                FlatRedBall.SpriteManager.RemoveSpriteOneWay(SpriteInstance);
            }
            if (TextInstance != null)
            {
                FlatRedBall.Graphics.TextManager.RemoveTextOneWay(TextInstance);
            }
        }
        public virtual void AssignCustomVariables (bool callOnContainedElements) 
        {
            if (callOnContainedElements)
            {
            }
            SpriteInstance.TextureScale = 1f;
            SpriteInstance.Red = 0.1f;
            SpriteInstance.Green = 0.1f;
            SpriteInstance.Blue = 0.1f;
            if (TextInstance.Parent == null)
            {
                TextInstance.Z = 5f;
            }
            else
            {
                TextInstance.RelativeZ = 5f;
            }
            TextInstance.AdjustPositionForPixelPerfectDrawing = false;
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
            Text = "Button";
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
                        FlatRedBall.FlatRedBallServices.GetContentManagerByName(ContentManagerName).AddUnloadMethod("ButtonStaticUnload", UnloadStaticContent);
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
                        FlatRedBall.FlatRedBallServices.GetContentManagerByName(ContentManagerName).AddUnloadMethod("ButtonStaticUnload", UnloadStaticContent);
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
        
    // DELEGATE START HERE
    

        #region IWindow methods and properties

        public event FlatRedBall.Gui.WindowEvent Click;
		public event FlatRedBall.Gui.WindowEvent ClickNoSlide;
		public event FlatRedBall.Gui.WindowEvent SlideOnClick;
        public event FlatRedBall.Gui.WindowEvent Push;
		public event FlatRedBall.Gui.WindowEvent DragOver;
		public event FlatRedBall.Gui.WindowEvent RollOn;
		public event FlatRedBall.Gui.WindowEvent RollOff;
		public event FlatRedBall.Gui.WindowEvent RollOver;
		public event FlatRedBall.Gui.WindowEvent LosePush;
		public event FlatRedBall.Gui.WindowEvent EnabledChange;

        System.Collections.ObjectModel.ReadOnlyCollection<FlatRedBall.Gui.IWindow> FlatRedBall.Gui.IWindow.Children
        {
            get { throw new System.NotImplementedException(); }
        }

        bool mEnabled = true;


		bool FlatRedBall.Graphics.IVisible.Visible
        {
            get
            {
                return this.AbsoluteVisible;
            }
			set
			{
				this.Visible = value;
			}
        }
		
		public bool MovesWhenGrabbed
        {
            get;
            set;
        }

        bool FlatRedBall.Gui.IWindow.GuiManagerDrawn
        {
            get
            {
                return false;
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }

        public bool IgnoredByCursor
        {
            get
            {
                return false;
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }



        public System.Collections.ObjectModel.ReadOnlyCollection<FlatRedBall.Gui.IWindow> FloatingChildren
        {
            get { return null; }
        }

        public FlatRedBall.ManagedSpriteGroups.SpriteFrame SpriteFrame
        {
            get
            {
                return null;
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }

        float FlatRedBall.Gui.IWindow.WorldUnitX
        {
            get
            {
                return Position.X;
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }

        float FlatRedBall.Gui.IWindow.WorldUnitY
        {
            get
            {
                return Position.Y;
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }

        float FlatRedBall.Gui.IWindow.WorldUnitRelativeX
        {
            get
            {
                return RelativePosition.X;
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }

        float FlatRedBall.Gui.IWindow.WorldUnitRelativeY
        {
            get
            {
                return RelativePosition.Y;
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }

        float FlatRedBall.Gui.IWindow.ScaleX
        {
            get;
            set;
        }

        float FlatRedBall.Gui.IWindow.ScaleY
        {
            get;
            set;
        }

        FlatRedBall.Gui.IWindow FlatRedBall.Gui.IWindow.Parent
        {
            get
            {
                return null;
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }

        void FlatRedBall.Gui.IWindow.Activity(FlatRedBall.Camera camera)
        {

        }

        void FlatRedBall.Gui.IWindow.CallRollOff()
        {
			if(RollOff != null)
			{
				RollOff(this);
			}
        }

        void FlatRedBall.Gui.IWindow.CallRollOn()
        {
			if(RollOn != null)
			{
				RollOn(this);
			}
        }

		
		void FlatRedBall.Gui.IWindow.CallRollOver()
		{
			if(RollOver != null)
			{
				RollOver(this);
			}	
		}
		
		void CallLosePush(FlatRedBall.Gui.IWindow instance)
		{
			if(LosePush != null)
			{
				LosePush(instance);
			}
		}

        void FlatRedBall.Gui.IWindow.CloseWindow()
        {
            throw new System.NotImplementedException();
        }

		void FlatRedBall.Gui.IWindow.CallClick()
		{
			if(Click != null)
			{
				Click(this);
			}
		}

        public bool GetParentVisibility()
        {
            throw new System.NotImplementedException();
        }

        bool FlatRedBall.Gui.IWindow.IsPointOnWindow(float x, float y)
        {
            throw new System.NotImplementedException();
        }

        public void OnDragging()
        {
			if(DragOver != null)
			{
				DragOver(this);
			}
        }

        public void OnResize()
        {
            throw new System.NotImplementedException();
        }

        public void OnResizeEnd()
        {
            throw new System.NotImplementedException();
        }

        public void OnLosingFocus()
        {
            // Do nothing
        }

        public bool OverlapsWindow(FlatRedBall.Gui.IWindow otherWindow)
        {
            return false; // we don't care about this.
        }

        public void SetScaleTL(float newScaleX, float newScaleY)
        {
            throw new System.NotImplementedException();
        }

        public void SetScaleTL(float newScaleX, float newScaleY, bool keepTopLeftStatic)
        {
            throw new System.NotImplementedException();
        }

        public virtual void TestCollision(FlatRedBall.Gui.Cursor cursor)
        {
            if (HasCursorOver(cursor))
            {
                cursor.WindowOver = this;

                if (cursor.PrimaryPush)
                {

                    cursor.WindowPushed = this;

                    if (Push != null)
                        Push(this);

						
					cursor.GrabWindow(this);

                }

                if (cursor.PrimaryClick) // both pushing and clicking can occur in one frame because of buffered input
                {
                    if (cursor.WindowPushed == this)
                    {
                        if (Click != null)
                        {
                            Click(this);
                        }
						if(cursor.PrimaryClickNoSlide && ClickNoSlide != null)
						{
							ClickNoSlide(this);
						}

                        // if (cursor.PrimaryDoubleClick && DoubleClick != null)
                        //   DoubleClick(this);
                    }
					else
					{
						if(SlideOnClick != null)
						{
							SlideOnClick(this);
						}
					}
                }
            }
        }

        void FlatRedBall.Gui.IWindow.UpdateDependencies()
        {
            // do nothing
        }

        FlatRedBall.Graphics.Layer FlatRedBall.Graphics.ILayered.Layer
        {
            get
            {
				return LayerProvidedByContainer;
            }
        }


        #endregion

        bool FlatRedBall.Gui.IWindow.Enabled
        {
            get
            {
                return mEnabled;
            }
            set
            {
                if (mEnabled != value)
                {
                    mEnabled = value;
                    EnabledChange?.Invoke(this);
                }
            }
        }
        public virtual bool HasCursorOver (FlatRedBall.Gui.Cursor cursor) 
        {
            if (mIsPaused)
            {
                return false;
            }
            if (!AbsoluteVisible)
            {
                return false;
            }
            if (LayerProvidedByContainer != null && LayerProvidedByContainer.Visible == false)
            {
                return false;
            }
            if (!cursor.IsOn(LayerProvidedByContainer))
            {
                return false;
            }
            if (SpriteInstance.Alpha != 0 && SpriteInstance.AbsoluteVisible && cursor.IsOn3D(SpriteInstance, LayerProvidedByContainer))
            {
                return true;
            }
            if (TextInstance.Alpha != 0 && TextInstance.AbsoluteVisible && cursor.IsOn3D(TextInstance, LayerProvidedByContainer))
            {
                return true;
            }
            return false;
        }
        public virtual bool WasClickedThisFrame (FlatRedBall.Gui.Cursor cursor) 
        {
            return cursor.PrimaryClick && HasCursorOver(cursor);
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
            LayerProvidedByContainer = layerToMoveTo;
        }
    }
    public static class ButtonExtensionMethods
    {
        public static void SetVisible (this FlatRedBall.Math.PositionedObjectList<Button> list, bool value) 
        {
            int count = list.Count;
            for (int i = 0; i < count; i++)
            {
                list[i].Visible = value;
            }
        }
    }
}
