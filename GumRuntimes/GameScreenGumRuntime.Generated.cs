    using System.Linq;
    namespace Pirates.GumRuntimes
    {
        public partial class GameScreenGumRuntime : Gum.Wireframe.GraphicalUiElement
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
                            ButtonPistol.ButtonText = "Equiper pistolet";
                            ButtonPistol.Height = 61f;
                            ButtonPistol.HeightUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                            ButtonPistol.Width = 256f;
                            ButtonPistol.WidthUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                            ButtonPistol.X = -256f;
                            ButtonPistol.XUnits = Gum.Converters.GeneralUnitType.PixelsFromLarge;
                            ButtonPistol.Y = 0f;
                            ButtonShotgun.ButtonText = "Equiper pompe";
                            ButtonShotgun.Height = 61f;
                            ButtonShotgun.HeightUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                            ButtonShotgun.Width = 256f;
                            ButtonShotgun.WidthUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                            ButtonShotgun.X = -256f;
                            ButtonShotgun.XUnits = Gum.Converters.GeneralUnitType.PixelsFromLarge;
                            ButtonShotgun.Y = 64f;
                            InventoryBarInstance.Height = 10f;
                            InventoryBarInstance.HeightUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                            InventoryBarInstance.Visible = true;
                            InventoryGui.Visible = true;
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
                bool setButtonPistolHeightFirstValue = false;
                bool setButtonPistolHeightSecondValue = false;
                float ButtonPistolHeightFirstValue= 0;
                float ButtonPistolHeightSecondValue= 0;
                bool setButtonPistolWidthFirstValue = false;
                bool setButtonPistolWidthSecondValue = false;
                float ButtonPistolWidthFirstValue= 0;
                float ButtonPistolWidthSecondValue= 0;
                bool setButtonPistolXFirstValue = false;
                bool setButtonPistolXSecondValue = false;
                float ButtonPistolXFirstValue= 0;
                float ButtonPistolXSecondValue= 0;
                bool setButtonPistolYFirstValue = false;
                bool setButtonPistolYSecondValue = false;
                float ButtonPistolYFirstValue= 0;
                float ButtonPistolYSecondValue= 0;
                bool setButtonShotgunHeightFirstValue = false;
                bool setButtonShotgunHeightSecondValue = false;
                float ButtonShotgunHeightFirstValue= 0;
                float ButtonShotgunHeightSecondValue= 0;
                bool setButtonShotgunWidthFirstValue = false;
                bool setButtonShotgunWidthSecondValue = false;
                float ButtonShotgunWidthFirstValue= 0;
                float ButtonShotgunWidthSecondValue= 0;
                bool setButtonShotgunXFirstValue = false;
                bool setButtonShotgunXSecondValue = false;
                float ButtonShotgunXFirstValue= 0;
                float ButtonShotgunXSecondValue= 0;
                bool setButtonShotgunYFirstValue = false;
                bool setButtonShotgunYSecondValue = false;
                float ButtonShotgunYFirstValue= 0;
                float ButtonShotgunYSecondValue= 0;
                bool setInventoryBarInstanceHeightFirstValue = false;
                bool setInventoryBarInstanceHeightSecondValue = false;
                float InventoryBarInstanceHeightFirstValue= 0;
                float InventoryBarInstanceHeightSecondValue= 0;
                switch(firstState)
                {
                    case  VariableState.Default:
                        if (interpolationValue < 1)
                        {
                            this.ButtonPistol.ButtonText = "Equiper pistolet";
                        }
                        setButtonPistolHeightFirstValue = true;
                        ButtonPistolHeightFirstValue = 61f;
                        if (interpolationValue < 1)
                        {
                            this.ButtonPistol.HeightUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        setButtonPistolWidthFirstValue = true;
                        ButtonPistolWidthFirstValue = 256f;
                        if (interpolationValue < 1)
                        {
                            this.ButtonPistol.WidthUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        setButtonPistolXFirstValue = true;
                        ButtonPistolXFirstValue = -256f;
                        if (interpolationValue < 1)
                        {
                            this.ButtonPistol.XUnits = Gum.Converters.GeneralUnitType.PixelsFromLarge;
                        }
                        setButtonPistolYFirstValue = true;
                        ButtonPistolYFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.ButtonShotgun.ButtonText = "Equiper pompe";
                        }
                        setButtonShotgunHeightFirstValue = true;
                        ButtonShotgunHeightFirstValue = 61f;
                        if (interpolationValue < 1)
                        {
                            this.ButtonShotgun.HeightUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        setButtonShotgunWidthFirstValue = true;
                        ButtonShotgunWidthFirstValue = 256f;
                        if (interpolationValue < 1)
                        {
                            this.ButtonShotgun.WidthUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        setButtonShotgunXFirstValue = true;
                        ButtonShotgunXFirstValue = -256f;
                        if (interpolationValue < 1)
                        {
                            this.ButtonShotgun.XUnits = Gum.Converters.GeneralUnitType.PixelsFromLarge;
                        }
                        setButtonShotgunYFirstValue = true;
                        ButtonShotgunYFirstValue = 64f;
                        setInventoryBarInstanceHeightFirstValue = true;
                        InventoryBarInstanceHeightFirstValue = 10f;
                        if (interpolationValue < 1)
                        {
                            this.InventoryBarInstance.HeightUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        if (interpolationValue < 1)
                        {
                            this.InventoryBarInstance.Visible = true;
                        }
                        if (interpolationValue < 1)
                        {
                            this.InventoryGui.Visible = true;
                        }
                        break;
                }
                switch(secondState)
                {
                    case  VariableState.Default:
                        if (interpolationValue >= 1)
                        {
                            this.ButtonPistol.ButtonText = "Equiper pistolet";
                        }
                        setButtonPistolHeightSecondValue = true;
                        ButtonPistolHeightSecondValue = 61f;
                        if (interpolationValue >= 1)
                        {
                            this.ButtonPistol.HeightUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        setButtonPistolWidthSecondValue = true;
                        ButtonPistolWidthSecondValue = 256f;
                        if (interpolationValue >= 1)
                        {
                            this.ButtonPistol.WidthUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        setButtonPistolXSecondValue = true;
                        ButtonPistolXSecondValue = -256f;
                        if (interpolationValue >= 1)
                        {
                            this.ButtonPistol.XUnits = Gum.Converters.GeneralUnitType.PixelsFromLarge;
                        }
                        setButtonPistolYSecondValue = true;
                        ButtonPistolYSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.ButtonShotgun.ButtonText = "Equiper pompe";
                        }
                        setButtonShotgunHeightSecondValue = true;
                        ButtonShotgunHeightSecondValue = 61f;
                        if (interpolationValue >= 1)
                        {
                            this.ButtonShotgun.HeightUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        setButtonShotgunWidthSecondValue = true;
                        ButtonShotgunWidthSecondValue = 256f;
                        if (interpolationValue >= 1)
                        {
                            this.ButtonShotgun.WidthUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        setButtonShotgunXSecondValue = true;
                        ButtonShotgunXSecondValue = -256f;
                        if (interpolationValue >= 1)
                        {
                            this.ButtonShotgun.XUnits = Gum.Converters.GeneralUnitType.PixelsFromLarge;
                        }
                        setButtonShotgunYSecondValue = true;
                        ButtonShotgunYSecondValue = 64f;
                        setInventoryBarInstanceHeightSecondValue = true;
                        InventoryBarInstanceHeightSecondValue = 10f;
                        if (interpolationValue >= 1)
                        {
                            this.InventoryBarInstance.HeightUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.InventoryBarInstance.Visible = true;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.InventoryGui.Visible = true;
                        }
                        break;
                }
                if (setButtonPistolHeightFirstValue && setButtonPistolHeightSecondValue)
                {
                    ButtonPistol.Height = ButtonPistolHeightFirstValue * (1 - interpolationValue) + ButtonPistolHeightSecondValue * interpolationValue;
                }
                if (setButtonPistolWidthFirstValue && setButtonPistolWidthSecondValue)
                {
                    ButtonPistol.Width = ButtonPistolWidthFirstValue * (1 - interpolationValue) + ButtonPistolWidthSecondValue * interpolationValue;
                }
                if (setButtonPistolXFirstValue && setButtonPistolXSecondValue)
                {
                    ButtonPistol.X = ButtonPistolXFirstValue * (1 - interpolationValue) + ButtonPistolXSecondValue * interpolationValue;
                }
                if (setButtonPistolYFirstValue && setButtonPistolYSecondValue)
                {
                    ButtonPistol.Y = ButtonPistolYFirstValue * (1 - interpolationValue) + ButtonPistolYSecondValue * interpolationValue;
                }
                if (setButtonShotgunHeightFirstValue && setButtonShotgunHeightSecondValue)
                {
                    ButtonShotgun.Height = ButtonShotgunHeightFirstValue * (1 - interpolationValue) + ButtonShotgunHeightSecondValue * interpolationValue;
                }
                if (setButtonShotgunWidthFirstValue && setButtonShotgunWidthSecondValue)
                {
                    ButtonShotgun.Width = ButtonShotgunWidthFirstValue * (1 - interpolationValue) + ButtonShotgunWidthSecondValue * interpolationValue;
                }
                if (setButtonShotgunXFirstValue && setButtonShotgunXSecondValue)
                {
                    ButtonShotgun.X = ButtonShotgunXFirstValue * (1 - interpolationValue) + ButtonShotgunXSecondValue * interpolationValue;
                }
                if (setButtonShotgunYFirstValue && setButtonShotgunYSecondValue)
                {
                    ButtonShotgun.Y = ButtonShotgunYFirstValue * (1 - interpolationValue) + ButtonShotgunYSecondValue * interpolationValue;
                }
                if (setInventoryBarInstanceHeightFirstValue && setInventoryBarInstanceHeightSecondValue)
                {
                    InventoryBarInstance.Height = InventoryBarInstanceHeightFirstValue * (1 - interpolationValue) + InventoryBarInstanceHeightSecondValue * interpolationValue;
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
            public FlatRedBall.Glue.StateInterpolation.Tweener InterpolateTo (Pirates.GumRuntimes.GameScreenGumRuntime.VariableState fromState,Pirates.GumRuntimes.GameScreenGumRuntime.VariableState toState, double secondsToTake, FlatRedBall.Glue.StateInterpolation.InterpolationType interpolationType, FlatRedBall.Glue.StateInterpolation.Easing easing, object owner = null) 
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
                ButtonPistol.StopAnimations();
                ButtonShotgun.StopAnimations();
                InventoryBarInstance.StopAnimations();
                InventoryGui.StopAnimations();
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
                            Name = "ButtonPistol.ButtonText",
                            Type = "string",
                            Value = ButtonPistol.ButtonText
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonPistol.Height",
                            Type = "float",
                            Value = ButtonPistol.Height
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonPistol.Height Units",
                            Type = "DimensionUnitType",
                            Value = ButtonPistol.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonPistol.Width",
                            Type = "float",
                            Value = ButtonPistol.Width
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonPistol.Width Units",
                            Type = "DimensionUnitType",
                            Value = ButtonPistol.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonPistol.X",
                            Type = "float",
                            Value = ButtonPistol.X
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonPistol.X Units",
                            Type = "PositionUnitType",
                            Value = ButtonPistol.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonPistol.Y",
                            Type = "float",
                            Value = ButtonPistol.Y
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonShotgun.ButtonText",
                            Type = "string",
                            Value = ButtonShotgun.ButtonText
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonShotgun.Height",
                            Type = "float",
                            Value = ButtonShotgun.Height
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonShotgun.Height Units",
                            Type = "DimensionUnitType",
                            Value = ButtonShotgun.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonShotgun.Width",
                            Type = "float",
                            Value = ButtonShotgun.Width
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonShotgun.Width Units",
                            Type = "DimensionUnitType",
                            Value = ButtonShotgun.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonShotgun.X",
                            Type = "float",
                            Value = ButtonShotgun.X
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonShotgun.X Units",
                            Type = "PositionUnitType",
                            Value = ButtonShotgun.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonShotgun.Y",
                            Type = "float",
                            Value = ButtonShotgun.Y
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "InventoryBarInstance.Height",
                            Type = "float",
                            Value = InventoryBarInstance.Height
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "InventoryBarInstance.Height Units",
                            Type = "DimensionUnitType",
                            Value = InventoryBarInstance.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "InventoryBarInstance.Visible",
                            Type = "bool",
                            Value = InventoryBarInstance.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "InventoryGui.Visible",
                            Type = "bool",
                            Value = InventoryGui.Visible
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
                            Name = "ButtonPistol.ButtonText",
                            Type = "string",
                            Value = ButtonPistol.ButtonText
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonPistol.Height",
                            Type = "float",
                            Value = ButtonPistol.Height + 61f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonPistol.Height Units",
                            Type = "DimensionUnitType",
                            Value = ButtonPistol.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonPistol.Width",
                            Type = "float",
                            Value = ButtonPistol.Width + 256f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonPistol.Width Units",
                            Type = "DimensionUnitType",
                            Value = ButtonPistol.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonPistol.X",
                            Type = "float",
                            Value = ButtonPistol.X + -256f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonPistol.X Units",
                            Type = "PositionUnitType",
                            Value = ButtonPistol.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonPistol.Y",
                            Type = "float",
                            Value = ButtonPistol.Y + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonShotgun.ButtonText",
                            Type = "string",
                            Value = ButtonShotgun.ButtonText
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonShotgun.Height",
                            Type = "float",
                            Value = ButtonShotgun.Height + 61f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonShotgun.Height Units",
                            Type = "DimensionUnitType",
                            Value = ButtonShotgun.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonShotgun.Width",
                            Type = "float",
                            Value = ButtonShotgun.Width + 256f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonShotgun.Width Units",
                            Type = "DimensionUnitType",
                            Value = ButtonShotgun.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonShotgun.X",
                            Type = "float",
                            Value = ButtonShotgun.X + -256f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonShotgun.X Units",
                            Type = "PositionUnitType",
                            Value = ButtonShotgun.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonShotgun.Y",
                            Type = "float",
                            Value = ButtonShotgun.Y + 64f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "InventoryBarInstance.Height",
                            Type = "float",
                            Value = InventoryBarInstance.Height + 10f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "InventoryBarInstance.Height Units",
                            Type = "DimensionUnitType",
                            Value = InventoryBarInstance.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "InventoryBarInstance.Visible",
                            Type = "bool",
                            Value = InventoryBarInstance.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "InventoryGui.Visible",
                            Type = "bool",
                            Value = InventoryGui.Visible
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
            public Pirates.GumRuntimes.ButtonRuntime ButtonPistol { get; set; }
            public Pirates.GumRuntimes.ButtonRuntime ButtonShotgun { get; set; }
            public Pirates.GumRuntimes.InventoryForms.InventoryBarRuntime InventoryBarInstance { get; set; }
            public Pirates.GumRuntimes.InventoryForms.InventoryGuiRuntime InventoryGui { get; set; }
            public GameScreenGumRuntime (bool fullInstantiation = true, bool tryCreateFormsObject = true) 
            {
                if (fullInstantiation)
                {
                    Gum.DataTypes.ElementSave elementSave = Gum.Managers.ObjectFinder.Self.GumProjectSave.Screens.First(item => item.Name == "GameScreenGum");
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
                ButtonPistol = this.GetGraphicalUiElementByName("ButtonPistol") as Pirates.GumRuntimes.ButtonRuntime;
                ButtonShotgun = this.GetGraphicalUiElementByName("ButtonShotgun") as Pirates.GumRuntimes.ButtonRuntime;
                InventoryBarInstance = this.GetGraphicalUiElementByName("InventoryBarInstance") as Pirates.GumRuntimes.InventoryForms.InventoryBarRuntime;
                InventoryGui = this.GetGraphicalUiElementByName("InventoryGui") as Pirates.GumRuntimes.InventoryForms.InventoryGuiRuntime;
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
