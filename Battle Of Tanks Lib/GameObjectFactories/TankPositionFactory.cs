using Battle_Of_Tanks_Lib.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle_Of_Tanks_Lib.GameObjectFactories
{
    public class TankPositionFactory : GameObjectFactory
    {
        public TankPositionFactory(string name, Rectangle rectangle) : base(name, rectangle)
        {
        }

        public override GameObject GetObject()
        {
            throw new NotImplementedException();
        }
    }
}
