using JambApp.Managers;
using JambApp.Models;
using JambApp.Managers;
using JambApp.Menus;
using JambApp.Managers.Interfaces;
namespace JambApp
{
    internal class Program 
    {
        static void Main(string[] args)
        {
             MainMenu menu = new MainMenu();
             menu.Menu();
           

        }
    }
}