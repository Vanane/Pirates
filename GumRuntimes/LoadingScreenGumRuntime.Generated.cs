    using System.Linq;
    namespace Pirates.GumRuntimes
    {
        public partial class LoadingScreenGumRuntime : Gum.Wireframe.GraphicalUiElement
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
                            LoadingText.Font = "Chiller";
                            LoadingText.FontSize = 48;
                            LoadingText.HorizontalAlignment = RenderingLibrary.Graphics.HorizontalAlignment.Right;
                            LoadingText.Text = "Loading...";
                            LoadingText.VerticalAlignment = RenderingLibrary.Graphics.VerticalAlignment.Bottom;
                            LoadingText.X = 0f;
                            LoadingText.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Right;
                            LoadingText.XUnits = Gum.Converters.GeneralUnitType.PixelsFromLarge;
                            LoadingText.Y = 0f;
                            LoadingText.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Bottom;
                            LoadingText.YUnits = Gum.Converters.GeneralUnitType.PixelsFromLarge;
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
                bool setLoadingTextFontSizeFirstValue = false;
                bool setLoadingTextFontSizeSecondValue = false;
                int LoadingTextFontSizeFirstValue= 0;
                int LoadingTextFontSizeSecondValue= 0;
                bool setLoadingTextXFirstValue = false;
                bool setLoadingTextXSecondValue = false;
                float LoadingTextXFirstValue= 0;
                float LoadingTextXSecondValue= 0;
                bool setLoadingTextYFirstValue = false;
                bool setLoadingTextYSecondValue = false;
                float LoadingTextYFirstValue= 0;
                float LoadingTextYSecondValue= 0;
                switch(firstState)
                {
                    case  VariableState.Default:
                        if (interpolationValue < 1)
                        {
                            this.LoadingText.Font = "Chiller";
                        }
                        setLoadingTextFontSizeFirstValue = true;
                        LoadingTextFontSizeFirstValue = 48;
                        if (interpolationValue < 1)
                        {
                            this.LoadingText.HorizontalAlignment = RenderingLibrary.Graphics.HorizontalAlignment.Right;
                        }
                        if (interpolationValue < 1)
                        {
                            this.LoadingText.Text = "Loading...";
                        }
                        if (interpolationValue < 1)
                        {
                            this.LoadingText.VerticalAlignment = RenderingLibrary.Graphics.VerticalAlignment.Bottom;
                        }
                        setLoadingTextXFirstValue = true;
                        LoadingTextXFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.LoadingText.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Right;
                        }
                        if (interpolationValue < 1)
                        {
                            this.LoadingText.XUnits = Gum.Converters.GeneralUnitType.PixelsFromLarge;
                        }
                        setLoadingTextYFirstValue = true;
                        LoadingTextYFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.LoadingText.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Bottom;
                        }
                        if (interpolationValue < 1)
                        {
                            this.LoadingText.YUnits = Gum.Converters.GeneralUnitType.PixelsFromLarge;
                        }
                        break;
                }
                switch(secondState)
                {
                    case  VariableState.Default:
                        if (interpolationValue >= 1)
                        {
                            this.LoadingText.Font = "Chiller";
                        }
                        setLoadingTextFontSizeSecondValue = true;
                        LoadingTextFontSizeSecondValue = 48;
                        if (interpolationValue >= 1)
                        {
                            this.LoadingText.HorizontalAlignment = RenderingLibrary.Graphics.HorizontalAlignment.Right;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.LoadingText.Text = "Loading...";
                        }
                        if (interpolationValue >= 1)
                        {
                            this.LoadingText.VerticalAlignment = RenderingLibrary.Graphics.VerticalAlignment.Bottom;
                        }
                        setLoadingTextXSecondValue = true;
                        LoadingTextXSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.LoadingText.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Right;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.LoadingText.XUnits = Gum.Converters.GeneralUnitType.PixelsFromLarge;
                        }
                        setLoadingTextYSecondValue = true;
                        LoadingTextYSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.LoadingText.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Bottom;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.LoadingText.YUnits = Gum.Converters.GeneralUnitType.PixelsFromLarge;
                        }
                        break;
                }
                if (setLoadingTextFontSizeFirstValue && setLoadingTextFontSizeSecondValue)
                {
                    LoadingText.FontSize = FlatRedBall.Math.MathFunctions.RoundToInt(LoadingTextFontSizeFirstValue* (1 - interpolationValue) + LoadingTextFontSizeSecondValue * interpolationValue);
                }
                if (setLoadingTextXFirstValue && setLoadingTextXSecondValue)
                {
                    LoadingText.X = LoadingTextXFirstValue * (1 - interpolationValue) + LoadingTextXSecondValue * interpolationValue;
                }
                if (setLoadingTextYFirstValue && setLoadingTextYSecondValue)
                {
                    LoadingText.Y = LoadingTextYFirstValue * (1 - interpolationValue) + LoadingTextYSecondValue * interpolationValue;
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
            public FlatRedBall.Glue.StateInterpolation.Tweener InterpolateTo (Pirates.GumRuntimes.LoadingScreenGumRuntime.VariableState fromState,Pirates.GumRuntimes.LoadingScreenGumRuntime.VariableState toState, double secondsToTake, FlatRedBall.Glue.StateInterpolation.InterpolationType interpolationType, FlatRedBall.Glue.StateInterpolation.Easing easing, object owner = null) 
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
                            Name = "LoadingText.Font",
                            Type = "string",
                            Value = LoadingText.Font
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "LoadingText.FontSize",
                            Type = "int",
                            Value = LoadingText.FontSize
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "LoadingText.HorizontalAlignment",
                            Type = "HorizontalAlignment",
                            Value = LoadingText.HorizontalAlignment
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "LoadingText.Text",
                            Type = "string",
                            Value = LoadingText.Text
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "LoadingText.VerticalAlignment",
                            Type = "VerticalAlignment",
                            Value = LoadingText.VerticalAlignment
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "LoadingText.X",
                            Type = "float",
                            Value = LoadingText.X
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "LoadingText.X Origin",
                            Type = "HorizontalAlignment",
                            Value = LoadingText.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "LoadingText.X Units",
                            Type = "PositionUnitType",
                            Value = LoadingText.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "LoadingText.Y",
                            Type = "float",
                            Value = LoadingText.Y
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "LoadingText.Y Origin",
                            Type = "VerticalAlignment",
                            Value = LoadingText.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "LoadingText.Y Units",
                            Type = "PositionUnitType",
                            Value = LoadingText.YUnits
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
                            Name = "LoadingText.Font",
                            Type = "string",
                            Value = LoadingText.Font
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "LoadingText.FontSize",
                            Type = "int",
                            Value = LoadingText.FontSize + 48
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "LoadingText.HorizontalAlignment",
                            Type = "HorizontalAlignment",
                            Value = LoadingText.HorizontalAlignment
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "LoadingText.Text",
                            Type = "string",
                            Value = LoadingText.Text
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "LoadingText.VerticalAlignment",
                            Type = "VerticalAlignment",
                            Value = LoadingText.VerticalAlignment
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "LoadingText.X",
                            Type = "float",
                            Value = LoadingText.X + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "LoadingText.X Origin",
                            Type = "HorizontalAlignment",
                            Value = LoadingText.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "LoadingText.X Units",
                            Type = "PositionUnitType",
                            Value = LoadingText.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "LoadingText.Y",
                            Type = "float",
                            Value = LoadingText.Y + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "LoadingText.Y Origin",
                            Type = "VerticalAlignment",
                            Value = LoadingText.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "LoadingText.Y Units",
                            Type = "PositionUnitType",
                            Value = LoadingText.YUnits
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
            public Pirates.GumRuntimes.TextRuntime LoadingText { get; set; }
            public LoadingScreenGumRuntime (bool fullInstantiation = true, bool tryCreateFormsObject = true) 
            {
                if (fullInstantiation)
                {
                    Gum.DataTypes.ElementSave elementSave = Gum.Managers.ObjectFinder.Self.GumProjectSave.Screens.First(item => item.Name == "LoadingScreenGum");
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
                LoadingText = this.GetGraphicalUiElementByName("LoadingText") as Pirates.GumRuntimes.TextRuntime;
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
