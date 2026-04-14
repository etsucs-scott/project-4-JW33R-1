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
        public UpgradeDictionary() 
        {
            Upgrades = new();
        }
        public void AddUpgrade(string upgradeName, IUpgrade upgrade)
        {
            Upgrades.TryAdd(upgradeName, upgrade);
        }
        public void RemoveUpgrade(string upgradeName)
        {
            Upgrades.Remove(upgradeName);
        }
    }
}
