using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle_Of_Tanks_Lib.GameObjects
{
    public class Brick : GameObject
    {
        public Brick(Rectangle rectangle) : base(rectangle)
        {
            IsSolid = true;
            CanMove = false;
        }
    }
}
