using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Test
{
    public interface IMainMenuApplication
    {
        string MainMenuApplicationType { get; }
        void Show();
    }
}
