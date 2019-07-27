    using System.Linq;
    namespace Pirates.GumRuntimes.DefaultForms
    {
        public partial class SliderRuntime : Pirates.GumRuntimes.ContainerRuntime
        {
            #region State Enums
            public enum VariableState
            {
                Default
            }
            public enum SliderCategory
            {
            }
            #endregion
            #region State Fields
            VariableState mCurrentVariableState;
            SliderCategory? mCurrentSliderCategoryState;
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
                            LineInstance.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "ContainerInstance") ?? this;
                            ThumbInstance.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "ContainerInstance") ?? this;
                            Height = 48f;
                            Width = 484f;
                            LineInstance.Height = 16f;
                            LineInstance.HeightUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                            LineInstance.Width = 0f;
                            LineInstance.WidthUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                            LineInstance.X = 0f;
                            LineInstance.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                            LineInstance.XUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                            LineInstance.Y = 0f;
                            LineInstance.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                            LineInstance.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                            ThumbInstance.Height = 40f;
                            ThumbInstance.Width = 33f;
                            ThumbInstance.X = 0f;
                            ThumbInstance.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                            ThumbInstance.Y = 0f;
                            ThumbInstance.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                            ThumbInstance.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                            ContainerInstance.Height = 0f;
                            ContainerInstance.HeightUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                            ContainerInstance.Width = -34f;
                            ContainerInstance.WidthUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                            ContainerInstance.X = 0f;
                            ContainerInstance.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                            ContainerInstance.XUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                            ContainerInstance.Y = 0f;
                            ContainerInstance.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                            ContainerInstance.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                            break;
                    }
                }
            }
            public SliderCategory? CurrentSliderCategoryState
            {
                get
                {
                    return mCurrentSliderCategoryState;
                }
                set
                {
                    if (value != null)
                    {
                        mCurrentSliderCategoryState = value;
                        switch(mCurrentSliderCategoryState)
                        {
                        }
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
                bool setContainerInstanceHeightFirstValue = false;
                bool setContainerInstanceHeightSecondValue = false;
                float ContainerInstanceHeightFirstValue= 0;
                float ContainerInstanceHeightSecondValue= 0;
                bool setContainerInstanceWidthFirstValue = false;
                bool setContainerInstanceWidthSecondValue = false;
                float ContainerInstanceWidthFirstValue= 0;
                float ContainerInstanceWidthSecondValue= 0;
                bool setContainerInstanceXFirstValue = false;
                bool setContainerInstanceXSecondValue = false;
                float ContainerInstanceXFirstValue= 0;
                float ContainerInstanceXSecondValue= 0;
                bool setContainerInstanceYFirstValue = false;
                bool setContainerInstanceYSecondValue = false;
                float ContainerInstanceYFirstValue= 0;
                float ContainerInstanceYSecondValue= 0;
                bool setHeightFirstValue = false;
                bool setHeightSecondValue = false;
                float HeightFirstValue= 0;
                float HeightSecondValue= 0;
                bool setLineInstanceHeightFirstValue = false;
                bool setLineInstanceHeightSecondValue = false;
                float LineInstanceHeightFirstValue= 0;
                float LineInstanceHeightSecondValue= 0;
                bool setLineInstanceWidthFirstValue = false;
                bool setLineInstanceWidthSecondValue = false;
                float LineInstanceWidthFirstValue= 0;
                float LineInstanceWidthSecondValue= 0;
                bool setLineInstanceXFirstValue = false;
                bool setLineInstanceXSecondValue = false;
                float LineInstanceXFirstValue= 0;
                float LineInstanceXSecondValue= 0;
                bool setLineInstanceYFirstValue = false;
                bool setLineInstanceYSecondValue = false;
                float LineInstanceYFirstValue= 0;
                float LineInstanceYSecondValue= 0;
                bool setThumbInstanceHeightFirstValue = false;
                bool setThumbInstanceHeightSecondValue = false;
                float ThumbInstanceHeightFirstValue= 0;
                float ThumbInstanceHeightSecondValue= 0;
                bool setThumbInstanceWidthFirstValue = false;
                bool setThumbInstanceWidthSecondValue = false;
                float ThumbInstanceWidthFirstValue= 0;
                float ThumbInstanceWidthSecondValue= 0;
                bool setThumbInstanceXFirstValue = false;
                bool setThumbInstanceXSecondValue = false;
                float ThumbInstanceXFirstValue= 0;
                float ThumbInstanceXSecondValue= 0;
                bool setThumbInstanceYFirstValue = false;
                bool setThumbInstanceYSecondValue = false;
                float ThumbInstanceYFirstValue= 0;
                float ThumbInstanceYSecondValue= 0;
                bool setWidthFirstValue = false;
                bool setWidthSecondValue = false;
                float WidthFirstValue= 0;
                float WidthSecondValue= 0;
                switch(firstState)
                {
                    case  VariableState.Default:
                        setContainerInstanceHeightFirstValue = true;
                        ContainerInstanceHeightFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.ContainerInstance.HeightUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                        }
                        setContainerInstanceWidthFirstValue = true;
                        ContainerInstanceWidthFirstValue = -34f;
                        if (interpolationValue < 1)
                        {
                            this.ContainerInstance.WidthUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                        }
                        setContainerInstanceXFirstValue = true;
                        ContainerInstanceXFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.ContainerInstance.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ContainerInstance.XUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        setContainerInstanceYFirstValue = true;
                        ContainerInstanceYFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.ContainerInstance.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ContainerInstance.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        setHeightFirstValue = true;
                        HeightFirstValue = 48f;
                        setLineInstanceHeightFirstValue = true;
                        LineInstanceHeightFirstValue = 16f;
                        if (interpolationValue < 1)
                        {
                            this.LineInstance.HeightUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        if (interpolationValue < 1)
                        {
                            this.LineInstance.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "ContainerInstance") ?? this;
                        }
                        setLineInstanceWidthFirstValue = true;
                        LineInstanceWidthFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.LineInstance.WidthUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                        }
                        setLineInstanceXFirstValue = true;
                        LineInstanceXFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.LineInstance.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                        }
                        if (interpolationValue < 1)
                        {
                            this.LineInstance.XUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        setLineInstanceYFirstValue = true;
                        LineInstanceYFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.LineInstance.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                        }
                        if (interpolationValue < 1)
                        {
                            this.LineInstance.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        setThumbInstanceHeightFirstValue = true;
                        ThumbInstanceHeightFirstValue = 40f;
                        if (interpolationValue < 1)
                        {
                            this.ThumbInstance.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "ContainerInstance") ?? this;
                        }
                        setThumbInstanceWidthFirstValue = true;
                        ThumbInstanceWidthFirstValue = 33f;
                        setThumbInstanceXFirstValue = true;
                        ThumbInstanceXFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.ThumbInstance.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                        }
                        setThumbInstanceYFirstValue = true;
                        ThumbInstanceYFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.ThumbInstance.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ThumbInstance.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        setWidthFirstValue = true;
                        WidthFirstValue = 484f;
                        break;
                }
                switch(secondState)
                {
                    case  VariableState.Default:
                        setContainerInstanceHeightSecondValue = true;
                        ContainerInstanceHeightSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.ContainerInstance.HeightUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                        }
                        setContainerInstanceWidthSecondValue = true;
                        ContainerInstanceWidthSecondValue = -34f;
                        if (interpolationValue >= 1)
                        {
                            this.ContainerInstance.WidthUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                        }
                        setContainerInstanceXSecondValue = true;
                        ContainerInstanceXSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.ContainerInstance.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ContainerInstance.XUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        setContainerInstanceYSecondValue = true;
                        ContainerInstanceYSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.ContainerInstance.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ContainerInstance.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        setHeightSecondValue = true;
                        HeightSecondValue = 48f;
                        setLineInstanceHeightSecondValue = true;
                        LineInstanceHeightSecondValue = 16f;
                        if (interpolationValue >= 1)
                        {
                            this.LineInstance.HeightUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.LineInstance.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "ContainerInstance") ?? this;
                        }
                        setLineInstanceWidthSecondValue = true;
                        LineInstanceWidthSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.LineInstance.WidthUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                        }
                        setLineInstanceXSecondValue = true;
                        LineInstanceXSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.LineInstance.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.LineInstance.XUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        setLineInstanceYSecondValue = true;
                        LineInstanceYSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.LineInstance.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.LineInstance.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        setThumbInstanceHeightSecondValue = true;
                        ThumbInstanceHeightSecondValue = 40f;
                        if (interpolationValue >= 1)
                        {
                            this.ThumbInstance.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "ContainerInstance") ?? this;
                        }
                        setThumbInstanceWidthSecondValue = true;
                        ThumbInstanceWidthSecondValue = 33f;
                        setThumbInstanceXSecondValue = true;
                        ThumbInstanceXSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.ThumbInstance.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                        }
                        setThumbInstanceYSecondValue = true;
                        ThumbInstanceYSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.ThumbInstance.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ThumbInstance.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        setWidthSecondValue = true;
                        WidthSecondValue = 484f;
                        break;
                }
                if (setContainerInstanceHeightFirstValue && setContainerInstanceHeightSecondValue)
                {
                    ContainerInstance.Height = ContainerInstanceHeightFirstValue * (1 - interpolationValue) + ContainerInstanceHeightSecondValue * interpolationValue;
                }
                if (setContainerInstanceWidthFirstValue && setContainerInstanceWidthSecondValue)
                {
                    ContainerInstance.Width = ContainerInstanceWidthFirstValue * (1 - interpolationValue) + ContainerInstanceWidthSecondValue * interpolationValue;
                }
                if (setContainerInstanceXFirstValue && setContainerInstanceXSecondValue)
                {
                    ContainerInstance.X = ContainerInstanceXFirstValue * (1 - interpolationValue) + ContainerInstanceXSecondValue * interpolationValue;
                }
                if (setContainerInstanceYFirstValue && setContainerInstanceYSecondValue)
                {
                    ContainerInstance.Y = ContainerInstanceYFirstValue * (1 - interpolationValue) + ContainerInstanceYSecondValue * interpolationValue;
                }
                if (setHeightFirstValue && setHeightSecondValue)
                {
                    Height = HeightFirstValue * (1 - interpolationValue) + HeightSecondValue * interpolationValue;
                }
                if (setLineInstanceHeightFirstValue && setLineInstanceHeightSecondValue)
                {
                    LineInstance.Height = LineInstanceHeightFirstValue * (1 - interpolationValue) + LineInstanceHeightSecondValue * interpolationValue;
                }
                if (setLineInstanceWidthFirstValue && setLineInstanceWidthSecondValue)
                {
                    LineInstance.Width = LineInstanceWidthFirstValue * (1 - interpolationValue) + LineInstanceWidthSecondValue * interpolationValue;
                }
                if (setLineInstanceXFirstValue && setLineInstanceXSecondValue)
                {
                    LineInstance.X = LineInstanceXFirstValue * (1 - interpolationValue) + LineInstanceXSecondValue * interpolationValue;
                }
                if (setLineInstanceYFirstValue && setLineInstanceYSecondValue)
                {
                    LineInstance.Y = LineInstanceYFirstValue * (1 - interpolationValue) + LineInstanceYSecondValue * interpolationValue;
                }
                if (setThumbInstanceHeightFirstValue && setThumbInstanceHeightSecondValue)
                {
                    ThumbInstance.Height = ThumbInstanceHeightFirstValue * (1 - interpolationValue) + ThumbInstanceHeightSecondValue * interpolationValue;
                }
                if (setThumbInstanceWidthFirstValue && setThumbInstanceWidthSecondValue)
                {
                    ThumbInstance.Width = ThumbInstanceWidthFirstValue * (1 - interpolationValue) + ThumbInstanceWidthSecondValue * interpolationValue;
                }
                if (setThumbInstanceXFirstValue && setThumbInstanceXSecondValue)
                {
                    ThumbInstance.X = ThumbInstanceXFirstValue * (1 - interpolationValue) + ThumbInstanceXSecondValue * interpolationValue;
                }
                if (setThumbInstanceYFirstValue && setThumbInstanceYSecondValue)
                {
                    ThumbInstance.Y = ThumbInstanceYFirstValue * (1 - interpolationValue) + ThumbInstanceYSecondValue * interpolationValue;
                }
                if (setWidthFirstValue && setWidthSecondValue)
                {
                    Width = WidthFirstValue * (1 - interpolationValue) + WidthSecondValue * interpolationValue;
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
            public void InterpolateBetween (SliderCategory firstState, SliderCategory secondState, float interpolationValue) 
            {
                #if DEBUG
                if (float.IsNaN(interpolationValue))
                {
                    throw new System.Exception("interpolationValue cannot be NaN");
                }
                #endif
                switch(firstState)
                {
                }
                switch(secondState)
                {
                }
                if (interpolationValue < 1)
                {
                    mCurrentSliderCategoryState = firstState;
                }
                else
                {
                    mCurrentSliderCategoryState = secondState;
                }
            }
            #endregion
            #region State Interpolate To
            public FlatRedBall.Glue.StateInterpolation.Tweener InterpolateTo (Pirates.GumRuntimes.DefaultForms.SliderRuntime.VariableState fromState,Pirates.GumRuntimes.DefaultForms.SliderRuntime.VariableState toState, double secondsToTake, FlatRedBall.Glue.StateInterpolation.InterpolationType interpolationType, FlatRedBall.Glue.StateInterpolation.Easing easing, object owner = null) 
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
            public FlatRedBall.Glue.StateInterpolation.Tweener InterpolateTo (Pirates.GumRuntimes.DefaultForms.SliderRuntime.SliderCategory fromState,Pirates.GumRuntimes.DefaultForms.SliderRuntime.SliderCategory toState, double secondsToTake, FlatRedBall.Glue.StateInterpolation.InterpolationType interpolationType, FlatRedBall.Glue.StateInterpolation.Easing easing, object owner = null) 
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
            public FlatRedBall.Glue.StateInterpolation.Tweener InterpolateTo (SliderCategory toState, double secondsToTake, FlatRedBall.Glue.StateInterpolation.InterpolationType interpolationType, FlatRedBall.Glue.StateInterpolation.Easing easing, object owner = null ) 
            {
                Gum.DataTypes.Variables.StateSave current = GetCurrentValuesOnState(toState);
                Gum.DataTypes.Variables.StateSave toAsStateSave = this.ElementSave.Categories.First(item => item.Name == "SliderCategory").States.First(item => item.Name == toState.ToString());
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
                tweener.Ended += ()=> this.CurrentSliderCategoryState = toState;
                tweener.Start();
                StateInterpolationPlugin.TweenerManager.Self.Add(tweener);
                return tweener;
            }
            public FlatRedBall.Glue.StateInterpolation.Tweener InterpolateToRelative (SliderCategory toState, double secondsToTake, FlatRedBall.Glue.StateInterpolation.InterpolationType interpolationType, FlatRedBall.Glue.StateInterpolation.Easing easing, object owner = null ) 
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
                tweener.Ended += ()=> this.CurrentSliderCategoryState = toState;
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
                LineInstance.StopAnimations();
                ThumbInstance.StopAnimations();
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
                            Name = "Width",
                            Type = "float",
                            Value = Width
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "LineInstance.Height",
                            Type = "float",
                            Value = LineInstance.Height
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "LineInstance.Height Units",
                            Type = "DimensionUnitType",
                            Value = LineInstance.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "LineInstance.Parent",
                            Type = "string",
                            Value = LineInstance.Parent
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "LineInstance.Width",
                            Type = "float",
                            Value = LineInstance.Width
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "LineInstance.Width Units",
                            Type = "DimensionUnitType",
                            Value = LineInstance.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "LineInstance.X",
                            Type = "float",
                            Value = LineInstance.X
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "LineInstance.X Origin",
                            Type = "HorizontalAlignment",
                            Value = LineInstance.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "LineInstance.X Units",
                            Type = "PositionUnitType",
                            Value = LineInstance.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "LineInstance.Y",
                            Type = "float",
                            Value = LineInstance.Y
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "LineInstance.Y Origin",
                            Type = "VerticalAlignment",
                            Value = LineInstance.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "LineInstance.Y Units",
                            Type = "PositionUnitType",
                            Value = LineInstance.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ThumbInstance.Height",
                            Type = "float",
                            Value = ThumbInstance.Height
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ThumbInstance.Parent",
                            Type = "string",
                            Value = ThumbInstance.Parent
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ThumbInstance.Width",
                            Type = "float",
                            Value = ThumbInstance.Width
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ThumbInstance.X",
                            Type = "float",
                            Value = ThumbInstance.X
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ThumbInstance.X Origin",
                            Type = "HorizontalAlignment",
                            Value = ThumbInstance.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ThumbInstance.Y",
                            Type = "float",
                            Value = ThumbInstance.Y
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ThumbInstance.Y Origin",
                            Type = "VerticalAlignment",
                            Value = ThumbInstance.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ThumbInstance.Y Units",
                            Type = "PositionUnitType",
                            Value = ThumbInstance.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerInstance.Height",
                            Type = "float",
                            Value = ContainerInstance.Height
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerInstance.Height Units",
                            Type = "DimensionUnitType",
                            Value = ContainerInstance.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerInstance.Width",
                            Type = "float",
                            Value = ContainerInstance.Width
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerInstance.Width Units",
                            Type = "DimensionUnitType",
                            Value = ContainerInstance.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerInstance.X",
                            Type = "float",
                            Value = ContainerInstance.X
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerInstance.X Origin",
                            Type = "HorizontalAlignment",
                            Value = ContainerInstance.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerInstance.X Units",
                            Type = "PositionUnitType",
                            Value = ContainerInstance.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerInstance.Y",
                            Type = "float",
                            Value = ContainerInstance.Y
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerInstance.Y Origin",
                            Type = "VerticalAlignment",
                            Value = ContainerInstance.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerInstance.Y Units",
                            Type = "PositionUnitType",
                            Value = ContainerInstance.YUnits
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
                            Value = Height + 48f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Width",
                            Type = "float",
                            Value = Width + 484f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "LineInstance.Height",
                            Type = "float",
                            Value = LineInstance.Height + 16f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "LineInstance.Height Units",
                            Type = "DimensionUnitType",
                            Value = LineInstance.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "LineInstance.Parent",
                            Type = "string",
                            Value = LineInstance.Parent
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "LineInstance.Width",
                            Type = "float",
                            Value = LineInstance.Width + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "LineInstance.Width Units",
                            Type = "DimensionUnitType",
                            Value = LineInstance.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "LineInstance.X",
                            Type = "float",
                            Value = LineInstance.X + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "LineInstance.X Origin",
                            Type = "HorizontalAlignment",
                            Value = LineInstance.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "LineInstance.X Units",
                            Type = "PositionUnitType",
                            Value = LineInstance.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "LineInstance.Y",
                            Type = "float",
                            Value = LineInstance.Y + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "LineInstance.Y Origin",
                            Type = "VerticalAlignment",
                            Value = LineInstance.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "LineInstance.Y Units",
                            Type = "PositionUnitType",
                            Value = LineInstance.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ThumbInstance.Height",
                            Type = "float",
                            Value = ThumbInstance.Height + 40f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ThumbInstance.Parent",
                            Type = "string",
                            Value = ThumbInstance.Parent
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ThumbInstance.Width",
                            Type = "float",
                            Value = ThumbInstance.Width + 33f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ThumbInstance.X",
                            Type = "float",
                            Value = ThumbInstance.X + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ThumbInstance.X Origin",
                            Type = "HorizontalAlignment",
                            Value = ThumbInstance.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ThumbInstance.Y",
                            Type = "float",
                            Value = ThumbInstance.Y + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ThumbInstance.Y Origin",
                            Type = "VerticalAlignment",
                            Value = ThumbInstance.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ThumbInstance.Y Units",
                            Type = "PositionUnitType",
                            Value = ThumbInstance.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerInstance.Height",
                            Type = "float",
                            Value = ContainerInstance.Height + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerInstance.Height Units",
                            Type = "DimensionUnitType",
                            Value = ContainerInstance.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerInstance.Width",
                            Type = "float",
                            Value = ContainerInstance.Width + -34f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerInstance.Width Units",
                            Type = "DimensionUnitType",
                            Value = ContainerInstance.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerInstance.X",
                            Type = "float",
                            Value = ContainerInstance.X + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerInstance.X Origin",
                            Type = "HorizontalAlignment",
                            Value = ContainerInstance.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerInstance.X Units",
                            Type = "PositionUnitType",
                            Value = ContainerInstance.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerInstance.Y",
                            Type = "float",
                            Value = ContainerInstance.Y + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerInstance.Y Origin",
                            Type = "VerticalAlignment",
                            Value = ContainerInstance.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ContainerInstance.Y Units",
                            Type = "PositionUnitType",
                            Value = ContainerInstance.YUnits
                        }
                        );
                        break;
                }
                return newState;
            }
            private Gum.DataTypes.Variables.StateSave GetCurrentValuesOnState (SliderCategory state) 
            {
                Gum.DataTypes.Variables.StateSave newState = new Gum.DataTypes.Variables.StateSave();
                switch(state)
                {
                }
                return newState;
            }
            private Gum.DataTypes.Variables.StateSave AddToCurrentValuesWithState (SliderCategory state) 
            {
                Gum.DataTypes.Variables.StateSave newState = new Gum.DataTypes.Variables.StateSave();
                switch(state)
                {
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
                    else if (category.Name == "SliderCategory")
                    {
                    }
                }
                base.ApplyState(state);
            }
            private bool tryCreateFormsObject;
            private Pirates.GumRuntimes.DefaultForms.ColoredFrameRuntime LineInstance { get; set; }
            private Pirates.GumRuntimes.DefaultForms.ScrollBarThumbRuntime ThumbInstance { get; set; }
            private Pirates.GumRuntimes.ContainerRuntime ContainerInstance { get; set; }
            public event FlatRedBall.Gui.WindowEvent ThumbInstanceClick;
            public event FlatRedBall.Gui.WindowEvent ContainerInstanceClick;
            public SliderRuntime (bool fullInstantiation = true, bool tryCreateFormsObject = true) 
            	: base(false, tryCreateFormsObject)
            {
                this.tryCreateFormsObject = tryCreateFormsObject;
                this.HasEvents = true;
                if (fullInstantiation)
                {
                    Gum.DataTypes.ElementSave elementSave = Gum.Managers.ObjectFinder.Self.GumProjectSave.Components.First(item => item.Name == "DefaultForms/Slider");
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
                LineInstance = this.GetGraphicalUiElementByName("LineInstance") as Pirates.GumRuntimes.DefaultForms.ColoredFrameRuntime;
                ThumbInstance = this.GetGraphicalUiElementByName("ThumbInstance") as Pirates.GumRuntimes.DefaultForms.ScrollBarThumbRuntime;
                ContainerInstance = this.GetGraphicalUiElementByName("ContainerInstance") as Pirates.GumRuntimes.ContainerRuntime;
                ThumbInstance.Click += (unused) => ThumbInstanceClick?.Invoke(this);
                ContainerInstance.Click += (unused) => ContainerInstanceClick?.Invoke(this);
                if (tryCreateFormsObject)
                {
                    FormsControl = new FlatRedBall.Forms.Controls.Slider(this);
                }
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
            public FlatRedBall.Forms.Controls.Slider FormsControl {get; private set;}
            public override object FormsControlAsObject { get { return FormsControl; } }
        }
    }
