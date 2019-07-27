    namespace Pirates.GumRuntimes
    {
        #region State Enums
        public enum ButtonBehaviorButtonCategory
        {
            Enabled,
            Disabled,
            Highlighted,
            Pushed
        }
        #endregion
        public interface IButtonBehavior
        {
            ButtonBehaviorButtonCategory CurrentButtonBehaviorButtonCategoryState {set;}
        }
    }
