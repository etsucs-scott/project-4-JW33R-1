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
        public void Timer()
        {
            timer = new System.Timers.Timer(100);
            timer.Elapsed += (sender, e) => DoAutomatedUpgrades(AutomatedUpgrade);
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
        public void PurchaseUpgrade(string upgradeName)
        {
            if (UpgradeDictionary.Upgrades.TryGetValue(upgradeName, out IUpgrade upgrade))
            {
                if (upgrade.CanUpgrade(CurrentTotal, upgrade.Cost))
                {
                    CurrentTotal -= upgrade.Cost;
                    TotalClickRate += upgrade.ClickRate;

                }
            }
        }
        public void AddUpgrades()
        {
            for (int i = 1; i < 10; i++)
            {
                ClickUpgrade = new ClickUpgrade((int)Math.Pow(i, 2), "Increases the amount of points per click by 1.", $"{i + 1} of Spades", (int)Math.Pow(i, 2) * 100);
                AutomatedUpgrade = new AutomatedUpgrades($"{i + 1} of Hearts", "Automatically generates points every second.", (int)Math.Pow(i, 2) * 100);
                UpgradeDictionary.AddUpgrade(ClickUpgrade.Name, ClickUpgrade);
                UpgradeDictionary.AddUpgrade(AutomatedUpgrade.Name, AutomatedUpgrade);
            }
        }
        public void DoAutomatedUpgrades(AutomatedUpgrades upgrade)
        {

            CurrentTotal += 1 + upgrade.LogUpgrade();
            Change?.Invoke();
        }
    }
}
