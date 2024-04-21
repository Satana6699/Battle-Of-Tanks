using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle_Of_Tanks_Lib.GameObjects
{
    public class Bush : GameObject
    {
        public Bush(Rectangle rectangle) : base(rectangle)
        {
            CanMove = true;
            IsSolid = false;
        }
    }
}
