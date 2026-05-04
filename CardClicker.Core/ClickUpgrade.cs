using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardClicker.Core
{
    /// <summary>
    /// Outline for the click upgrade
    /// </summary>
    public class ClickUpgrade : IUpgrade
    {
        public int Level { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int ClickRate { get; private set; }
        public int Cost { get; private set; }
        public ClickUpgrade(int clickRate, string description, string name, int cost)
        {
            ClickRate = clickRate;
            Description = description;
            Name = name;
            Cost = cost;
        }
        /// <summary>
        /// Makes sure the user can upgrade based on amount of money compared to cost of upgrade
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
        /// Upgrades the clickrate
        /// </summary>
        /// <param name="currentScore"></param>
        public void Upgrade(int currentScore)
        {
            currentScore += ClickRate;
        }
        /// <summary>
        /// Increases the level of the upgrade
        /// </summary>
        public void IncreaseLevel()
        {
            Level++;
            Cost += (int)Math.Pow(Level, 2) * 100;
        }
        /// <summary>
        /// Sets the level of the upgrade based on data from a file
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
