using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;


namespace Pirates.GumRuntimes.InventoryForms
{
    public partial class InventoryGuiRuntime
    {
        private Custom.Item ItemHeldByMouse;

        public EventHandler<ItemMovedCaseEventArgs> OnItemMovedCase;
        public ItemMovedCaseEventArgs OnItemMovedCaseEventArgs;

        partial void CustomInitialize()
        {
            OnItemMovedCaseEventArgs = new ItemMovedCaseEventArgs();
            SetVisibility(false);
        }

        public void PlaceCasesInInventoryPanel(int NbOfCases, int NbOfCols)
        {
            var container = this.GetGraphicalUiElementByName("ContainerItems") as ContainerRuntime;

            for (int i = 0; i < NbOfCases; i++)
            {
                var box = new InventoryBoxRuntime();
                //box.Width = (float)(container.GetAbsoluteWidth() / NbOfCols);
                box.Name = box.GetType().ToString() + i.ToString();
                box.BoxIndex = i;
                container.Children.Add(box);
            }

            AffectEvents();
        }


        public void PlaceCasesInInventoryPanel(int NbOfCases, int NbOfCols, int NbOfRows)
        {
            var container = this.GetGraphicalUiElementByName("ContainerItems") as ContainerRuntime;

            for (int i = 0; i < NbOfCases; i++)
            {
                var box = new InventoryBoxRuntime();
                box.Name = box.GetType().ToString() + i.ToString();

                box.BoxIndex = i;

                container.Children.Add(box);
            }

            AffectEvents();
        }


        private void AffectEvents()
        {
            foreach (InventoryBoxRuntime c in ContainerItems.Children.Where(x => x.GetType() == typeof(InventoryBoxRuntime)))
            {
                c.Click += InventoryBoxOnClick;
            }

            foreach (InventoryBoxRuntime t in InventoryBar.GetInventoryBoxList())
            {
                t.Click += IntenvoryBarBoxOnClick;
                t.Click += (x) => {Console.WriteLine("DEBUG : " + "(inventoryguiruntime.cs 67)"); };
            }
        }

        #region Events Methods

        /// <summary>
        /// Event for inventory boxes. 
        /// </summary>
        /// <param name="o">The clicked Box</param>
        /// <param name="IsBarBox">If so, event won't be fired</param>
        private void InventoryBoxOnClick(object o)
        {
            Custom.Item ItemOfBox = ((InventoryBoxRuntime)o).GetContainedItem();

            if (ItemHeldByMouse != null)
            {
                //On affecte le paramètre de l'event pour contenir la box sur laquelle on clique, qui est la nouvelle box de l'item.
                OnItemMovedCaseEventArgs.NewBox = (InventoryBoxRuntime)o;

                //Si la souris tient un item
                if (ItemOfBox != null)
                {
                    //Si la box n'est pas vide
                    using (Custom.Item ItemToSwitch = Custom.Item.CloneItem(ItemHeldByMouse))
                    {
                        //On change l'item graphique de l'écran pour switch
                        ItemHeldByMouse = Custom.Item.CloneItem(ItemOfBox);
                        HeldItemSprite.Texture = ItemHeldByMouse.GetTextureFromStream();

                        //On met l'item sauvegardé dans la box, après avoir mis l'autre dans la souris
                        ((InventoryBoxRuntime)o).SetContainedItem(ItemToSwitch);

                        //Et on affecte l'item qui a été déposé à l'évènement "Lorsqu'un item est bougé"
                        OnItemMovedCaseEventArgs.Item = ItemToSwitch;

                        //On raise l'event avec les informations (PreviousBox, NewBox) du premier item
                        if (OnItemMovedCase != null)
                        {
                            OnItemMovedCase.Invoke(this, OnItemMovedCaseEventArgs);
                        }
                        //Puis on affecte à PreviousBox la Box actuelle, en prévision de l'event du deuxième item
                        OnItemMovedCaseEventArgs.PreviousBox = (InventoryBoxRuntime)o;
                    }
                }
                //Si la box est vide
                else
                {
                    //On met l'item dedans
                    ((InventoryBoxRuntime)o).SetContainedItem(ItemHeldByMouse);

                    //On affecte les valeurs pour l'evenement "Lorsqu'un item est bougé"                
                    OnItemMovedCaseEventArgs.Item = ItemHeldByMouse;

                    //On efface l'item graphique de l'interface
                    ItemHeldByMouse = null;
                    HeldItemSprite.Texture = null;

                    if (OnItemMovedCase != null)
                    {
                        OnItemMovedCase.Invoke(this, OnItemMovedCaseEventArgs);
                    }
                }
            }
            //Si la souris ne tient PAS un item
            else
            {
                //Si la box n'est pas vide
                if(ItemOfBox != null)
                {
                    //On Prend l'item
                    ItemHeldByMouse = ItemOfBox;
                    HeldItemSprite.Texture = ItemHeldByMouse.GetTextureFromStream();


                    ((InventoryBoxRuntime)o).SetContainedItem(null);

                    OnItemMovedCaseEventArgs.PreviousBox = (InventoryBoxRuntime)o;
                }
            }            
        }


        private void IntenvoryBarBoxOnClick(object o)
        {
            if (ItemHeldByMouse != null)
            {
                ((InventoryBoxRuntime)o).SetContainedItem(ItemHeldByMouse);
            }
        }

        #endregion

        public void RefreshHeldItem()
        {
            HeldItemSprite.X = FlatRedBall.Input.InputManager.Mouse.X;
            HeldItemSprite.Y = FlatRedBall.Input.InputManager.Mouse.Y;
        }


        public void DisplayItemsOnUI(Custom.Item[] Items)
        {
            //Place les items de l'inventaire dans les cases de l'UI, rafraichissant le précédent affichage.

            //Récupère les enfants du container qui contient les InventoryBox afin de les parcourir et les remplir
            var InventoryBoxList = ContainerItems.Children.Where(x => x.GetType() == typeof(InventoryBoxRuntime)).ToList();

            for (int i = 0; i < Items.Length; i++)
            {
                (InventoryBoxList[i] as InventoryBoxRuntime).SetContainedItem(Items[i]);
            }
        }

        private void ResetHeldItem()
        {
            ItemHeldByMouse = null;
            HeldItemSprite.Texture = null;
        }

        #region Getters - Setters

        public void SetVisibility(bool Visible)
        {
            this.Visible = Visible;
            this.InventoryBar.Visible = Visible;
            if (!Visible)
                ResetHeldItem();
        }

        public bool GetVisibility()
        {
            return this.Visible;
        }

        public Custom.Item GetHeldItem()
        {
            return ItemHeldByMouse;
        }


        public InventoryBarRuntime GetInventoryBar()
        {
            return InventoryBar;
        }
        #endregion
    }

    public class ItemMovedCaseEventArgs : EventArgs
    {
        public InventoryBoxRuntime PreviousBox;
        public InventoryBoxRuntime NewBox;
        public Custom.Item Item;
    }
}
