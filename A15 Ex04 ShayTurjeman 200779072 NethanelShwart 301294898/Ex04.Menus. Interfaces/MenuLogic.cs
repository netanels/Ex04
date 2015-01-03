using System;
using System.Text;
using Ex04.Menus.Interfaces.Interfaces;

namespace Ex04.Menus.Interfaces
{
    internal static class MenuLogic
    {
        internal const string k_Exit = "Exit";
        internal const string k_Back = "Back";
        
        internal static void SelectItemsLogic(IMenuItem i_MenuItem)
        {
            Console.Clear();
            int userInput = getUserInput(i_MenuItem);

            IMenuItem selectedMenuItem = i_MenuItem.SubItems[userInput];

            if (selectedMenuItem.Name != k_Exit)
            {
                if (selectedMenuItem.Name == k_Back)
                {
                    SelectItemsLogic(selectedMenuItem.FatherMenuItem);
                }
                else
                {
                    if ((selectedMenuItem as MenuItem).HasSubItems)
                    {
                        SelectItemsLogic(selectedMenuItem);
                    }
                    else
                    {
                        Console.Clear();
                        (selectedMenuItem as MenuItem).ItemSelected();
                    }
                }
            }
        }

        private static int getUserInput(IMenuItem i_MenuItem)
        {
            int counter = 0, userInput;
            bool inputIsValid;
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(string.Format("{0}:{1}", i_MenuItem.Name, Environment.NewLine));
            foreach (IMenuItem item in i_MenuItem.SubItems)
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
                    Console.WriteLine("{0}Input is invalid{0}", Environment.NewLine);
                    Console.ResetColor();
                }
            } while (!inputIsValid);

            return userInput;
        }
    }
}
