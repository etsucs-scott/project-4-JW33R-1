using Microsoft.VisualBasic.FileIO;
using System.IO;
using Microsoft.VisualBasic;
namespace CardClicker.Core
{
    /// <summary>
    /// Used to get both of the names and levels of each upgrade in BoughtUpgrades Dictionary
    /// </summary>
    public class FileHandling
    {
        /// <summary>
        /// Gets the names of the bought upgrades and puts them in a list
        /// </summary>
        /// <param name="upgradeNames"></param>
        /// <returns></returns>
        public List<string> SaveGame(Dictionary<string, IUpgrade> upgradeNames)
        {
            var savedGame = upgradeNames.Keys.ToList();
            return savedGame;
        }
        /// <summary>
        /// Gets the levels of each upgrade and puts them into a list
        /// </summary>
        /// <param name="upgradeNames"></param>
        /// <returns></returns>
        public List<int> SavedLevels(Dictionary<string, IUpgrade> upgradeNames)
        {
            var savedLevels = new List<int>();
            foreach (var upgrade in upgradeNames)
            {
                if (upgrade.Value.GetType() == typeof(AutomatedUpgrades))
                {
                    savedLevels.Add(upgrade.Value.Level);
                }
                else if (upgrade.Value.GetType() == typeof(ClickUpgrade))
                {
                    savedLevels.Add(upgrade.Value.Level);
                }
            }
            return savedLevels;
        }

    }
}
