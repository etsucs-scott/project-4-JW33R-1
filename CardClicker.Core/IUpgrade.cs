namespace CardClicker.Core;

public interface IUpgrade
{
    public bool CanUpgrade(int totalScore, int upgradeCost);
    public string Name { get; }
    public string Description { get; }


}
