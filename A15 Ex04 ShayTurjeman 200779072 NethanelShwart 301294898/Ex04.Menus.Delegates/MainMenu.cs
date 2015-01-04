using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public class MainMenu
    {
        private const string k_MainManueName = "Main menu";
        private readonly List<MenuItem> r_MenuItems;

        public MainMenu()
        {
            r_MenuItems = new List<MenuItem>();
            r_MenuItems.Add(new MenuItem(MenuLogic.eSpecialValues.Exit.ToString()));
        }

        public void Show()
        {
            MenuLogic.menuItem_SubItemSelected(k_MainManueName, r_MenuItems);
        }

        public MenuItem AddItem(string i_MenuItemName)
        {
            MenuItem menuItem = new MenuItem(i_MenuItemName);
            r_MenuItems.Add(menuItem);
            menuItem.BackSelected += newMenuItem_BackSelected;
            menuItem.SubItemSelected += MenuLogic.menuItem_SubItemSelected;
            return menuItem;
        }

        private void newMenuItem_BackSelected()
        {
            MenuLogic.menuItem_SubItemSelected(k_MainManueName, r_MenuItems);
        }
    }
}
