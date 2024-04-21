using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle_Of_Tanks_Lib.GameObjects
{
    public class Water : GameObject
    {
        public Water(Rectangle rectangle) : base(rectangle)
        {
            IsSolid = false;
            CanMove = false;
        }
    }
}
