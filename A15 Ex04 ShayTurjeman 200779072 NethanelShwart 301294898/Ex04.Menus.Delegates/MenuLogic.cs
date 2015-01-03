using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Delegates
{
    internal static class MenuLogic
    {
        internal const string k_Exit = "Exit";
        internal const string k_Back = "Back";

        internal static void menuItem_SubItemSelected(string i_SelectedMenuItemName, List<MenuItem> i_MenuItems)
        {
            Console.Clear();
            int userInput = getUserInput(i_SelectedMenuItemName, i_MenuItems);

            MenuItem selectedMenuItem = i_MenuItems[userInput];

            if (selectedMenuItem.Name != k_Exit)
            {
                if (selectedMenuItem.Name == k_Back)
                {
                    selectedMenuItem.OnBackSelected();
                }
                else
                {
                    Console.Clear();
                    selectedMenuItem.OnSelected();
                }
            }
        }

        private static int getUserInput(string i_Header, List<MenuItem> i_MenuItems)
        {
            int counter = 0, userInput;
            bool inputIsValid;
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(string.Format("{0}:{1}", i_Header, Environment.NewLine));
            foreach (MenuItem item in i_MenuItems)
            {
                stringBuilder.AppendLine(string.Format("{0}. {1}", counter, item.Name));
                counter++;
            }
            stringBuilder.AppendLine(string.Format("{0}Please select one of the options:", Environment.NewLine));
            Console.WriteLine(stringBuilder.ToString());

            do
            {
                inputIsValid = int.TryParse(Console.ReadLine(), out userInput)
                               && userInput >= 0
                               && userInput < counter;
                if (!inputIsValid)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("{0}Input is invalid, please try again{0}", Environment.NewLine);
                    Console.ResetColor();
                }
            } while (!inputIsValid);

            return userInput;
        }
    }
}