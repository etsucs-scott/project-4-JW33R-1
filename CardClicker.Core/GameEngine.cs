using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardClicker.Core
{
    /// <summary>
    /// Used for all main operations 
    /// </summary>
    public class GameEngine
    {
        public int CurrentTotal { get; private set; }
        public UpgradeDictionary UpgradeDictionary { get; private set; }
        public int TotalClickRate { get; private set; } = 1;
        public event Action? Change;
        private System.Timers.Timer timer;
        public GameEngine()
        {
            UpgradeDictionary = new UpgradeDictionary();
        }
        /// <summary>
        /// Used to have all the automated upgrades happen every 1/10 of a second
        /// </summary>
        /// <param name="autoUpgrade"></param>
        public void Timer(AutomatedUpgrades autoUpgrade)
        {
            timer = new System.Timers.Timer(100);
            timer.Elapsed += (sender, e) => DoAutomatedUpgrades(autoUpgrade);
            timer.Start();
        }
        /// <summary>
        /// Used to increase count 
        /// </summary>
        /// <returns></returns>
        public int IncrementCount()
        {
            return CurrentTotal += TotalClickRate;
        }
        /// <summary>
        /// Used for when the player loads a file back in and needs to get their upgrades
        /// </summary>
        /// <param name="upgradeName"></param>
        /// <param name="level"></param>
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
        /// <summary>
        /// Used for when a player buys a upgrade from the shop
        /// </summary>
        /// <param name="upgradeName"></param>
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
        /// <summary>
        /// Used to add upgrades for the user to buy
        /// </summary>
        public void AddUpgrades()
        {
            for (int i = 1; i < 10; i++)
            {
                ClickUpgrade clickUpgrade = new ClickUpgrade((int)Math.Pow(i, 2), "Increases the amount of points per click by 1.", $"{i + 1} of Spades", (int)Math.Pow(i, 2) * 100);
                AutomatedUpgrades automatedUpgrade = new AutomatedUpgrades((int)Math.Pow(i - 1, 2), $"{i + 1} of Hearts", "Automatically generates points every second.", (int)Math.Pow(i, 2) * 50);
                UpgradeDictionary.AddBaseUpgrade(clickUpgrade.Name, clickUpgrade);
                UpgradeDictionary.AddBaseUpgrade(automatedUpgrade.Name, automatedUpgrade);
            }
        }
        /// <summary>
        /// Funtion that has all the potentional automated upgrades that can happen
        /// </summary>
        /// <param name="upgrade"></param>
        public void DoAutomatedUpgrades(AutomatedUpgrades upgrade)
        {

            CurrentTotal += upgrade.ClickRate;
            Change?.Invoke();
        }
        /// <summary>
        /// Used to give out values to the user from the file they selected
        /// </summary>
        /// <param name="currentTotal"></param>
        /// <param name="upgradeNames"></param>
        /// <param name="levels"></param>
        public void GiveValues(int currentTotal, List<string> upgradeNames, List<int> levels)
        {
            if (currentTotal >= 1000 && upgradeNames.Count == 0) {  return; }
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
