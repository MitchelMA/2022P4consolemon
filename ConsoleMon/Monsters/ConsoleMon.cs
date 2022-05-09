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

        internal void TakeDamage(int damage) => health -= damage;
        internal void DepleteEnergy(int energy) => this.energy -= energy;
    }
}
