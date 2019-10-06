    using System.Linq;
    namespace Pirates.GumRuntimes.InventoryForms
    {
        public partial class InventoryBarRuntime : Pirates.GumRuntimes.ContainerRuntime
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
                            InventoryBoxInstance1.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "ContainerItems") ?? this;
                            InventoryBoxInstance2.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "ContainerItems") ?? this;
                            InventoryBoxInstance3.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "ContainerItems") ?? this;
                            InventoryBoxInstance4.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "ContainerItems") ?? this;
                            ChildrenLayout = Gum.Managers.ChildrenLayout.Regular;
                            Height = 60f;
                            HeightUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                            Width = 240f;
                            WidthUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                            X = 0f;
                            XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                            XUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                            Y = 0f;
                            YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Bottom;
                            YUnits = Gum.Converters.GeneralUnitType.PixelsFromLarge;
                            BackgroundRectangle.Alpha = 192;
                            BackgroundRectangle.Blue = 128;
                            BackgroundRectangle.Green = 128;
                            BackgroundRectangle.Height = 100f;
                            BackgroundRectangle.HeightUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                            BackgroundRectangle.Red = 128;
                            BackgroundRectangle.Width = 100f;
                            BackgroundRectangle.WidthUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                            BackgroundRectangle.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                            BackgroundRectangle.XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                            BackgroundRectangle.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Top;
                            BackgroundRectangle.YUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                            InventoryBoxInstance1.HeightUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                            InventoryBoxInstance1.Width = 60f;
                            InventoryBoxInstance1.WidthUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                            InventoryBoxInstance1.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                            InventoryBoxInstance1.XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                            InventoryBoxInstance1.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Top;
                            InventoryBoxInstance2.Width = 60f;
                            InventoryBoxInstance2.WidthUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                            InventoryBoxInstance2.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                            InventoryBoxInstance2.XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                            InventoryBoxInstance2.YUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                            InventoryBoxInstance3.Width = 60f;
                            InventoryBoxInstance3.WidthUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                            InventoryBoxInstance3.XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                            InventoryBoxInstance4.Width = 60f;
                            InventoryBoxInstance4.WidthUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                            InventoryBoxInstance4.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                            InventoryBoxInstance4.XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                            InventoryBoxInstance4.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Top;
                            InventoryBoxInstance4.YUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                            ContainerItems.ChildrenLayout = Gum.Managers.ChildrenLayout.LeftToRightStack;
                            ContainerItems.ClipsChildren = false;
                            ContainerItems.Height = 100f;
                            ContainerItems.HeightUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                            ContainerItems.Width = 100f;
                            ContainerItems.WidthUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                            ContainerItems.WrapsChildren = false;
                            ContainerItems.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
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
                bool setBackgroundRectangleAlphaFirstValue = false;
                bool setBackgroundRectangleAlphaSecondValue = false;
                int BackgroundRectangleAlphaFirstValue= 0;
                int BackgroundRectangleAlphaSecondValue= 0;
                bool setBackgroundRectangleBlueFirstValue = false;
                bool setBackgroundRectangleBlueSecondValue = false;
                int BackgroundRectangleBlueFirstValue= 0;
                int BackgroundRectangleBlueSecondValue= 0;
                bool setBackgroundRectangleGreenFirstValue = false;
                bool setBackgroundRectangleGreenSecondValue = false;
                int BackgroundRectangleGreenFirstValue= 0;
                int BackgroundRectangleGreenSecondValue= 0;
                bool setBackgroundRectangleHeightFirstValue = false;
                bool setBackgroundRectangleHeightSecondValue = false;
                float BackgroundRectangleHeightFirstValue= 0;
                float BackgroundRectangleHeightSecondValue= 0;
                bool setBackgroundRectangleRedFirstValue = false;
                bool setBackgroundRectangleRedSecondValue = false;
                int BackgroundRectangleRedFirstValue= 0;
                int BackgroundRectangleRedSecondValue= 0;
                bool setBackgroundRectangleWidthFirstValue = false;
                bool setBackgroundRectangleWidthSecondValue = false;
                float BackgroundRectangleWidthFirstValue= 0;
                float BackgroundRectangleWidthSecondValue= 0;
                bool setContainerItemsHeightFirstValue = false;
                bool setContainerItemsHeightSecondValue = false;
                float ContainerItemsHeightFirstValue= 0;
                float ContainerItemsHeightSecondValue= 0;
                bool setContainerItemsWidthFirstValue = false;
                bool setContainerItemsWidthSecondValue = false;
                float ContainerItemsWidthFirstValue= 0;
                float ContainerItemsWidthSecondValue= 0;
                bool setHeightFirstValue = false;
                bool setHeightSecondValue = false;
                float HeightFirstValue= 0;
                float HeightSecondValue= 0;
                bool setInventoryBoxInstance1WidthFirstValue = false;
                bool setInventoryBoxInstance1WidthSecondValue = false;
                float InventoryBoxInstance1WidthFirstValue= 0;
                float InventoryBoxInstance1WidthSecondValue= 0;
                bool setInventoryBoxInstance2WidthFirstValue = false;
                bool setInventoryBoxInstance2WidthSecondValue = false;
                float InventoryBoxInstance2WidthFirstValue= 0;
                float InventoryBoxInstance2WidthSecondValue= 0;
                bool setInventoryBoxInstance3WidthFirstValue = false;
                bool setInventoryBoxInstance3WidthSecondValue = false;
                float InventoryBoxInstance3WidthFirstValue= 0;
                float InventoryBoxInstance3WidthSecondValue= 0;
                bool setInventoryBoxInstance4WidthFirstValue = false;
                bool setInventoryBoxInstance4WidthSecondValue = false;
                float InventoryBoxInstance4WidthFirstValue= 0;
                float InventoryBoxInstance4WidthSecondValue= 0;
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
                        setBackgroundRectangleAlphaFirstValue = true;
                        BackgroundRectangleAlphaFirstValue = 192;
                        setBackgroundRectangleBlueFirstValue = true;
                        BackgroundRectangleBlueFirstValue = 128;
                        setBackgroundRectangleGreenFirstValue = true;
                        BackgroundRectangleGreenFirstValue = 128;
                        setBackgroundRectangleHeightFirstValue = true;
                        BackgroundRectangleHeightFirstValue = 100f;
                        if (interpolationValue < 1)
                        {
                            this.BackgroundRectangle.HeightUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        setBackgroundRectangleRedFirstValue = true;
                        BackgroundRectangleRedFirstValue = 128;
                        setBackgroundRectangleWidthFirstValue = true;
                        BackgroundRectangleWidthFirstValue = 100f;
                        if (interpolationValue < 1)
                        {
                            this.BackgroundRectangle.WidthUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        if (interpolationValue < 1)
                        {
                            this.BackgroundRectangle.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                        }
                        if (interpolationValue < 1)
                        {
                            this.BackgroundRectangle.XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        if (interpolationValue < 1)
                        {
                            this.BackgroundRectangle.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Top;
                        }
                        if (interpolationValue < 1)
                        {
                            this.BackgroundRectangle.YUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ChildrenLayout = Gum.Managers.ChildrenLayout.Regular;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ContainerItems.ChildrenLayout = Gum.Managers.ChildrenLayout.LeftToRightStack;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ContainerItems.ClipsChildren = false;
                        }
                        setContainerItemsHeightFirstValue = true;
                        ContainerItemsHeightFirstValue = 100f;
                        if (interpolationValue < 1)
                        {
                            this.ContainerItems.HeightUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        setContainerItemsWidthFirstValue = true;
                        ContainerItemsWidthFirstValue = 100f;
                        if (interpolationValue < 1)
                        {
                            this.ContainerItems.WidthUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ContainerItems.WrapsChildren = false;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ContainerItems.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                        }
                        setHeightFirstValue = true;
                        HeightFirstValue = 60f;
                        if (interpolationValue < 1)
                        {
                            this.HeightUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        if (interpolationValue < 1)
                        {
                            this.InventoryBoxInstance1.HeightUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        if (interpolationValue < 1)
                        {
                            this.InventoryBoxInstance1.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "ContainerItems") ?? this;
                        }
                        setInventoryBoxInstance1WidthFirstValue = true;
                        InventoryBoxInstance1WidthFirstValue = 60f;
                        if (interpolationValue < 1)
                        {
                            this.InventoryBoxInstance1.WidthUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        if (interpolationValue < 1)
                        {
                            this.InventoryBoxInstance1.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                        }
                        if (interpolationValue < 1)
                        {
                            this.InventoryBoxInstance1.XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        if (interpolationValue < 1)
                        {
                            this.InventoryBoxInstance1.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Top;
                        }
                        if (interpolationValue < 1)
                        {
                            this.InventoryBoxInstance2.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "ContainerItems") ?? this;
                        }
                        setInventoryBoxInstance2WidthFirstValue = true;
                        InventoryBoxInstance2WidthFirstValue = 60f;
                        if (interpolationValue < 1)
                        {
                            this.InventoryBoxInstance2.WidthUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        if (interpolationValue < 1)
                        {
                            this.InventoryBoxInstance2.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                        }
                        if (interpolationValue < 1)
                        {
                            this.InventoryBoxInstance2.XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        if (interpolationValue < 1)
                        {
                            this.InventoryBoxInstance2.YUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        if (interpolationValue < 1)
                        {
                            this.InventoryBoxInstance3.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "ContainerItems") ?? this;
                        }
                        setInventoryBoxInstance3WidthFirstValue = true;
                        InventoryBoxInstance3WidthFirstValue = 60f;
                        if (interpolationValue < 1)
                        {
                            this.InventoryBoxInstance3.WidthUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        if (interpolationValue < 1)
                        {
                            this.InventoryBoxInstance3.XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        if (interpolationValue < 1)
                        {
                            this.InventoryBoxInstance4.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "ContainerItems") ?? this;
                        }
                        setInventoryBoxInstance4WidthFirstValue = true;
                        InventoryBoxInstance4WidthFirstValue = 60f;
                        if (interpolationValue < 1)
                        {
                            this.InventoryBoxInstance4.WidthUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        if (interpolationValue < 1)
                        {
                            this.InventoryBoxInstance4.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                        }
                        if (interpolationValue < 1)
                        {
                            this.InventoryBoxInstance4.XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        if (interpolationValue < 1)
                        {
                            this.InventoryBoxInstance4.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Top;
                        }
                        if (interpolationValue < 1)
                        {
                            this.InventoryBoxInstance4.YUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        setWidthFirstValue = true;
                        WidthFirstValue = 240f;
                        if (interpolationValue < 1)
                        {
                            this.WidthUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        setXFirstValue = true;
                        XFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                        }
                        if (interpolationValue < 1)
                        {
                            this.XUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        setYFirstValue = true;
                        YFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Bottom;
                        }
                        if (interpolationValue < 1)
                        {
                            this.YUnits = Gum.Converters.GeneralUnitType.PixelsFromLarge;
                        }
                        break;
                }
                switch(secondState)
                {
                    case  VariableState.Default:
                        setBackgroundRectangleAlphaSecondValue = true;
                        BackgroundRectangleAlphaSecondValue = 192;
                        setBackgroundRectangleBlueSecondValue = true;
                        BackgroundRectangleBlueSecondValue = 128;
                        setBackgroundRectangleGreenSecondValue = true;
                        BackgroundRectangleGreenSecondValue = 128;
                        setBackgroundRectangleHeightSecondValue = true;
                        BackgroundRectangleHeightSecondValue = 100f;
                        if (interpolationValue >= 1)
                        {
                            this.BackgroundRectangle.HeightUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        setBackgroundRectangleRedSecondValue = true;
                        BackgroundRectangleRedSecondValue = 128;
                        setBackgroundRectangleWidthSecondValue = true;
                        BackgroundRectangleWidthSecondValue = 100f;
                        if (interpolationValue >= 1)
                        {
                            this.BackgroundRectangle.WidthUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.BackgroundRectangle.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.BackgroundRectangle.XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.BackgroundRectangle.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Top;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.BackgroundRectangle.YUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ChildrenLayout = Gum.Managers.ChildrenLayout.Regular;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ContainerItems.ChildrenLayout = Gum.Managers.ChildrenLayout.LeftToRightStack;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ContainerItems.ClipsChildren = false;
                        }
                        setContainerItemsHeightSecondValue = true;
                        ContainerItemsHeightSecondValue = 100f;
                        if (interpolationValue >= 1)
                        {
                            this.ContainerItems.HeightUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        setContainerItemsWidthSecondValue = true;
                        ContainerItemsWidthSecondValue = 100f;
                        if (interpolationValue >= 1)
                        {
                            this.ContainerItems.WidthUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ContainerItems.WrapsChildren = false;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ContainerItems.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                        }
                        setHeightSecondValue = true;
                        HeightSecondValue = 60f;
                        if (interpolationValue >= 1)
                        {
                            this.HeightUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.InventoryBoxInstance1.HeightUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.InventoryBoxInstance1.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "ContainerItems") ?? this;
                        }
                        setInventoryBoxInstance1WidthSecondValue = true;
                        InventoryBoxInstance1WidthSecondValue = 60f;
                        if (interpolationValue >= 1)
                        {
                            this.InventoryBoxInstance1.WidthUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.InventoryBoxInstance1.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.InventoryBoxInstance1.XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.InventoryBoxInstance1.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Top;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.InventoryBoxInstance2.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "ContainerItems") ?? this;
                        }
                        setInventoryBoxInstance2WidthSecondValue = true;
                        InventoryBoxInstance2WidthSecondValue = 60f;
                        if (interpolationValue >= 1)
                        {
                            this.InventoryBoxInstance2.WidthUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.InventoryBoxInstance2.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.InventoryBoxInstance2.XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.InventoryBoxInstance2.YUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.InventoryBoxInstance3.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "ContainerItems") ?? this;
                        }
                        setInventoryBoxInstance3WidthSecondValue = true;
                        InventoryBoxInstance3WidthSecondValue = 60f;
                        if (interpolationValue >= 1)
                        {
                            this.InventoryBoxInstance3.WidthUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.InventoryBoxInstance3.XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.InventoryBoxInstance4.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "ContainerItems") ?? this;
                        }
                        setInventoryBoxInstance4WidthSecondValue = true;
                        InventoryBoxInstance4WidthSecondValue = 60f;
                        if (interpolationValue >= 1)
                        {
                            this.InventoryBoxInstance4.WidthUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.InventoryBoxInstance4.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.InventoryBoxInstance4.XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.InventoryBoxInstance4.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Top;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.InventoryBoxInstance4.YUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        setWidthSecondValue = true;
                        WidthSecondValue = 240f;
                        if (interpolationValue >= 1)
                        {
                            this.WidthUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        setXSecondValue = true;
                        XSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.XUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        setYSecondValue = true;
                        YSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Bottom;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.YUnits = Gum.Converters.GeneralUnitType.PixelsFromLarge;
                        }
                        break;
                }
                if (setBackgroundRectangleAlphaFirstValue && setBackgroundRectangleAlphaSecondValue)
                {
                    BackgroundRectangle.Alpha = FlatRedBall.Math.MathFunctions.RoundToInt(BackgroundRectangleAlphaFirstValue* (1 - interpolationValue) + BackgroundRectangleAlphaSecondValue * interpolationValue);
                }
                if (setBackgroundRectangleBlueFirstValue && setBackgroundRectangleBlueSecondValue)
                {
                    BackgroundRectangle.Blue = FlatRedBall.Math.MathFunctions.RoundToInt(BackgroundRectangleBlueFirstValue* (1 - interpolationValue) + BackgroundRectangleBlueSecondValue * interpolationValue);
                }
                if (setBackgroundRectangleGreenFirstValue && setBackgroundRectangleGreenSecondValue)
                {
                    BackgroundRectangle.Green = FlatRedBall.Math.MathFunctions.RoundToInt(BackgroundRectangleGreenFirstValue* (1 - interpolationValue) + BackgroundRectangleGreenSecondValue * interpolationValue);
                }
                if (setBackgroundRectangleHeightFirstValue && setBackgroundRectangleHeightSecondValue)
                {
                    BackgroundRectangle.Height = BackgroundRectangleHeightFirstValue * (1 - interpolationValue) + BackgroundRectangleHeightSecondValue * interpolationValue;
                }
                if (setBackgroundRectangleRedFirstValue && setBackgroundRectangleRedSecondValue)
                {
                    BackgroundRectangle.Red = FlatRedBall.Math.MathFunctions.RoundToInt(BackgroundRectangleRedFirstValue* (1 - interpolationValue) + BackgroundRectangleRedSecondValue * interpolationValue);
                }
                if (setBackgroundRectangleWidthFirstValue && setBackgroundRectangleWidthSecondValue)
                {
                    BackgroundRectangle.Width = BackgroundRectangleWidthFirstValue * (1 - interpolationValue) + BackgroundRectangleWidthSecondValue * interpolationValue;
                }
                if (setContainerItemsHeightFirstValue && setContainerItemsHeightSecondValue)
                {
                    ContainerItems.Height = ContainerItemsHeightFirstValue * (1 - interpolationValue) + ContainerItemsHeightSecondValue * interpolationValue;
                }
                if (setContainerItemsWidthFirstValue && setContainerItemsWidthSecondValue)
                {
                    ContainerItems.Width = ContainerItemsWidthFirstValue * (1 - interpolationValue) + ContainerItemsWidthSecondValue * interpolationValue;
                }
                if (setHeightFirstValue && setHeightSecondValue)
                {
                    Height = HeightFirstValue * (1 - interpolationValue) + HeightSecondValue * interpolationValue;
                }
                if (setInventoryBoxInstance1WidthFirstValue && setInventoryBoxInstance1WidthSecondValue)
                {
                    InventoryBoxInstance1.Width = InventoryBoxInstance1WidthFirstValue * (1 - interpolationValue) + InventoryBoxInstance1WidthSecondValue * interpolationValue;
                }
                if (setInventoryBoxInstance2WidthFirstValue && setInventoryBoxInstance2WidthSecondValue)
                {
                    InventoryBoxInstance2.Width = InventoryBoxInstance2WidthFirstValue * (1 - interpolationValue) + InventoryBoxInstance2WidthSecondValue * interpolationValue;
                }
                if (setInventoryBoxInstance3WidthFirstValue && setInventoryBoxInstance3WidthSecondValue)
                {
                    InventoryBoxInstance3.Width = InventoryBoxInstance3WidthFirstValue * (1 - interpolationValue) + InventoryBoxInstance3WidthSecondValue * interpolationValue;
                }
                if (setInventoryBoxInstance4WidthFirstValue && setInventoryBoxInstance4WidthSecondValue)
                {
                    InventoryBoxInstance4.Width = InventoryBoxInstance4WidthFirstValue * (1 - interpolationValue) + InventoryBoxInstance4WidthSecondValue * interpolationValue;
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
            public FlatRedBall.Glue.StateInterpolation.Tweener InterpolateTo (Pirates.GumRuntimes.InventoryForms.InventoryBarRuntime.VariableState fromState,Pirates.GumRuntimes.InventoryForms.InventoryBarRuntime.VariableState toState, double secondsToTake, FlatRedBall.Glue.StateInterpolation.InterpolationType interpolationType, FlatRedBall.Glue.StateInterpolation.Easing easing, object owner = null) 
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
                InventoryBoxInstance1.StopAnimations();
                InventoryBoxInstance2.StopAnimations();
                InventoryBoxInstance3.StopAnimations();
                InventoryBoxInstance4.StopAnimations();
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
                            Name = "BackgroundRectangle.Alpha",
                            Type = "int",
                            Value = BackgroundRectangle.Alpha
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "BackgroundRectangle.Blue",
                            Type = "int",
                            Value = BackgroundRectangle.Blue
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "BackgroundRectangle.Green",
                            Type = "int",
                            Value = BackgroundRectangle.Green
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "BackgroundRectangle.Height",
                            Type = "float",
                            Value = BackgroundRectangle.Height
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "BackgroundRectangle.Height Units",
                            Type = "DimensionUnitType",
                            Value = BackgroundRectangle.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "BackgroundRectangle.Red",
                            Type = "int",
                            Value = BackgroundRectangle.Red
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "BackgroundRectangle.Width",
                            Type = "float",
                            Value = BackgroundRectangle.Width
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "BackgroundRectangle.Width Units",
                            Type = "DimensionUnitType",
                            Value = BackgroundRectangle.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "BackgroundRectangle.X Origin",
                            Type = "HorizontalAlignment",
                            Value = BackgroundRectangle.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "BackgroundRectangle.X Units",
                            Type = "PositionUnitType",
                            Value = BackgroundRectangle.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "BackgroundRectangle.Y Origin",
                            Type = "VerticalAlignment",
                            Value = BackgroundRectangle.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "BackgroundRectangle.Y Units",
                            Type = "PositionUnitType",
                            Value = BackgroundRectangle.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "InventoryBoxInstance1.Height Units",
                            Type = "DimensionUnitType",
                            Value = InventoryBoxInstance1.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "InventoryBoxInstance1.Parent",
                            Type = "string",
                            Value = InventoryBoxInstance1.Parent
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "InventoryBoxInstance1.Width",
                            Type = "float",
                            Value = InventoryBoxInstance1.Width
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "InventoryBoxInstance1.Width Units",
                            Type = "DimensionUnitType",
                            Value = InventoryBoxInstance1.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "InventoryBoxInstance1.X Origin",
                            Type = "HorizontalAlignment",
                            Value = InventoryBoxInstance1.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "InventoryBoxInstance1.X Units",
                            Type = "PositionUnitType",
                            Value = InventoryBoxInstance1.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "InventoryBoxInstance1.Y Origin",
                            Type = "VerticalAlignment",
                            Value = InventoryBoxInstance1.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "InventoryBoxInstance2.Parent",
                            Type = "string",
                            Value = InventoryBoxInstance2.Parent
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "InventoryBoxInstance2.Width",
                            Type = "float",
                            Value = InventoryBoxInstance2.Width
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "InventoryBoxInstance2.Width Units",
                            Type = "DimensionUnitType",
                            Value = InventoryBoxInstance2.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "InventoryBoxInstance2.X Origin",
                            Type = "HorizontalAlignment",
                            Value = InventoryBoxInstance2.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "InventoryBoxInstance2.X Units",
                            Type = "PositionUnitType",
                            Value = InventoryBoxInstance2.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "InventoryBoxInstance2.Y Units",
                            Type = "PositionUnitType",
                            Value = InventoryBoxInstance2.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "InventoryBoxInstance3.Parent",
                            Type = "string",
                            Value = InventoryBoxInstance3.Parent
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "InventoryBoxInstance3.Width",
                            Type = "float",
                            Value = InventoryBoxInstance3.Width
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "InventoryBoxInstance3.Width Units",
                            Type = "DimensionUnitType",
                            Value = InventoryBoxInstance3.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "InventoryBoxInstance3.X Units",
                            Type = "PositionUnitType",
                            Value = InventoryBoxInstance3.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "InventoryBoxInstance4.Parent",
                            Type = "string",
                            Value = InventoryBoxInstance4.Parent
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "InventoryBoxInstance4.Width",
                            Type = "float",
                            Value = InventoryBoxInstance4.Width
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "InventoryBoxInstance4.Width Units",
                            Type = "DimensionUnitType",
                            Value = InventoryBoxInstance4.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "InventoryBoxInstance4.X Origin",
                            Type = "HorizontalAlignment",
                            Value = InventoryBoxInstance4.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "InventoryBoxInstance4.X Units",
                            Type = "PositionUnitType",
                            Value = InventoryBoxInstance4.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "InventoryBoxInstance4.Y Origin",
                            Type = "VerticalAlignment",
                            Value = InventoryBoxInstance4.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "InventoryBoxInstance4.Y Units",
                            Type = "PositionUnitType",
                            Value = InventoryBoxInstance4.YUnits
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
                            Name = "ContainerItems.X Origin",
                            Type = "HorizontalAlignment",
                            Value = ContainerItems.XOrigin
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
                            Name = "Height",
                            Type = "float",
                            Value = Height + 60f
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
                            Name = "Width",
                            Type = "float",
                            Value = Width + 240f
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
                            Name = "X",
                            Type = "float",
                            Value = X + 0f
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
                            Value = Y + 0f
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
                            Name = "BackgroundRectangle.Alpha",
                            Type = "int",
                            Value = BackgroundRectangle.Alpha + 192
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "BackgroundRectangle.Blue",
                            Type = "int",
                            Value = BackgroundRectangle.Blue + 128
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "BackgroundRectangle.Green",
                            Type = "int",
                            Value = BackgroundRectangle.Green + 128
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "BackgroundRectangle.Height",
                            Type = "float",
                            Value = BackgroundRectangle.Height + 100f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "BackgroundRectangle.Height Units",
                            Type = "DimensionUnitType",
                            Value = BackgroundRectangle.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "BackgroundRectangle.Red",
                            Type = "int",
                            Value = BackgroundRectangle.Red + 128
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "BackgroundRectangle.Width",
                            Type = "float",
                            Value = BackgroundRectangle.Width + 100f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "BackgroundRectangle.Width Units",
                            Type = "DimensionUnitType",
                            Value = BackgroundRectangle.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "BackgroundRectangle.X Origin",
                            Type = "HorizontalAlignment",
                            Value = BackgroundRectangle.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "BackgroundRectangle.X Units",
                            Type = "PositionUnitType",
                            Value = BackgroundRectangle.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "BackgroundRectangle.Y Origin",
                            Type = "VerticalAlignment",
                            Value = BackgroundRectangle.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "BackgroundRectangle.Y Units",
                            Type = "PositionUnitType",
                            Value = BackgroundRectangle.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "InventoryBoxInstance1.Height Units",
                            Type = "DimensionUnitType",
                            Value = InventoryBoxInstance1.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "InventoryBoxInstance1.Parent",
                            Type = "string",
                            Value = InventoryBoxInstance1.Parent
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "InventoryBoxInstance1.Width",
                            Type = "float",
                            Value = InventoryBoxInstance1.Width + 60f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "InventoryBoxInstance1.Width Units",
                            Type = "DimensionUnitType",
                            Value = InventoryBoxInstance1.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "InventoryBoxInstance1.X Origin",
                            Type = "HorizontalAlignment",
                            Value = InventoryBoxInstance1.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "InventoryBoxInstance1.X Units",
                            Type = "PositionUnitType",
                            Value = InventoryBoxInstance1.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "InventoryBoxInstance1.Y Origin",
                            Type = "VerticalAlignment",
                            Value = InventoryBoxInstance1.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "InventoryBoxInstance2.Parent",
                            Type = "string",
                            Value = InventoryBoxInstance2.Parent
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "InventoryBoxInstance2.Width",
                            Type = "float",
                            Value = InventoryBoxInstance2.Width + 60f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "InventoryBoxInstance2.Width Units",
                            Type = "DimensionUnitType",
                            Value = InventoryBoxInstance2.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "InventoryBoxInstance2.X Origin",
                            Type = "HorizontalAlignment",
                            Value = InventoryBoxInstance2.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "InventoryBoxInstance2.X Units",
                            Type = "PositionUnitType",
                            Value = InventoryBoxInstance2.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "InventoryBoxInstance2.Y Units",
                            Type = "PositionUnitType",
                            Value = InventoryBoxInstance2.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "InventoryBoxInstance3.Parent",
                            Type = "string",
                            Value = InventoryBoxInstance3.Parent
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "InventoryBoxInstance3.Width",
                            Type = "float",
                            Value = InventoryBoxInstance3.Width + 60f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "InventoryBoxInstance3.Width Units",
                            Type = "DimensionUnitType",
                            Value = InventoryBoxInstance3.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "InventoryBoxInstance3.X Units",
                            Type = "PositionUnitType",
                            Value = InventoryBoxInstance3.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "InventoryBoxInstance4.Parent",
                            Type = "string",
                            Value = InventoryBoxInstance4.Parent
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "InventoryBoxInstance4.Width",
                            Type = "float",
                            Value = InventoryBoxInstance4.Width + 60f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "InventoryBoxInstance4.Width Units",
                            Type = "DimensionUnitType",
                            Value = InventoryBoxInstance4.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "InventoryBoxInstance4.X Origin",
                            Type = "HorizontalAlignment",
                            Value = InventoryBoxInstance4.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "InventoryBoxInstance4.X Units",
                            Type = "PositionUnitType",
                            Value = InventoryBoxInstance4.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "InventoryBoxInstance4.Y Origin",
                            Type = "VerticalAlignment",
                            Value = InventoryBoxInstance4.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "InventoryBoxInstance4.Y Units",
                            Type = "PositionUnitType",
                            Value = InventoryBoxInstance4.YUnits
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
                            Value = ContainerItems.Height + 100f
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
                            Name = "ContainerItems.Width",
                            Type = "float",
                            Value = ContainerItems.Width + 100f
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
                            Name = "ContainerItems.X Origin",
                            Type = "HorizontalAlignment",
                            Value = ContainerItems.XOrigin
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
            private Pirates.GumRuntimes.ColoredRectangleRuntime BackgroundRectangle { get; set; }
            private Pirates.GumRuntimes.InventoryForms.InventoryBoxRuntime InventoryBoxInstance1 { get; set; }
            private Pirates.GumRuntimes.InventoryForms.InventoryBoxRuntime InventoryBoxInstance2 { get; set; }
            private Pirates.GumRuntimes.InventoryForms.InventoryBoxRuntime InventoryBoxInstance3 { get; set; }
            private Pirates.GumRuntimes.InventoryForms.InventoryBoxRuntime InventoryBoxInstance4 { get; set; }
            private Pirates.GumRuntimes.ContainerRuntime ContainerItems { get; set; }
            public event FlatRedBall.Gui.WindowEvent InventoryBoxInstance1Click;
            public event FlatRedBall.Gui.WindowEvent InventoryBoxInstance2Click;
            public event FlatRedBall.Gui.WindowEvent InventoryBoxInstance3Click;
            public event FlatRedBall.Gui.WindowEvent InventoryBoxInstance4Click;
            public event FlatRedBall.Gui.WindowEvent ContainerItemsClick;
            public InventoryBarRuntime (bool fullInstantiation = true, bool tryCreateFormsObject = true) 
            	: base(false, tryCreateFormsObject)
            {
                if (fullInstantiation)
                {
                    Gum.DataTypes.ElementSave elementSave = Gum.Managers.ObjectFinder.Self.GumProjectSave.Components.First(item => item.Name == "InventoryForms/InventoryBar");
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
                BackgroundRectangle = this.GetGraphicalUiElementByName("BackgroundRectangle") as Pirates.GumRuntimes.ColoredRectangleRuntime;
                InventoryBoxInstance1 = this.GetGraphicalUiElementByName("InventoryBoxInstance1") as Pirates.GumRuntimes.InventoryForms.InventoryBoxRuntime;
                InventoryBoxInstance2 = this.GetGraphicalUiElementByName("InventoryBoxInstance2") as Pirates.GumRuntimes.InventoryForms.InventoryBoxRuntime;
                InventoryBoxInstance3 = this.GetGraphicalUiElementByName("InventoryBoxInstance3") as Pirates.GumRuntimes.InventoryForms.InventoryBoxRuntime;
                InventoryBoxInstance4 = this.GetGraphicalUiElementByName("InventoryBoxInstance4") as Pirates.GumRuntimes.InventoryForms.InventoryBoxRuntime;
                ContainerItems = this.GetGraphicalUiElementByName("ContainerItems") as Pirates.GumRuntimes.ContainerRuntime;
                InventoryBoxInstance1.Click += (unused) => InventoryBoxInstance1Click?.Invoke(this);
                InventoryBoxInstance2.Click += (unused) => InventoryBoxInstance2Click?.Invoke(this);
                InventoryBoxInstance3.Click += (unused) => InventoryBoxInstance3Click?.Invoke(this);
                InventoryBoxInstance4.Click += (unused) => InventoryBoxInstance4Click?.Invoke(this);
                ContainerItems.Click += (unused) => ContainerItemsClick?.Invoke(this);
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
