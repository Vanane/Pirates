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
    public partial class GameScreen
    {
        void OnButtonPistolClickTunnel (FlatRedBall.Gui.IWindow window) 
        {
            if (this.ButtonPistolClick != null)
            {
                ButtonPistolClick(window);
            }
        }
        void OnButtonShotgunClickTunnel (FlatRedBall.Gui.IWindow window) 
        {
            if (this.ButtonShotgunClick != null)
            {
                ButtonShotgunClick(window);
            }
        }
    }
}
