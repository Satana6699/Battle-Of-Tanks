using Battle_Of_Tanks_Lib.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle_Of_Tanks.GameObjectPictures
{
    public class ArmorPicture : GameObjectPicture
    {
        public Armor Armor;
        public ArmorPicture(Armor armor, PictureBox pictureBox) : base(armor, pictureBox)
        {
            this.Armor = armor;
        }

    }
}
