    namespace Pirates.GumRuntimes
    {
        #region State Enums
        public enum ComboBoxBehaviorComboBoxCategory
        {
            Enabled,
            Disabled,
            Highlighted,
            Pushed
        }
        #endregion
        public interface IComboBoxBehavior
        {
            ComboBoxBehaviorComboBoxCategory CurrentComboBoxBehaviorComboBoxCategoryState {set;}
        }
    }
