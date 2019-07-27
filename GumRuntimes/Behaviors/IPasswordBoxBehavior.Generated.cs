    namespace Pirates.GumRuntimes
    {
        #region State Enums
        public enum PasswordBoxBehaviorPasswordBoxCategory
        {
            Enabled,
            Disabled,
            Highlighted,
            Selected
        }
        #endregion
        public interface IPasswordBoxBehavior
        {
            PasswordBoxBehaviorPasswordBoxCategory CurrentPasswordBoxBehaviorPasswordBoxCategoryState {set;}
        }
    }
