using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardClicker.Core
{
    /// <summary>
    /// Outline for the automated upgrades
    /// </summary>
    public class AutomatedUpgrades : IUpgrade
    {
        public int Level { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int Cost { get; private set; }
        public int ClickRate { get; private set; }
        public AutomatedUpgrades(int clickRate, string name, string description, int cost)
        {
            ClickRate = clickRate;
            Name = name;
            Description = description;
            Cost = cost;
        }
        /// <summary>
        /// Makes sure the user can upgrade depending on how much money they have compared to the cost
        /// </summary>
        /// <param name="totalScore"></param>
        /// <param name="upgradeCost"></param>
        /// <returns></returns>
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
        /// <summary>
        /// An option for the player to buy
        /// </summary>
        /// <returns></returns>
        /// Currently not in use but will be later 
        public int LogUpgrade()
        {
            ClickRate = 1;
            return (int)Math.Log(ClickRate);
        }
        /// <summary>
        /// Used to increase the level of the upgrade
        /// </summary>
        public void IncreaseLevel()
        {
            Level++;
            ClickRate += 1;
            Cost += (int)Math.Pow(Level, 2) * 200;
        }
        /// <summary>
        /// Used to set the level of the upgrade upon enterting data from a file
        /// </summary>
        /// <param name="level"></param>
        public void SetLevel(int level)
        {
            if (level > 11)
            {
                Level = 0;
            }
            else
            {
                Level = level;
                ClickRate += level;
                Cost += (int)Math.Pow(Level, 2) * 200;
            }
        }
    }
}
