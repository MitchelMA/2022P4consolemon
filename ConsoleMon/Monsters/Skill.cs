using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMon.Monsters
{
    internal class Skill
    {
        internal int baseDamage;
        internal int energyCost;
        internal string name;
        internal Elementen element;

        // empty constructor
        internal Skill() { }
        
        // copy constructor
        private Skill(Skill toCopy)
        {
            this.baseDamage = toCopy.baseDamage;
            this.energyCost = toCopy.energyCost;
            this.name = toCopy.name;
            this.element = toCopy.element;
        }

        internal void UseOn(ConsoleMonster target, ConsoleMonster caster)
        {
            caster.DepleteEnergy(energyCost);
            target.TakeDamage(baseDamage);
        }

        // copy method that uses the private copy constructor
        internal Skill Copy()
        {
            return new Skill(this);
        }
    }
}
