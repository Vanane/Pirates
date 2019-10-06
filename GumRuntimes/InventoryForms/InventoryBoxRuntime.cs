using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using FlatRedBall;
using FlatRedBall.Gui;
    
namespace Pirates.GumRuntimes.InventoryForms
{
    public partial class InventoryBoxRuntime
    {
        private Custom.Item ContainedItem;

        public int BoxIndex;

        partial void CustomInitialize() 
        {

        }

        public void SetContainedItem(Custom.Item item)
        {
            if (item == null)
            {
                ContainedItem = null;
                ItemSprite.Visible = false;
                return;
            }

            ContainedItem = item;
            ItemSprite.Texture = item.GetTextureFromStream();
            ItemSprite.Visible = true;
        }


        public Custom.Item GetContainedItem()
        {
            return ContainedItem != null ? ContainedItem : null;
        }

        public void SetSpriteClickEvent(WindowEvent WEvent)
        {
            this.ItemSprite.Click += WEvent;
        }

    }
}
