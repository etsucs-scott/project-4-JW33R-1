using Microsoft.VisualBasic.FileIO;
using System.IO;
using Microsoft.Maui.Storage;
using Microsoft.VisualBasic;
namespace CardClicker.Core
{
    public class FileHandling
    {
        private string GetPath()
        {
            string folder = Microsoft.Maui.Storage.FileSystem.Current.AppDataDirectory; //Gets the path to the local application data folder
            return Path.Combine(folder, "card_clicker.csv"); //Puts the file in the local app data folder
        }
        public void SaveGame(int totalScore, Dictionary<string, IUpgrade> upgrades)
        {
            Console.WriteLine("Game saved successfully.");
            var fileName = GetPath();
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            var upgradeNames = new List<string>();
            upgradeNames.Add(totalScore.ToString());
            foreach (var upgrade in upgrades)
            {
                upgradeNames.Add(upgrade.Key);
            }
            File.WriteAllLines(fileName, upgradeNames);
            Console.WriteLine("Game saved successfully.");

        }
        public string[] LoadGame()
        {
            var fileName = GetPath();
            if (File.Exists(fileName))
            {
                Console.WriteLine("Game loaded successfully.");
                return File.ReadAllLines(fileName);
            }
            Console.WriteLine("No saved game found.");
            return Array.Empty<string>();
        }
    }
}
