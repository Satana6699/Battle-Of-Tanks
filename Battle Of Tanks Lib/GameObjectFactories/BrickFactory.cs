using Battle_Of_Tanks_Lib.GameObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Battle_Of_Tanks_Lib.GameObjectFactories
{
    public class BrickFactory : GameObjectFactory
    {

        public BrickFactory(string name, Rectangle rectangle) : base(name, rectangle)
        {
        }

        public override GameObject GetObject() => new Brick(_position);
    }
}
