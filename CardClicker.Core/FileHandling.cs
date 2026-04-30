using Microsoft.VisualBasic.FileIO;
using System.IO;
using Microsoft.VisualBasic;
namespace CardClicker.Core
{
    public class FileHandling
    {
        public List<string> SaveGame(Dictionary<string, IUpgrade> upgradeNames)
        {
            var savedGame = upgradeNames.Keys.ToList();
            return savedGame;
        }
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
