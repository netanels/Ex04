using System;
using System.Collections.Generic;
using System.Text;
using Ex04.Menus.Interfaces.Interfaces;

namespace Ex04.Menus.Interfaces
{
    public class MainMenu : IMenuItem
    {
        private const string k_MainManueName = "Main menu";
        private readonly List<IMenuItem> r_MenuItems;
        private readonly IMenuActivation r_MenuActivation;

        string IMenuItem.Name
        {
            get { return k_MainManueName; }
        }

        IMenuItem IMenuItem.FatherMenuItem
        {
            get { return null; }
        }

        List<IMenuItem> IMenuItem.SubItems
        {
            get { return r_MenuItems; }
        }

        public MainMenu(IMenuActivation i_MenuActivation)
        {
            r_MenuItems = new List<IMenuItem>();
            r_MenuActivation = i_MenuActivation;
            r_MenuItems.Add(new MenuItem(MenuLogic.eSpecialValues.Exit.ToString(), r_MenuActivation, this));
        }

        public void Show()
        {
            MenuLogic.SelectItemsLogic(this);
        }

        public MenuItem AddItem(string i_MenuItemName)
        {
            MenuItem newMenuItem = new MenuItem(i_MenuItemName, r_MenuActivation, this);
            r_MenuItems.Add(newMenuItem);
            return newMenuItem;
        }
        

    }
}
