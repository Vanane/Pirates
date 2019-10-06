#if ANDROID || IOS || DESKTOP_GL
// Android doesn't allow background loading. iOS doesn't allow background rendering (which is used by converting textures to use premult alpha)
#define REQUIRES_PRIMARY_THREAD_LOADING
#endif
using System.Collections.Generic;
using System.Threading;
using FlatRedBall;
using FlatRedBall.Math.Geometry;
using FlatRedBall.ManagedSpriteGroups;
using FlatRedBall.Graphics.Animation;
using FlatRedBall.Graphics.Particle;
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Utilities;
using BitmapFont = FlatRedBall.Graphics.BitmapFont;
using FlatRedBall.Localization;

namespace Pirates
{
    public static partial class GlobalContent
    {
        
        public static FlatRedBall.Gum.GumIdb GumProject { get; set; }
        public static Microsoft.Xna.Framework.Graphics.Texture2D pistol { get; set; }
        public static Microsoft.Xna.Framework.Graphics.Texture2D shotgun { get; set; }
        public static FlatRedBall.Graphics.Animation.AnimationChainList SkeletonAnimation { get; set; }
        [System.Obsolete("Use GetFile instead")]
        public static object GetStaticMember (string memberName) 
        {
            switch(memberName)
            {
                case  "GumProject":
                    return GumProject;
                case  "pistol":
                    return pistol;
                case  "shotgun":
                    return shotgun;
                case  "SkeletonAnimation":
                    return SkeletonAnimation;
            }
            return null;
        }
        public static object GetFile (string memberName) 
        {
            switch(memberName)
            {
                case  "GumProject":
                    return GumProject;
                case  "pistol":
                    return pistol;
                case  "shotgun":
                    return shotgun;
                case  "SkeletonAnimation":
                    return SkeletonAnimation;
            }
            return null;
        }
        public static bool IsInitialized { get; private set; }
        public static bool ShouldStopLoading { get; set; }
        const string ContentManagerName = "Global";
        public static void Initialize () 
        {
            
            FlatRedBall.Gum.GumIdb.StaticInitialize("content/gumproject/gumproject.gumx"); FlatRedBall.Gum.GumIdbExtensions.RegisterTypes();  FlatRedBall.Gui.GuiManager.BringsClickedWindowsToFront = false;FlatRedBall.Gum.GumIdb.FixedCanvasAspectRatio = null;FlatRedBall.FlatRedBallServices.GraphicsOptions.SizeOrOrientationChanged += (not, used) => { FlatRedBall.Gum.GumIdb.UpdateDisplayToMainFrbCamera(); };Gum.Wireframe.GraphicalUiElement.ShowLineRectangles = false;
            pistol = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/sprites/weapons/pistol.png", ContentManagerName);
            shotgun = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/sprites/weapons/shotgun.png", ContentManagerName);
            SkeletonAnimation = FlatRedBall.FlatRedBallServices.Load<FlatRedBall.Graphics.Animation.AnimationChainList>(@"content/sprites/mobs/skeletonanimation.achx", ContentManagerName);
            			IsInitialized = true;
            #if DEBUG && WINDOWS
            InitializeFileWatch();
            #endif
            // Added by GumPlugin becasue of the Show Mouse checkbox on the .gumx:
            FlatRedBall.FlatRedBallServices.Game.IsMouseVisible = true;
        }
        public static void Reload (object whatToReload) 
        {
            if (whatToReload == SkeletonAnimation)
            {
                {
                    var cm = FlatRedBall.FlatRedBallServices.GetContentManagerByName("Global");
                    cm.UnloadAsset(SkeletonAnimation);
                    SkeletonAnimation = FlatRedBall.FlatRedBallServices.Load<FlatRedBall.Graphics.Animation.AnimationChainList>("content/sprites/mobs/skeletonanimation.achx");
                }
            }
        }
        #if DEBUG && WINDOWS
        static System.IO.FileSystemWatcher watcher;
        private static void InitializeFileWatch () 
        {
            string globalContent = FlatRedBall.IO.FileManager.RelativeDirectory + "content/globalcontent/";
            if (System.IO.Directory.Exists(globalContent))
            {
                watcher = new System.IO.FileSystemWatcher();
                watcher.Path = globalContent;
                watcher.NotifyFilter = System.IO.NotifyFilters.LastWrite;
                watcher.Filter = "*.*";
                watcher.Changed += HandleFileChanged;
                watcher.EnableRaisingEvents = true;
            }
        }
        private static void HandleFileChanged (object sender, System.IO.FileSystemEventArgs e) 
        {
            try
            {
                System.Threading.Thread.Sleep(500);
                var fullFileName = e.FullPath;
                var relativeFileName = FlatRedBall.IO.FileManager.MakeRelative(FlatRedBall.IO.FileManager.Standardize(fullFileName));
                if (relativeFileName == "content/gumproject/gumproject.gumx")
                {
                    Reload(GumProject);
                }
                if (relativeFileName == "content/sprites/weapons/pistol.png")
                {
                    Reload(pistol);
                }
                if (relativeFileName == "content/sprites/weapons/shotgun.png")
                {
                    Reload(shotgun);
                }
                if (relativeFileName == "content/sprites/mobs/skeletonanimation.achx")
                {
                    Reload(SkeletonAnimation);
                }
            }
            catch{}
        }
        #endif
        
        
    }
}
