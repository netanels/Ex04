using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{
    public class MainMenu
    {
        private const string k_MainManueName = "Main menu";
        private readonly IMenuActivation r_MenuActivation;
        private readonly List<MenuItem> r_MenuItems;

        public MainMenu(IMenuActivation i_MenuActivation)
        {
            r_MenuItems = new List<MenuItem>();
            r_MenuActivation = i_MenuActivation;
            r_MenuItems.Add(new MenuItem(MenuLogic.eSpecialMenuItemsValues.Exit.ToString(), r_MenuActivation));
        }

        public void Show()
        {
            MenuLogic.SubItemsSelectedLogic(k_MainManueName, r_MenuItems);
        }

        public MenuItem AddItem(string i_MenuItemName)
        {
            MenuItem newMenuItem = new MenuItem(i_MenuItemName, r_MenuActivation);
            r_MenuItems.Add(newMenuItem);
            return newMenuItem;
        }
    }
}