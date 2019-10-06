using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using FlatRedBall;
using FlatRedBall.Input;
using FlatRedBall.Instructions;
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Graphics.Animation;
using FlatRedBall.Graphics.Particle;
using FlatRedBall.Gui;
using FlatRedBall.Math.Geometry;
using FlatRedBall.Localization;
using FlatRedBall.Screens;
using FlatRedBall.Forms.Controls;
using GumRuntime;

using Pirates.Custom;


namespace Pirates.Screens
{
	public partial class MainMenuScreen
	{
		void CustomInitialize()
		{
            InitializeEvents();

            InitializeValues();

            SliderVolume.FormsControl.IsSnapToTickEnabled = true;
            SliderVolume.FormsControl.TicksFrequency = 1;
        }

		void CustomActivity(bool firstTimeCalled)
		{
            TextVolumeLevel.Text = SliderVolume.FormsControl.Value.ToString();

		}

		void CustomDestroy()
		{


		}

        static void CustomLoadStaticContent(string contentManagerName)
        {


        }


        private void InitializeEvents()
        {
            ButtonPlayClick += ButtonPlay_Click;
            ButtonSettingsClick += ButtonSettings_Click;
            ButtonQuitClick += ButtonQuit_Click;
            ButtonBackClick += ButtonBack_Click;
            ButtonApplyClick += ButtonApply_Click;

            ButtonSwitchFullscreenClick += (x) =>
            {
                FlatRedBallServices.GraphicsOptions.SetFullScreen(1366, 768);
            };
        }

        private void InitializeValues()
        {
            SliderVolume.FormsControl.Value = GameSettings.GetSettings.VolumeLevel * 100;
        }

        private void ButtonPlay_Click(object o)
        {
            MoveToScreen("LoadingScreen");
            PauseThisScreen();
        }

        private void ButtonSettings_Click(object o)
        {
            MainContainer.X += Camera.Main.OrthogonalWidth;
            SettingsContainer.X -= 100;            
        }

        private void ButtonBack_Click(object o)
        {
            MainContainer.X -= Camera.Main.OrthogonalWidth;
            SettingsContainer.X += 100;

        }

        private void ButtonQuit_Click(object o)
        {
            FlatRedBallServices.Game.Exit();
        }

        private void ButtonApply_Click(object o)
        {
            GameSettings.GetSettings.VolumeLevel = (float)SliderVolume.FormsControl.Value / 100;
            ButtonBack_Click(o);

            GameSettings.SaveSettings();
        }
    }
}
