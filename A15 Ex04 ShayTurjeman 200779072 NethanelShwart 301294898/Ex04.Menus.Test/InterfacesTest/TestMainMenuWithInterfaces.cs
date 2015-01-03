using System;
using System.Collections.Generic;
using InterfacesMainMenu = Ex04.Menus.Interfaces.MainMenu;
using InterfacesMenuItem = Ex04.Menus.Interfaces.MenuItem;
using Ex04.Menus.Interfaces.Interfaces;

namespace Ex04.Menus.Test.InterfacesTest
{
    public class TestMainMenuWithInterfaces : IMenuActivation, IMainMenuApplication
    {
        private readonly InterfacesMainMenu r_MainMenu;

        private readonly Dictionary<string, eApplicationAction> r_ApplicationActionsDictionary =
            new Dictionary<string, eApplicationAction>();


        public string MainMenuApplicationType { get { return "interfaces"; } }

        public void Show()
        {
            r_MainMenu.Show();
        }

        public TestMainMenuWithInterfaces()
        {
            r_MainMenu = new InterfacesMainMenu(this);

            InterfacesMenuItem wordCounterMenuItem = r_MainMenu.AddItem(Helpers.k_WordCounter);
            r_ApplicationActionsDictionary.Add(Helpers.k_WordCounter, eApplicationAction.WordCounter);

            InterfacesMenuItem showDateTimeMenuItem = r_MainMenu.AddItem(Helpers.k_ShowDateTime);

            InterfacesMenuItem showDateMenuItem = showDateTimeMenuItem.AddItem(Helpers.k_ShowDate);
            r_ApplicationActionsDictionary.Add(Helpers.k_ShowDate, eApplicationAction.ShowDate);


            InterfacesMenuItem showTimeMenuItem = showDateTimeMenuItem.AddItem(Helpers.k_ShowTime);
            r_ApplicationActionsDictionary.Add(Helpers.k_ShowTime, eApplicationAction.ShowTime);

            InterfacesMenuItem showVersionMenuItem = r_MainMenu.AddItem(Helpers.k_ShowVersion);
            r_ApplicationActionsDictionary.Add(Helpers.k_ShowVersion, eApplicationAction.ShowVersion);

            Console.Clear();
            Helpers.ShowMainMenu(this);
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

            Helpers.ShowMainMenu(this);
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