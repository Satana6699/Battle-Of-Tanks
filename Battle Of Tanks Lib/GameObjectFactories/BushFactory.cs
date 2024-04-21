using Battle_Of_Tanks_Lib.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle_Of_Tanks_Lib.GameObjectFactories
{
    public class BushFactory : GameObjectFactory
    {
        public BushFactory(string name, Rectangle rectangle) : base(name, rectangle)
        {
        }

        public override GameObject GetObject() => new Bush(_position);
    }
}
