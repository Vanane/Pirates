    namespace Pirates.GumRuntimes
    {
        #region State Enums
        public enum ListBoxItemBehaviorListBoxItemCategory
        {
            Enabled,
            Highlighted,
            Selected
        }
        #endregion
        public interface IListBoxItemBehavior
        {
            ListBoxItemBehaviorListBoxItemCategory CurrentListBoxItemBehaviorListBoxItemCategoryState {set;}
        }
    }
