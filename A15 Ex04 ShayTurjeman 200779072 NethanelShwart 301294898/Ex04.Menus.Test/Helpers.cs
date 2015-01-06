using System;

namespace Ex04.Menus.Test
{
    public static class Helpers
    {
        public const string k_WordCounter = "Word Counter";
        public const string k_ShowDateTime = "Show Date/Time";
        public const string k_ShowTime = "Show Time";
        public const string k_ShowDate = "Show Date";
        public const string k_ShowVersion = "Show Version";
        public const string k_Version = "Version: 15.1.4.0";

        public static void ShowMainMenu(IMainMenuApplication i_MainMenuApplication)
        {
            Console.Clear();
            Console.Write("This 'Main Menu' application is using ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(i_MainMenuApplication.MainMenuApplicationType);
            Console.ResetColor();
            waitTillEnterToCountinue();
            i_MainMenuApplication.Show();
        }

        internal static void WordCounter()
        {
            Console.Clear();
            Console.WriteLine("Please enter a sentence:");
            string userInput = Console.ReadLine();

            userInput = userInput.Trim(' ');

            Console.WriteLine("{0}The sentence has {1} words{0}", Environment.NewLine, userInput.Split(' ').Length);
            waitTillEnterToCountinue();
        }

        internal static void ShowVersion()
        {
            Console.Clear();
            Console.WriteLine("{0}The version is: {1}{0}", Environment.NewLine, k_Version);
            waitTillEnterToCountinue();
        }

        internal static void ShowDate()
        {
            Console.Clear();
            Console.WriteLine("{0}The Date is: {1}{0}", Environment.NewLine, getTimeByFormat(@"dd/MM/yyyy"));
            waitTillEnterToCountinue();
        }

        internal static void ShowTime()
        {
            Console.Clear();
            Console.WriteLine("{0}The Time is: {1}{0}", Environment.NewLine, getTimeByFormat(@"HH:mm:ss"));
            waitTillEnterToCountinue();
        }

        private static string getTimeByFormat(string i_Format)
        {
            return DateTime.Now.ToString(i_Format);
        }

        private static void waitTillEnterToCountinue()
        {
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }
    }
}