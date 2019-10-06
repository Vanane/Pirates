    using System.Linq;
    namespace Pirates.GumRuntimes.InventoryForms
    {
        public partial class InventoryBoxRuntime : Pirates.GumRuntimes.ContainerRuntime
        {
            #region State Enums
            public enum VariableState
            {
                Default,
                Selected
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
                            BackgroundRectangle.CurrentVariableState = Pirates.GumRuntimes.ColoredRectangleRuntime.VariableState.Default;
                            Height = 60f;
                            HeightUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                            Width = 60f;
                            WidthUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                            XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                            YUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                            BackgroundRectangle.Alpha = 128;
                            BackgroundRectangle.Height = 100f;
                            BackgroundRectangle.HeightUnits = Gum.DataTypes.DimensionUnitType.PercentageOfOtherDimension;
                            BackgroundRectangle.Width = 90f;
                            BackgroundRectangle.WidthUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                            BackgroundRectangle.X = 5f;
                            BackgroundRectangle.XUnits = Gum.Converters.GeneralUnitType.Percentage;
                            BackgroundRectangle.Y = 5f;
                            BackgroundRectangle.YUnits = Gum.Converters.GeneralUnitType.Percentage;
                            ItemSprite.Height = 100f;
                            ItemSprite.HeightUnits = Gum.DataTypes.DimensionUnitType.PercentageOfOtherDimension;
                            ItemSprite.Width = 90f;
                            ItemSprite.WidthUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                            ItemSprite.X = 5f;
                            ItemSprite.XUnits = Gum.Converters.GeneralUnitType.Percentage;
                            ItemSprite.Y = 5f;
                            ItemSprite.YUnits = Gum.Converters.GeneralUnitType.Percentage;
                            break;
                        case  VariableState.Selected:
                            BackgroundRectangle.Alpha = 255;
                            BackgroundRectangle.Blue = 0;
                            BackgroundRectangle.Green = 0;
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
                bool setBackgroundRectangleHeightFirstValue = false;
                bool setBackgroundRectangleHeightSecondValue = false;
                float BackgroundRectangleHeightFirstValue= 0;
                float BackgroundRectangleHeightSecondValue= 0;
                bool setBackgroundRectangleCurrentVariableStateFirstValue = false;
                bool setBackgroundRectangleCurrentVariableStateSecondValue = false;
                Pirates.GumRuntimes.ColoredRectangleRuntime.VariableState BackgroundRectangleCurrentVariableStateFirstValue= Pirates.GumRuntimes.ColoredRectangleRuntime.VariableState.Default;
                Pirates.GumRuntimes.ColoredRectangleRuntime.VariableState BackgroundRectangleCurrentVariableStateSecondValue= Pirates.GumRuntimes.ColoredRectangleRuntime.VariableState.Default;
                bool setBackgroundRectangleWidthFirstValue = false;
                bool setBackgroundRectangleWidthSecondValue = false;
                float BackgroundRectangleWidthFirstValue= 0;
                float BackgroundRectangleWidthSecondValue= 0;
                bool setBackgroundRectangleXFirstValue = false;
                bool setBackgroundRectangleXSecondValue = false;
                float BackgroundRectangleXFirstValue= 0;
                float BackgroundRectangleXSecondValue= 0;
                bool setBackgroundRectangleYFirstValue = false;
                bool setBackgroundRectangleYSecondValue = false;
                float BackgroundRectangleYFirstValue= 0;
                float BackgroundRectangleYSecondValue= 0;
                bool setHeightFirstValue = false;
                bool setHeightSecondValue = false;
                float HeightFirstValue= 0;
                float HeightSecondValue= 0;
                bool setItemSpriteHeightFirstValue = false;
                bool setItemSpriteHeightSecondValue = false;
                float ItemSpriteHeightFirstValue= 0;
                float ItemSpriteHeightSecondValue= 0;
                bool setItemSpriteWidthFirstValue = false;
                bool setItemSpriteWidthSecondValue = false;
                float ItemSpriteWidthFirstValue= 0;
                float ItemSpriteWidthSecondValue= 0;
                bool setItemSpriteXFirstValue = false;
                bool setItemSpriteXSecondValue = false;
                float ItemSpriteXFirstValue= 0;
                float ItemSpriteXSecondValue= 0;
                bool setItemSpriteYFirstValue = false;
                bool setItemSpriteYSecondValue = false;
                float ItemSpriteYFirstValue= 0;
                float ItemSpriteYSecondValue= 0;
                bool setWidthFirstValue = false;
                bool setWidthSecondValue = false;
                float WidthFirstValue= 0;
                float WidthSecondValue= 0;
                bool setBackgroundRectangleBlueFirstValue = false;
                bool setBackgroundRectangleBlueSecondValue = false;
                int BackgroundRectangleBlueFirstValue= 0;
                int BackgroundRectangleBlueSecondValue= 0;
                bool setBackgroundRectangleGreenFirstValue = false;
                bool setBackgroundRectangleGreenSecondValue = false;
                int BackgroundRectangleGreenFirstValue= 0;
                int BackgroundRectangleGreenSecondValue= 0;
                switch(firstState)
                {
                    case  VariableState.Default:
                        setBackgroundRectangleAlphaFirstValue = true;
                        BackgroundRectangleAlphaFirstValue = 128;
                        setBackgroundRectangleHeightFirstValue = true;
                        BackgroundRectangleHeightFirstValue = 100f;
                        if (interpolationValue < 1)
                        {
                            this.BackgroundRectangle.HeightUnits = Gum.DataTypes.DimensionUnitType.PercentageOfOtherDimension;
                        }
                        setBackgroundRectangleCurrentVariableStateFirstValue = true;
                        BackgroundRectangleCurrentVariableStateFirstValue = Pirates.GumRuntimes.ColoredRectangleRuntime.VariableState.Default;
                        setBackgroundRectangleWidthFirstValue = true;
                        BackgroundRectangleWidthFirstValue = 90f;
                        if (interpolationValue < 1)
                        {
                            this.BackgroundRectangle.WidthUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        setBackgroundRectangleXFirstValue = true;
                        BackgroundRectangleXFirstValue = 5f;
                        if (interpolationValue < 1)
                        {
                            this.BackgroundRectangle.XUnits = Gum.Converters.GeneralUnitType.Percentage;
                        }
                        setBackgroundRectangleYFirstValue = true;
                        BackgroundRectangleYFirstValue = 5f;
                        if (interpolationValue < 1)
                        {
                            this.BackgroundRectangle.YUnits = Gum.Converters.GeneralUnitType.Percentage;
                        }
                        setHeightFirstValue = true;
                        HeightFirstValue = 60f;
                        if (interpolationValue < 1)
                        {
                            this.HeightUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        setItemSpriteHeightFirstValue = true;
                        ItemSpriteHeightFirstValue = 100f;
                        if (interpolationValue < 1)
                        {
                            this.ItemSprite.HeightUnits = Gum.DataTypes.DimensionUnitType.PercentageOfOtherDimension;
                        }
                        setItemSpriteWidthFirstValue = true;
                        ItemSpriteWidthFirstValue = 90f;
                        if (interpolationValue < 1)
                        {
                            this.ItemSprite.WidthUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        setItemSpriteXFirstValue = true;
                        ItemSpriteXFirstValue = 5f;
                        if (interpolationValue < 1)
                        {
                            this.ItemSprite.XUnits = Gum.Converters.GeneralUnitType.Percentage;
                        }
                        setItemSpriteYFirstValue = true;
                        ItemSpriteYFirstValue = 5f;
                        if (interpolationValue < 1)
                        {
                            this.ItemSprite.YUnits = Gum.Converters.GeneralUnitType.Percentage;
                        }
                        setWidthFirstValue = true;
                        WidthFirstValue = 60f;
                        if (interpolationValue < 1)
                        {
                            this.WidthUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        if (interpolationValue < 1)
                        {
                            this.XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        if (interpolationValue < 1)
                        {
                            this.YUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        break;
                    case  VariableState.Selected:
                        setBackgroundRectangleAlphaFirstValue = true;
                        BackgroundRectangleAlphaFirstValue = 255;
                        setBackgroundRectangleBlueFirstValue = true;
                        BackgroundRectangleBlueFirstValue = 0;
                        setBackgroundRectangleGreenFirstValue = true;
                        BackgroundRectangleGreenFirstValue = 0;
                        break;
                }
                switch(secondState)
                {
                    case  VariableState.Default:
                        setBackgroundRectangleAlphaSecondValue = true;
                        BackgroundRectangleAlphaSecondValue = 128;
                        setBackgroundRectangleHeightSecondValue = true;
                        BackgroundRectangleHeightSecondValue = 100f;
                        if (interpolationValue >= 1)
                        {
                            this.BackgroundRectangle.HeightUnits = Gum.DataTypes.DimensionUnitType.PercentageOfOtherDimension;
                        }
                        setBackgroundRectangleCurrentVariableStateSecondValue = true;
                        BackgroundRectangleCurrentVariableStateSecondValue = Pirates.GumRuntimes.ColoredRectangleRuntime.VariableState.Default;
                        setBackgroundRectangleWidthSecondValue = true;
                        BackgroundRectangleWidthSecondValue = 90f;
                        if (interpolationValue >= 1)
                        {
                            this.BackgroundRectangle.WidthUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        setBackgroundRectangleXSecondValue = true;
                        BackgroundRectangleXSecondValue = 5f;
                        if (interpolationValue >= 1)
                        {
                            this.BackgroundRectangle.XUnits = Gum.Converters.GeneralUnitType.Percentage;
                        }
                        setBackgroundRectangleYSecondValue = true;
                        BackgroundRectangleYSecondValue = 5f;
                        if (interpolationValue >= 1)
                        {
                            this.BackgroundRectangle.YUnits = Gum.Converters.GeneralUnitType.Percentage;
                        }
                        setHeightSecondValue = true;
                        HeightSecondValue = 60f;
                        if (interpolationValue >= 1)
                        {
                            this.HeightUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        setItemSpriteHeightSecondValue = true;
                        ItemSpriteHeightSecondValue = 100f;
                        if (interpolationValue >= 1)
                        {
                            this.ItemSprite.HeightUnits = Gum.DataTypes.DimensionUnitType.PercentageOfOtherDimension;
                        }
                        setItemSpriteWidthSecondValue = true;
                        ItemSpriteWidthSecondValue = 90f;
                        if (interpolationValue >= 1)
                        {
                            this.ItemSprite.WidthUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        setItemSpriteXSecondValue = true;
                        ItemSpriteXSecondValue = 5f;
                        if (interpolationValue >= 1)
                        {
                            this.ItemSprite.XUnits = Gum.Converters.GeneralUnitType.Percentage;
                        }
                        setItemSpriteYSecondValue = true;
                        ItemSpriteYSecondValue = 5f;
                        if (interpolationValue >= 1)
                        {
                            this.ItemSprite.YUnits = Gum.Converters.GeneralUnitType.Percentage;
                        }
                        setWidthSecondValue = true;
                        WidthSecondValue = 60f;
                        if (interpolationValue >= 1)
                        {
                            this.WidthUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.YUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        break;
                    case  VariableState.Selected:
                        setBackgroundRectangleAlphaSecondValue = true;
                        BackgroundRectangleAlphaSecondValue = 255;
                        setBackgroundRectangleBlueSecondValue = true;
                        BackgroundRectangleBlueSecondValue = 0;
                        setBackgroundRectangleGreenSecondValue = true;
                        BackgroundRectangleGreenSecondValue = 0;
                        break;
                }
                if (setBackgroundRectangleAlphaFirstValue && setBackgroundRectangleAlphaSecondValue)
                {
                    BackgroundRectangle.Alpha = FlatRedBall.Math.MathFunctions.RoundToInt(BackgroundRectangleAlphaFirstValue* (1 - interpolationValue) + BackgroundRectangleAlphaSecondValue * interpolationValue);
                }
                if (setBackgroundRectangleHeightFirstValue && setBackgroundRectangleHeightSecondValue)
                {
                    BackgroundRectangle.Height = BackgroundRectangleHeightFirstValue * (1 - interpolationValue) + BackgroundRectangleHeightSecondValue * interpolationValue;
                }
                if (setBackgroundRectangleCurrentVariableStateFirstValue && setBackgroundRectangleCurrentVariableStateSecondValue)
                {
                    BackgroundRectangle.InterpolateBetween(BackgroundRectangleCurrentVariableStateFirstValue, BackgroundRectangleCurrentVariableStateSecondValue, interpolationValue);
                }
                if (setBackgroundRectangleWidthFirstValue && setBackgroundRectangleWidthSecondValue)
                {
                    BackgroundRectangle.Width = BackgroundRectangleWidthFirstValue * (1 - interpolationValue) + BackgroundRectangleWidthSecondValue * interpolationValue;
                }
                if (setBackgroundRectangleXFirstValue && setBackgroundRectangleXSecondValue)
                {
                    BackgroundRectangle.X = BackgroundRectangleXFirstValue * (1 - interpolationValue) + BackgroundRectangleXSecondValue * interpolationValue;
                }
                if (setBackgroundRectangleYFirstValue && setBackgroundRectangleYSecondValue)
                {
                    BackgroundRectangle.Y = BackgroundRectangleYFirstValue * (1 - interpolationValue) + BackgroundRectangleYSecondValue * interpolationValue;
                }
                if (setHeightFirstValue && setHeightSecondValue)
                {
                    Height = HeightFirstValue * (1 - interpolationValue) + HeightSecondValue * interpolationValue;
                }
                if (setItemSpriteHeightFirstValue && setItemSpriteHeightSecondValue)
                {
                    ItemSprite.Height = ItemSpriteHeightFirstValue * (1 - interpolationValue) + ItemSpriteHeightSecondValue * interpolationValue;
                }
                if (setItemSpriteWidthFirstValue && setItemSpriteWidthSecondValue)
                {
                    ItemSprite.Width = ItemSpriteWidthFirstValue * (1 - interpolationValue) + ItemSpriteWidthSecondValue * interpolationValue;
                }
                if (setItemSpriteXFirstValue && setItemSpriteXSecondValue)
                {
                    ItemSprite.X = ItemSpriteXFirstValue * (1 - interpolationValue) + ItemSpriteXSecondValue * interpolationValue;
                }
                if (setItemSpriteYFirstValue && setItemSpriteYSecondValue)
                {
                    ItemSprite.Y = ItemSpriteYFirstValue * (1 - interpolationValue) + ItemSpriteYSecondValue * interpolationValue;
                }
                if (setWidthFirstValue && setWidthSecondValue)
                {
                    Width = WidthFirstValue * (1 - interpolationValue) + WidthSecondValue * interpolationValue;
                }
                if (setBackgroundRectangleBlueFirstValue && setBackgroundRectangleBlueSecondValue)
                {
                    BackgroundRectangle.Blue = FlatRedBall.Math.MathFunctions.RoundToInt(BackgroundRectangleBlueFirstValue* (1 - interpolationValue) + BackgroundRectangleBlueSecondValue * interpolationValue);
                }
                if (setBackgroundRectangleGreenFirstValue && setBackgroundRectangleGreenSecondValue)
                {
                    BackgroundRectangle.Green = FlatRedBall.Math.MathFunctions.RoundToInt(BackgroundRectangleGreenFirstValue* (1 - interpolationValue) + BackgroundRectangleGreenSecondValue * interpolationValue);
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
            public FlatRedBall.Glue.StateInterpolation.Tweener InterpolateTo (Pirates.GumRuntimes.InventoryForms.InventoryBoxRuntime.VariableState fromState,Pirates.GumRuntimes.InventoryForms.InventoryBoxRuntime.VariableState toState, double secondsToTake, FlatRedBall.Glue.StateInterpolation.InterpolationType interpolationType, FlatRedBall.Glue.StateInterpolation.Easing easing, object owner = null) 
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
                            Name = "X Units",
                            Type = "PositionUnitType",
                            Value = XUnits
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
                            Name = "BackgroundRectangle.State",
                            Type = "State",
                            Value = BackgroundRectangle.CurrentVariableState
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
                            Name = "BackgroundRectangle.X",
                            Type = "float",
                            Value = BackgroundRectangle.X
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
                            Name = "BackgroundRectangle.Y",
                            Type = "float",
                            Value = BackgroundRectangle.Y
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
                            Name = "ItemSprite.Height",
                            Type = "float",
                            Value = ItemSprite.Height
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ItemSprite.Height Units",
                            Type = "DimensionUnitType",
                            Value = ItemSprite.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ItemSprite.Width",
                            Type = "float",
                            Value = ItemSprite.Width
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ItemSprite.Width Units",
                            Type = "DimensionUnitType",
                            Value = ItemSprite.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ItemSprite.X",
                            Type = "float",
                            Value = ItemSprite.X
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ItemSprite.X Units",
                            Type = "PositionUnitType",
                            Value = ItemSprite.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ItemSprite.Y",
                            Type = "float",
                            Value = ItemSprite.Y
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ItemSprite.Y Units",
                            Type = "PositionUnitType",
                            Value = ItemSprite.YUnits
                        }
                        );
                        break;
                    case  VariableState.Selected:
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
                            Value = Width + 60f
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
                            Name = "X Units",
                            Type = "PositionUnitType",
                            Value = XUnits
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
                            Value = BackgroundRectangle.Alpha + 128
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
                            Name = "BackgroundRectangle.State",
                            Type = "State",
                            Value = BackgroundRectangle.CurrentVariableState
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "BackgroundRectangle.Width",
                            Type = "float",
                            Value = BackgroundRectangle.Width + 90f
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
                            Name = "BackgroundRectangle.X",
                            Type = "float",
                            Value = BackgroundRectangle.X + 5f
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
                            Name = "BackgroundRectangle.Y",
                            Type = "float",
                            Value = BackgroundRectangle.Y + 5f
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
                            Name = "ItemSprite.Height",
                            Type = "float",
                            Value = ItemSprite.Height + 100f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ItemSprite.Height Units",
                            Type = "DimensionUnitType",
                            Value = ItemSprite.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ItemSprite.Width",
                            Type = "float",
                            Value = ItemSprite.Width + 90f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ItemSprite.Width Units",
                            Type = "DimensionUnitType",
                            Value = ItemSprite.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ItemSprite.X",
                            Type = "float",
                            Value = ItemSprite.X + 5f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ItemSprite.X Units",
                            Type = "PositionUnitType",
                            Value = ItemSprite.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ItemSprite.Y",
                            Type = "float",
                            Value = ItemSprite.Y + 5f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ItemSprite.Y Units",
                            Type = "PositionUnitType",
                            Value = ItemSprite.YUnits
                        }
                        );
                        break;
                    case  VariableState.Selected:
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "BackgroundRectangle.Alpha",
                            Type = "int",
                            Value = BackgroundRectangle.Alpha + 255
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "BackgroundRectangle.Blue",
                            Type = "int",
                            Value = BackgroundRectangle.Blue + 0
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "BackgroundRectangle.Green",
                            Type = "int",
                            Value = BackgroundRectangle.Green + 0
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
                        if (state.Name == "Selected") this.mCurrentVariableState = VariableState.Selected;
                    }
                }
                base.ApplyState(state);
            }
            private Pirates.GumRuntimes.ColoredRectangleRuntime BackgroundRectangle { get; set; }
            private Pirates.GumRuntimes.SpriteRuntime ItemSprite { get; set; }
            public InventoryBoxRuntime (bool fullInstantiation = true, bool tryCreateFormsObject = true) 
            	: base(false, tryCreateFormsObject)
            {
                this.HasEvents = true;
                if (fullInstantiation)
                {
                    Gum.DataTypes.ElementSave elementSave = Gum.Managers.ObjectFinder.Self.GumProjectSave.Components.First(item => item.Name == "InventoryForms/InventoryBox");
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
                ItemSprite = this.GetGraphicalUiElementByName("ItemSprite") as Pirates.GumRuntimes.SpriteRuntime;
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
