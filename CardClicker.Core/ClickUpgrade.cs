using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardClicker.Core
{
    public class ClickUpgrade : IUpgrade
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int ClickRate { get; private set; }
        public ClickUpgrade(int clickRate, string description, string name)
        {
            ClickRate = clickRate;
            Description = description;
            Name = name;
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
    }
}
