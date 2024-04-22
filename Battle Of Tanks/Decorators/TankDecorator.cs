using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battle_Of_Tanks_Lib.GameObjects;
using Rectngle = Battle_Of_Tanks_Lib.Rectangle;
using Battle_Of_Tanks.GameObjectPictures;

namespace Battle_Of_Tanks.Decorators
{
    public class TankDecorator : TankPicture
    {
        protected TankPicture TankPicture { get; set; }

        public TankDecorator
            (Tank tank, PictureBox pictureBox, string name, TankPicture tankPicture) :
            base(tank, pictureBox, name)
        {
            TankPicture = tankPicture;
            TankPicture.Image = tankPicture.Image;
            tankPicture.Tank.movementHelper = tank.movementHelper;
        }
    }
}
