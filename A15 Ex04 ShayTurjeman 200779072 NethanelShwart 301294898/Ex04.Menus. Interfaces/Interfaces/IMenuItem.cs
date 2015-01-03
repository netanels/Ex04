using System.Collections.Generic;

namespace Ex04.Menus.Interfaces.Interfaces
{
    internal interface IMenuItem
    {
        string Name { get; }
        IMenuItem FatherMenuItem { get; }
        List<IMenuItem> SubItems { get; } 
    }
}
