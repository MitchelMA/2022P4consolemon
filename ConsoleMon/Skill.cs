using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMon
{
    internal class Skill
    {
        internal int damage;
        internal int energyCost;
        internal string name;
        Elementen element;

        // empty constructor
        internal Skill() { }
        
        // copy constructor
        private Skill(Skill toCopy)
        {
            this.damage = toCopy.damage;
            this.energyCost = toCopy.energyCost;
            this.name = toCopy.name;
            this.element = toCopy.element;
        }

        internal void UseOn(ConsoleMon target, ConsoleMon caster)
        {
            caster.DepleteEnergy(energyCost);
            target.TakeDamage(damage);
        }

        // copy method that uses the private copy constructor
        internal Skill Copy()
        {
            return new Skill(this);
        }
    }
}
