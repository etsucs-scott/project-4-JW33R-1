using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardClicker.Core
{
    public class FileHandling
    {
        public void SaveGame(int totalScore, Dictionary<string, IUpgrade> upgrades)
        {
            var lines = new string[2] {
                totalScore.ToString(),
                upgrades.Count.ToString()
            };
            var fileName = "card_clicker.csv";
            File.WriteAllLines(fileName, lines);

        }
        public void LoadGame()
        {

        }
    }
}
