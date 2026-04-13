using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardClicker.Core
{
    public class AutomatedUpgrades : IUpgrade
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public AutomatedUpgrades(string name, string description)
        {
            Name = name;
            Description = description;
        }
        public bool CanUpgrade(int totalScore, int upgradeCost)
        {
            if (totalScore < upgradeCost)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
