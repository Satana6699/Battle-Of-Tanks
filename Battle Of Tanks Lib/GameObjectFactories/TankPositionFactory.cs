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
        private string _name;
        public TankPositionFactory(string name, Rectangle rectangle) : base(name, rectangle)
        {
            _name = name;
        }

        public override GameObject GetObject() => new TankPosition(_name, _position);
    }
}
