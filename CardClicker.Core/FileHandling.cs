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

    }
}
