using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardClicker.Core
{
    public class ClickUpgrade : IUpgrade
    {
        public int Level { get; private set; }
        public bool IsUnlocked { get; private set; }
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
        public void Upgrade(int currentScore)
        {
            currentScore += ClickRate;
        }
        public void IncreaseLevel()
        {
            Level++;
            Cost += (int)Math.Pow(Level, 2) * 100;
        }
        public void SetLevel(int level)
        {
            Level = level;
        }
    }
}
