using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMon.Monsters
{
    internal struct Reason
    {
        internal bool end;
        internal string reason;
    }
    internal class ConsoleMonArena
    {
        private bool battleIndex = false;
        internal void DoBattle(ConsoleMonster a, ConsoleMonster b)
        {
            Console.WriteLine("----Battle Start----");
            ContinueBattle(a, b);
            // reset the battle index
            battleIndex = false;
        }
        private void ContinueBattle(ConsoleMonster a, ConsoleMonster b)
        {
            List<ConsoleMonster> mons = new List<ConsoleMonster>() {a, b};
            int cur = battleIndex ? 1 : 0;
            int op = !battleIndex ? 1 : 0;
            Console.WriteLine($"{mons[cur].name}'s turn:");

            Random turnRand = new Random(Guid.NewGuid().GetHashCode());
            int used = turnRand.Next(mons[cur].skills.Count);
            a.skills[used].UseOn(mons[cur], mons[op]);
            Console.WriteLine($"{mons[cur].name} used: {mons[cur].skills[used].name}\n");
            a.ShortData();
            Console.WriteLine();
            b.ShortData();
            // invert from 0->1 or 1->0 to switch between who's at turn
            battleIndex = !battleIndex;

            // check if the battle has ended
            if(checkEnd(a).end || checkEnd(b).end)
            {
                Console.WriteLine("----Battle End----");
                if(checkEnd(a).end)
                {
                    Console.WriteLine("Results:");
                    Console.WriteLine($"{b.name} has won");
                    Console.WriteLine($"{a.name} lost, because: {checkEnd(a).reason}");
                }
                else
                {
                    Console.WriteLine("Results:");
                    Console.WriteLine($"{a.name} has won");
                    Console.WriteLine($"{b.name} lost, because: {checkEnd(b).reason}");
                }
            }
            else
            {
                // wait for user-input to continue
                Console.WriteLine("Press any button to continue...\n");
                Console.ReadKey();
                ContinueBattle(a, b);
            }
            
        }
        private Reason checkEnd(ConsoleMonster monster)
        {
            if(monster.health == 0)
            {
                return new Reason()
                {
                    end = true,
                    reason = "health fully depleted",
                };
            } else if (monster.energy == 0)
            {
                return new Reason()
                {
                    end = true,
                    reason = "energy fully depleted",
                };
            }
            return new Reason()
            {
                 end=false,
            };
        }
    }
}
