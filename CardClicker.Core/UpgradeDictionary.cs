using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardClicker.Core
{
    /// <summary>
    /// Used to add/remove upgrades from both the main pool of upgrades and the bought ones
    /// </summary>
    public class UpgradeDictionary
    {
        public Dictionary<string, IUpgrade> Upgrades { get; private set; }
        public Dictionary<string, IUpgrade> BoughtUpgrades { get; private set; }
        public UpgradeDictionary() 
        {
            Upgrades = new();
            BoughtUpgrades = new();
        }
        /// <summary>
        /// Adds Upgrade to the base pool of Upgrades
        /// </summary>
        /// <param name="upgradeName"></param>
        /// <param name="upgrade"></param>
        public void AddBaseUpgrade(string upgradeName, IUpgrade upgrade)
        {
            Upgrades.TryAdd(upgradeName, upgrade);
        }
        /// <summary>
        /// Removes Upgrade from base pool of Upgrades
        /// </summary>
        /// <param name="upgradeName"></param>
        public void RemoveBaseUpgrade(string upgradeName)
        {
            Upgrades.Remove(upgradeName);
        }
        /// <summary>
        /// Removes a bought upgrade from the dictionary
        /// </summary>
        /// <param name="upgradeName"></param>
        public void RemoveBoughtUpgrade(string upgradeName)
        {
            BoughtUpgrades.Remove(upgradeName);
        }
        /// <summary>
        /// Adds a bought upgrade to the dictionary
        /// </summary>
        /// <param name="upgradeName"></param>
        /// <param name="upgrade"></param>
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
