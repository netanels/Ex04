using System;
using System.Collections.Generic;
using System.Text;
using Ex04.Menus.Test.DelegatesTest;
using Ex04.Menus.Test.InterfacesTest;

namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()
        {
            IMainMenuApplication testMainMenuWithInterfaces = new TestMainMenuWithInterfaces();

            IMainMenuApplication testMainMenuWithDelegates = new TestMainMenuWithDelegates();
        }
    }
}
