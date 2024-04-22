using Battle_Of_Tanks;

public class TankInfo
{
    public string Name { get; }
    public int ArmorPoints { get; }
    public Image Image { get; }
    public string Description { get; }
    public int Damage { get; }
    public int Speed { get; }
    public int SpeedArmor { get; }

    public static TankInfo TankInFoForPLayer { get; private set; }

    public TankInfo(string name, string description, Image image, int armorPoints, int damage, int speed, int speedArmor)
    {
        Name = name;
        Description = description;
        Image = image;
        ArmorPoints = armorPoints;
        Damage = damage;
        Speed = speed;
        SpeedArmor = speedArmor;
    }

    public static void SetPlayer(TankInfo tankInfo)
    {
        TankInFoForPLayer = tankInfo;
    }
}