    using System.Linq;
    namespace Pirates.GumRuntimes
    {
        public partial class MainMenuScreenGumRuntime : Gum.Wireframe.GraphicalUiElement
        {
            #region State Enums
            public enum VariableState
            {
                Default
            }
            #endregion
            #region State Fields
            VariableState mCurrentVariableState;
            #endregion
            #region State Properties
            public VariableState CurrentVariableState
            {
                get
                {
                    return mCurrentVariableState;
                }
                set
                {
                    mCurrentVariableState = value;
                    switch(mCurrentVariableState)
                    {
                        case  VariableState.Default:
                            ButtonPlay.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "MainContainer");
                            ButtonSettings.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "MainContainer");
                            ButtonQuit.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "MainContainer");
                            ButtonBack.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "SettingsContainer");
                            TextVolumeLevel.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "SettingsContainer");
                            SliderVolume.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "SettingsContainer");
                            ButtonSwitchFullscreen.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "SettingsContainer");
                            ButtonApply.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "SettingsContainer");
                            ButtonPlay.ButtonText = "Jouer";
                            ButtonPlay.ChildrenLayout = Gum.Managers.ChildrenLayout.Regular;
                            ButtonPlay.ClipsChildren = false;
                            ButtonPlay.Height = 15f;
                            ButtonPlay.HeightUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                            ButtonPlay.WrapsChildren = false;
                            ButtonPlay.X = 50f;
                            ButtonPlay.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                            ButtonPlay.XUnits = Gum.Converters.GeneralUnitType.Percentage;
                            ButtonPlay.Y = 30f;
                            ButtonPlay.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                            ButtonPlay.YUnits = Gum.Converters.GeneralUnitType.Percentage;
                            ButtonSettings.ButtonText = "Settings";
                            ButtonSettings.Height = 15f;
                            ButtonSettings.HeightUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                            ButtonSettings.X = 50f;
                            ButtonSettings.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                            ButtonSettings.XUnits = Gum.Converters.GeneralUnitType.Percentage;
                            ButtonSettings.Y = 50f;
                            ButtonSettings.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                            ButtonSettings.YUnits = Gum.Converters.GeneralUnitType.Percentage;
                            ButtonQuit.ButtonText = "Quitter";
                            ButtonQuit.Height = 15f;
                            ButtonQuit.HeightUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                            ButtonQuit.X = 50f;
                            ButtonQuit.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                            ButtonQuit.XUnits = Gum.Converters.GeneralUnitType.Percentage;
                            ButtonQuit.Y = 70f;
                            ButtonQuit.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                            ButtonQuit.YUnits = Gum.Converters.GeneralUnitType.Percentage;
                            Background.Blue = 255;
                            Background.Green = 255;
                            Background.Height = 100f;
                            Background.HeightUnits = Gum.DataTypes.DimensionUnitType.PercentageOfOtherDimension;
                            Background.Red = 255;
                            SetProperty("Background.SourceFile", "BackgroundSprite.png");
                            Background.Visible = true;
                            Background.Width = 100f;
                            Background.WidthUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                            Background.X = 0f;
                            Background.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                            Background.XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                            Background.Y = 0f;
                            Background.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Top;
                            Background.YUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                            MainContainer.Height = 0f;
                            MainContainer.HeightUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                            MainContainer.Width = 0f;
                            MainContainer.WidthUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                            MainContainer.X = 0f;
                            MainContainer.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                            MainContainer.XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                            MainContainer.Y = 0f;
                            MainContainer.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Top;
                            MainContainer.YUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                            SettingsContainer.Height = 100f;
                            SettingsContainer.HeightUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                            SettingsContainer.Width = 100f;
                            SettingsContainer.WidthUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                            SettingsContainer.X = 100f;
                            SettingsContainer.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                            SettingsContainer.XUnits = Gum.Converters.GeneralUnitType.Percentage;
                            SettingsContainer.Y = 0f;
                            SettingsContainer.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Top;
                            SettingsContainer.YUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                            ButtonBack.ButtonText = "Retour";
                            ButtonBack.Height = 15f;
                            ButtonBack.HeightUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                            ButtonBack.Width = 25f;
                            ButtonBack.WidthUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                            ButtonBack.X = 70f;
                            ButtonBack.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                            ButtonBack.XUnits = Gum.Converters.GeneralUnitType.Percentage;
                            ButtonBack.Y = 80f;
                            ButtonBack.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Top;
                            ButtonBack.YUnits = Gum.Converters.GeneralUnitType.Percentage;
                            TextVolumeLevel.Font = "Vivaldi";
                            TextVolumeLevel.FontSize = 48;
                            TextVolumeLevel.Height = 20f;
                            TextVolumeLevel.HorizontalAlignment = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                            TextVolumeLevel.Text = "100";
                            TextVolumeLevel.VerticalAlignment = RenderingLibrary.Graphics.VerticalAlignment.Center;
                            TextVolumeLevel.Width = 5f;
                            TextVolumeLevel.WidthUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                            TextVolumeLevel.X = 92f;
                            TextVolumeLevel.XUnits = Gum.Converters.GeneralUnitType.Percentage;
                            TextVolumeLevel.Y = 5f;
                            TextVolumeLevel.YUnits = Gum.Converters.GeneralUnitType.Percentage;
                            SliderVolume.Width = 50f;
                            SliderVolume.WidthUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                            ButtonSwitchFullscreen.ButtonText = "Fullscreen";
                            ButtonSwitchFullscreen.Height = 15f;
                            ButtonSwitchFullscreen.HeightUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                            ButtonSwitchFullscreen.Width = 25f;
                            ButtonSwitchFullscreen.WidthUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                            ButtonSwitchFullscreen.X = 0f;
                            ButtonSwitchFullscreen.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                            ButtonSwitchFullscreen.XUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                            ButtonSwitchFullscreen.Y = 0f;
                            ButtonSwitchFullscreen.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                            ButtonSwitchFullscreen.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                            ButtonApply.ButtonText = "Appliquer";
                            ButtonApply.Height = 15f;
                            ButtonApply.HeightUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                            ButtonApply.Width = 25f;
                            ButtonApply.WidthUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                            ButtonApply.X = 5f;
                            ButtonApply.XUnits = Gum.Converters.GeneralUnitType.Percentage;
                            ButtonApply.Y = 80f;
                            ButtonApply.YUnits = Gum.Converters.GeneralUnitType.Percentage;
                            break;
                    }
                }
            }
            #endregion
            #region State Interpolation
            public void InterpolateBetween (VariableState firstState, VariableState secondState, float interpolationValue) 
            {
                #if DEBUG
                if (float.IsNaN(interpolationValue))
                {
                    throw new System.Exception("interpolationValue cannot be NaN");
                }
                #endif
                bool setBackgroundBlueFirstValue = false;
                bool setBackgroundBlueSecondValue = false;
                int BackgroundBlueFirstValue= 0;
                int BackgroundBlueSecondValue= 0;
                bool setBackgroundGreenFirstValue = false;
                bool setBackgroundGreenSecondValue = false;
                int BackgroundGreenFirstValue= 0;
                int BackgroundGreenSecondValue= 0;
                bool setBackgroundHeightFirstValue = false;
                bool setBackgroundHeightSecondValue = false;
                float BackgroundHeightFirstValue= 0;
                float BackgroundHeightSecondValue= 0;
                bool setBackgroundRedFirstValue = false;
                bool setBackgroundRedSecondValue = false;
                int BackgroundRedFirstValue= 0;
                int BackgroundRedSecondValue= 0;
                bool setBackgroundWidthFirstValue = false;
                bool setBackgroundWidthSecondValue = false;
                float BackgroundWidthFirstValue= 0;
                float BackgroundWidthSecondValue= 0;
                bool setBackgroundXFirstValue = false;
                bool setBackgroundXSecondValue = false;
                float BackgroundXFirstValue= 0;
                float BackgroundXSecondValue= 0;
                bool setBackgroundYFirstValue = false;
                bool setBackgroundYSecondValue = false;
                float BackgroundYFirstValue= 0;
                float BackgroundYSecondValue= 0;
                bool setButtonApplyHeightFirstValue = false;
                bool setButtonApplyHeightSecondValue = false;
                float ButtonApplyHeightFirstValue= 0;
                float ButtonApplyHeightSecondValue= 0;
                bool setButtonApplyWidthFirstValue = false;
                bool setButtonApplyWidthSecondValue = false;
                float ButtonApplyWidthFirstValue= 0;
                float ButtonApplyWidthSecondValue= 0;
                bool setButtonApplyXFirstValue = false;
                bool setButtonApplyXSecondValue = false;
                float ButtonApplyXFirstValue= 0;
                float ButtonApplyXSecondValue= 0;
                bool setButtonApplyYFirstValue = false;
                bool setButtonApplyYSecondValue = false;
                float ButtonApplyYFirstValue= 0;
                float ButtonApplyYSecondValue= 0;
                bool setButtonBackHeightFirstValue = false;
                bool setButtonBackHeightSecondValue = false;
                float ButtonBackHeightFirstValue= 0;
                float ButtonBackHeightSecondValue= 0;
                bool setButtonBackWidthFirstValue = false;
                bool setButtonBackWidthSecondValue = false;
                float ButtonBackWidthFirstValue= 0;
                float ButtonBackWidthSecondValue= 0;
                bool setButtonBackXFirstValue = false;
                bool setButtonBackXSecondValue = false;
                float ButtonBackXFirstValue= 0;
                float ButtonBackXSecondValue= 0;
                bool setButtonBackYFirstValue = false;
                bool setButtonBackYSecondValue = false;
                float ButtonBackYFirstValue= 0;
                float ButtonBackYSecondValue= 0;
                bool setButtonPlayHeightFirstValue = false;
                bool setButtonPlayHeightSecondValue = false;
                float ButtonPlayHeightFirstValue= 0;
                float ButtonPlayHeightSecondValue= 0;
                bool setButtonPlayXFirstValue = false;
                bool setButtonPlayXSecondValue = false;
                float ButtonPlayXFirstValue= 0;
                float ButtonPlayXSecondValue= 0;
                bool setButtonPlayYFirstValue = false;
                bool setButtonPlayYSecondValue = false;
                float ButtonPlayYFirstValue= 0;
                float ButtonPlayYSecondValue= 0;
                bool setButtonQuitHeightFirstValue = false;
                bool setButtonQuitHeightSecondValue = false;
                float ButtonQuitHeightFirstValue= 0;
                float ButtonQuitHeightSecondValue= 0;
                bool setButtonQuitXFirstValue = false;
                bool setButtonQuitXSecondValue = false;
                float ButtonQuitXFirstValue= 0;
                float ButtonQuitXSecondValue= 0;
                bool setButtonQuitYFirstValue = false;
                bool setButtonQuitYSecondValue = false;
                float ButtonQuitYFirstValue= 0;
                float ButtonQuitYSecondValue= 0;
                bool setButtonSettingsHeightFirstValue = false;
                bool setButtonSettingsHeightSecondValue = false;
                float ButtonSettingsHeightFirstValue= 0;
                float ButtonSettingsHeightSecondValue= 0;
                bool setButtonSettingsXFirstValue = false;
                bool setButtonSettingsXSecondValue = false;
                float ButtonSettingsXFirstValue= 0;
                float ButtonSettingsXSecondValue= 0;
                bool setButtonSettingsYFirstValue = false;
                bool setButtonSettingsYSecondValue = false;
                float ButtonSettingsYFirstValue= 0;
                float ButtonSettingsYSecondValue= 0;
                bool setButtonSwitchFullscreenHeightFirstValue = false;
                bool setButtonSwitchFullscreenHeightSecondValue = false;
                float ButtonSwitchFullscreenHeightFirstValue= 0;
                float ButtonSwitchFullscreenHeightSecondValue= 0;
                bool setButtonSwitchFullscreenWidthFirstValue = false;
                bool setButtonSwitchFullscreenWidthSecondValue = false;
                float ButtonSwitchFullscreenWidthFirstValue= 0;
                float ButtonSwitchFullscreenWidthSecondValue= 0;
                bool setButtonSwitchFullscreenXFirstValue = false;
                bool setButtonSwitchFullscreenXSecondValue = false;
                float ButtonSwitchFullscreenXFirstValue= 0;
                float ButtonSwitchFullscreenXSecondValue= 0;
                bool setButtonSwitchFullscreenYFirstValue = false;
                bool setButtonSwitchFullscreenYSecondValue = false;
                float ButtonSwitchFullscreenYFirstValue= 0;
                float ButtonSwitchFullscreenYSecondValue= 0;
                bool setMainContainerHeightFirstValue = false;
                bool setMainContainerHeightSecondValue = false;
                float MainContainerHeightFirstValue= 0;
                float MainContainerHeightSecondValue= 0;
                bool setMainContainerWidthFirstValue = false;
                bool setMainContainerWidthSecondValue = false;
                float MainContainerWidthFirstValue= 0;
                float MainContainerWidthSecondValue= 0;
                bool setMainContainerXFirstValue = false;
                bool setMainContainerXSecondValue = false;
                float MainContainerXFirstValue= 0;
                float MainContainerXSecondValue= 0;
                bool setMainContainerYFirstValue = false;
                bool setMainContainerYSecondValue = false;
                float MainContainerYFirstValue= 0;
                float MainContainerYSecondValue= 0;
                bool setSettingsContainerHeightFirstValue = false;
                bool setSettingsContainerHeightSecondValue = false;
                float SettingsContainerHeightFirstValue= 0;
                float SettingsContainerHeightSecondValue= 0;
                bool setSettingsContainerWidthFirstValue = false;
                bool setSettingsContainerWidthSecondValue = false;
                float SettingsContainerWidthFirstValue= 0;
                float SettingsContainerWidthSecondValue= 0;
                bool setSettingsContainerXFirstValue = false;
                bool setSettingsContainerXSecondValue = false;
                float SettingsContainerXFirstValue= 0;
                float SettingsContainerXSecondValue= 0;
                bool setSettingsContainerYFirstValue = false;
                bool setSettingsContainerYSecondValue = false;
                float SettingsContainerYFirstValue= 0;
                float SettingsContainerYSecondValue= 0;
                bool setSliderVolumeWidthFirstValue = false;
                bool setSliderVolumeWidthSecondValue = false;
                float SliderVolumeWidthFirstValue= 0;
                float SliderVolumeWidthSecondValue= 0;
                bool setTextVolumeLevelFontSizeFirstValue = false;
                bool setTextVolumeLevelFontSizeSecondValue = false;
                int TextVolumeLevelFontSizeFirstValue= 0;
                int TextVolumeLevelFontSizeSecondValue= 0;
                bool setTextVolumeLevelHeightFirstValue = false;
                bool setTextVolumeLevelHeightSecondValue = false;
                float TextVolumeLevelHeightFirstValue= 0;
                float TextVolumeLevelHeightSecondValue= 0;
                bool setTextVolumeLevelWidthFirstValue = false;
                bool setTextVolumeLevelWidthSecondValue = false;
                float TextVolumeLevelWidthFirstValue= 0;
                float TextVolumeLevelWidthSecondValue= 0;
                bool setTextVolumeLevelXFirstValue = false;
                bool setTextVolumeLevelXSecondValue = false;
                float TextVolumeLevelXFirstValue= 0;
                float TextVolumeLevelXSecondValue= 0;
                bool setTextVolumeLevelYFirstValue = false;
                bool setTextVolumeLevelYSecondValue = false;
                float TextVolumeLevelYFirstValue= 0;
                float TextVolumeLevelYSecondValue= 0;
                switch(firstState)
                {
                    case  VariableState.Default:
                        setBackgroundBlueFirstValue = true;
                        BackgroundBlueFirstValue = 255;
                        setBackgroundGreenFirstValue = true;
                        BackgroundGreenFirstValue = 255;
                        setBackgroundHeightFirstValue = true;
                        BackgroundHeightFirstValue = 100f;
                        if (interpolationValue < 1)
                        {
                            this.Background.HeightUnits = Gum.DataTypes.DimensionUnitType.PercentageOfOtherDimension;
                        }
                        setBackgroundRedFirstValue = true;
                        BackgroundRedFirstValue = 255;
                        if (interpolationValue < 1)
                        {
                            SetProperty("Background.SourceFile", "BackgroundSprite.png");
                        }
                        if (interpolationValue < 1)
                        {
                            this.Background.Visible = true;
                        }
                        setBackgroundWidthFirstValue = true;
                        BackgroundWidthFirstValue = 100f;
                        if (interpolationValue < 1)
                        {
                            this.Background.WidthUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        setBackgroundXFirstValue = true;
                        BackgroundXFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.Background.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                        }
                        if (interpolationValue < 1)
                        {
                            this.Background.XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        setBackgroundYFirstValue = true;
                        BackgroundYFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.Background.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Top;
                        }
                        if (interpolationValue < 1)
                        {
                            this.Background.YUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ButtonApply.ButtonText = "Appliquer";
                        }
                        setButtonApplyHeightFirstValue = true;
                        ButtonApplyHeightFirstValue = 15f;
                        if (interpolationValue < 1)
                        {
                            this.ButtonApply.HeightUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ButtonApply.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "SettingsContainer");
                        }
                        setButtonApplyWidthFirstValue = true;
                        ButtonApplyWidthFirstValue = 25f;
                        if (interpolationValue < 1)
                        {
                            this.ButtonApply.WidthUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        setButtonApplyXFirstValue = true;
                        ButtonApplyXFirstValue = 5f;
                        if (interpolationValue < 1)
                        {
                            this.ButtonApply.XUnits = Gum.Converters.GeneralUnitType.Percentage;
                        }
                        setButtonApplyYFirstValue = true;
                        ButtonApplyYFirstValue = 80f;
                        if (interpolationValue < 1)
                        {
                            this.ButtonApply.YUnits = Gum.Converters.GeneralUnitType.Percentage;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ButtonBack.ButtonText = "Retour";
                        }
                        setButtonBackHeightFirstValue = true;
                        ButtonBackHeightFirstValue = 15f;
                        if (interpolationValue < 1)
                        {
                            this.ButtonBack.HeightUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ButtonBack.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "SettingsContainer");
                        }
                        setButtonBackWidthFirstValue = true;
                        ButtonBackWidthFirstValue = 25f;
                        if (interpolationValue < 1)
                        {
                            this.ButtonBack.WidthUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        setButtonBackXFirstValue = true;
                        ButtonBackXFirstValue = 70f;
                        if (interpolationValue < 1)
                        {
                            this.ButtonBack.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ButtonBack.XUnits = Gum.Converters.GeneralUnitType.Percentage;
                        }
                        setButtonBackYFirstValue = true;
                        ButtonBackYFirstValue = 80f;
                        if (interpolationValue < 1)
                        {
                            this.ButtonBack.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Top;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ButtonBack.YUnits = Gum.Converters.GeneralUnitType.Percentage;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ButtonPlay.ButtonText = "Jouer";
                        }
                        if (interpolationValue < 1)
                        {
                            this.ButtonPlay.ChildrenLayout = Gum.Managers.ChildrenLayout.Regular;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ButtonPlay.ClipsChildren = false;
                        }
                        setButtonPlayHeightFirstValue = true;
                        ButtonPlayHeightFirstValue = 15f;
                        if (interpolationValue < 1)
                        {
                            this.ButtonPlay.HeightUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ButtonPlay.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "MainContainer");
                        }
                        if (interpolationValue < 1)
                        {
                            this.ButtonPlay.WrapsChildren = false;
                        }
                        setButtonPlayXFirstValue = true;
                        ButtonPlayXFirstValue = 50f;
                        if (interpolationValue < 1)
                        {
                            this.ButtonPlay.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ButtonPlay.XUnits = Gum.Converters.GeneralUnitType.Percentage;
                        }
                        setButtonPlayYFirstValue = true;
                        ButtonPlayYFirstValue = 30f;
                        if (interpolationValue < 1)
                        {
                            this.ButtonPlay.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ButtonPlay.YUnits = Gum.Converters.GeneralUnitType.Percentage;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ButtonQuit.ButtonText = "Quitter";
                        }
                        setButtonQuitHeightFirstValue = true;
                        ButtonQuitHeightFirstValue = 15f;
                        if (interpolationValue < 1)
                        {
                            this.ButtonQuit.HeightUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ButtonQuit.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "MainContainer");
                        }
                        setButtonQuitXFirstValue = true;
                        ButtonQuitXFirstValue = 50f;
                        if (interpolationValue < 1)
                        {
                            this.ButtonQuit.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ButtonQuit.XUnits = Gum.Converters.GeneralUnitType.Percentage;
                        }
                        setButtonQuitYFirstValue = true;
                        ButtonQuitYFirstValue = 70f;
                        if (interpolationValue < 1)
                        {
                            this.ButtonQuit.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ButtonQuit.YUnits = Gum.Converters.GeneralUnitType.Percentage;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ButtonSettings.ButtonText = "Settings";
                        }
                        setButtonSettingsHeightFirstValue = true;
                        ButtonSettingsHeightFirstValue = 15f;
                        if (interpolationValue < 1)
                        {
                            this.ButtonSettings.HeightUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ButtonSettings.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "MainContainer");
                        }
                        setButtonSettingsXFirstValue = true;
                        ButtonSettingsXFirstValue = 50f;
                        if (interpolationValue < 1)
                        {
                            this.ButtonSettings.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ButtonSettings.XUnits = Gum.Converters.GeneralUnitType.Percentage;
                        }
                        setButtonSettingsYFirstValue = true;
                        ButtonSettingsYFirstValue = 50f;
                        if (interpolationValue < 1)
                        {
                            this.ButtonSettings.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ButtonSettings.YUnits = Gum.Converters.GeneralUnitType.Percentage;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ButtonSwitchFullscreen.ButtonText = "Fullscreen";
                        }
                        setButtonSwitchFullscreenHeightFirstValue = true;
                        ButtonSwitchFullscreenHeightFirstValue = 15f;
                        if (interpolationValue < 1)
                        {
                            this.ButtonSwitchFullscreen.HeightUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ButtonSwitchFullscreen.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "SettingsContainer");
                        }
                        setButtonSwitchFullscreenWidthFirstValue = true;
                        ButtonSwitchFullscreenWidthFirstValue = 25f;
                        if (interpolationValue < 1)
                        {
                            this.ButtonSwitchFullscreen.WidthUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        setButtonSwitchFullscreenXFirstValue = true;
                        ButtonSwitchFullscreenXFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.ButtonSwitchFullscreen.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ButtonSwitchFullscreen.XUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        setButtonSwitchFullscreenYFirstValue = true;
                        ButtonSwitchFullscreenYFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.ButtonSwitchFullscreen.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ButtonSwitchFullscreen.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        setMainContainerHeightFirstValue = true;
                        MainContainerHeightFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.MainContainer.HeightUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                        }
                        setMainContainerWidthFirstValue = true;
                        MainContainerWidthFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.MainContainer.WidthUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                        }
                        setMainContainerXFirstValue = true;
                        MainContainerXFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.MainContainer.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                        }
                        if (interpolationValue < 1)
                        {
                            this.MainContainer.XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        setMainContainerYFirstValue = true;
                        MainContainerYFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.MainContainer.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Top;
                        }
                        if (interpolationValue < 1)
                        {
                            this.MainContainer.YUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        setSettingsContainerHeightFirstValue = true;
                        SettingsContainerHeightFirstValue = 100f;
                        if (interpolationValue < 1)
                        {
                            this.SettingsContainer.HeightUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        setSettingsContainerWidthFirstValue = true;
                        SettingsContainerWidthFirstValue = 100f;
                        if (interpolationValue < 1)
                        {
                            this.SettingsContainer.WidthUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        setSettingsContainerXFirstValue = true;
                        SettingsContainerXFirstValue = 100f;
                        if (interpolationValue < 1)
                        {
                            this.SettingsContainer.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                        }
                        if (interpolationValue < 1)
                        {
                            this.SettingsContainer.XUnits = Gum.Converters.GeneralUnitType.Percentage;
                        }
                        setSettingsContainerYFirstValue = true;
                        SettingsContainerYFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.SettingsContainer.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Top;
                        }
                        if (interpolationValue < 1)
                        {
                            this.SettingsContainer.YUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        if (interpolationValue < 1)
                        {
                            this.SliderVolume.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "SettingsContainer");
                        }
                        setSliderVolumeWidthFirstValue = true;
                        SliderVolumeWidthFirstValue = 50f;
                        if (interpolationValue < 1)
                        {
                            this.SliderVolume.WidthUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        if (interpolationValue < 1)
                        {
                            this.TextVolumeLevel.Font = "Vivaldi";
                        }
                        setTextVolumeLevelFontSizeFirstValue = true;
                        TextVolumeLevelFontSizeFirstValue = 48;
                        setTextVolumeLevelHeightFirstValue = true;
                        TextVolumeLevelHeightFirstValue = 20f;
                        if (interpolationValue < 1)
                        {
                            this.TextVolumeLevel.HorizontalAlignment = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                        }
                        if (interpolationValue < 1)
                        {
                            this.TextVolumeLevel.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "SettingsContainer");
                        }
                        if (interpolationValue < 1)
                        {
                            this.TextVolumeLevel.Text = "100";
                        }
                        if (interpolationValue < 1)
                        {
                            this.TextVolumeLevel.VerticalAlignment = RenderingLibrary.Graphics.VerticalAlignment.Center;
                        }
                        setTextVolumeLevelWidthFirstValue = true;
                        TextVolumeLevelWidthFirstValue = 5f;
                        if (interpolationValue < 1)
                        {
                            this.TextVolumeLevel.WidthUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        setTextVolumeLevelXFirstValue = true;
                        TextVolumeLevelXFirstValue = 92f;
                        if (interpolationValue < 1)
                        {
                            this.TextVolumeLevel.XUnits = Gum.Converters.GeneralUnitType.Percentage;
                        }
                        setTextVolumeLevelYFirstValue = true;
                        TextVolumeLevelYFirstValue = 5f;
                        if (interpolationValue < 1)
                        {
                            this.TextVolumeLevel.YUnits = Gum.Converters.GeneralUnitType.Percentage;
                        }
                        break;
                }
                switch(secondState)
                {
                    case  VariableState.Default:
                        setBackgroundBlueSecondValue = true;
                        BackgroundBlueSecondValue = 255;
                        setBackgroundGreenSecondValue = true;
                        BackgroundGreenSecondValue = 255;
                        setBackgroundHeightSecondValue = true;
                        BackgroundHeightSecondValue = 100f;
                        if (interpolationValue >= 1)
                        {
                            this.Background.HeightUnits = Gum.DataTypes.DimensionUnitType.PercentageOfOtherDimension;
                        }
                        setBackgroundRedSecondValue = true;
                        BackgroundRedSecondValue = 255;
                        if (interpolationValue >= 1)
                        {
                            SetProperty("Background.SourceFile", "BackgroundSprite.png");
                        }
                        if (interpolationValue >= 1)
                        {
                            this.Background.Visible = true;
                        }
                        setBackgroundWidthSecondValue = true;
                        BackgroundWidthSecondValue = 100f;
                        if (interpolationValue >= 1)
                        {
                            this.Background.WidthUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        setBackgroundXSecondValue = true;
                        BackgroundXSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.Background.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.Background.XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        setBackgroundYSecondValue = true;
                        BackgroundYSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.Background.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Top;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.Background.YUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ButtonApply.ButtonText = "Appliquer";
                        }
                        setButtonApplyHeightSecondValue = true;
                        ButtonApplyHeightSecondValue = 15f;
                        if (interpolationValue >= 1)
                        {
                            this.ButtonApply.HeightUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ButtonApply.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "SettingsContainer");
                        }
                        setButtonApplyWidthSecondValue = true;
                        ButtonApplyWidthSecondValue = 25f;
                        if (interpolationValue >= 1)
                        {
                            this.ButtonApply.WidthUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        setButtonApplyXSecondValue = true;
                        ButtonApplyXSecondValue = 5f;
                        if (interpolationValue >= 1)
                        {
                            this.ButtonApply.XUnits = Gum.Converters.GeneralUnitType.Percentage;
                        }
                        setButtonApplyYSecondValue = true;
                        ButtonApplyYSecondValue = 80f;
                        if (interpolationValue >= 1)
                        {
                            this.ButtonApply.YUnits = Gum.Converters.GeneralUnitType.Percentage;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ButtonBack.ButtonText = "Retour";
                        }
                        setButtonBackHeightSecondValue = true;
                        ButtonBackHeightSecondValue = 15f;
                        if (interpolationValue >= 1)
                        {
                            this.ButtonBack.HeightUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ButtonBack.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "SettingsContainer");
                        }
                        setButtonBackWidthSecondValue = true;
                        ButtonBackWidthSecondValue = 25f;
                        if (interpolationValue >= 1)
                        {
                            this.ButtonBack.WidthUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        setButtonBackXSecondValue = true;
                        ButtonBackXSecondValue = 70f;
                        if (interpolationValue >= 1)
                        {
                            this.ButtonBack.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ButtonBack.XUnits = Gum.Converters.GeneralUnitType.Percentage;
                        }
                        setButtonBackYSecondValue = true;
                        ButtonBackYSecondValue = 80f;
                        if (interpolationValue >= 1)
                        {
                            this.ButtonBack.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Top;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ButtonBack.YUnits = Gum.Converters.GeneralUnitType.Percentage;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ButtonPlay.ButtonText = "Jouer";
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ButtonPlay.ChildrenLayout = Gum.Managers.ChildrenLayout.Regular;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ButtonPlay.ClipsChildren = false;
                        }
                        setButtonPlayHeightSecondValue = true;
                        ButtonPlayHeightSecondValue = 15f;
                        if (interpolationValue >= 1)
                        {
                            this.ButtonPlay.HeightUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ButtonPlay.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "MainContainer");
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ButtonPlay.WrapsChildren = false;
                        }
                        setButtonPlayXSecondValue = true;
                        ButtonPlayXSecondValue = 50f;
                        if (interpolationValue >= 1)
                        {
                            this.ButtonPlay.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ButtonPlay.XUnits = Gum.Converters.GeneralUnitType.Percentage;
                        }
                        setButtonPlayYSecondValue = true;
                        ButtonPlayYSecondValue = 30f;
                        if (interpolationValue >= 1)
                        {
                            this.ButtonPlay.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ButtonPlay.YUnits = Gum.Converters.GeneralUnitType.Percentage;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ButtonQuit.ButtonText = "Quitter";
                        }
                        setButtonQuitHeightSecondValue = true;
                        ButtonQuitHeightSecondValue = 15f;
                        if (interpolationValue >= 1)
                        {
                            this.ButtonQuit.HeightUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ButtonQuit.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "MainContainer");
                        }
                        setButtonQuitXSecondValue = true;
                        ButtonQuitXSecondValue = 50f;
                        if (interpolationValue >= 1)
                        {
                            this.ButtonQuit.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ButtonQuit.XUnits = Gum.Converters.GeneralUnitType.Percentage;
                        }
                        setButtonQuitYSecondValue = true;
                        ButtonQuitYSecondValue = 70f;
                        if (interpolationValue >= 1)
                        {
                            this.ButtonQuit.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ButtonQuit.YUnits = Gum.Converters.GeneralUnitType.Percentage;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ButtonSettings.ButtonText = "Settings";
                        }
                        setButtonSettingsHeightSecondValue = true;
                        ButtonSettingsHeightSecondValue = 15f;
                        if (interpolationValue >= 1)
                        {
                            this.ButtonSettings.HeightUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ButtonSettings.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "MainContainer");
                        }
                        setButtonSettingsXSecondValue = true;
                        ButtonSettingsXSecondValue = 50f;
                        if (interpolationValue >= 1)
                        {
                            this.ButtonSettings.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ButtonSettings.XUnits = Gum.Converters.GeneralUnitType.Percentage;
                        }
                        setButtonSettingsYSecondValue = true;
                        ButtonSettingsYSecondValue = 50f;
                        if (interpolationValue >= 1)
                        {
                            this.ButtonSettings.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ButtonSettings.YUnits = Gum.Converters.GeneralUnitType.Percentage;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ButtonSwitchFullscreen.ButtonText = "Fullscreen";
                        }
                        setButtonSwitchFullscreenHeightSecondValue = true;
                        ButtonSwitchFullscreenHeightSecondValue = 15f;
                        if (interpolationValue >= 1)
                        {
                            this.ButtonSwitchFullscreen.HeightUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ButtonSwitchFullscreen.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "SettingsContainer");
                        }
                        setButtonSwitchFullscreenWidthSecondValue = true;
                        ButtonSwitchFullscreenWidthSecondValue = 25f;
                        if (interpolationValue >= 1)
                        {
                            this.ButtonSwitchFullscreen.WidthUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        setButtonSwitchFullscreenXSecondValue = true;
                        ButtonSwitchFullscreenXSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.ButtonSwitchFullscreen.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ButtonSwitchFullscreen.XUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        setButtonSwitchFullscreenYSecondValue = true;
                        ButtonSwitchFullscreenYSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.ButtonSwitchFullscreen.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ButtonSwitchFullscreen.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        setMainContainerHeightSecondValue = true;
                        MainContainerHeightSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.MainContainer.HeightUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                        }
                        setMainContainerWidthSecondValue = true;
                        MainContainerWidthSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.MainContainer.WidthUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                        }
                        setMainContainerXSecondValue = true;
                        MainContainerXSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.MainContainer.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.MainContainer.XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        setMainContainerYSecondValue = true;
                        MainContainerYSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.MainContainer.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Top;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.MainContainer.YUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        setSettingsContainerHeightSecondValue = true;
                        SettingsContainerHeightSecondValue = 100f;
                        if (interpolationValue >= 1)
                        {
                            this.SettingsContainer.HeightUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        setSettingsContainerWidthSecondValue = true;
                        SettingsContainerWidthSecondValue = 100f;
                        if (interpolationValue >= 1)
                        {
                            this.SettingsContainer.WidthUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        setSettingsContainerXSecondValue = true;
                        SettingsContainerXSecondValue = 100f;
                        if (interpolationValue >= 1)
                        {
                            this.SettingsContainer.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.SettingsContainer.XUnits = Gum.Converters.GeneralUnitType.Percentage;
                        }
                        setSettingsContainerYSecondValue = true;
                        SettingsContainerYSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.SettingsContainer.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Top;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.SettingsContainer.YUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.SliderVolume.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "SettingsContainer");
                        }
                        setSliderVolumeWidthSecondValue = true;
                        SliderVolumeWidthSecondValue = 50f;
                        if (interpolationValue >= 1)
                        {
                            this.SliderVolume.WidthUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.TextVolumeLevel.Font = "Vivaldi";
                        }
                        setTextVolumeLevelFontSizeSecondValue = true;
                        TextVolumeLevelFontSizeSecondValue = 48;
                        setTextVolumeLevelHeightSecondValue = true;
                        TextVolumeLevelHeightSecondValue = 20f;
                        if (interpolationValue >= 1)
                        {
                            this.TextVolumeLevel.HorizontalAlignment = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.TextVolumeLevel.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "SettingsContainer");
                        }
                        if (interpolationValue >= 1)
                        {
                            this.TextVolumeLevel.Text = "100";
                        }
                        if (interpolationValue >= 1)
                        {
                            this.TextVolumeLevel.VerticalAlignment = RenderingLibrary.Graphics.VerticalAlignment.Center;
                        }
                        setTextVolumeLevelWidthSecondValue = true;
                        TextVolumeLevelWidthSecondValue = 5f;
                        if (interpolationValue >= 1)
                        {
                            this.TextVolumeLevel.WidthUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        setTextVolumeLevelXSecondValue = true;
                        TextVolumeLevelXSecondValue = 92f;
                        if (interpolationValue >= 1)
                        {
                            this.TextVolumeLevel.XUnits = Gum.Converters.GeneralUnitType.Percentage;
                        }
                        setTextVolumeLevelYSecondValue = true;
                        TextVolumeLevelYSecondValue = 5f;
                        if (interpolationValue >= 1)
                        {
                            this.TextVolumeLevel.YUnits = Gum.Converters.GeneralUnitType.Percentage;
                        }
                        break;
                }
                if (setBackgroundBlueFirstValue && setBackgroundBlueSecondValue)
                {
                    Background.Blue = FlatRedBall.Math.MathFunctions.RoundToInt(BackgroundBlueFirstValue* (1 - interpolationValue) + BackgroundBlueSecondValue * interpolationValue);
                }
                if (setBackgroundGreenFirstValue && setBackgroundGreenSecondValue)
                {
                    Background.Green = FlatRedBall.Math.MathFunctions.RoundToInt(BackgroundGreenFirstValue* (1 - interpolationValue) + BackgroundGreenSecondValue * interpolationValue);
                }
                if (setBackgroundHeightFirstValue && setBackgroundHeightSecondValue)
                {
                    Background.Height = BackgroundHeightFirstValue * (1 - interpolationValue) + BackgroundHeightSecondValue * interpolationValue;
                }
                if (setBackgroundRedFirstValue && setBackgroundRedSecondValue)
                {
                    Background.Red = FlatRedBall.Math.MathFunctions.RoundToInt(BackgroundRedFirstValue* (1 - interpolationValue) + BackgroundRedSecondValue * interpolationValue);
                }
                if (setBackgroundWidthFirstValue && setBackgroundWidthSecondValue)
                {
                    Background.Width = BackgroundWidthFirstValue * (1 - interpolationValue) + BackgroundWidthSecondValue * interpolationValue;
                }
                if (setBackgroundXFirstValue && setBackgroundXSecondValue)
                {
                    Background.X = BackgroundXFirstValue * (1 - interpolationValue) + BackgroundXSecondValue * interpolationValue;
                }
                if (setBackgroundYFirstValue && setBackgroundYSecondValue)
                {
                    Background.Y = BackgroundYFirstValue * (1 - interpolationValue) + BackgroundYSecondValue * interpolationValue;
                }
                if (setButtonApplyHeightFirstValue && setButtonApplyHeightSecondValue)
                {
                    ButtonApply.Height = ButtonApplyHeightFirstValue * (1 - interpolationValue) + ButtonApplyHeightSecondValue * interpolationValue;
                }
                if (setButtonApplyWidthFirstValue && setButtonApplyWidthSecondValue)
                {
                    ButtonApply.Width = ButtonApplyWidthFirstValue * (1 - interpolationValue) + ButtonApplyWidthSecondValue * interpolationValue;
                }
                if (setButtonApplyXFirstValue && setButtonApplyXSecondValue)
                {
                    ButtonApply.X = ButtonApplyXFirstValue * (1 - interpolationValue) + ButtonApplyXSecondValue * interpolationValue;
                }
                if (setButtonApplyYFirstValue && setButtonApplyYSecondValue)
                {
                    ButtonApply.Y = ButtonApplyYFirstValue * (1 - interpolationValue) + ButtonApplyYSecondValue * interpolationValue;
                }
                if (setButtonBackHeightFirstValue && setButtonBackHeightSecondValue)
                {
                    ButtonBack.Height = ButtonBackHeightFirstValue * (1 - interpolationValue) + ButtonBackHeightSecondValue * interpolationValue;
                }
                if (setButtonBackWidthFirstValue && setButtonBackWidthSecondValue)
                {
                    ButtonBack.Width = ButtonBackWidthFirstValue * (1 - interpolationValue) + ButtonBackWidthSecondValue * interpolationValue;
                }
                if (setButtonBackXFirstValue && setButtonBackXSecondValue)
                {
                    ButtonBack.X = ButtonBackXFirstValue * (1 - interpolationValue) + ButtonBackXSecondValue * interpolationValue;
                }
                if (setButtonBackYFirstValue && setButtonBackYSecondValue)
                {
                    ButtonBack.Y = ButtonBackYFirstValue * (1 - interpolationValue) + ButtonBackYSecondValue * interpolationValue;
                }
                if (setButtonPlayHeightFirstValue && setButtonPlayHeightSecondValue)
                {
                    ButtonPlay.Height = ButtonPlayHeightFirstValue * (1 - interpolationValue) + ButtonPlayHeightSecondValue * interpolationValue;
                }
                if (setButtonPlayXFirstValue && setButtonPlayXSecondValue)
                {
                    ButtonPlay.X = ButtonPlayXFirstValue * (1 - interpolationValue) + ButtonPlayXSecondValue * interpolationValue;
                }
                if (setButtonPlayYFirstValue && setButtonPlayYSecondValue)
                {
                    ButtonPlay.Y = ButtonPlayYFirstValue * (1 - interpolationValue) + ButtonPlayYSecondValue * interpolationValue;
                }
                if (setButtonQuitHeightFirstValue && setButtonQuitHeightSecondValue)
                {
                    ButtonQuit.Height = ButtonQuitHeightFirstValue * (1 - interpolationValue) + ButtonQuitHeightSecondValue * interpolationValue;
                }
                if (setButtonQuitXFirstValue && setButtonQuitXSecondValue)
                {
                    ButtonQuit.X = ButtonQuitXFirstValue * (1 - interpolationValue) + ButtonQuitXSecondValue * interpolationValue;
                }
                if (setButtonQuitYFirstValue && setButtonQuitYSecondValue)
                {
                    ButtonQuit.Y = ButtonQuitYFirstValue * (1 - interpolationValue) + ButtonQuitYSecondValue * interpolationValue;
                }
                if (setButtonSettingsHeightFirstValue && setButtonSettingsHeightSecondValue)
                {
                    ButtonSettings.Height = ButtonSettingsHeightFirstValue * (1 - interpolationValue) + ButtonSettingsHeightSecondValue * interpolationValue;
                }
                if (setButtonSettingsXFirstValue && setButtonSettingsXSecondValue)
                {
                    ButtonSettings.X = ButtonSettingsXFirstValue * (1 - interpolationValue) + ButtonSettingsXSecondValue * interpolationValue;
                }
                if (setButtonSettingsYFirstValue && setButtonSettingsYSecondValue)
                {
                    ButtonSettings.Y = ButtonSettingsYFirstValue * (1 - interpolationValue) + ButtonSettingsYSecondValue * interpolationValue;
                }
                if (setButtonSwitchFullscreenHeightFirstValue && setButtonSwitchFullscreenHeightSecondValue)
                {
                    ButtonSwitchFullscreen.Height = ButtonSwitchFullscreenHeightFirstValue * (1 - interpolationValue) + ButtonSwitchFullscreenHeightSecondValue * interpolationValue;
                }
                if (setButtonSwitchFullscreenWidthFirstValue && setButtonSwitchFullscreenWidthSecondValue)
                {
                    ButtonSwitchFullscreen.Width = ButtonSwitchFullscreenWidthFirstValue * (1 - interpolationValue) + ButtonSwitchFullscreenWidthSecondValue * interpolationValue;
                }
                if (setButtonSwitchFullscreenXFirstValue && setButtonSwitchFullscreenXSecondValue)
                {
                    ButtonSwitchFullscreen.X = ButtonSwitchFullscreenXFirstValue * (1 - interpolationValue) + ButtonSwitchFullscreenXSecondValue * interpolationValue;
                }
                if (setButtonSwitchFullscreenYFirstValue && setButtonSwitchFullscreenYSecondValue)
                {
                    ButtonSwitchFullscreen.Y = ButtonSwitchFullscreenYFirstValue * (1 - interpolationValue) + ButtonSwitchFullscreenYSecondValue * interpolationValue;
                }
                if (setMainContainerHeightFirstValue && setMainContainerHeightSecondValue)
                {
                    MainContainer.Height = MainContainerHeightFirstValue * (1 - interpolationValue) + MainContainerHeightSecondValue * interpolationValue;
                }
                if (setMainContainerWidthFirstValue && setMainContainerWidthSecondValue)
                {
                    MainContainer.Width = MainContainerWidthFirstValue * (1 - interpolationValue) + MainContainerWidthSecondValue * interpolationValue;
                }
                if (setMainContainerXFirstValue && setMainContainerXSecondValue)
                {
                    MainContainer.X = MainContainerXFirstValue * (1 - interpolationValue) + MainContainerXSecondValue * interpolationValue;
                }
                if (setMainContainerYFirstValue && setMainContainerYSecondValue)
                {
                    MainContainer.Y = MainContainerYFirstValue * (1 - interpolationValue) + MainContainerYSecondValue * interpolationValue;
                }
                if (setSettingsContainerHeightFirstValue && setSettingsContainerHeightSecondValue)
                {
                    SettingsContainer.Height = SettingsContainerHeightFirstValue * (1 - interpolationValue) + SettingsContainerHeightSecondValue * interpolationValue;
                }
                if (setSettingsContainerWidthFirstValue && setSettingsContainerWidthSecondValue)
                {
                    SettingsContainer.Width = SettingsContainerWidthFirstValue * (1 - interpolationValue) + SettingsContainerWidthSecondValue * interpolationValue;
                }
                if (setSettingsContainerXFirstValue && setSettingsContainerXSecondValue)
                {
                    SettingsContainer.X = SettingsContainerXFirstValue * (1 - interpolationValue) + SettingsContainerXSecondValue * interpolationValue;
                }
                if (setSettingsContainerYFirstValue && setSettingsContainerYSecondValue)
                {
                    SettingsContainer.Y = SettingsContainerYFirstValue * (1 - interpolationValue) + SettingsContainerYSecondValue * interpolationValue;
                }
                if (setSliderVolumeWidthFirstValue && setSliderVolumeWidthSecondValue)
                {
                    SliderVolume.Width = SliderVolumeWidthFirstValue * (1 - interpolationValue) + SliderVolumeWidthSecondValue * interpolationValue;
                }
                if (setTextVolumeLevelFontSizeFirstValue && setTextVolumeLevelFontSizeSecondValue)
                {
                    TextVolumeLevel.FontSize = FlatRedBall.Math.MathFunctions.RoundToInt(TextVolumeLevelFontSizeFirstValue* (1 - interpolationValue) + TextVolumeLevelFontSizeSecondValue * interpolationValue);
                }
                if (setTextVolumeLevelHeightFirstValue && setTextVolumeLevelHeightSecondValue)
                {
                    TextVolumeLevel.Height = TextVolumeLevelHeightFirstValue * (1 - interpolationValue) + TextVolumeLevelHeightSecondValue * interpolationValue;
                }
                if (setTextVolumeLevelWidthFirstValue && setTextVolumeLevelWidthSecondValue)
                {
                    TextVolumeLevel.Width = TextVolumeLevelWidthFirstValue * (1 - interpolationValue) + TextVolumeLevelWidthSecondValue * interpolationValue;
                }
                if (setTextVolumeLevelXFirstValue && setTextVolumeLevelXSecondValue)
                {
                    TextVolumeLevel.X = TextVolumeLevelXFirstValue * (1 - interpolationValue) + TextVolumeLevelXSecondValue * interpolationValue;
                }
                if (setTextVolumeLevelYFirstValue && setTextVolumeLevelYSecondValue)
                {
                    TextVolumeLevel.Y = TextVolumeLevelYFirstValue * (1 - interpolationValue) + TextVolumeLevelYSecondValue * interpolationValue;
                }
                if (interpolationValue < 1)
                {
                    mCurrentVariableState = firstState;
                }
                else
                {
                    mCurrentVariableState = secondState;
                }
            }
            #endregion
            #region State Interpolate To
            public FlatRedBall.Glue.StateInterpolation.Tweener InterpolateTo (Pirates.GumRuntimes.MainMenuScreenGumRuntime.VariableState fromState,Pirates.GumRuntimes.MainMenuScreenGumRuntime.VariableState toState, double secondsToTake, FlatRedBall.Glue.StateInterpolation.InterpolationType interpolationType, FlatRedBall.Glue.StateInterpolation.Easing easing, object owner = null) 
            {
                FlatRedBall.Glue.StateInterpolation.Tweener tweener = new FlatRedBall.Glue.StateInterpolation.Tweener(from:0, to:1, duration:(float)secondsToTake, type:interpolationType, easing:easing );
                if (owner == null)
                {
                    tweener.Owner = this;
                }
                else
                {
                    tweener.Owner = owner;
                }
                tweener.PositionChanged = newPosition => this.InterpolateBetween(fromState, toState, newPosition);
                tweener.Start();
                StateInterpolationPlugin.TweenerManager.Self.Add(tweener);
                return tweener;
            }
            public FlatRedBall.Glue.StateInterpolation.Tweener InterpolateTo (VariableState toState, double secondsToTake, FlatRedBall.Glue.StateInterpolation.InterpolationType interpolationType, FlatRedBall.Glue.StateInterpolation.Easing easing, object owner = null ) 
            {
                Gum.DataTypes.Variables.StateSave current = GetCurrentValuesOnState(toState);
                Gum.DataTypes.Variables.StateSave toAsStateSave = this.ElementSave.States.First(item => item.Name == toState.ToString());
                FlatRedBall.Glue.StateInterpolation.Tweener tweener = new FlatRedBall.Glue.StateInterpolation.Tweener(from: 0, to: 1, duration: (float)secondsToTake, type: interpolationType, easing: easing);
                if (owner == null)
                {
                    tweener.Owner = this;
                }
                else
                {
                    tweener.Owner = owner;
                }
                tweener.PositionChanged = newPosition => this.InterpolateBetween(current, toAsStateSave, newPosition);
                tweener.Ended += ()=> this.CurrentVariableState = toState;
                tweener.Start();
                StateInterpolationPlugin.TweenerManager.Self.Add(tweener);
                return tweener;
            }
            public FlatRedBall.Glue.StateInterpolation.Tweener InterpolateToRelative (VariableState toState, double secondsToTake, FlatRedBall.Glue.StateInterpolation.InterpolationType interpolationType, FlatRedBall.Glue.StateInterpolation.Easing easing, object owner = null ) 
            {
                Gum.DataTypes.Variables.StateSave current = GetCurrentValuesOnState(toState);
                Gum.DataTypes.Variables.StateSave toAsStateSave = AddToCurrentValuesWithState(toState);
                FlatRedBall.Glue.StateInterpolation.Tweener tweener = new FlatRedBall.Glue.StateInterpolation.Tweener(from: 0, to: 1, duration: (float)secondsToTake, type: interpolationType, easing: easing);
                if (owner == null)
                {
                    tweener.Owner = this;
                }
                else
                {
                    tweener.Owner = owner;
                }
                tweener.PositionChanged = newPosition => this.InterpolateBetween(current, toAsStateSave, newPosition);
                tweener.Ended += ()=> this.CurrentVariableState = toState;
                tweener.Start();
                StateInterpolationPlugin.TweenerManager.Self.Add(tweener);
                return tweener;
            }
            #endregion
            #region State Animations
            #endregion
            public override void StopAnimations () 
            {
                base.StopAnimations();
                ButtonPlay.StopAnimations();
                ButtonSettings.StopAnimations();
                ButtonQuit.StopAnimations();
                ButtonBack.StopAnimations();
                SliderVolume.StopAnimations();
                ButtonSwitchFullscreen.StopAnimations();
                ButtonApply.StopAnimations();
            }
            #region Get Current Values on State
            private Gum.DataTypes.Variables.StateSave GetCurrentValuesOnState (VariableState state) 
            {
                Gum.DataTypes.Variables.StateSave newState = new Gum.DataTypes.Variables.StateSave();
                switch(state)
                {
                    case  VariableState.Default:
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonPlay.ButtonText",
                            Type = "string",
                            Value = ButtonPlay.ButtonText
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonPlay.Children Layout",
                            Type = "ChildrenLayout",
                            Value = ButtonPlay.ChildrenLayout
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonPlay.Clips Children",
                            Type = "bool",
                            Value = ButtonPlay.ClipsChildren
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonPlay.Height",
                            Type = "float",
                            Value = ButtonPlay.Height
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonPlay.Height Units",
                            Type = "DimensionUnitType",
                            Value = ButtonPlay.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonPlay.Parent",
                            Type = "string",
                            Value = ButtonPlay.Parent
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonPlay.Wraps Children",
                            Type = "bool",
                            Value = ButtonPlay.WrapsChildren
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonPlay.X",
                            Type = "float",
                            Value = ButtonPlay.X
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonPlay.X Origin",
                            Type = "HorizontalAlignment",
                            Value = ButtonPlay.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonPlay.X Units",
                            Type = "PositionUnitType",
                            Value = ButtonPlay.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonPlay.Y",
                            Type = "float",
                            Value = ButtonPlay.Y
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonPlay.Y Origin",
                            Type = "VerticalAlignment",
                            Value = ButtonPlay.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonPlay.Y Units",
                            Type = "PositionUnitType",
                            Value = ButtonPlay.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonSettings.ButtonText",
                            Type = "string",
                            Value = ButtonSettings.ButtonText
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonSettings.Height",
                            Type = "float",
                            Value = ButtonSettings.Height
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonSettings.Height Units",
                            Type = "DimensionUnitType",
                            Value = ButtonSettings.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonSettings.Parent",
                            Type = "string",
                            Value = ButtonSettings.Parent
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonSettings.X",
                            Type = "float",
                            Value = ButtonSettings.X
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonSettings.X Origin",
                            Type = "HorizontalAlignment",
                            Value = ButtonSettings.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonSettings.X Units",
                            Type = "PositionUnitType",
                            Value = ButtonSettings.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonSettings.Y",
                            Type = "float",
                            Value = ButtonSettings.Y
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonSettings.Y Origin",
                            Type = "VerticalAlignment",
                            Value = ButtonSettings.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonSettings.Y Units",
                            Type = "PositionUnitType",
                            Value = ButtonSettings.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonQuit.ButtonText",
                            Type = "string",
                            Value = ButtonQuit.ButtonText
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonQuit.Height",
                            Type = "float",
                            Value = ButtonQuit.Height
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonQuit.Height Units",
                            Type = "DimensionUnitType",
                            Value = ButtonQuit.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonQuit.Parent",
                            Type = "string",
                            Value = ButtonQuit.Parent
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonQuit.X",
                            Type = "float",
                            Value = ButtonQuit.X
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonQuit.X Origin",
                            Type = "HorizontalAlignment",
                            Value = ButtonQuit.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonQuit.X Units",
                            Type = "PositionUnitType",
                            Value = ButtonQuit.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonQuit.Y",
                            Type = "float",
                            Value = ButtonQuit.Y
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonQuit.Y Origin",
                            Type = "VerticalAlignment",
                            Value = ButtonQuit.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonQuit.Y Units",
                            Type = "PositionUnitType",
                            Value = ButtonQuit.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Background.Blue",
                            Type = "int",
                            Value = Background.Blue
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Background.Green",
                            Type = "int",
                            Value = Background.Green
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Background.Height",
                            Type = "float",
                            Value = Background.Height
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Background.Height Units",
                            Type = "DimensionUnitType",
                            Value = Background.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Background.Red",
                            Type = "int",
                            Value = Background.Red
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Background.SourceFile",
                            Type = "string",
                            Value = Background.SourceFile
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Background.Visible",
                            Type = "bool",
                            Value = Background.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Background.Width",
                            Type = "float",
                            Value = Background.Width
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Background.Width Units",
                            Type = "DimensionUnitType",
                            Value = Background.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Background.X",
                            Type = "float",
                            Value = Background.X
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Background.X Origin",
                            Type = "HorizontalAlignment",
                            Value = Background.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Background.X Units",
                            Type = "PositionUnitType",
                            Value = Background.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Background.Y",
                            Type = "float",
                            Value = Background.Y
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Background.Y Origin",
                            Type = "VerticalAlignment",
                            Value = Background.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Background.Y Units",
                            Type = "PositionUnitType",
                            Value = Background.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MainContainer.Height",
                            Type = "float",
                            Value = MainContainer.Height
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MainContainer.Height Units",
                            Type = "DimensionUnitType",
                            Value = MainContainer.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MainContainer.Width",
                            Type = "float",
                            Value = MainContainer.Width
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MainContainer.Width Units",
                            Type = "DimensionUnitType",
                            Value = MainContainer.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MainContainer.X",
                            Type = "float",
                            Value = MainContainer.X
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MainContainer.X Origin",
                            Type = "HorizontalAlignment",
                            Value = MainContainer.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MainContainer.X Units",
                            Type = "PositionUnitType",
                            Value = MainContainer.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MainContainer.Y",
                            Type = "float",
                            Value = MainContainer.Y
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MainContainer.Y Origin",
                            Type = "VerticalAlignment",
                            Value = MainContainer.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MainContainer.Y Units",
                            Type = "PositionUnitType",
                            Value = MainContainer.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SettingsContainer.Height",
                            Type = "float",
                            Value = SettingsContainer.Height
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SettingsContainer.Height Units",
                            Type = "DimensionUnitType",
                            Value = SettingsContainer.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SettingsContainer.Width",
                            Type = "float",
                            Value = SettingsContainer.Width
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SettingsContainer.Width Units",
                            Type = "DimensionUnitType",
                            Value = SettingsContainer.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SettingsContainer.X",
                            Type = "float",
                            Value = SettingsContainer.X
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SettingsContainer.X Origin",
                            Type = "HorizontalAlignment",
                            Value = SettingsContainer.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SettingsContainer.X Units",
                            Type = "PositionUnitType",
                            Value = SettingsContainer.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SettingsContainer.Y",
                            Type = "float",
                            Value = SettingsContainer.Y
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SettingsContainer.Y Origin",
                            Type = "VerticalAlignment",
                            Value = SettingsContainer.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SettingsContainer.Y Units",
                            Type = "PositionUnitType",
                            Value = SettingsContainer.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonBack.ButtonText",
                            Type = "string",
                            Value = ButtonBack.ButtonText
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonBack.Height",
                            Type = "float",
                            Value = ButtonBack.Height
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonBack.Height Units",
                            Type = "DimensionUnitType",
                            Value = ButtonBack.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonBack.Parent",
                            Type = "string",
                            Value = ButtonBack.Parent
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonBack.Width",
                            Type = "float",
                            Value = ButtonBack.Width
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonBack.Width Units",
                            Type = "DimensionUnitType",
                            Value = ButtonBack.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonBack.X",
                            Type = "float",
                            Value = ButtonBack.X
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonBack.X Origin",
                            Type = "HorizontalAlignment",
                            Value = ButtonBack.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonBack.X Units",
                            Type = "PositionUnitType",
                            Value = ButtonBack.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonBack.Y",
                            Type = "float",
                            Value = ButtonBack.Y
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonBack.Y Origin",
                            Type = "VerticalAlignment",
                            Value = ButtonBack.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonBack.Y Units",
                            Type = "PositionUnitType",
                            Value = ButtonBack.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextVolumeLevel.Font",
                            Type = "string",
                            Value = TextVolumeLevel.Font
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextVolumeLevel.FontSize",
                            Type = "int",
                            Value = TextVolumeLevel.FontSize
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextVolumeLevel.Height",
                            Type = "float",
                            Value = TextVolumeLevel.Height
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextVolumeLevel.HorizontalAlignment",
                            Type = "HorizontalAlignment",
                            Value = TextVolumeLevel.HorizontalAlignment
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextVolumeLevel.Parent",
                            Type = "string",
                            Value = TextVolumeLevel.Parent
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextVolumeLevel.Text",
                            Type = "string",
                            Value = TextVolumeLevel.Text
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextVolumeLevel.VerticalAlignment",
                            Type = "VerticalAlignment",
                            Value = TextVolumeLevel.VerticalAlignment
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextVolumeLevel.Width",
                            Type = "float",
                            Value = TextVolumeLevel.Width
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextVolumeLevel.Width Units",
                            Type = "DimensionUnitType",
                            Value = TextVolumeLevel.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextVolumeLevel.X",
                            Type = "float",
                            Value = TextVolumeLevel.X
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextVolumeLevel.X Units",
                            Type = "PositionUnitType",
                            Value = TextVolumeLevel.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextVolumeLevel.Y",
                            Type = "float",
                            Value = TextVolumeLevel.Y
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextVolumeLevel.Y Units",
                            Type = "PositionUnitType",
                            Value = TextVolumeLevel.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SliderVolume.Parent",
                            Type = "string",
                            Value = SliderVolume.Parent
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SliderVolume.Width",
                            Type = "float",
                            Value = SliderVolume.Width
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SliderVolume.Width Units",
                            Type = "DimensionUnitType",
                            Value = SliderVolume.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonSwitchFullscreen.ButtonText",
                            Type = "string",
                            Value = ButtonSwitchFullscreen.ButtonText
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonSwitchFullscreen.Height",
                            Type = "float",
                            Value = ButtonSwitchFullscreen.Height
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonSwitchFullscreen.Height Units",
                            Type = "DimensionUnitType",
                            Value = ButtonSwitchFullscreen.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonSwitchFullscreen.Parent",
                            Type = "string",
                            Value = ButtonSwitchFullscreen.Parent
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonSwitchFullscreen.Width",
                            Type = "float",
                            Value = ButtonSwitchFullscreen.Width
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonSwitchFullscreen.Width Units",
                            Type = "DimensionUnitType",
                            Value = ButtonSwitchFullscreen.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonSwitchFullscreen.X",
                            Type = "float",
                            Value = ButtonSwitchFullscreen.X
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonSwitchFullscreen.X Origin",
                            Type = "HorizontalAlignment",
                            Value = ButtonSwitchFullscreen.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonSwitchFullscreen.X Units",
                            Type = "PositionUnitType",
                            Value = ButtonSwitchFullscreen.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonSwitchFullscreen.Y",
                            Type = "float",
                            Value = ButtonSwitchFullscreen.Y
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonSwitchFullscreen.Y Origin",
                            Type = "VerticalAlignment",
                            Value = ButtonSwitchFullscreen.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonSwitchFullscreen.Y Units",
                            Type = "PositionUnitType",
                            Value = ButtonSwitchFullscreen.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonApply.ButtonText",
                            Type = "string",
                            Value = ButtonApply.ButtonText
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonApply.Height",
                            Type = "float",
                            Value = ButtonApply.Height
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonApply.Height Units",
                            Type = "DimensionUnitType",
                            Value = ButtonApply.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonApply.Parent",
                            Type = "string",
                            Value = ButtonApply.Parent
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonApply.Width",
                            Type = "float",
                            Value = ButtonApply.Width
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonApply.Width Units",
                            Type = "DimensionUnitType",
                            Value = ButtonApply.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonApply.X",
                            Type = "float",
                            Value = ButtonApply.X
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonApply.X Units",
                            Type = "PositionUnitType",
                            Value = ButtonApply.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonApply.Y",
                            Type = "float",
                            Value = ButtonApply.Y
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonApply.Y Units",
                            Type = "PositionUnitType",
                            Value = ButtonApply.YUnits
                        }
                        );
                        break;
                }
                return newState;
            }
            private Gum.DataTypes.Variables.StateSave AddToCurrentValuesWithState (VariableState state) 
            {
                Gum.DataTypes.Variables.StateSave newState = new Gum.DataTypes.Variables.StateSave();
                switch(state)
                {
                    case  VariableState.Default:
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonPlay.ButtonText",
                            Type = "string",
                            Value = ButtonPlay.ButtonText
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonPlay.Children Layout",
                            Type = "ChildrenLayout",
                            Value = ButtonPlay.ChildrenLayout
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonPlay.Clips Children",
                            Type = "bool",
                            Value = ButtonPlay.ClipsChildren
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonPlay.Height",
                            Type = "float",
                            Value = ButtonPlay.Height + 15f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonPlay.Height Units",
                            Type = "DimensionUnitType",
                            Value = ButtonPlay.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonPlay.Parent",
                            Type = "string",
                            Value = ButtonPlay.Parent
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonPlay.Wraps Children",
                            Type = "bool",
                            Value = ButtonPlay.WrapsChildren
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonPlay.X",
                            Type = "float",
                            Value = ButtonPlay.X + 50f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonPlay.X Origin",
                            Type = "HorizontalAlignment",
                            Value = ButtonPlay.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonPlay.X Units",
                            Type = "PositionUnitType",
                            Value = ButtonPlay.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonPlay.Y",
                            Type = "float",
                            Value = ButtonPlay.Y + 30f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonPlay.Y Origin",
                            Type = "VerticalAlignment",
                            Value = ButtonPlay.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonPlay.Y Units",
                            Type = "PositionUnitType",
                            Value = ButtonPlay.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonSettings.ButtonText",
                            Type = "string",
                            Value = ButtonSettings.ButtonText
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonSettings.Height",
                            Type = "float",
                            Value = ButtonSettings.Height + 15f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonSettings.Height Units",
                            Type = "DimensionUnitType",
                            Value = ButtonSettings.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonSettings.Parent",
                            Type = "string",
                            Value = ButtonSettings.Parent
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonSettings.X",
                            Type = "float",
                            Value = ButtonSettings.X + 50f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonSettings.X Origin",
                            Type = "HorizontalAlignment",
                            Value = ButtonSettings.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonSettings.X Units",
                            Type = "PositionUnitType",
                            Value = ButtonSettings.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonSettings.Y",
                            Type = "float",
                            Value = ButtonSettings.Y + 50f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonSettings.Y Origin",
                            Type = "VerticalAlignment",
                            Value = ButtonSettings.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonSettings.Y Units",
                            Type = "PositionUnitType",
                            Value = ButtonSettings.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonQuit.ButtonText",
                            Type = "string",
                            Value = ButtonQuit.ButtonText
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonQuit.Height",
                            Type = "float",
                            Value = ButtonQuit.Height + 15f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonQuit.Height Units",
                            Type = "DimensionUnitType",
                            Value = ButtonQuit.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonQuit.Parent",
                            Type = "string",
                            Value = ButtonQuit.Parent
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonQuit.X",
                            Type = "float",
                            Value = ButtonQuit.X + 50f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonQuit.X Origin",
                            Type = "HorizontalAlignment",
                            Value = ButtonQuit.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonQuit.X Units",
                            Type = "PositionUnitType",
                            Value = ButtonQuit.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonQuit.Y",
                            Type = "float",
                            Value = ButtonQuit.Y + 70f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonQuit.Y Origin",
                            Type = "VerticalAlignment",
                            Value = ButtonQuit.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonQuit.Y Units",
                            Type = "PositionUnitType",
                            Value = ButtonQuit.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Background.Blue",
                            Type = "int",
                            Value = Background.Blue + 255
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Background.Green",
                            Type = "int",
                            Value = Background.Green + 255
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Background.Height",
                            Type = "float",
                            Value = Background.Height + 100f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Background.Height Units",
                            Type = "DimensionUnitType",
                            Value = Background.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Background.Red",
                            Type = "int",
                            Value = Background.Red + 255
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Background.SourceFile",
                            Type = "string",
                            Value = Background.SourceFile
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Background.Visible",
                            Type = "bool",
                            Value = Background.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Background.Width",
                            Type = "float",
                            Value = Background.Width + 100f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Background.Width Units",
                            Type = "DimensionUnitType",
                            Value = Background.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Background.X",
                            Type = "float",
                            Value = Background.X + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Background.X Origin",
                            Type = "HorizontalAlignment",
                            Value = Background.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Background.X Units",
                            Type = "PositionUnitType",
                            Value = Background.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Background.Y",
                            Type = "float",
                            Value = Background.Y + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Background.Y Origin",
                            Type = "VerticalAlignment",
                            Value = Background.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Background.Y Units",
                            Type = "PositionUnitType",
                            Value = Background.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MainContainer.Height",
                            Type = "float",
                            Value = MainContainer.Height + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MainContainer.Height Units",
                            Type = "DimensionUnitType",
                            Value = MainContainer.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MainContainer.Width",
                            Type = "float",
                            Value = MainContainer.Width + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MainContainer.Width Units",
                            Type = "DimensionUnitType",
                            Value = MainContainer.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MainContainer.X",
                            Type = "float",
                            Value = MainContainer.X + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MainContainer.X Origin",
                            Type = "HorizontalAlignment",
                            Value = MainContainer.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MainContainer.X Units",
                            Type = "PositionUnitType",
                            Value = MainContainer.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MainContainer.Y",
                            Type = "float",
                            Value = MainContainer.Y + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MainContainer.Y Origin",
                            Type = "VerticalAlignment",
                            Value = MainContainer.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MainContainer.Y Units",
                            Type = "PositionUnitType",
                            Value = MainContainer.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SettingsContainer.Height",
                            Type = "float",
                            Value = SettingsContainer.Height + 100f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SettingsContainer.Height Units",
                            Type = "DimensionUnitType",
                            Value = SettingsContainer.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SettingsContainer.Width",
                            Type = "float",
                            Value = SettingsContainer.Width + 100f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SettingsContainer.Width Units",
                            Type = "DimensionUnitType",
                            Value = SettingsContainer.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SettingsContainer.X",
                            Type = "float",
                            Value = SettingsContainer.X + 100f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SettingsContainer.X Origin",
                            Type = "HorizontalAlignment",
                            Value = SettingsContainer.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SettingsContainer.X Units",
                            Type = "PositionUnitType",
                            Value = SettingsContainer.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SettingsContainer.Y",
                            Type = "float",
                            Value = SettingsContainer.Y + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SettingsContainer.Y Origin",
                            Type = "VerticalAlignment",
                            Value = SettingsContainer.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SettingsContainer.Y Units",
                            Type = "PositionUnitType",
                            Value = SettingsContainer.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonBack.ButtonText",
                            Type = "string",
                            Value = ButtonBack.ButtonText
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonBack.Height",
                            Type = "float",
                            Value = ButtonBack.Height + 15f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonBack.Height Units",
                            Type = "DimensionUnitType",
                            Value = ButtonBack.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonBack.Parent",
                            Type = "string",
                            Value = ButtonBack.Parent
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonBack.Width",
                            Type = "float",
                            Value = ButtonBack.Width + 25f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonBack.Width Units",
                            Type = "DimensionUnitType",
                            Value = ButtonBack.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonBack.X",
                            Type = "float",
                            Value = ButtonBack.X + 70f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonBack.X Origin",
                            Type = "HorizontalAlignment",
                            Value = ButtonBack.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonBack.X Units",
                            Type = "PositionUnitType",
                            Value = ButtonBack.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonBack.Y",
                            Type = "float",
                            Value = ButtonBack.Y + 80f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonBack.Y Origin",
                            Type = "VerticalAlignment",
                            Value = ButtonBack.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonBack.Y Units",
                            Type = "PositionUnitType",
                            Value = ButtonBack.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextVolumeLevel.Font",
                            Type = "string",
                            Value = TextVolumeLevel.Font
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextVolumeLevel.FontSize",
                            Type = "int",
                            Value = TextVolumeLevel.FontSize + 48
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextVolumeLevel.Height",
                            Type = "float",
                            Value = TextVolumeLevel.Height + 20f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextVolumeLevel.HorizontalAlignment",
                            Type = "HorizontalAlignment",
                            Value = TextVolumeLevel.HorizontalAlignment
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextVolumeLevel.Parent",
                            Type = "string",
                            Value = TextVolumeLevel.Parent
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextVolumeLevel.Text",
                            Type = "string",
                            Value = TextVolumeLevel.Text
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextVolumeLevel.VerticalAlignment",
                            Type = "VerticalAlignment",
                            Value = TextVolumeLevel.VerticalAlignment
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextVolumeLevel.Width",
                            Type = "float",
                            Value = TextVolumeLevel.Width + 5f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextVolumeLevel.Width Units",
                            Type = "DimensionUnitType",
                            Value = TextVolumeLevel.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextVolumeLevel.X",
                            Type = "float",
                            Value = TextVolumeLevel.X + 92f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextVolumeLevel.X Units",
                            Type = "PositionUnitType",
                            Value = TextVolumeLevel.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextVolumeLevel.Y",
                            Type = "float",
                            Value = TextVolumeLevel.Y + 5f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextVolumeLevel.Y Units",
                            Type = "PositionUnitType",
                            Value = TextVolumeLevel.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SliderVolume.Parent",
                            Type = "string",
                            Value = SliderVolume.Parent
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SliderVolume.Width",
                            Type = "float",
                            Value = SliderVolume.Width + 50f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SliderVolume.Width Units",
                            Type = "DimensionUnitType",
                            Value = SliderVolume.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonSwitchFullscreen.ButtonText",
                            Type = "string",
                            Value = ButtonSwitchFullscreen.ButtonText
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonSwitchFullscreen.Height",
                            Type = "float",
                            Value = ButtonSwitchFullscreen.Height + 15f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonSwitchFullscreen.Height Units",
                            Type = "DimensionUnitType",
                            Value = ButtonSwitchFullscreen.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonSwitchFullscreen.Parent",
                            Type = "string",
                            Value = ButtonSwitchFullscreen.Parent
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonSwitchFullscreen.Width",
                            Type = "float",
                            Value = ButtonSwitchFullscreen.Width + 25f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonSwitchFullscreen.Width Units",
                            Type = "DimensionUnitType",
                            Value = ButtonSwitchFullscreen.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonSwitchFullscreen.X",
                            Type = "float",
                            Value = ButtonSwitchFullscreen.X + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonSwitchFullscreen.X Origin",
                            Type = "HorizontalAlignment",
                            Value = ButtonSwitchFullscreen.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonSwitchFullscreen.X Units",
                            Type = "PositionUnitType",
                            Value = ButtonSwitchFullscreen.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonSwitchFullscreen.Y",
                            Type = "float",
                            Value = ButtonSwitchFullscreen.Y + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonSwitchFullscreen.Y Origin",
                            Type = "VerticalAlignment",
                            Value = ButtonSwitchFullscreen.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonSwitchFullscreen.Y Units",
                            Type = "PositionUnitType",
                            Value = ButtonSwitchFullscreen.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonApply.ButtonText",
                            Type = "string",
                            Value = ButtonApply.ButtonText
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonApply.Height",
                            Type = "float",
                            Value = ButtonApply.Height + 15f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonApply.Height Units",
                            Type = "DimensionUnitType",
                            Value = ButtonApply.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonApply.Parent",
                            Type = "string",
                            Value = ButtonApply.Parent
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonApply.Width",
                            Type = "float",
                            Value = ButtonApply.Width + 25f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonApply.Width Units",
                            Type = "DimensionUnitType",
                            Value = ButtonApply.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonApply.X",
                            Type = "float",
                            Value = ButtonApply.X + 5f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonApply.X Units",
                            Type = "PositionUnitType",
                            Value = ButtonApply.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonApply.Y",
                            Type = "float",
                            Value = ButtonApply.Y + 80f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonApply.Y Units",
                            Type = "PositionUnitType",
                            Value = ButtonApply.YUnits
                        }
                        );
                        break;
                }
                return newState;
            }
            #endregion
            public override void ApplyState (Gum.DataTypes.Variables.StateSave state) 
            {
                bool matches = this.ElementSave.AllStates.Contains(state);
                if (matches)
                {
                    var category = this.ElementSave.Categories.FirstOrDefault(item => item.States.Contains(state));
                    if (category == null)
                    {
                        if (state.Name == "Default") this.mCurrentVariableState = VariableState.Default;
                    }
                }
                base.ApplyState(state);
            }
            public Pirates.GumRuntimes.ButtonRuntime ButtonPlay { get; set; }
            public Pirates.GumRuntimes.ButtonRuntime ButtonSettings { get; set; }
            public Pirates.GumRuntimes.ButtonRuntime ButtonQuit { get; set; }
            public Pirates.GumRuntimes.SpriteRuntime Background { get; set; }
            public Pirates.GumRuntimes.ContainerRuntime MainContainer { get; set; }
            public Pirates.GumRuntimes.ContainerRuntime SettingsContainer { get; set; }
            public Pirates.GumRuntimes.ButtonRuntime ButtonBack { get; set; }
            public Pirates.GumRuntimes.TextRuntime TextVolumeLevel { get; set; }
            public Pirates.GumRuntimes.DefaultForms.SliderRuntime SliderVolume { get; set; }
            public Pirates.GumRuntimes.ButtonRuntime ButtonSwitchFullscreen { get; set; }
            public Pirates.GumRuntimes.ButtonRuntime ButtonApply { get; set; }
            public MainMenuScreenGumRuntime (bool fullInstantiation = true, bool tryCreateFormsObject = true) 
            {
                if (fullInstantiation)
                {
                    Gum.DataTypes.ElementSave elementSave = Gum.Managers.ObjectFinder.Self.GumProjectSave.Screens.First(item => item.Name == "MainMenuScreenGum");
                    this.ElementSave = elementSave;
                    string oldDirectory = FlatRedBall.IO.FileManager.RelativeDirectory;
                    FlatRedBall.IO.FileManager.RelativeDirectory = FlatRedBall.IO.FileManager.GetDirectory(Gum.Managers.ObjectFinder.Self.GumProjectSave.FullFileName);
                    GumRuntime.ElementSaveExtensions.SetGraphicalUiElement(elementSave, this, RenderingLibrary.SystemManagers.Default);
                    FlatRedBall.IO.FileManager.RelativeDirectory = oldDirectory;
                }
            }
            public override void SetInitialState () 
            {
                base.SetInitialState();
                this.CurrentVariableState = VariableState.Default;
                CallCustomInitialize();
            }
            public override void CreateChildrenRecursively (Gum.DataTypes.ElementSave elementSave, RenderingLibrary.SystemManagers systemManagers) 
            {
                base.CreateChildrenRecursively(elementSave, systemManagers);
                this.AssignReferences();
            }
            private void AssignReferences () 
            {
                ButtonPlay = this.GetGraphicalUiElementByName("ButtonPlay") as Pirates.GumRuntimes.ButtonRuntime;
                ButtonSettings = this.GetGraphicalUiElementByName("ButtonSettings") as Pirates.GumRuntimes.ButtonRuntime;
                ButtonQuit = this.GetGraphicalUiElementByName("ButtonQuit") as Pirates.GumRuntimes.ButtonRuntime;
                Background = this.GetGraphicalUiElementByName("Background") as Pirates.GumRuntimes.SpriteRuntime;
                MainContainer = this.GetGraphicalUiElementByName("MainContainer") as Pirates.GumRuntimes.ContainerRuntime;
                SettingsContainer = this.GetGraphicalUiElementByName("SettingsContainer") as Pirates.GumRuntimes.ContainerRuntime;
                ButtonBack = this.GetGraphicalUiElementByName("ButtonBack") as Pirates.GumRuntimes.ButtonRuntime;
                TextVolumeLevel = this.GetGraphicalUiElementByName("TextVolumeLevel") as Pirates.GumRuntimes.TextRuntime;
                SliderVolume = this.GetGraphicalUiElementByName("SliderVolume") as Pirates.GumRuntimes.DefaultForms.SliderRuntime;
                ButtonSwitchFullscreen = this.GetGraphicalUiElementByName("ButtonSwitchFullscreen") as Pirates.GumRuntimes.ButtonRuntime;
                ButtonApply = this.GetGraphicalUiElementByName("ButtonApply") as Pirates.GumRuntimes.ButtonRuntime;
            }
            public override void AddToManagers (RenderingLibrary.SystemManagers managers, RenderingLibrary.Graphics.Layer layer) 
            {
                base.AddToManagers(managers, layer);
            }
            private void CallCustomInitialize () 
            {
                CustomInitialize();
            }
            partial void CustomInitialize();
        }
    }
