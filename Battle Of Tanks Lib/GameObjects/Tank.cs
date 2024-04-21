using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle_Of_Tanks_Lib.GameObjects
{
    public enum MovementHelper
    {
        Up,
        Down,
        Left,
        Right
    }
    public class Tank : DynamicObject
    {
        public List<Armor> armors = new List<Armor>(0);
        public int ArmorMaxPoint { get; private set; }
        public int ArmorPoint { get; private set; }
        public int Damage { get; private set; }
        public int SpeedArmor { get; private set; }
        private int _maxArmors = 3;
        public Tank(Rectangle position, int armorMaxPoint, int damage, int speed, int speedArmor) : base (position, speed)
        {
            ArmorMaxPoint = armorMaxPoint;
            ArmorPoint = armorMaxPoint;
            Damage = damage;
            Speed = speed;
            SpeedArmor = speedArmor;
        }


        public int ProcentHP()
        {
            return Convert.ToInt32((double)ArmorPoint / ArmorMaxPoint * 100);
        }

        public void TakeDamage(int damage) => ArmorPoint -= damage;

        public Armor Piu()
        {
            int widthArmor = Convert.ToInt32(0.5 * Position.Width);
            int heightArmor = Convert.ToInt32(0.5 * Position.Height);

            armors.Add
                (
                    new Armor
                            (
                                new Rectangle
                                (
                                    new Point
                                    (
                                        Convert.ToInt32(Position.Point.X + Position.Width / 2 - widthArmor),
                                        Convert.ToInt32(Position.Point.Y + Position.Height / 2 - heightArmor / 2)
                                    ),
                                    widthArmor,
                                    heightArmor
                                ),
                                Damage,
                                movementHelper,
                                SpeedArmor
                            )
                    );
            return armors[armors.Count - 1];
        }

        public bool IsPiu()
        {
            return armors.Count <= _maxArmors - 1;
        }


        public void Remove(Armor armor) => armors.Remove(armor);
    }
}
