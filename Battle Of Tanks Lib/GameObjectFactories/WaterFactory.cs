using Battle_Of_Tanks_Lib.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle_Of_Tanks_Lib.GameObjectFactories
{
    public class WaterFactory : GameObjectFactory
    {
        public WaterFactory(string name, Rectangle rectangle) : base(name, rectangle)
        {
        }

        public override GameObject GetObject() => new Water(_position);
    }
}
