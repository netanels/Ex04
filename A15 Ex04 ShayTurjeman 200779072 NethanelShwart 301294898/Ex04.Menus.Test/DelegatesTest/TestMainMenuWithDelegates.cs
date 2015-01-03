using System;
using DelegatesMainMenu = Ex04.Menus.Delegates.MainMenu;
using DelegatesMenuItem = Ex04.Menus.Delegates.MenuItem;

namespace Ex04.Menus.Test.DelegatesTest
{
    public class TestMainMenuWithDelegates : IMainMenuApplication
    {
        private readonly DelegatesMainMenu r_MainMenu;

        public string MainMenuApplicationType { get { return "delegates"; } }

        public void Show()
        {
            r_MainMenu.Show();
        }

        public TestMainMenuWithDelegates()
        {
            r_MainMenu = new DelegatesMainMenu();

            DelegatesMenuItem wordCounterMenuItem = r_MainMenu.AddItem(Helpers.k_WordCounter);
            wordCounterMenuItem.Selected += wordCounterMenuItem_Selected;

            DelegatesMenuItem showDateTimeMenuItem = r_MainMenu.AddItem(Helpers.k_ShowDateTime);

            DelegatesMenuItem showDateMenuItem = showDateTimeMenuItem.AddItem(Helpers.k_ShowDate);
            showDateMenuItem.Selected += showDateMenuItem_Selected;

            DelegatesMenuItem showTimeMenuItem = showDateTimeMenuItem.AddItem(Helpers.k_ShowTime);
            showTimeMenuItem.Selected += showTimeMenuItem_Selected;

            DelegatesMenuItem showVersionMenuItem = r_MainMenu.AddItem(Helpers.k_ShowVersion);
            showVersionMenuItem.Selected += showVersionMenuItem_Selected;

            Console.Clear();
            Helpers.ShowMainMenu(this);
        }

        private void wordCounterMenuItem_Selected()
        {
            Helpers.WordCounter();
            Helpers.ShowMainMenu(this);
        }

        private void showDateMenuItem_Selected()
        {
            Helpers.ShowDate();
            Helpers.ShowMainMenu(this);
        }

        private void showTimeMenuItem_Selected()
        {
            Helpers.ShowTime();
            Helpers.ShowMainMenu(this);
        }

        private void showVersionMenuItem_Selected()
        {
            Helpers.ShowVersion();
            Helpers.ShowMainMenu(this);
        }

    }
}