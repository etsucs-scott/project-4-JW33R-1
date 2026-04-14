using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardClicker.Core
{
    public class GameEngine
    {
        public int CurrentTotal { get; private set; }
        public UpgradeDictionary UpgradeDictionary { get; private set; }
        public ClickUpgrade ClickUpgrade { get; private set; }
        public AutomatedUpgrades AutomatedUpgrade { get; private set; }
        public int TotalClickRate { get; private set; } = 1;

        public GameEngine()
        {
            UpgradeDictionary = new UpgradeDictionary();
        }
        public int IncrementCount()
        {
            return CurrentTotal += TotalClickRate;
        }
        public void PurchaseUpgrade(string upgradeName)
        {
            if (UpgradeDictionary.Upgrades.TryGetValue(upgradeName, out IUpgrade upgrade))
            {
                if (CurrentTotal >= upgrade.Cost)
                {
                    CurrentTotal -= upgrade.Cost;
                    TotalClickRate += upgrade.ClickRate;
                    //UpgradeDictionary.RemoveUpgrade(upgradeName);

                }
            }
        }
        public void AddUpgrades()
        {
            for (int i = 1; i < 10; i++)
            {
                ClickUpgrade = new ClickUpgrade((i + 2)^2, "Increases the amount of points per click by 1.", $"{i + 1} of Spades", (i + 1) * 50);
                AutomatedUpgrade = new AutomatedUpgrades($"{i + 1} of Hearts", "Automatically generates points every second.", (i + 10) * 50);
                UpgradeDictionary.AddUpgrade(ClickUpgrade.Name, ClickUpgrade);
                UpgradeDictionary.AddUpgrade(AutomatedUpgrade.Name, AutomatedUpgrade);
            }
        }
    }
}
