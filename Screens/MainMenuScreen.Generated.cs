#if ANDROID || IOS || DESKTOP_GL
#define REQUIRES_PRIMARY_THREAD_LOADING
#endif
using Color = Microsoft.Xna.Framework.Color;
using System.Linq;
using FlatRedBall;
using System;
using System.Collections.Generic;
using System.Text;
namespace Pirates.Screens
{
    public partial class MainMenuScreen : FlatRedBall.Screens.Screen
    {
        #if DEBUG
        static bool HasBeenLoadedWithGlobalContentManager = false;
        #endif
        protected static Gum.Wireframe.GraphicalUiElement MainMenuScreenGum;
        
        private Pirates.GumRuntimes.ButtonRuntime ButtonPlay;
        private Pirates.GumRuntimes.ButtonRuntime ButtonSettings;
        private Pirates.GumRuntimes.ButtonRuntime ButtonQuit;
        private Pirates.GumRuntimes.ButtonRuntime ButtonBack;
        private Pirates.GumRuntimes.ContainerRuntime MainContainer;
        private Pirates.GumRuntimes.ContainerRuntime SettingsContainer;
        private Pirates.GumRuntimes.DefaultForms.SliderRuntime SliderVolume;
        private Pirates.GumRuntimes.TextRuntime TextVolumeLevel;
        private Pirates.GumRuntimes.ButtonRuntime ButtonSwitchFullscreen;
        private Pirates.GumRuntimes.ButtonRuntime ButtonApply;
        public event FlatRedBall.Gui.WindowEvent ButtonPlayClick;
        public event FlatRedBall.Gui.WindowEvent ButtonSettingsClick;
        public event FlatRedBall.Gui.WindowEvent ButtonQuitClick;
        public event FlatRedBall.Gui.WindowEvent ButtonBackClick;
        public event FlatRedBall.Gui.WindowEvent ButtonSwitchFullscreenClick;
        public event FlatRedBall.Gui.WindowEvent ButtonApplyClick;
        public MainMenuScreen () 
        	: base ("MainMenuScreen")
        {
        }
        public override void Initialize (bool addToManagers) 
        {
            LoadStaticContent(ContentManagerName);
            ButtonPlay = MainMenuScreenGum.GetGraphicalUiElementByName("ButtonPlay") as Pirates.GumRuntimes.ButtonRuntime;
            ButtonSettings = MainMenuScreenGum.GetGraphicalUiElementByName("ButtonSettings") as Pirates.GumRuntimes.ButtonRuntime;
            ButtonQuit = MainMenuScreenGum.GetGraphicalUiElementByName("ButtonQuit") as Pirates.GumRuntimes.ButtonRuntime;
            ButtonBack = MainMenuScreenGum.GetGraphicalUiElementByName("ButtonBack") as Pirates.GumRuntimes.ButtonRuntime;
            MainContainer = MainMenuScreenGum.GetGraphicalUiElementByName("MainContainer") as Pirates.GumRuntimes.ContainerRuntime;
            SettingsContainer = MainMenuScreenGum.GetGraphicalUiElementByName("SettingsContainer") as Pirates.GumRuntimes.ContainerRuntime;
            SliderVolume = MainMenuScreenGum.GetGraphicalUiElementByName("SliderVolume") as Pirates.GumRuntimes.DefaultForms.SliderRuntime;
            TextVolumeLevel = MainMenuScreenGum.GetGraphicalUiElementByName("TextVolumeLevel") as Pirates.GumRuntimes.TextRuntime;
            ButtonSwitchFullscreen = MainMenuScreenGum.GetGraphicalUiElementByName("ButtonSwitchFullscreen") as Pirates.GumRuntimes.ButtonRuntime;
            ButtonApply = MainMenuScreenGum.GetGraphicalUiElementByName("ButtonApply") as Pirates.GumRuntimes.ButtonRuntime;
            
            
            PostInitialize();
            base.Initialize(addToManagers);
            if (addToManagers)
            {
                AddToManagers();
            }
        }
        public override void AddToManagers () 
        {
            MainMenuScreenGum.AddToManagers();FlatRedBall.FlatRedBallServices.GraphicsOptions.SizeOrOrientationChanged += RefreshLayoutInternal;
            base.AddToManagers();
            AddToManagersBottomUp();
            CustomInitialize();
        }
        public override void Activity (bool firstTimeCalled) 
        {
            if (!IsPaused)
            {
                
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
            MainMenuScreenGum.RemoveFromManagers();
            MainMenuScreenGum = null;
            
            if (ButtonPlay != null)
            {
                ButtonPlay.RemoveFromManagers();
            }
            if (ButtonSettings != null)
            {
                ButtonSettings.RemoveFromManagers();
            }
            if (ButtonQuit != null)
            {
                ButtonQuit.RemoveFromManagers();
            }
            if (ButtonBack != null)
            {
                ButtonBack.RemoveFromManagers();
            }
            if (MainContainer != null)
            {
                MainContainer.RemoveFromManagers();
            }
            if (SettingsContainer != null)
            {
                SettingsContainer.RemoveFromManagers();
            }
            if (SliderVolume != null)
            {
                SliderVolume.RemoveFromManagers();
            }
            if (TextVolumeLevel != null)
            {
                TextVolumeLevel.RemoveFromManagers();
            }
            if (ButtonSwitchFullscreen != null)
            {
                ButtonSwitchFullscreen.RemoveFromManagers();
            }
            if (ButtonApply != null)
            {
                ButtonApply.RemoveFromManagers();
            }
            FlatRedBall.Math.Collision.CollisionManager.Self.Relationships.Clear();
            CustomDestroy();
        }
        public virtual void PostInitialize () 
        {
            bool oldShapeManagerSuppressAdd = FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue;
            FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = true;
            ButtonPlay.Click += OnButtonPlayClick;
            ButtonPlay.Click += OnButtonPlayClickTunnel;
            ButtonSettings.Click += OnButtonSettingsClick;
            ButtonSettings.Click += OnButtonSettingsClickTunnel;
            ButtonQuit.Click += OnButtonQuitClick;
            ButtonQuit.Click += OnButtonQuitClickTunnel;
            ButtonBack.Click += OnButtonBackClick;
            ButtonBack.Click += OnButtonBackClickTunnel;
            ButtonSwitchFullscreen.Click += OnButtonSwitchFullscreenClick;
            ButtonSwitchFullscreen.Click += OnButtonSwitchFullscreenClickTunnel;
            ButtonApply.Click += OnButtonApplyClick;
            ButtonApply.Click += OnButtonApplyClickTunnel;
            FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = oldShapeManagerSuppressAdd;
        }
        public virtual void AddToManagersBottomUp () 
        {
            CameraSetup.ResetCamera(SpriteManager.Camera);
            AssignCustomVariables(false);
        }
        public virtual void RemoveFromManagers () 
        {
            if (ButtonPlay != null)
            {
                ButtonPlay.RemoveFromManagers();
            }
            if (ButtonSettings != null)
            {
                ButtonSettings.RemoveFromManagers();
            }
            if (ButtonQuit != null)
            {
                ButtonQuit.RemoveFromManagers();
            }
            if (ButtonBack != null)
            {
                ButtonBack.RemoveFromManagers();
            }
            if (MainContainer != null)
            {
                MainContainer.RemoveFromManagers();
            }
            if (SettingsContainer != null)
            {
                SettingsContainer.RemoveFromManagers();
            }
            if (SliderVolume != null)
            {
                SliderVolume.RemoveFromManagers();
            }
            if (TextVolumeLevel != null)
            {
                TextVolumeLevel.RemoveFromManagers();
            }
            if (ButtonSwitchFullscreen != null)
            {
                ButtonSwitchFullscreen.RemoveFromManagers();
            }
            if (ButtonApply != null)
            {
                ButtonApply.RemoveFromManagers();
            }
        }
        public virtual void AssignCustomVariables (bool callOnContainedElements) 
        {
            if (callOnContainedElements)
            {
            }
        }
        public virtual void ConvertToManuallyUpdated () 
        {
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
            FlatRedBall.Gum.GumIdb.UpdateDisplayToMainFrbCamera();MainMenuScreenGum = GumRuntime.ElementSaveExtensions.CreateGueForElement( Gum.Managers.ObjectFinder.Self.GetScreen(FlatRedBall.IO.FileManager.RemoveExtension(FlatRedBall.IO.FileManager.RemovePath("content/gumproject/screens/mainmenuscreengum.gusx"))), true);
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
                case  "MainMenuScreenGum":
                    return MainMenuScreenGum;
            }
            return null;
        }
        public static object GetFile (string memberName) 
        {
            switch(memberName)
            {
                case  "MainMenuScreenGum":
                    return MainMenuScreenGum;
            }
            return null;
        }
        object GetMember (string memberName) 
        {
            switch(memberName)
            {
                case  "MainMenuScreenGum":
                    return MainMenuScreenGum;
            }
            return null;
        }
        private void RefreshLayoutInternal (object sender, EventArgs e) 
        {
            MainMenuScreenGum.UpdateLayout();
        }
    }
}
