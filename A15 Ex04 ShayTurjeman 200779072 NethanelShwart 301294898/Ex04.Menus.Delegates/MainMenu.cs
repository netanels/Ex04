using System.Collections.Generic;

namespace Ex04.Menus.Delegates
{
    public class MainMenu
    {
        private const string k_MainManueName = "Main menu";
        private readonly List<MenuItem> r_MenuItems;

        public MainMenu()
        {
            r_MenuItems = new List<MenuItem>();
            r_MenuItems.Add(new MenuItem(MenuLogic.eSpecialMenuItemsValues.Exit.ToString()));
        }

        public void Show()
        {
            MenuLogic.SubItemsSelectedLogic(k_MainManueName, r_MenuItems);
        }

        public MenuItem AddItem(string i_MenuItemName)
        {
            MenuItem newMenuItem = new MenuItem(i_MenuItemName);
            r_MenuItems.Add(newMenuItem);
            return newMenuItem;
        }
    }
}