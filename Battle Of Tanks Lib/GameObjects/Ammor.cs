using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle_Of_Tanks_Lib.GameObjects
{
    public class Ammor : DynamicObject
    {
        private int _timeLive = 100;
        public int Damage { get; set; }
        public MovementHelper MovementHelper { get; set; }
        public Ammor(Rectangle rectangle, int damage, MovementHelper movementHelper, int speed) : base(rectangle, speed)
        {
            Damage = damage;
            MovementHelper = movementHelper;
        }

        public void Move()
        {
            _timeLive--;
            Movement(MovementHelper);
        }

        public bool IsLive()
        {
            return _timeLive >= 0;
        }
    }
}
