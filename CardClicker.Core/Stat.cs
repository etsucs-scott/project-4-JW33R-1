using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardClicker.Core
{
    public class Stat
    {
        public int CurrentTotal { get; private set; }
        public List<string> UpgradeNames { get; private set; }
        public List<int> Levels { get; private set; }
        public Stat(int currentTotal, List<string> upgradeNames, List<int> levels)
        {
            CurrentTotal = currentTotal;
            UpgradeNames = upgradeNames;
            Levels = levels;
        }
    }
}
