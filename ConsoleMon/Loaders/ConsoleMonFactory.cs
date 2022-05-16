using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleMon.Monsters;
using ConsoleMon.Tools;

namespace ConsoleMon.Loaders
{
    internal class ConsoleMonFactory
    {
        private Dictionary<string, ConsoleMonster> templates = new Dictionary<string, ConsoleMonster>();
        
        internal void Load(string filePath)
        {
            string[] lines = PathHelper.ReadAsLines(filePath);
            for(int i = 0; i < lines.Length; i+=2)
            {
                // load in the monster from the file
                ConsoleMonster tmp = ReadMonster(lines[i].Split(','));

                // load in the skills of this monster from this file
                string[] skillsL = lines[i + 1].Split(';');
                // remove the "Skills" at the first index
                skillsL = skillsL.Where((source, index) => index != 0).ToArray();
                List<Skill> monsterSkills = ReadSkills(skillsL);

                // add the list of skills to the monster
                tmp.skills = monsterSkills;

                // add the monster to the "templates" dictionary
                templates.Add(tmp.monsterType, tmp);
            }
        }

        private ConsoleMonster ReadMonster(string[] data)
        {
            return new ConsoleMonster()
            {
                monsterType = data[0],
                energy = Convert.ToInt32(data[2]),
                health = Convert.ToInt32(data[2]),
                baseDamage = Convert.ToInt32(data[4]),
                weakness = (Elementen)Enum.Parse(typeof(Elementen), data[6]),
            };
        }

        private List<Skill> ReadSkills(string[] data)
        {
            List<Skill> skills = new List<Skill>();
            foreach(string item in data)
            {
                string[] splitted = item.Split(',');
                Skill tmp = new Skill()
                {
                    name = splitted[0],
                    baseDamage = Convert.ToInt32(splitted[2]),
                    energyCost = Convert.ToInt32(splitted[4]),
                    element = (Elementen)Enum.Parse(typeof(Elementen), splitted[6])
                };
                skills.Add(tmp);
            }
            return skills;
        }

        internal ConsoleMonster Make(string monstertype)
        {
            return new ConsoleMonster(templates[monstertype]);
        }
    }
}
