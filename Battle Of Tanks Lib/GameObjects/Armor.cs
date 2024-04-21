using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle_Of_Tanks_Lib.GameObjects
{
    public class Armor : DynamicObject
    {
        public int Damage { get; set; }
        public MovementHelper MovementHelper { get; set; }
        public Armor(Rectangle rectangle, int damage, MovementHelper movementHelper, int speed) : base(rectangle, speed)
        {
            Damage = damage;
            MovementHelper = movementHelper;
        }

        public void Move()
        {
            Movement(MovementHelper);
        }

    }
}
