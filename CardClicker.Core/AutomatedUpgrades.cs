using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardClicker.Core
{
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
        public int LogUpgrade()
        {
            ClickRate = 1;
            return (int)Math.Log(ClickRate);
        }
        public void IncreaseLevel()
        {
            Level++;
            ClickRate += 1;
            Cost += (int)Math.Pow(Level, 2) * 200;
        }
        public void SetLevel(int level)
        {
            Level = level;
            ClickRate += level;
            Cost += (int)Math.Pow(Level, 2) * 200;
        }
    }
}
