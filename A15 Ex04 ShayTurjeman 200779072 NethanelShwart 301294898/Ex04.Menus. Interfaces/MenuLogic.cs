using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    internal static class MenuLogic
    {
        internal static void SubItemsSelectedLogic(string i_SelectedMenuItemName, List<MenuItem> i_MenuItems)
        {
            bool continueLoopFlag;

            do
            {
                Console.Clear();
                int userInput = getUserInput(i_SelectedMenuItemName, i_MenuItems);
                MenuItem selectedMenuItem = i_MenuItems[userInput];

                continueLoopFlag = selectedMenuItem.Name != eSpecialMenuItemsValues.Exit.ToString()
                                   && selectedMenuItem.Name != eSpecialMenuItemsValues.Back.ToString();
                if (continueLoopFlag)
                {
                    selectedMenuItem.ItemSelectedLogic();
                }
            } while (continueLoopFlag);
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

        internal enum eSpecialMenuItemsValues
        {
            Exit,
            Back
        }
    }
}