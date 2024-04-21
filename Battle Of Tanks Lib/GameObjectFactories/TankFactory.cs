using Battle_Of_Tanks_Lib.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle_Of_Tanks_Lib.GameObjectFactories
{
    public class TankFactory : GameObjectFactory
    {
        protected int _armorPoint;

        protected int _damage;

        protected int _speed;
        protected int _speedArmor;

        public TankFactory(string name, Rectangle rectangle, int armorPoint, int damage, int speed, int speedArmor) : base(name, rectangle)
        {
            _armorPoint = armorPoint;
            _damage = damage;
            _speed = speed;
        }

        public override GameObject GetObject() => new Tank(_position, _armorPoint, _damage, _speed, _speedArmor);
    }
}
