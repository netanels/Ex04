using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Test
{
    public static class Helpers
    {
        public const string k_WordCounter = "Word Counter";
        public const string k_ShowDate = "Show Date";
        public const string k_ShowDateTime = "Show Date/Time";
        public const string k_ShowTime = "Show Time";
        public const string k_ShowVersion = "Show Version";
        public const string k_Version = "Version: 15.1.4.0";

        public static void ShowMainMenu(IMainMenuApplication i_MainMenuApplication)
        {
            Console.Write("{0}This 'Main Menu' application is using ",Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(i_MainMenuApplication.MainMenuApplicationType);
            Console.ResetColor();
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
            i_MainMenuApplication.Show();
        }

        public static void ShowVersion()
        {
            Console.WriteLine(k_Version);
        }

        public static void ShowDate()
        {
            showTimeByFormat(@"dd/MM/yyyy");
        }

        public static void ShowTime()
        {
            showTimeByFormat(@"HH:mm:ss");
        }

        private static void showTimeByFormat(string i_Format)
        {
            DateTime time = DateTime.Now;
            Console.WriteLine(time.ToString(i_Format));
        }

        internal static void WordCounter()
        {
            Console.WriteLine("Please enter a sentence");
            string userInput = Console.ReadLine();

            userInput = userInput.Trim(' ');

            Console.WriteLine("{0}The sentence has {1} words", Environment.NewLine, userInput.Split(' ').Length);
        }
    }
}
