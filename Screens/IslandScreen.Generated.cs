#if ANDROID || IOS || DESKTOP_GL
#define REQUIRES_PRIMARY_THREAD_LOADING
#endif
using Color = Microsoft.Xna.Framework.Color;
using System.Linq;
using FlatRedBall;
using System;
using System.Collections.Generic;
using System.Text;
using Pirates.Entities.UI;
namespace Pirates.Screens
{
    public partial class IslandScreen : FlatRedBall.Screens.Screen
    {
        #if DEBUG
        static bool HasBeenLoadedWithGlobalContentManager = false;
        #endif
        protected static Microsoft.Xna.Framework.Graphics.Texture2D BackgroundSprite;
        
        private FlatRedBall.Sprite SpriteInstance;
        private Pirates.Entities.UI.Button ButtonLeave;
        FlatRedBall.Gum.GumIdb gumIdb;
        public IslandScreen () 
        	: base ("IslandScreen")
        {
        }
        public override void Initialize (bool addToManagers) 
        {
            LoadStaticContent(ContentManagerName);
            SpriteInstance = new FlatRedBall.Sprite();
            SpriteInstance.Name = "SpriteInstance";
            ButtonLeave = new Pirates.Entities.UI.Button(ContentManagerName, false);
            ButtonLeave.Name = "ButtonLeave";
            gumIdb = new FlatRedBall.Gum.GumIdb();
            
            
            PostInitialize();
            base.Initialize(addToManagers);
            if (addToManagers)
            {
                AddToManagers();
            }
        }
        public override void AddToManagers () 
        {
            FlatRedBall.SpriteManager.AddDrawableBatch(gumIdb);
            FlatRedBall.SpriteManager.AddSprite(SpriteInstance);
            ButtonLeave.AddToManagers(mLayer);
            base.AddToManagers();
            AddToManagersBottomUp();
            CustomInitialize();
        }
        public override void Activity (bool firstTimeCalled) 
        {
            if (!IsPaused)
            {
                
                ButtonLeave.Activity();
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
            FlatRedBall.SpriteManager.RemoveDrawableBatch(gumIdb);
            base.Destroy();
            BackgroundSprite = null;
            
            if (SpriteInstance != null)
            {
                FlatRedBall.SpriteManager.RemoveSprite(SpriteInstance);
            }
            if (ButtonLeave != null)
            {
                ButtonLeave.Destroy();
                ButtonLeave.Detach();
            }
            FlatRedBall.Math.Collision.CollisionManager.Self.Relationships.Clear();
            CustomDestroy();
        }
        public virtual void PostInitialize () 
        {
            bool oldShapeManagerSuppressAdd = FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue;
            FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = true;
            SpriteInstance.Texture = BackgroundSprite;
            SpriteInstance.TextureScale = 1f;
            FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = oldShapeManagerSuppressAdd;
        }
        public virtual void AddToManagersBottomUp () 
        {
            CameraSetup.ResetCamera(SpriteManager.Camera);
            AssignCustomVariables(false);
        }
        public virtual void RemoveFromManagers () 
        {
            if (SpriteInstance != null)
            {
                FlatRedBall.SpriteManager.RemoveSpriteOneWay(SpriteInstance);
            }
            ButtonLeave.RemoveFromManagers();
        }
        public virtual void AssignCustomVariables (bool callOnContainedElements) 
        {
            if (callOnContainedElements)
            {
                ButtonLeave.AssignCustomVariables(true);
            }
            SpriteInstance.Texture = BackgroundSprite;
            SpriteInstance.TextureScale = 1f;
        }
        public virtual void ConvertToManuallyUpdated () 
        {
            FlatRedBall.SpriteManager.ConvertToManuallyUpdated(SpriteInstance);
            ButtonLeave.ConvertToManuallyUpdated();
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
            BackgroundSprite = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/screens/islandscreen/backgroundsprite.png", contentManagerName);
            Pirates.Entities.UI.Button.LoadStaticContent(contentManagerName);
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
                case  "BackgroundSprite":
                    return BackgroundSprite;
            }
            return null;
        }
        public static object GetFile (string memberName) 
        {
            switch(memberName)
            {
                case  "BackgroundSprite":
                    return BackgroundSprite;
            }
            return null;
        }
        object GetMember (string memberName) 
        {
            switch(memberName)
            {
                case  "BackgroundSprite":
                    return BackgroundSprite;
            }
            return null;
        }
    }
}
