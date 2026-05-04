using CardClicker.WebApp.Client;
using CardClicker.Core;
using CardClicker.WebApp.Client.Pages;
using Microsoft.AspNetCore.Components.Forms;
namespace CardClicker.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void TryPurchaseUpgradeWithoutRightName()
        {
            GameEngine gameEngine = new();
            gameEngine.AddUpgrades();

            gameEngine.PurchaseUpgrade("3 of Clubs");

            Assert.Empty(gameEngine.UpgradeDictionary.BoughtUpgrades);
        }
        [Fact]
        public void TryPurchaseUpgradeWithRightName()
        {
            GameEngine gameEngine = new();
            gameEngine.AddUpgrades();

            gameEngine.PurchaseUpgradeFromFile("2 of Spades", 1);

            Assert.NotEmpty(gameEngine.UpgradeDictionary.BoughtUpgrades);
        }
        [Fact]
        public void TryToBuyUpgradeWithoutEnoughPoints()
        {
            GameEngine game = new();
            game.AddUpgrades();

            game.PurchaseUpgrade("2 of Spades");

            Assert.Empty(game.UpgradeDictionary.BoughtUpgrades);
        }
        [Fact]
        public void DoesGiveValuesCorrectlyWork()
        {
            GameEngine game = new();
            game.AddUpgrades();
            game.GiveValues(1000, new List<string>() { "2 of Spades"}, new List<int>() { 2});

            Assert.Equal(1000, game.CurrentTotal);
        }
        [Fact]
        public void TryToBuyUpgradeWithEnoughPoints()
        {
            GameEngine game = new();
            game.AddUpgrades();
            game.GiveValues(1000, new List<string>() { "3 of Spades"}, new List<int>() { 1});

            game.PurchaseUpgrade("2 of Spades");

            Assert.Equal(900, game.CurrentTotal);
        }
        [Fact]
        public void TryToPurchaseUpgradeWhenLevelTooHigh()
        {
            GameEngine game = new();

            game.AddUpgrades();
            game.GiveValues(1000, new List<string>() { "2 of Spades"}, new List<int>() { 11 });

            game.PurchaseUpgrade("2 of Spades");

            Assert.Equal(11, game.UpgradeDictionary.Upgrades["2 of Spades"].Level);

        }
        [Fact]
        public void TryingToEditLevelHigherThanElevenFromFile()
        {
            GameEngine game = new();

            game.AddUpgrades();
            game.PurchaseUpgradeFromFile("2 of Spades", 12);

            Assert.Equal(0, game.UpgradeDictionary.Upgrades["2 of Spades"].Level);
        }
        [Fact]
        public void TryingToEditTotalScoreFromFile()
        {
            GameEngine game = new();

            game.AddUpgrades();
            game.GiveValues(10000, new List<string>(), new List<int>());

            Assert.Equal(0, game.CurrentTotal);
        }
    }
}