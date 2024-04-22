using Battle_Of_Tanks.GameObjectPictures;
using Battle_Of_Tanks_Lib.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle_Of_Tanks.Decorators
{
    public class DamageUp : TankDecorator
    {
        public DamageUp(TankPicture tankPicture) :
            base(tankPicture.Tank,
                tankPicture.PictureBox,
                tankPicture.Name,
                tankPicture)
        {
            tankPicture.Tank.Damage *= 2;
        }
    }
}
