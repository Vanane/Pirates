using System;
using FlatRedBall;
using FlatRedBall.Input;
using FlatRedBall.Instructions;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Specialized;
using FlatRedBall.Audio;
using FlatRedBall.Screens;
using Pirates.Entities.Animations;
using Pirates.Entities;
using Pirates.Entities.UI;
using Pirates.Screens;
namespace Pirates.Screens
{
    public partial class MainMenuScreen
    {
        void OnButtonPlayClickTunnel (FlatRedBall.Gui.IWindow window) 
        {
            if (this.ButtonPlayClick != null)
            {
                ButtonPlayClick(window);
            }
        }
        void OnButtonSettingsClickTunnel (FlatRedBall.Gui.IWindow window) 
        {
            if (this.ButtonSettingsClick != null)
            {
                ButtonSettingsClick(window);
            }
        }
        void OnButtonQuitClickTunnel (FlatRedBall.Gui.IWindow window) 
        {
            if (this.ButtonQuitClick != null)
            {
                ButtonQuitClick(window);
            }
        }
        void OnButtonBackClickTunnel (FlatRedBall.Gui.IWindow window) 
        {
            if (this.ButtonBackClick != null)
            {
                ButtonBackClick(window);
            }
        }
        void OnButtonSwitchFullscreenClickTunnel (FlatRedBall.Gui.IWindow window) 
        {
            if (this.ButtonSwitchFullscreenClick != null)
            {
                ButtonSwitchFullscreenClick(window);
            }
        }
        void OnButtonApplyClickTunnel (FlatRedBall.Gui.IWindow window) 
        {
            if (this.ButtonApplyClick != null)
            {
                ButtonApplyClick(window);
            }
        }
    }
}
