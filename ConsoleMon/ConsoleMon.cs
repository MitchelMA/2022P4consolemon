using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMon
{
    internal class ConsoleMon
    {
        internal int health;
        internal int energy;
        internal string name;
        internal List<Skill> skills = new List<Skill>();
        Elementen weakness;

        ConsoleMon() { }

        internal ConsoleMon(ConsoleMon copyForm)
        {
            this.health = copyForm.health;
            this.energy = copyForm.health;
            this.weakness = copyForm.weakness;
            this.name = copyForm.name;
            this.skills = new List<Skill>();
            foreach(Skill skill in copyForm.skills)
            {
                this.skills.Add(skill.Copy());
            }
        }

        internal void TakeDamage(int damage) => health -= damage;
        internal void DepleteEnergy(int energy) => this.energy -= energy;
    }
}
