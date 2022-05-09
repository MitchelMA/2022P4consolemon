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
            // load the data file
            myFactory.Load("./data/monsterdata.txt");

            // make a new monster
            ConsoleMonster myMon = myFactory.Make("DeleteMon");
            Console.WriteLine("name: " + myMon.name);
            Console.WriteLine($"health: {myMon.health}");
            Console.WriteLine($"energy: {myMon.energy}");
            Console.WriteLine($"type: {myMon.monsterType}");
            Console.WriteLine($"weakness: {myMon.weakness}");
            Console.WriteLine($"base-damage: {myMon.baseDamage}");
            Console.WriteLine("skills:");
            foreach(Skill skill in myMon.skills)
            {
                Console.WriteLine($"skill-name: {skill.name}");
                Console.WriteLine($"skill-base-damage: {skill.baseDamage}");
                Console.WriteLine($"skill-energy-cost: {skill.energyCost}");
                Console.WriteLine($"skill-type: {skill.element}\n");
            }
        }
    }
}
