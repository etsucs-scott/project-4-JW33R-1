using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public event Action? Change;
        private System.Timers.Timer timer;
        public void Timer(AutomatedUpgrades autoUpgrade)
        {
            timer = new System.Timers.Timer(100);
            timer.Elapsed += (sender, e) => DoAutomatedUpgrades(autoUpgrade);
            timer.Start();
        }

        public GameEngine()
        {
            UpgradeDictionary = new UpgradeDictionary();
        }
        public int IncrementCount()
        {
            return CurrentTotal += TotalClickRate;
        }
        public void PurchaseUpgradeFromFile(string upgradeName, int level)
        {
            if (UpgradeDictionary.Upgrades.TryGetValue(upgradeName, out var upgrade))
            {
                if (upgrade.GetType() == typeof(AutomatedUpgrades) && upgrade.Level < 11)
                {
                    Timer((AutomatedUpgrades)upgrade);
                    UpgradeDictionary.AddBoughtUpgrade(upgradeName, upgrade);
                    upgrade.SetLevel(level);
                }
                else if (upgrade.GetType() == typeof(ClickUpgrade) && upgrade.Level < 11)
                {
                    TotalClickRate += upgrade.ClickRate;
                    UpgradeDictionary.AddBoughtUpgrade(upgradeName, upgrade);
                    upgrade.SetLevel(level);
                }
            }
        }
        public void PurchaseUpgrade(string upgradeName)
        {
            if (UpgradeDictionary.Upgrades.TryGetValue(upgradeName, out IUpgrade upgrade))
            {
                if (upgrade.CanUpgrade(CurrentTotal, upgrade.Cost) && upgrade.Level < 11)
                {
                    if (upgrade.GetType() == typeof(AutomatedUpgrades) && upgrade.Level < 11)
                    {
                        Timer((AutomatedUpgrades)upgrade);
                        CurrentTotal -= upgrade.Cost;
                        UpgradeDictionary.AddBoughtUpgrade(upgradeName, upgrade);
                        upgrade.IncreaseLevel();
                    }
                    else if (upgrade.GetType() == typeof(ClickUpgrade) && upgrade.Level < 11)
                    {
                        CurrentTotal -= upgrade.Cost;
                        TotalClickRate += upgrade.ClickRate;
                        UpgradeDictionary.AddBoughtUpgrade(upgradeName, upgrade);
                        upgrade.IncreaseLevel();
                    }
                }
            }
        }
        public void AddUpgrades()
        {
            for (int i = 1; i < 10; i++)
            {
                ClickUpgrade = new ClickUpgrade((int)Math.Pow(i, 2), "Increases the amount of points per click by 1.", $"{i + 1} of Spades", (int)Math.Pow(i, 2) * 100);
                AutomatedUpgrade = new AutomatedUpgrades((int)Math.Pow(i - 1, 2), $"{i + 1} of Hearts", "Automatically generates points every second.", (int)Math.Pow(i, 2) * 50);
                UpgradeDictionary.AddBaseUpgrade(ClickUpgrade.Name, ClickUpgrade);
                UpgradeDictionary.AddBaseUpgrade(AutomatedUpgrade.Name, AutomatedUpgrade);
            }
        }
        public void DoAutomatedUpgrades(AutomatedUpgrades upgrade)
        {

            CurrentTotal += upgrade.ClickRate;//upgrade.LogUpgrade();
            Change?.Invoke();
        }
        public void GiveValues(int currentTotal, List<string> upgradeNames, List<int> levels)
        {
            CurrentTotal = currentTotal;
            if (upgradeNames.Count > 0)
            {
                for (int i = 0; i < upgradeNames.Count; i++)
                {
                    Console.WriteLine(upgradeNames[i]);
                    PurchaseUpgradeFromFile(upgradeNames[i], levels[i]);
                }
            }
            upgradeNames = new List<string>();

        }
    }
}
