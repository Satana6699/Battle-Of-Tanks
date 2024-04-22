using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle_Of_Tanks
{
    

    public class SettingsPlayer
    {
        public int armorPoint;
        public int damage;
        public int speed;
        public int speedArmor;
        public Image image;
        public string name;

        public SettingsPlayer(int armorPoint, int damage, int speed, int speedArmor, Image image, string name)
        {
            this.armorPoint = armorPoint;
            this.damage = damage;
            this.speed = speed;
            this.speedArmor = speedArmor;
            this.image = image;
            this.name = name;
        }
    }
}
