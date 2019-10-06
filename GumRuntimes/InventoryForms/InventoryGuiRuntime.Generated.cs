    using System.Linq;
    namespace Pirates.GumRuntimes.InventoryForms
    {
        public partial class InventoryGuiRuntime : Pirates.GumRuntimes.ContainerRuntime
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
                            RectangleBackground.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "ContainerMain") ?? this;
                            ContainerInfos.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "ContainerMain") ?? this;
                            ContainerItems.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "ContainerMain") ?? this;
                            TextLabelPlayerName.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "ContainerInfos") ?? this;
                            TextPlayerName.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "ContainerInfos") ?? this;
                            InventoryBar.CurrentVariableState = Pirates.GumRuntimes.InventoryForms.InventoryBarRuntime.VariableState.Default;
                            ChildrenLayout = Gum.Managers.ChildrenLayout.Regular;
                            ClipsChildren = false;
                            Height = 90f;
                            HeightUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                            Visible = true;
                            Width = 80f;
                            WidthUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                            WrapsChildren = true;
                            X = 10f;
                            XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                            XUnits = Gum.Converters.GeneralUnitType.Percentage;
                            Y = 10f;
                            YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Top;
                            YUnits = Gum.Converters.GeneralUnitType.Percentage;
                            ContainerMain.Height = 89f;
                            ContainerMain.HeightUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                            ContainerMain.Width = 100f;
                            ContainerMain.WidthUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                            RectangleBackground.Alpha = 192;
                            RectangleBackground.Blue = 128;
                            RectangleBackground.Green = 128;
                            RectangleBackground.Height = 100f;
                            RectangleBackground.HeightUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                            RectangleBackground.Red = 128;
                            RectangleBackground.Width = 100f;
                            RectangleBackground.WidthUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                            ContainerInfos.Height = 50f;
                            ContainerInfos.HeightUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                            ContainerInfos.Width = 100f;
                            ContainerInfos.WidthUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                            ContainerInfos.X = 0f;
                            ContainerInfos.XUnits = Gum.Converters.GeneralUnitType.Percentage;
                            ContainerInfos.Y = 0f;
                            ContainerInfos.YUnits = Gum.Converters.GeneralUnitType.Percentage;
                            ContainerItems.ChildrenLayout = Gum.Managers.ChildrenLayout.LeftToRightStack;
                            ContainerItems.ClipsChildren = true;
                            ContainerItems.Height = 240f;
                            ContainerItems.HeightUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                            ContainerItems.Visible = true;
                            ContainerItems.Width = 480f;
                            ContainerItems.WidthUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                            ContainerItems.WrapsChildren = true;
                            ContainerItems.X = 0f;
                            ContainerItems.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                            ContainerItems.XUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                            ContainerItems.Y = 50f;
                            ContainerItems.YUnits = Gum.Converters.GeneralUnitType.Percentage;
                            TextLabelPlayerName.Font = "Vivaldi";
                            TextLabelPlayerName.FontSize = 40;
                            TextLabelPlayerName.Height = 0f;
                            TextLabelPlayerName.HeightUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                            TextLabelPlayerName.Text = "Player Name :";
                            TextLabelPlayerName.Width = 50f;
                            TextLabelPlayerName.WidthUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                            TextPlayerName.Font = "Vivaldi";
                            TextPlayerName.FontSize = 40;
                            TextPlayerName.Height = 0f;
                            TextPlayerName.Text = "";
                            TextPlayerName.Width = 50f;
                            TextPlayerName.WidthUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                            TextPlayerName.X = 50f;
                            TextPlayerName.XUnits = Gum.Converters.GeneralUnitType.Percentage;
                            TextPlayerName.Y = 0f;
                            HeldItemSprite.Height = 60f;
                            HeldItemSprite.HeightUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                            HeldItemSprite.Width = 60f;
                            HeldItemSprite.WidthUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                            HeldItemSprite.X = 0f;
                            HeldItemSprite.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                            HeldItemSprite.XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                            HeldItemSprite.Y = 0f;
                            HeldItemSprite.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Top;
                            HeldItemSprite.YUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                            InventoryBar.ClipsChildren = false;
                            InventoryBar.Visible = true;
                            InventoryBar.WrapsChildren = false;
                            InventoryBar.Y = 0f;
                            InventoryBar.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Bottom;
                            InventoryBar.YUnits = Gum.Converters.GeneralUnitType.PixelsFromLarge;
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
                bool setContainerInfosHeightFirstValue = false;
                bool setContainerInfosHeightSecondValue = false;
                float ContainerInfosHeightFirstValue= 0;
                float ContainerInfosHeightSecondValue= 0;
                bool setContainerInfosWidthFirstValue = false;
                bool setContainerInfosWidthSecondValue = false;
                float ContainerInfosWidthFirstValue= 0;
                float ContainerInfosWidthSecondValue= 0;
                bool setContainerInfosXFirstValue = false;
                bool setContainerInfosXSecondValue = false;
                float ContainerInfosXFirstValue= 0;
                float ContainerInfosXSecondValue= 0;
                bool setContainerInfosYFirstValue = false;
                bool setContainerInfosYSecondValue = false;
                float ContainerInfosYFirstValue= 0;
                float ContainerInfosYSecondValue= 0;
                bool setContainerItemsHeightFirstValue = false;
                bool setContainerItemsHeightSecondValue = false;
                float ContainerItemsHeightFirstValue= 0;
                float ContainerItemsHeightSecondValue= 0;
                bool setContainerItemsWidthFirstValue = false;
                bool setContainerItemsWidthSecondValue = false;
                float ContainerItemsWidthFirstValue= 0;
                float ContainerItemsWidthSecondValue= 0;
                bool setContainerItemsXFirstValue = false;
                bool setContainerItemsXSecondValue = false;
                float ContainerItemsXFirstValue= 0;
                float ContainerItemsXSecondValue= 0;
                bool setContainerItemsYFirstValue = false;
                bool setContainerItemsYSecondValue = false;
                float ContainerItemsYFirstValue= 0;
                float ContainerItemsYSecondValue= 0;
                bool setContainerMainHeightFirstValue = false;
                bool setContainerMainHeightSecondValue = false;
                float ContainerMainHeightFirstValue= 0;
                float ContainerMainHeightSecondValue= 0;
                bool setContainerMainWidthFirstValue = false;
                bool setContainerMainWidthSecondValue = false;
                float ContainerMainWidthFirstValue= 0;
                float ContainerMainWidthSecondValue= 0;
                bool setHeightFirstValue = false;
                bool setHeightSecondValue = false;
                float HeightFirstValue= 0;
                float HeightSecondValue= 0;
                bool setHeldItemSpriteHeightFirstValue = false;
                bool setHeldItemSpriteHeightSecondValue = false;
                float HeldItemSpriteHeightFirstValue= 0;
                float HeldItemSpriteHeightSecondValue= 0;
                bool setHeldItemSpriteWidthFirstValue = false;
                bool setHeldItemSpriteWidthSecondValue = false;
                float HeldItemSpriteWidthFirstValue= 0;
                float HeldItemSpriteWidthSecondValue= 0;
                bool setHeldItemSpriteXFirstValue = false;
                bool setHeldItemSpriteXSecondValue = false;
                float HeldItemSpriteXFirstValue= 0;
                float HeldItemSpriteXSecondValue= 0;
                bool setHeldItemSpriteYFirstValue = false;
                bool setHeldItemSpriteYSecondValue = false;
                float HeldItemSpriteYFirstValue= 0;
                float HeldItemSpriteYSecondValue= 0;
                bool setInventoryBarCurrentVariableStateFirstValue = false;
                bool setInventoryBarCurrentVariableStateSecondValue = false;
                Pirates.GumRuntimes.InventoryForms.InventoryBarRuntime.VariableState InventoryBarCurrentVariableStateFirstValue= Pirates.GumRuntimes.InventoryForms.InventoryBarRuntime.VariableState.Default;
                Pirates.GumRuntimes.InventoryForms.InventoryBarRuntime.VariableState InventoryBarCurrentVariableStateSecondValue= Pirates.GumRuntimes.InventoryForms.InventoryBarRuntime.VariableState.Default;
                bool setInventoryBarYFirstValue = false;
                bool setInventoryBarYSecondValue = false;
                float InventoryBarYFirstValue= 0;
                float InventoryBarYSecondValue= 0;
                bool setRectangleBackgroundAlphaFirstValue = false;
                bool setRectangleBackgroundAlphaSecondValue = false;
                int RectangleBackgroundAlphaFirstValue= 0;
                int RectangleBackgroundAlphaSecondValue= 0;
                bool setRectangleBackgroundBlueFirstValue = false;
                bool setRectangleBackgroundBlueSecondValue = false;
                int RectangleBackgroundBlueFirstValue= 0;
                int RectangleBackgroundBlueSecondValue= 0;
                bool setRectangleBackgroundGreenFirstValue = false;
                bool setRectangleBackgroundGreenSecondValue = false;
                int RectangleBackgroundGreenFirstValue= 0;
                int RectangleBackgroundGreenSecondValue= 0;
                bool setRectangleBackgroundHeightFirstValue = false;
                bool setRectangleBackgroundHeightSecondValue = false;
                float RectangleBackgroundHeightFirstValue= 0;
                float RectangleBackgroundHeightSecondValue= 0;
                bool setRectangleBackgroundRedFirstValue = false;
                bool setRectangleBackgroundRedSecondValue = false;
                int RectangleBackgroundRedFirstValue= 0;
                int RectangleBackgroundRedSecondValue= 0;
                bool setRectangleBackgroundWidthFirstValue = false;
                bool setRectangleBackgroundWidthSecondValue = false;
                float RectangleBackgroundWidthFirstValue= 0;
                float RectangleBackgroundWidthSecondValue= 0;
                bool setTextLabelPlayerNameFontSizeFirstValue = false;
                bool setTextLabelPlayerNameFontSizeSecondValue = false;
                int TextLabelPlayerNameFontSizeFirstValue= 0;
                int TextLabelPlayerNameFontSizeSecondValue= 0;
                bool setTextLabelPlayerNameHeightFirstValue = false;
                bool setTextLabelPlayerNameHeightSecondValue = false;
                float TextLabelPlayerNameHeightFirstValue= 0;
                float TextLabelPlayerNameHeightSecondValue= 0;
                bool setTextLabelPlayerNameWidthFirstValue = false;
                bool setTextLabelPlayerNameWidthSecondValue = false;
                float TextLabelPlayerNameWidthFirstValue= 0;
                float TextLabelPlayerNameWidthSecondValue= 0;
                bool setTextPlayerNameFontSizeFirstValue = false;
                bool setTextPlayerNameFontSizeSecondValue = false;
                int TextPlayerNameFontSizeFirstValue= 0;
                int TextPlayerNameFontSizeSecondValue= 0;
                bool setTextPlayerNameHeightFirstValue = false;
                bool setTextPlayerNameHeightSecondValue = false;
                float TextPlayerNameHeightFirstValue= 0;
                float TextPlayerNameHeightSecondValue= 0;
                bool setTextPlayerNameWidthFirstValue = false;
                bool setTextPlayerNameWidthSecondValue = false;
                float TextPlayerNameWidthFirstValue= 0;
                float TextPlayerNameWidthSecondValue= 0;
                bool setTextPlayerNameXFirstValue = false;
                bool setTextPlayerNameXSecondValue = false;
                float TextPlayerNameXFirstValue= 0;
                float TextPlayerNameXSecondValue= 0;
                bool setTextPlayerNameYFirstValue = false;
                bool setTextPlayerNameYSecondValue = false;
                float TextPlayerNameYFirstValue= 0;
                float TextPlayerNameYSecondValue= 0;
                bool setWidthFirstValue = false;
                bool setWidthSecondValue = false;
                float WidthFirstValue= 0;
                float WidthSecondValue= 0;
                bool setXFirstValue = false;
                bool setXSecondValue = false;
                float XFirstValue= 0;
                float XSecondValue= 0;
                bool setYFirstValue = false;
                bool setYSecondValue = false;
                float YFirstValue= 0;
                float YSecondValue= 0;
                switch(firstState)
                {
                    case  VariableState.Default:
                        if (interpolationValue < 1)
                        {
                            this.ChildrenLayout = Gum.Managers.ChildrenLayout.Regular;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ClipsChildren = false;
                        }
                        setContainerInfosHeightFirstValue = true;
                        ContainerInfosHeightFirstValue = 50f;
                        if (interpolationValue < 1)
                        {
                            this.ContainerInfos.HeightUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ContainerInfos.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "ContainerMain") ?? this;
                        }
                        setContainerInfosWidthFirstValue = true;
                        ContainerInfosWidthFirstValue = 100f;
                        if (interpolationValue < 1)
                        {
                            this.ContainerInfos.WidthUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        setContainerInfosXFirstValue = true;
                        ContainerInfosXFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.ContainerInfos.XUnits = Gum.Converters.GeneralUnitType.Percentage;
                        }
                        setContainerInfosYFirstValue = true;
                        ContainerInfosYFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.ContainerInfos.YUnits = Gum.Converters.GeneralUnitType.Percentage;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ContainerItems.ChildrenLayout = Gum.Managers.ChildrenLayout.LeftToRightStack;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ContainerItems.ClipsChildren = true;
                        }
                        setContainerItemsHeightFirstValue = true;
                        ContainerItemsHeightFirstValue = 240f;
                        if (interpolationValue < 1)
                        {
                            this.ContainerItems.HeightUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ContainerItems.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "ContainerMain") ?? this;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ContainerItems.Visible = true;
                        }
                        setContainerItemsWidthFirstValue = true;
                        ContainerItemsWidthFirstValue = 480f;
                        if (interpolationValue < 1)
                        {
                            this.ContainerItems.WidthUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ContainerItems.WrapsChildren = true;
                        }
                        setContainerItemsXFirstValue = true;
                        ContainerItemsXFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.ContainerItems.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ContainerItems.XUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        setContainerItemsYFirstValue = true;
                        ContainerItemsYFirstValue = 50f;
                        if (interpolationValue < 1)
                        {
                            this.ContainerItems.YUnits = Gum.Converters.GeneralUnitType.Percentage;
                        }
                        setContainerMainHeightFirstValue = true;
                        ContainerMainHeightFirstValue = 89f;
                        if (interpolationValue < 1)
                        {
                            this.ContainerMain.HeightUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        setContainerMainWidthFirstValue = true;
                        ContainerMainWidthFirstValue = 100f;
                        if (interpolationValue < 1)
                        {
                            this.ContainerMain.WidthUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        setHeightFirstValue = true;
                        HeightFirstValue = 90f;
                        if (interpolationValue < 1)
                        {
                            this.HeightUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        setHeldItemSpriteHeightFirstValue = true;
                        HeldItemSpriteHeightFirstValue = 60f;
                        if (interpolationValue < 1)
                        {
                            this.HeldItemSprite.HeightUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        setHeldItemSpriteWidthFirstValue = true;
                        HeldItemSpriteWidthFirstValue = 60f;
                        if (interpolationValue < 1)
                        {
                            this.HeldItemSprite.WidthUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        setHeldItemSpriteXFirstValue = true;
                        HeldItemSpriteXFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.HeldItemSprite.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                        }
                        if (interpolationValue < 1)
                        {
                            this.HeldItemSprite.XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        setHeldItemSpriteYFirstValue = true;
                        HeldItemSpriteYFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.HeldItemSprite.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Top;
                        }
                        if (interpolationValue < 1)
                        {
                            this.HeldItemSprite.YUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        if (interpolationValue < 1)
                        {
                            this.InventoryBar.ClipsChildren = false;
                        }
                        setInventoryBarCurrentVariableStateFirstValue = true;
                        InventoryBarCurrentVariableStateFirstValue = Pirates.GumRuntimes.InventoryForms.InventoryBarRuntime.VariableState.Default;
                        if (interpolationValue < 1)
                        {
                            this.InventoryBar.Visible = true;
                        }
                        if (interpolationValue < 1)
                        {
                            this.InventoryBar.WrapsChildren = false;
                        }
                        setInventoryBarYFirstValue = true;
                        InventoryBarYFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.InventoryBar.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Bottom;
                        }
                        if (interpolationValue < 1)
                        {
                            this.InventoryBar.YUnits = Gum.Converters.GeneralUnitType.PixelsFromLarge;
                        }
                        setRectangleBackgroundAlphaFirstValue = true;
                        RectangleBackgroundAlphaFirstValue = 192;
                        setRectangleBackgroundBlueFirstValue = true;
                        RectangleBackgroundBlueFirstValue = 128;
                        setRectangleBackgroundGreenFirstValue = true;
                        RectangleBackgroundGreenFirstValue = 128;
                        setRectangleBackgroundHeightFirstValue = true;
                        RectangleBackgroundHeightFirstValue = 100f;
                        if (interpolationValue < 1)
                        {
                            this.RectangleBackground.HeightUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        if (interpolationValue < 1)
                        {
                            this.RectangleBackground.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "ContainerMain") ?? this;
                        }
                        setRectangleBackgroundRedFirstValue = true;
                        RectangleBackgroundRedFirstValue = 128;
                        setRectangleBackgroundWidthFirstValue = true;
                        RectangleBackgroundWidthFirstValue = 100f;
                        if (interpolationValue < 1)
                        {
                            this.RectangleBackground.WidthUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        if (interpolationValue < 1)
                        {
                            this.TextLabelPlayerName.Font = "Vivaldi";
                        }
                        setTextLabelPlayerNameFontSizeFirstValue = true;
                        TextLabelPlayerNameFontSizeFirstValue = 40;
                        setTextLabelPlayerNameHeightFirstValue = true;
                        TextLabelPlayerNameHeightFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.TextLabelPlayerName.HeightUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        if (interpolationValue < 1)
                        {
                            this.TextLabelPlayerName.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "ContainerInfos") ?? this;
                        }
                        if (interpolationValue < 1)
                        {
                            this.TextLabelPlayerName.Text = "Player Name :";
                        }
                        setTextLabelPlayerNameWidthFirstValue = true;
                        TextLabelPlayerNameWidthFirstValue = 50f;
                        if (interpolationValue < 1)
                        {
                            this.TextLabelPlayerName.WidthUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        if (interpolationValue < 1)
                        {
                            this.TextPlayerName.Font = "Vivaldi";
                        }
                        setTextPlayerNameFontSizeFirstValue = true;
                        TextPlayerNameFontSizeFirstValue = 40;
                        setTextPlayerNameHeightFirstValue = true;
                        TextPlayerNameHeightFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.TextPlayerName.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "ContainerInfos") ?? this;
                        }
                        if (interpolationValue < 1)
                        {
                            this.TextPlayerName.Text = "";
                        }
                        setTextPlayerNameWidthFirstValue = true;
                        TextPlayerNameWidthFirstValue = 50f;
                        if (interpolationValue < 1)
                        {
                            this.TextPlayerName.WidthUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        setTextPlayerNameXFirstValue = true;
                        TextPlayerNameXFirstValue = 50f;
                        if (interpolationValue < 1)
                        {
                            this.TextPlayerName.XUnits = Gum.Converters.GeneralUnitType.Percentage;
                        }
                        setTextPlayerNameYFirstValue = true;
                        TextPlayerNameYFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.Visible = true;
                        }
                        setWidthFirstValue = true;
                        WidthFirstValue = 80f;
                        if (interpolationValue < 1)
                        {
                            this.WidthUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        if (interpolationValue < 1)
                        {
                            this.WrapsChildren = true;
                        }
                        setXFirstValue = true;
                        XFirstValue = 10f;
                        if (interpolationValue < 1)
                        {
                            this.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                        }
                        if (interpolationValue < 1)
                        {
                            this.XUnits = Gum.Converters.GeneralUnitType.Percentage;
                        }
                        setYFirstValue = true;
                        YFirstValue = 10f;
                        if (interpolationValue < 1)
                        {
                            this.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Top;
                        }
                        if (interpolationValue < 1)
                        {
                            this.YUnits = Gum.Converters.GeneralUnitType.Percentage;
                        }
                        break;
                }
                switch(secondState)
                {
                    case  VariableState.Default:
                        if (interpolationValue >= 1)
                        {
                            this.ChildrenLayout = Gum.Managers.ChildrenLayout.Regular;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ClipsChildren = false;
                        }
                        setContainerInfosHeightSecondValue = true;
                        ContainerInfosHeightSecondValue = 50f;
                        if (interpolationValue >= 1)
                        {
                            this.ContainerInfos.HeightUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ContainerInfos.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "ContainerMain") ?? this;
                        }
                        setContainerInfosWidthSecondValue = true;
                        ContainerInfosWidthSecondValue = 100f;
                        if (interpolationValue >= 1)
                        {
                            this.ContainerInfos.WidthUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        setContainerInfosXSecondValue = true;
                        ContainerInfosXSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.ContainerInfos.XUnits = Gum.Converters.GeneralUnitType.Percentage;
                        }
                        setContainerInfosYSecondValue = true;
                        ContainerInfosYSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.ContainerInfos.YUnits = Gum.Converters.GeneralUnitType.Percentage;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ContainerItems.ChildrenLayout = Gum.Managers.ChildrenLayout.LeftToRightStack;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ContainerItems.ClipsChildren = true;
                        }
                        setContainerItemsHeightSecondValue = true;
                        ContainerItemsHeightSecondValue = 240f;
                        if (interpolationValue >= 1)
                        {
                            this.ContainerItems.HeightUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ContainerItems.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "ContainerMain") ?? this;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ContainerItems.Visible = true;
                        }
                        setContainerItemsWidthSecondValue = true;
                        ContainerItemsWidthSecondValue = 480f;
                        if (interpolationValue >= 1)
                        {
                            this.ContainerItems.WidthUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ContainerItems.WrapsChildren = true;
                        }
                        setContainerItemsXSecondValue = true;
                        ContainerItemsXSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.ContainerItems.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ContainerItems.XUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        setContainerItemsYSecondValue = true;
                        ContainerItemsYSecondValue = 50f;
                        if (interpolationValue >= 1)
                        {
                            this.ContainerItems.YUnits = Gum.Converters.GeneralUnitType.Percentage;
                        }
                        setContainerMainHeightSecondValue = true;
                        ContainerMainHeightSecondValue = 89f;
                        if (interpolationValue >= 1)
                        {
                            this.ContainerMain.HeightUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        setContainerMainWidthSecondValue = true;
                        ContainerMainWidthSecondValue = 100f;
                        if (interpolationValue >= 1)
                        {
                            this.ContainerMain.WidthUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        setHeightSecondValue = true;
                        HeightSecondValue = 90f;
                        if (interpolationValue >= 1)
                        {
                            this.HeightUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        setHeldItemSpriteHeightSecondValue = true;
                        HeldItemSpriteHeightSecondValue = 60f;
                        if (interpolationValue >= 1)
                        {
                            this.HeldItemSprite.HeightUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        setHeldItemSpriteWidthSecondValue = true;
                        HeldItemSpriteWidthSecondValue = 60f;
                        if (interpolationValue >= 1)
                        {
                            this.HeldItemSprite.WidthUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        setHeldItemSpriteXSecondValue = true;
                        HeldItemSpriteXSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.HeldItemSprite.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.HeldItemSprite.XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        setHeldItemSpriteYSecondValue = true;
                        HeldItemSpriteYSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.HeldItemSprite.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Top;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.HeldItemSprite.YUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.InventoryBar.ClipsChildren = false;
                        }
                        setInventoryBarCurrentVariableStateSecondValue = true;
                        InventoryBarCurrentVariableStateSecondValue = Pirates.GumRuntimes.InventoryForms.InventoryBarRuntime.VariableState.Default;
                        if (interpolationValue >= 1)
                        {
                            this.InventoryBar.Visible = true;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.InventoryBar.WrapsChildren = false;
                        }
                        setInventoryBarYSecondValue = true;
                        InventoryBarYSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.InventoryBar.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Bottom;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.InventoryBar.YUnits = Gum.Converters.GeneralUnitType.PixelsFromLarge;
                        }
                        setRectangleBackgroundAlphaSecondValue = true;
                        RectangleBackgroundAlphaSecondValue = 192;
                        setRectangleBackgroundBlueSecondValue = true;
                        RectangleBackgroundBlueSecondValue = 128;
                        setRectangleBackgroundGreenSecondValue = true;
                        RectangleBackgroundGreenSecondValue = 128;
                        setRectangleBackgroundHeightSecondValue = true;
                        RectangleBackgroundHeightSecondValue = 100f;
                        if (interpolationValue >= 1)
                        {
                            this.RectangleBackground.HeightUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.RectangleBackground.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "ContainerMain") ?? this;
                        }
                        setRectangleBackgroundRedSecondValue = true;
                        RectangleBackgroundRedSecondValue = 128;
                        setRectangleBackgroundWidthSecondValue = true;
                        RectangleBackgroundWidthSecondValue = 100f;
                        if (interpolationValue >= 1)
                        {
                            this.RectangleBackground.WidthUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.TextLabelPlayerName.Font = "Vivaldi";
                        }
                        setTextLabelPlayerNameFontSizeSecondValue = true;
                        TextLabelPlayerNameFontSizeSecondValue = 40;
                        setTextLabelPlayerNameHeightSecondValue = true;
                        TextLabelPlayerNameHeightSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.TextLabelPlayerName.HeightUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.TextLabelPlayerName.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "ContainerInfos") ?? this;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.TextLabelPlayerName.Text = "Player Name :";
                        }
                        setTextLabelPlayerNameWidthSecondValue = true;
                        TextLabelPlayerNameWidthSecondValue = 50f;
                        if (interpolationValue >= 1)
                        {
                            this.TextLabelPlayerName.WidthUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.TextPlayerName.Font = "Vivaldi";
                        }
                        setTextPlayerNameFontSizeSecondValue = true;
                        TextPlayerNameFontSizeSecondValue = 40;
                        setTextPlayerNameHeightSecondValue = true;
                        TextPlayerNameHeightSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.TextPlayerName.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "ContainerInfos") ?? this;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.TextPlayerName.Text = "";
                        }
                        setTextPlayerNameWidthSecondValue = true;
                        TextPlayerNameWidthSecondValue = 50f;
                        if (interpolationValue >= 1)
                        {
                            this.TextPlayerName.WidthUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        setTextPlayerNameXSecondValue = true;
                        TextPlayerNameXSecondValue = 50f;
                        if (interpolationValue >= 1)
                        {
                            this.TextPlayerName.XUnits = Gum.Converters.GeneralUnitType.Percentage;
                        }
                        setTextPlayerNameYSecondValue = true;
                        TextPlayerNameYSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.Visible = true;
                        }
                        setWidthSecondValue = true;
                        WidthSecondValue = 80f;
                        if (interpolationValue >= 1)
                        {
                            this.WidthUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.WrapsChildren = true;
                        }
                        setXSecondValue = true;
                        XSecondValue = 10f;
                        if (interpolationValue >= 1)
                        {
                            this.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.XUnits = Gum.Converters.GeneralUnitType.Percentage;
                        }
                        setYSecondValue = true;
                        YSecondValue = 10f;
                        if (interpolationValue >= 1)
                        {
                            this.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Top;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.YUnits = Gum.Converters.GeneralUnitType.Percentage;
                        }
                        break;
                }
                if (setContainerInfosHeightFirstValue && setContainerInfosHeightSecondValue)
                {
                    ContainerInfos.Height = ContainerInfosHeightFirstValue * (1 - interpolationValue) + ContainerInfosHeightSecondValue * interpolationValue;
                }
                if (setContainerInfosWidthFirstValue && setContainerInfosWidthSecondValue)
                {
                    ContainerInfos.Width = ContainerInfosWidthFirstValue * (1 - interpolationValue) + ContainerInfosWidthSecondValue * interpolationValue;
                }
                if (setContainerInfosXFirstValue && setContainerInfosXSecondValue)
                {
                    ContainerInfos.X = ContainerInfosXFirstValue * (1 - interpolationValue) + ContainerInfosXSecondValue * interpolationValue;
                }
                if (setContainerInfosYFirstValue && setContainerInfosYSecondValue)
                {
                    ContainerInfos.Y = ContainerInfosYFirstValue * (1 - interpolationValue) + ContainerInfosYSecondValue * interpolationValue;
                }
                if (setContainerItemsHeightFirstValue && setContainerItemsHeightSecondValue)
                {
                    ContainerItems.Height = ContainerItemsHeightFirstValue * (1 - interpolationValue) + ContainerItemsHeightSecondValue * interpolationValue;
                }
                if (setContainerItemsWidthFirstValue && setContainerItemsWidthSecondValue)
                {
                    ContainerItems.Width = ContainerItemsWidthFirstValue * (1 - interpolationValue) + ContainerItemsWidthSecondValue * interpolationValue;
                }
                if (setContainerItemsXFirstValue && setContainerItemsXSecondValue)
                {
                    ContainerItems.X = ContainerItemsXFirstValue * (1 - interpolationValue) + ContainerItemsXSecondValue * interpolationValue;
                }
                if (setContainerItemsYFirstValue && setContainerItemsYSecondValue)
                {
                    ContainerItems.Y = ContainerItemsYFirstValue * (1 - interpolationValue) + ContainerItemsYSecondValue * interpolationValue;
                }
                if (setContainerMainHeightFirstValue && setContainerMainHeightSecondValue)
                {
                    ContainerMain.Height = ContainerMainHeightFirstValue * (1 - interpolationValue) + ContainerMainHeightSecondValue * interpolationValue;
                }
                if (setContainerMainWidthFirstValue && setContainerMainWidthSecondValue)
                {
                    ContainerMain.Width = ContainerMainWidthFirstValue * (1 - interpolationValue) + ContainerMainWidthSecondValue * interpolationValue;
                }
                if (setHeightFirstValue && setHeightSecondValue)
                {
                    Height = HeightFirstValue * (1 - interpolationValue) + HeightSecondValue * interpolationValue;
                }
                if (setHeldItemSpriteHeightFirstValue && setHeldItemSpriteHeightSecondValue)
                {
                    HeldItemSprite.Height = HeldItemSpriteHeightFirstValue * (1 - interpolationValue) + HeldItemSpriteHeightSecondValue * interpolationValue;
                }
                if (setHeldItemSpriteWidthFirstValue && setHeldItemSpriteWidthSecondValue)
                {
                    HeldItemSprite.Width = HeldItemSpriteWidthFirstValue * (1 - interpolationValue) + HeldItemSpriteWidthSecondValue * interpolationValue;
                }
                if (setHeldItemSpriteXFirstValue && setHeldItemSpriteXSecondValue)
                {
                    HeldItemSprite.X = HeldItemSpriteXFirstValue * (1 - interpolationValue) + HeldItemSpriteXSecondValue * interpolationValue;
                }
                if (setHeldItemSpriteYFirstValue && setHeldItemSpriteYSecondValue)
                {
                    HeldItemSprite.Y = HeldItemSpriteYFirstValue * (1 - interpolationValue) + HeldItemSpriteYSecondValue * interpolationValue;
                }
                if (setInventoryBarCurrentVariableStateFirstValue && setInventoryBarCurrentVariableStateSecondValue)
                {
                    InventoryBar.InterpolateBetween(InventoryBarCurrentVariableStateFirstValue, InventoryBarCurrentVariableStateSecondValue, interpolationValue);
                }
                if (setInventoryBarYFirstValue && setInventoryBarYSecondValue)
                {
                    InventoryBar.Y = InventoryBarYFirstValue * (1 - interpolationValue) + InventoryBarYSecondValue * interpolationValue;
                }
                if (setRectangleBackgroundAlphaFirstValue && setRectangleBackgroundAlphaSecondValue)
                {
                    RectangleBackground.Alpha = FlatRedBall.Math.MathFunctions.RoundToInt(RectangleBackgroundAlphaFirstValue* (1 - interpolationValue) + RectangleBackgroundAlphaSecondValue * interpolationValue);
                }
                if (setRectangleBackgroundBlueFirstValue && setRectangleBackgroundBlueSecondValue)
                {
                    RectangleBackground.Blue = FlatRedBall.Math.MathFunctions.RoundToInt(RectangleBackgroundBlueFirstValue* (1 - interpolationValue) + RectangleBackgroundBlueSecondValue * interpolationValue);
                }
                if (setRectangleBackgroundGreenFirstValue && setRectangleBackgroundGreenSecondValue)
                {
                    RectangleBackground.Green = FlatRedBall.Math.MathFunctions.RoundToInt(RectangleBackgroundGreenFirstValue* (1 - interpolationValue) + RectangleBackgroundGreenSecondValue * interpolationValue);
                }
                if (setRectangleBackgroundHeightFirstValue && setRectangleBackgroundHeightSecondValue)
                {
                    RectangleBackground.Height = RectangleBackgroundHeightFirstValue * (1 - interpolationValue) + RectangleBackgroundHeightSecondValue * interpolationValue;
                }
                if (setRectangleBackgroundRedFirstValue && setRectangleBackgroundRedSecondValue)
                {
                    RectangleBackground.Red = FlatRedBall.Math.MathFunctions.RoundToInt(RectangleBackgroundRedFirstValue* (1 - interpolationValue) + RectangleBackgroundRedSecondValue * interpolationValue);
                }
                if (setRectangleBackgroundWidthFirstValue && setRectangleBackgroundWidthSecondValue)
                {
                    RectangleBackground.Width = RectangleBackgroundWidthFirstValue * (1 - interpolationValue) + RectangleBackgroundWidthSecondValue * interpolationValue;
                }
                if (setTextLabelPlayerNameFontSizeFirstValue && setTextLabelPlayerNameFontSizeSecondValue)
                {
                    TextLabelPlayerName.FontSize = FlatRedBall.Math.MathFunctions.RoundToInt(TextLabelPlayerNameFontSizeFirstValue* (1 - interpolationValue) + TextLabelPlayerNameFontSizeSecondValue * interpolationValue);
                }
                if (setTextLabelPlayerNameHeightFirstValue && setTextLabelPlayerNameHeightSecondValue)
                {
                    TextLabelPlayerName.Height = TextLabelPlayerNameHeightFirstValue * (1 - interpolationValue) + TextLabelPlayerNameHeightSecondValue * interpolationValue;
                }
                if (setTextLabelPlayerNameWidthFirstValue && setTextLabelPlayerNameWidthSecondValue)
                {
                    TextLabelPlayerName.Width = TextLabelPlayerNameWidthFirstValue * (1 - interpolationValue) + TextLabelPlayerNameWidthSecondValue * interpolationValue;
                }
                if (setTextPlayerNameFontSizeFirstValue && setTextPlayerNameFontSizeSecondValue)
                {
                    TextPlayerName.FontSize = FlatRedBall.Math.MathFunctions.RoundToInt(TextPlayerNameFontSizeFirstValue* (1 - interpolationValue) + TextPlayerNameFontSizeSecondValue * interpolationValue);
                }
                if (setTextPlayerNameHeightFirstValue && setTextPlayerNameHeightSecondValue)
                {
                    TextPlayerName.Height = TextPlayerNameHeightFirstValue * (1 - interpolationValue) + TextPlayerNameHeightSecondValue * interpolationValue;
                }
                if (setTextPlayerNameWidthFirstValue && setTextPlayerNameWidthSecondValue)
                {
                    TextPlayerName.Width = TextPlayerNameWidthFirstValue * (1 - interpolationValue) + TextPlayerNameWidthSecondValue * interpolationValue;
                }
                if (setTextPlayerNameXFirstValue && setTextPlayerNameXSecondValue)
                {
                    TextPlayerName.X = TextPlayerNameXFirstValue * (1 - interpolationValue) + TextPlayerNameXSecondValue * interpolationValue;
                }
                if (setTextPlayerNameYFirstValue && setTextPlayerNameYSecondValue)
                {
                    TextPlayerName.Y = TextPlayerNameYFirstValue * (1 - interpolationValue) + TextPlayerNameYSecondValue * interpolationValue;
                }
                if (setWidthFirstValue && setWidthSecondValue)
                {
                    Width = WidthFirstValue * (1 - interpolationValue) + WidthSecondValue * interpolationValue;
                }
                if (setXFirstValue && setXSecondValue)
                {
                    X = XFirstValue * (1 - interpolationValue) + XSecondValue * interpolationValue;
                }
                if (setYFirstValue && setYSecondValue)
                {
                    Y = YFirstValue * (1 - interpolationValue) + YSecondValue * interpolationValue;
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
            public FlatRedBall.Glue.StateInterpolation.Tweener InterpolateTo (Pirates.GumRuntimes.InventoryForms.InventoryGuiRuntime.VariableState fromState,Pirates.GumRuntimes.InventoryForms.InventoryGuiRuntime.VariableState toState, double secondsToTake, FlatRedBall.Glue.StateInterpolation.InterpolationType interpolationType, FlatRedBall.Glue.StateInterpolation.Easing easing, object owner = null) 
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
                InventoryBar.StopAnimations();
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
                            Name = "Children Layout",
                            Type = "ChildrenLayout",
                            Value = ChildrenLayout
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Clips Children",
                            Type = "bool",
                            Value = ClipsChildren
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Height",
                            Type = "float",
                            Value = Height
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Height Units",
                            Type = "DimensionUnitType",
                            Value = HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Visible",
                            Type = "bool",
                            Value = Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Width",
                            Type = "float",
                            Value = Width
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Width Units",
                            Type = "DimensionUnitType",
                            Value = WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Wraps Children",
                            Type = "bool",
                            Value = WrapsChildren
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "X",
                            Type = "float",
                            Value = X
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "X Origin",
                            Type = "HorizontalAlignment",
                            Value = XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "X Units",
                            Type = "PositionUnitType",
                            Value = XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Y",
                            Type = "float",
                            Value = Y
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Y Origin",
                            Type = "VerticalAlignment",
                            Value = YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Y Units",
                            Type = "PositionUnitType",
                            Value = YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerMain.Height",
                            Type = "float",
                            Value = ContainerMain.Height
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerMain.Height Units",
                            Type = "DimensionUnitType",
                            Value = ContainerMain.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerMain.Width",
                            Type = "float",
                            Value = ContainerMain.Width
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerMain.Width Units",
                            Type = "DimensionUnitType",
                            Value = ContainerMain.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "RectangleBackground.Alpha",
                            Type = "int",
                            Value = RectangleBackground.Alpha
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "RectangleBackground.Blue",
                            Type = "int",
                            Value = RectangleBackground.Blue
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "RectangleBackground.Green",
                            Type = "int",
                            Value = RectangleBackground.Green
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "RectangleBackground.Height",
                            Type = "float",
                            Value = RectangleBackground.Height
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "RectangleBackground.Height Units",
                            Type = "DimensionUnitType",
                            Value = RectangleBackground.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "RectangleBackground.Parent",
                            Type = "string",
                            Value = RectangleBackground.Parent
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "RectangleBackground.Red",
                            Type = "int",
                            Value = RectangleBackground.Red
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "RectangleBackground.Width",
                            Type = "float",
                            Value = RectangleBackground.Width
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "RectangleBackground.Width Units",
                            Type = "DimensionUnitType",
                            Value = RectangleBackground.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerInfos.Height",
                            Type = "float",
                            Value = ContainerInfos.Height
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerInfos.Height Units",
                            Type = "DimensionUnitType",
                            Value = ContainerInfos.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerInfos.Parent",
                            Type = "string",
                            Value = ContainerInfos.Parent
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerInfos.Width",
                            Type = "float",
                            Value = ContainerInfos.Width
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerInfos.Width Units",
                            Type = "DimensionUnitType",
                            Value = ContainerInfos.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerInfos.X",
                            Type = "float",
                            Value = ContainerInfos.X
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerInfos.X Units",
                            Type = "PositionUnitType",
                            Value = ContainerInfos.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerInfos.Y",
                            Type = "float",
                            Value = ContainerInfos.Y
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerInfos.Y Units",
                            Type = "PositionUnitType",
                            Value = ContainerInfos.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerItems.Children Layout",
                            Type = "ChildrenLayout",
                            Value = ContainerItems.ChildrenLayout
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerItems.Clips Children",
                            Type = "bool",
                            Value = ContainerItems.ClipsChildren
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerItems.Height",
                            Type = "float",
                            Value = ContainerItems.Height
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerItems.Height Units",
                            Type = "DimensionUnitType",
                            Value = ContainerItems.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerItems.Parent",
                            Type = "string",
                            Value = ContainerItems.Parent
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerItems.Visible",
                            Type = "bool",
                            Value = ContainerItems.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerItems.Width",
                            Type = "float",
                            Value = ContainerItems.Width
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerItems.Width Units",
                            Type = "DimensionUnitType",
                            Value = ContainerItems.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerItems.Wraps Children",
                            Type = "bool",
                            Value = ContainerItems.WrapsChildren
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerItems.X",
                            Type = "float",
                            Value = ContainerItems.X
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerItems.X Origin",
                            Type = "HorizontalAlignment",
                            Value = ContainerItems.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerItems.X Units",
                            Type = "PositionUnitType",
                            Value = ContainerItems.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerItems.Y",
                            Type = "float",
                            Value = ContainerItems.Y
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerItems.Y Units",
                            Type = "PositionUnitType",
                            Value = ContainerItems.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextLabelPlayerName.Font",
                            Type = "string",
                            Value = TextLabelPlayerName.Font
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextLabelPlayerName.FontSize",
                            Type = "int",
                            Value = TextLabelPlayerName.FontSize
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextLabelPlayerName.Height",
                            Type = "float",
                            Value = TextLabelPlayerName.Height
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextLabelPlayerName.Height Units",
                            Type = "DimensionUnitType",
                            Value = TextLabelPlayerName.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextLabelPlayerName.Parent",
                            Type = "string",
                            Value = TextLabelPlayerName.Parent
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextLabelPlayerName.Text",
                            Type = "string",
                            Value = TextLabelPlayerName.Text
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextLabelPlayerName.Width",
                            Type = "float",
                            Value = TextLabelPlayerName.Width
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextLabelPlayerName.Width Units",
                            Type = "DimensionUnitType",
                            Value = TextLabelPlayerName.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextPlayerName.Font",
                            Type = "string",
                            Value = TextPlayerName.Font
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextPlayerName.FontSize",
                            Type = "int",
                            Value = TextPlayerName.FontSize
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextPlayerName.Height",
                            Type = "float",
                            Value = TextPlayerName.Height
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextPlayerName.Parent",
                            Type = "string",
                            Value = TextPlayerName.Parent
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextPlayerName.Text",
                            Type = "string",
                            Value = TextPlayerName.Text
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextPlayerName.Width",
                            Type = "float",
                            Value = TextPlayerName.Width
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextPlayerName.Width Units",
                            Type = "DimensionUnitType",
                            Value = TextPlayerName.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextPlayerName.X",
                            Type = "float",
                            Value = TextPlayerName.X
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextPlayerName.X Units",
                            Type = "PositionUnitType",
                            Value = TextPlayerName.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextPlayerName.Y",
                            Type = "float",
                            Value = TextPlayerName.Y
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "HeldItemSprite.Height",
                            Type = "float",
                            Value = HeldItemSprite.Height
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "HeldItemSprite.Height Units",
                            Type = "DimensionUnitType",
                            Value = HeldItemSprite.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "HeldItemSprite.Width",
                            Type = "float",
                            Value = HeldItemSprite.Width
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "HeldItemSprite.Width Units",
                            Type = "DimensionUnitType",
                            Value = HeldItemSprite.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "HeldItemSprite.X",
                            Type = "float",
                            Value = HeldItemSprite.X
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "HeldItemSprite.X Origin",
                            Type = "HorizontalAlignment",
                            Value = HeldItemSprite.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "HeldItemSprite.X Units",
                            Type = "PositionUnitType",
                            Value = HeldItemSprite.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "HeldItemSprite.Y",
                            Type = "float",
                            Value = HeldItemSprite.Y
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "HeldItemSprite.Y Origin",
                            Type = "VerticalAlignment",
                            Value = HeldItemSprite.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "HeldItemSprite.Y Units",
                            Type = "PositionUnitType",
                            Value = HeldItemSprite.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "InventoryBar.Clips Children",
                            Type = "bool",
                            Value = InventoryBar.ClipsChildren
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "InventoryBar.State",
                            Type = "State",
                            Value = InventoryBar.CurrentVariableState
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "InventoryBar.Visible",
                            Type = "bool",
                            Value = InventoryBar.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "InventoryBar.Wraps Children",
                            Type = "bool",
                            Value = InventoryBar.WrapsChildren
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "InventoryBar.Y",
                            Type = "float",
                            Value = InventoryBar.Y
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "InventoryBar.Y Origin",
                            Type = "VerticalAlignment",
                            Value = InventoryBar.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "InventoryBar.Y Units",
                            Type = "PositionUnitType",
                            Value = InventoryBar.YUnits
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
                            Name = "Children Layout",
                            Type = "ChildrenLayout",
                            Value = ChildrenLayout
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Clips Children",
                            Type = "bool",
                            Value = ClipsChildren
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Height",
                            Type = "float",
                            Value = Height + 90f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Height Units",
                            Type = "DimensionUnitType",
                            Value = HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Visible",
                            Type = "bool",
                            Value = Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Width",
                            Type = "float",
                            Value = Width + 80f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Width Units",
                            Type = "DimensionUnitType",
                            Value = WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Wraps Children",
                            Type = "bool",
                            Value = WrapsChildren
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "X",
                            Type = "float",
                            Value = X + 10f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "X Origin",
                            Type = "HorizontalAlignment",
                            Value = XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "X Units",
                            Type = "PositionUnitType",
                            Value = XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Y",
                            Type = "float",
                            Value = Y + 10f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Y Origin",
                            Type = "VerticalAlignment",
                            Value = YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Y Units",
                            Type = "PositionUnitType",
                            Value = YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerMain.Height",
                            Type = "float",
                            Value = ContainerMain.Height + 89f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerMain.Height Units",
                            Type = "DimensionUnitType",
                            Value = ContainerMain.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerMain.Width",
                            Type = "float",
                            Value = ContainerMain.Width + 100f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerMain.Width Units",
                            Type = "DimensionUnitType",
                            Value = ContainerMain.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "RectangleBackground.Alpha",
                            Type = "int",
                            Value = RectangleBackground.Alpha + 192
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "RectangleBackground.Blue",
                            Type = "int",
                            Value = RectangleBackground.Blue + 128
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "RectangleBackground.Green",
                            Type = "int",
                            Value = RectangleBackground.Green + 128
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "RectangleBackground.Height",
                            Type = "float",
                            Value = RectangleBackground.Height + 100f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "RectangleBackground.Height Units",
                            Type = "DimensionUnitType",
                            Value = RectangleBackground.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "RectangleBackground.Parent",
                            Type = "string",
                            Value = RectangleBackground.Parent
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "RectangleBackground.Red",
                            Type = "int",
                            Value = RectangleBackground.Red + 128
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "RectangleBackground.Width",
                            Type = "float",
                            Value = RectangleBackground.Width + 100f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "RectangleBackground.Width Units",
                            Type = "DimensionUnitType",
                            Value = RectangleBackground.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerInfos.Height",
                            Type = "float",
                            Value = ContainerInfos.Height + 50f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerInfos.Height Units",
                            Type = "DimensionUnitType",
                            Value = ContainerInfos.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerInfos.Parent",
                            Type = "string",
                            Value = ContainerInfos.Parent
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerInfos.Width",
                            Type = "float",
                            Value = ContainerInfos.Width + 100f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerInfos.Width Units",
                            Type = "DimensionUnitType",
                            Value = ContainerInfos.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerInfos.X",
                            Type = "float",
                            Value = ContainerInfos.X + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerInfos.X Units",
                            Type = "PositionUnitType",
                            Value = ContainerInfos.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerInfos.Y",
                            Type = "float",
                            Value = ContainerInfos.Y + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerInfos.Y Units",
                            Type = "PositionUnitType",
                            Value = ContainerInfos.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerItems.Children Layout",
                            Type = "ChildrenLayout",
                            Value = ContainerItems.ChildrenLayout
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerItems.Clips Children",
                            Type = "bool",
                            Value = ContainerItems.ClipsChildren
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerItems.Height",
                            Type = "float",
                            Value = ContainerItems.Height + 240f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerItems.Height Units",
                            Type = "DimensionUnitType",
                            Value = ContainerItems.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerItems.Parent",
                            Type = "string",
                            Value = ContainerItems.Parent
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerItems.Visible",
                            Type = "bool",
                            Value = ContainerItems.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerItems.Width",
                            Type = "float",
                            Value = ContainerItems.Width + 480f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerItems.Width Units",
                            Type = "DimensionUnitType",
                            Value = ContainerItems.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerItems.Wraps Children",
                            Type = "bool",
                            Value = ContainerItems.WrapsChildren
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerItems.X",
                            Type = "float",
                            Value = ContainerItems.X + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerItems.X Origin",
                            Type = "HorizontalAlignment",
                            Value = ContainerItems.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerItems.X Units",
                            Type = "PositionUnitType",
                            Value = ContainerItems.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerItems.Y",
                            Type = "float",
                            Value = ContainerItems.Y + 50f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerItems.Y Units",
                            Type = "PositionUnitType",
                            Value = ContainerItems.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextLabelPlayerName.Font",
                            Type = "string",
                            Value = TextLabelPlayerName.Font
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextLabelPlayerName.FontSize",
                            Type = "int",
                            Value = TextLabelPlayerName.FontSize + 40
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextLabelPlayerName.Height",
                            Type = "float",
                            Value = TextLabelPlayerName.Height + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextLabelPlayerName.Height Units",
                            Type = "DimensionUnitType",
                            Value = TextLabelPlayerName.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextLabelPlayerName.Parent",
                            Type = "string",
                            Value = TextLabelPlayerName.Parent
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextLabelPlayerName.Text",
                            Type = "string",
                            Value = TextLabelPlayerName.Text
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextLabelPlayerName.Width",
                            Type = "float",
                            Value = TextLabelPlayerName.Width + 50f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextLabelPlayerName.Width Units",
                            Type = "DimensionUnitType",
                            Value = TextLabelPlayerName.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextPlayerName.Font",
                            Type = "string",
                            Value = TextPlayerName.Font
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextPlayerName.FontSize",
                            Type = "int",
                            Value = TextPlayerName.FontSize + 40
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextPlayerName.Height",
                            Type = "float",
                            Value = TextPlayerName.Height + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextPlayerName.Parent",
                            Type = "string",
                            Value = TextPlayerName.Parent
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextPlayerName.Text",
                            Type = "string",
                            Value = TextPlayerName.Text
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextPlayerName.Width",
                            Type = "float",
                            Value = TextPlayerName.Width + 50f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextPlayerName.Width Units",
                            Type = "DimensionUnitType",
                            Value = TextPlayerName.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextPlayerName.X",
                            Type = "float",
                            Value = TextPlayerName.X + 50f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextPlayerName.X Units",
                            Type = "PositionUnitType",
                            Value = TextPlayerName.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextPlayerName.Y",
                            Type = "float",
                            Value = TextPlayerName.Y + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "HeldItemSprite.Height",
                            Type = "float",
                            Value = HeldItemSprite.Height + 60f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "HeldItemSprite.Height Units",
                            Type = "DimensionUnitType",
                            Value = HeldItemSprite.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "HeldItemSprite.Width",
                            Type = "float",
                            Value = HeldItemSprite.Width + 60f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "HeldItemSprite.Width Units",
                            Type = "DimensionUnitType",
                            Value = HeldItemSprite.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "HeldItemSprite.X",
                            Type = "float",
                            Value = HeldItemSprite.X + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "HeldItemSprite.X Origin",
                            Type = "HorizontalAlignment",
                            Value = HeldItemSprite.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "HeldItemSprite.X Units",
                            Type = "PositionUnitType",
                            Value = HeldItemSprite.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "HeldItemSprite.Y",
                            Type = "float",
                            Value = HeldItemSprite.Y + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "HeldItemSprite.Y Origin",
                            Type = "VerticalAlignment",
                            Value = HeldItemSprite.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "HeldItemSprite.Y Units",
                            Type = "PositionUnitType",
                            Value = HeldItemSprite.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "InventoryBar.Clips Children",
                            Type = "bool",
                            Value = InventoryBar.ClipsChildren
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "InventoryBar.State",
                            Type = "State",
                            Value = InventoryBar.CurrentVariableState
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "InventoryBar.Visible",
                            Type = "bool",
                            Value = InventoryBar.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "InventoryBar.Wraps Children",
                            Type = "bool",
                            Value = InventoryBar.WrapsChildren
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "InventoryBar.Y",
                            Type = "float",
                            Value = InventoryBar.Y + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "InventoryBar.Y Origin",
                            Type = "VerticalAlignment",
                            Value = InventoryBar.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "InventoryBar.Y Units",
                            Type = "PositionUnitType",
                            Value = InventoryBar.YUnits
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
            private Pirates.GumRuntimes.ContainerRuntime ContainerMain { get; set; }
            private Pirates.GumRuntimes.ColoredRectangleRuntime RectangleBackground { get; set; }
            private Pirates.GumRuntimes.ContainerRuntime ContainerInfos { get; set; }
            private Pirates.GumRuntimes.ContainerRuntime ContainerItems { get; set; }
            private Pirates.GumRuntimes.TextRuntime TextLabelPlayerName { get; set; }
            private Pirates.GumRuntimes.TextRuntime TextPlayerName { get; set; }
            private Pirates.GumRuntimes.SpriteRuntime HeldItemSprite { get; set; }
            private Pirates.GumRuntimes.InventoryForms.InventoryBarRuntime InventoryBar { get; set; }
            public event FlatRedBall.Gui.WindowEvent ContainerMainClick;
            public event FlatRedBall.Gui.WindowEvent ContainerInfosClick;
            public event FlatRedBall.Gui.WindowEvent ContainerItemsClick;
            public event FlatRedBall.Gui.WindowEvent InventoryBarClick;
            public InventoryGuiRuntime (bool fullInstantiation = true, bool tryCreateFormsObject = true) 
            	: base(false, tryCreateFormsObject)
            {
                this.HasEvents = true;
                this.ExposeChildrenEvents = true;
                if (fullInstantiation)
                {
                    Gum.DataTypes.ElementSave elementSave = Gum.Managers.ObjectFinder.Self.GumProjectSave.Components.First(item => item.Name == "InventoryForms/InventoryGui");
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
                ContainerMain = this.GetGraphicalUiElementByName("ContainerMain") as Pirates.GumRuntimes.ContainerRuntime;
                RectangleBackground = this.GetGraphicalUiElementByName("RectangleBackground") as Pirates.GumRuntimes.ColoredRectangleRuntime;
                ContainerInfos = this.GetGraphicalUiElementByName("ContainerInfos") as Pirates.GumRuntimes.ContainerRuntime;
                ContainerItems = this.GetGraphicalUiElementByName("ContainerItems") as Pirates.GumRuntimes.ContainerRuntime;
                TextLabelPlayerName = this.GetGraphicalUiElementByName("TextLabelPlayerName") as Pirates.GumRuntimes.TextRuntime;
                TextPlayerName = this.GetGraphicalUiElementByName("TextPlayerName") as Pirates.GumRuntimes.TextRuntime;
                HeldItemSprite = this.GetGraphicalUiElementByName("HeldItemSprite") as Pirates.GumRuntimes.SpriteRuntime;
                InventoryBar = this.GetGraphicalUiElementByName("InventoryBar") as Pirates.GumRuntimes.InventoryForms.InventoryBarRuntime;
                ContainerMain.Click += (unused) => ContainerMainClick?.Invoke(this);
                ContainerInfos.Click += (unused) => ContainerInfosClick?.Invoke(this);
                ContainerItems.Click += (unused) => ContainerItemsClick?.Invoke(this);
                InventoryBar.Click += (unused) => InventoryBarClick?.Invoke(this);
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
