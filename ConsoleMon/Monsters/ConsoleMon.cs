using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMon.Monsters
{
    internal class ConsoleMonster
    {
        internal int health;
        internal int energy;
        internal string name;
        internal List<Skill> skills = new List<Skill>();
        internal string monsterType;
        internal Elementen weakness;
        internal int baseDamage;

        internal ConsoleMonster() { }

        internal ConsoleMonster(ConsoleMonster copyForm)
        {
            this.health = copyForm.health;
            this.energy = copyForm.health;
            this.name = copyForm.name;
            this.skills = new List<Skill>();
            this.monsterType = copyForm.monsterType;
            this.weakness = copyForm.weakness;
            this.baseDamage = copyForm.baseDamage;
            foreach(Skill skill in copyForm.skills)
            {
                this.skills.Add(skill.Copy());
            }
        }

        internal void PrintData()
        {
            Console.WriteLine("name: " + name);
            Console.WriteLine($"health: {health}");
            Console.WriteLine($"energy: {energy}");
            Console.WriteLine($"type: {monsterType}");
            Console.WriteLine($"weakness: {weakness}");
            Console.WriteLine($"base-damage: {baseDamage}");
            Console.WriteLine("skills:");
            foreach (Skill skill in skills)
            {
                Console.WriteLine($"skill-name: {skill.name}");
                Console.WriteLine($"skill-base-damage: {skill.baseDamage}");
                Console.WriteLine($"skill-energy-cost: {skill.energyCost}");
                Console.WriteLine($"skill-type: {skill.element}\n");
            }
        }

        internal void ShortData()
        {
            Console.WriteLine("name: " + name);
            Console.WriteLine($"health: {health}");
            Console.WriteLine($"energy: {energy}");
        }

        internal void TakeDamage(int damage) => health -= damage;
        internal void DepleteEnergy(int energy) => this.energy -= energy;
    }
}
