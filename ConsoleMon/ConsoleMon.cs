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

        internal ConsoleMon(int health, int energy, string name)
        {
            this.health = health;
            this.energy = energy;
            this.name = name;
        }

        internal void TakeDamage(int damage) => health -= damage;
        internal void DepleteEnergy(int energy) => this.energy -= energy;
    }
}
