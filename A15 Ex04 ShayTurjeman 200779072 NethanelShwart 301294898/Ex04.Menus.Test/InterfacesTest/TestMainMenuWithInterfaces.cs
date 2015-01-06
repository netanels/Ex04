using System;
using System.Collections.Generic;
using Ex04.Menus.Interfaces;
using InterfacesMainMenu = Ex04.Menus.Interfaces.MainMenu;
using InterfacesMenuItem = Ex04.Menus.Interfaces.MenuItem;

namespace Ex04.Menus.Test.InterfacesTest
{
    public class TestMainMenuWithInterfaces : IMenuActivation, IMainMenuApplication
    {
        private readonly Dictionary<string, eApplicationAction> r_ApplicationActionsDictionary =
            new Dictionary<string, eApplicationAction>();

        private readonly InterfacesMainMenu r_MainMenu;

        public TestMainMenuWithInterfaces()
        {
            r_MainMenu = new InterfacesMainMenu(this);

            createWordCounterMenuItem();
            createShowDateTimeMenuItem();
            createShowVersionMenuItem();

            Console.Clear();
            Helpers.ShowMainMenu(this);
        }

        public string MainMenuApplicationType
        {
            get { return "interfaces"; }
        }

        public void Show()
        {
            r_MainMenu.Show();
        }

        void IMenuActivation.MenuItemSelected(string i_SelectedItem)
        {
            eApplicationAction selectedAction = r_ApplicationActionsDictionary[i_SelectedItem];

            switch (selectedAction)
            {
                case eApplicationAction.WordCounter:
                    Helpers.WordCounter();
                    break;
                case eApplicationAction.ShowDate:
                    Helpers.ShowDate();
                    break;
                case eApplicationAction.ShowTime:
                    Helpers.ShowTime();
                    break;
                case eApplicationAction.ShowVersion:
                    Helpers.ShowVersion();
                    break;
            }
        }

        private void createWordCounterMenuItem()
        {
            InterfacesMenuItem wordCounterMenuItem = r_MainMenu.AddItem(Helpers.k_WordCounter);

            r_ApplicationActionsDictionary.Add(Helpers.k_WordCounter, eApplicationAction.WordCounter);
        }

        private void createShowDateTimeMenuItem()
        {
            InterfacesMenuItem showDateTimeMenuItem = r_MainMenu.AddItem(Helpers.k_ShowDateTime);

            createShowDateMenuItem(showDateTimeMenuItem);
            createShowTimeMenuItem(showDateTimeMenuItem);
        }

        private void createShowDateMenuItem(InterfacesMenuItem i_ShowDateTimeMenuItem)
        {
            InterfacesMenuItem showDateMenuItem = i_ShowDateTimeMenuItem.AddItem(Helpers.k_ShowDate);

            r_ApplicationActionsDictionary.Add(Helpers.k_ShowDate, eApplicationAction.ShowDate);
        }

        private void createShowTimeMenuItem(InterfacesMenuItem i_ShowDateTimeMenuItem)
        {
            InterfacesMenuItem showTimeMenuItem = i_ShowDateTimeMenuItem.AddItem(Helpers.k_ShowTime);

            r_ApplicationActionsDictionary.Add(Helpers.k_ShowTime, eApplicationAction.ShowTime);
        }

        private void createShowVersionMenuItem()
        {
            InterfacesMenuItem showVersionMenuItem = r_MainMenu.AddItem(Helpers.k_ShowVersion);

            r_ApplicationActionsDictionary.Add(Helpers.k_ShowVersion, eApplicationAction.ShowVersion);
        }

        private enum eApplicationAction
        {
            WordCounter,
            ShowDate,
            ShowTime,
            ShowVersion
        }
    }
}