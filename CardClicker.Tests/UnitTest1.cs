using CardClicker.Core;
namespace CardClicker.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void TryPurchaseUpgradeWithoutRightName()
        {
            GameEngine gameEngine = new();

            gameEngine.PurchaseUpgrade("3 of Clubs");

            Assert.Empty(gameEngine.UpgradeDictionary.BoughtUpgrades);
        }
        [Fact]
        public void TryPurchaseUpgradeWithRightName()
        {
            GameEngine gameEngine = new();

            gameEngine.PurchaseUpgradeFromFile("2 of Spades", 1);

            Assert.NotEmpty(gameEngine.UpgradeDictionary.BoughtUpgrades);
        }
        [Fact]
        public void 

    }
}