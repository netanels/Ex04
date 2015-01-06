using System;
using DelegatesMainMenu = Ex04.Menus.Delegates.MainMenu;
using DelegatesMenuItem = Ex04.Menus.Delegates.MenuItem;

namespace Ex04.Menus.Test.DelegatesTest
{
    public class TestMainMenuWithDelegates : IMainMenuApplication
    {
        private readonly DelegatesMainMenu r_MainMenu;

        public TestMainMenuWithDelegates()
        {
            r_MainMenu = new DelegatesMainMenu();
            createMenu();
            Helpers.ShowMainMenu(this);
        }

        public string MainMenuApplicationType
        {
            get { return "delegates"; }
        }

        public void Show()
        {
            r_MainMenu.Show();
        }

        private void createMenu()
        {
            createWordCounterMenuItem();
            createShowDateTimeMenuItem();
            createShowVersionMenuItem();
        }

        private void createWordCounterMenuItem()
        {
            DelegatesMenuItem wordCounterMenuItem = r_MainMenu.AddItem(Helpers.k_WordCounter);

            wordCounterMenuItem.Selected += wordCounterMenuItem_Selected;
        }

        private void createShowDateTimeMenuItem()
        {
            DelegatesMenuItem showDateTimeMenuItem = r_MainMenu.AddItem(Helpers.k_ShowDateTime);

            createShowDateMenuItem(showDateTimeMenuItem);
            createShowTimeMenuItem(showDateTimeMenuItem);
        }

        private void createShowDateMenuItem(DelegatesMenuItem i_ShowDateTimeMenuItem)
        {
            DelegatesMenuItem showDateMenuItem = i_ShowDateTimeMenuItem.AddItem(Helpers.k_ShowDate);

            showDateMenuItem.Selected += showDateMenuItem_Selected;
        }

        private void createShowTimeMenuItem(DelegatesMenuItem i_ShowDateTimeMenuItem)
        {
            DelegatesMenuItem showTimeMenuItem = i_ShowDateTimeMenuItem.AddItem(Helpers.k_ShowTime);

            showTimeMenuItem.Selected += showTimeMenuItem_Selected;
        }

        private void createShowVersionMenuItem()
        {
            DelegatesMenuItem showVersionMenuItem = r_MainMenu.AddItem(Helpers.k_ShowVersion);

            showVersionMenuItem.Selected += showVersionMenuItem_Selected;
        }

        private void wordCounterMenuItem_Selected()
        {
            Helpers.WordCounter();
        }

        private void showDateMenuItem_Selected()
        {
            Helpers.ShowDate();
        }

        private void showTimeMenuItem_Selected()
        {
            Helpers.ShowTime();
        }

        private void showVersionMenuItem_Selected()
        {
            Helpers.ShowVersion();
        }
    }
}