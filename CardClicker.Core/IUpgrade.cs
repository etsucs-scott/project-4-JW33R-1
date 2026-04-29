namespace CardClicker.Core;

public interface IUpgrade
{
    public int Level { get; }
    public bool IsUnlocked { get; }
    public bool CanUpgrade(int totalScore, int upgradeCost);
    public string Name { get; }
    public string Description { get; }
    public int Cost { get; }
    public int ClickRate { get; }
    public void IncreaseLevel();
    public void SetLevel(int level);


}
