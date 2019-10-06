using RenderingLibrary.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
    
namespace Pirates.GumRuntimes.InventoryForms
{
    public partial class InventoryBarRuntime
    {
        private InventoryBoxRuntime SelectedBox;

        partial void CustomInitialize() 
        {

        }

        public void SetSelectedItemCase(int ItemIndex)
        {
            foreach (InventoryBoxRuntime InventoryBox in ContainerItems.Children)
            {
                InventoryBox.CurrentVariableState = InventoryBoxRuntime.VariableState.Default;
            }

            SelectedBox = ContainerItems.Children[ItemIndex] as InventoryBoxRuntime;
            SelectedBox.CurrentVariableState = InventoryBoxRuntime.VariableState.Selected;
        }


        public void SetSelectedItemCase(InventoryBoxRuntime ClickedBox)
        {
            foreach (InventoryBoxRuntime InventoryBox in ContainerItems.Children)
            {
                InventoryBox.CurrentVariableState = InventoryBoxRuntime.VariableState.Default;
            }

            ClickedBox.CurrentVariableState = InventoryBoxRuntime.VariableState.Selected;
        }

        public Custom.Item GetSelectedItem()
        {
            return SelectedBox.GetContainedItem();
        }

        public void SetContainedItem(Custom.Item item, int Index)
        {
            (ContainerItems.Children[Index] as InventoryBoxRuntime).SetContainedItem(item);
        }

        public List<InventoryBoxRuntime> GetInventoryBoxList()
        {
            List<InventoryBoxRuntime> retour = new List<InventoryBoxRuntime>();
            foreach (var child in this.ContainerItems.Children)
            {
                if (child.GetType() == typeof(InventoryBoxRuntime))
                    retour.Add((InventoryBoxRuntime)child);
            }
            return retour;
        }

        public Custom.Item[] GetAllItems()
        {
            Custom.Item[] retour = new Custom.Item[4];
            int i = 0;

            foreach (var child in this.ContainerItems.Children)
            {
                if (child.GetType() == typeof(InventoryBoxRuntime))
                {
                    retour[i] = ((InventoryBoxRuntime)child).GetContainedItem();
                    i++;
                }
            }
            return retour;
        }

        public void SetAllItems(Custom.Item[] items)
        {
            int i = 0;
            foreach (var child in this.ContainerItems.Children)
            {
                if (child.GetType() == typeof(InventoryBoxRuntime))
                {
                    ((InventoryBoxRuntime)child).SetContainedItem(items[i]);
                    i++;
                }
            }
        }

        public void SetVisibility(bool Visible)
        {
            this.Visible = Visible;
        }

    }
}
