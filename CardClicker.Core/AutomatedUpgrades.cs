using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardClicker.Core
{
    public class AutomatedUpgrades : IUpgrade
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int Cost { get; private set; }
        public int ClickRate { get; private set; }
        public AutomatedUpgrades(string name, string description, int cost)
        {
            Name = name;
            Description = description;
            Cost = cost;
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
