using System;
using ConsoleMon.Tools;
using ConsoleMon.Monsters;
using ConsoleMon.Loaders;

namespace ConsoleMon
{
    internal enum Elementen
    {
        Fire,
        Water,
        Grass,
        Elec,
        Physical,
        Dark
    }
    internal class Program
    {
        internal static void Main(string[] args)
        {
            // create a new instance of a factory
            ConsoleMonFactory myFactory = new ConsoleMonFactory();
            // create a new instance of a battle arena
            ConsoleMonArena myArena = new ConsoleMonArena();
            // load the data file
            myFactory.Load("./data/monsterdata.txt");


            // make a new monster
            ConsoleMonster monA = myFactory.Make("EnterMon");
            ConsoleMonster monB = myFactory.Make("NewLineMon");
            monA.name = "Monachu";
            monB.name = "Monizard";

            myArena.DoBattle(monA, monB);

            
        }
    }
}
