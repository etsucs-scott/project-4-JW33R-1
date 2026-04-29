using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardClicker.Core
{
    public class UpgradeDictionary
    {
        public Dictionary<string, IUpgrade> Upgrades { get; private set; }
        public Dictionary<string, IUpgrade> BoughtUpgrades { get; private set; }
        public UpgradeDictionary() 
        {
            Upgrades = new();
            BoughtUpgrades = new();
        }
        public void AddBaseUpgrade(string upgradeName, IUpgrade upgrade)
        {
            Upgrades.TryAdd(upgradeName, upgrade);
        }
        public void RemoveBaseUpgrade(string upgradeName)
        {
            Upgrades.Remove(upgradeName);
        }
        public void RemoveBoughtUpgrade(string upgradeName)
        {
            BoughtUpgrades.Remove(upgradeName);
        }
        public void AddBoughtUpgrade(string upgradeName, IUpgrade upgrade)
        {
            if (BoughtUpgrades.ContainsKey(upgradeName))
            {
                BoughtUpgrades[upgradeName] = upgrade;
            }
            else
            {
                BoughtUpgrades.TryAdd(upgradeName, upgrade);
            }
        }
    }
}
