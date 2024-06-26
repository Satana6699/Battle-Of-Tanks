﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle_Of_Tanks_Lib.GameObjects
{
    
    public class Tank : DynamicObject
    {
        public List<Ammor> ammors = new List<Ammor>(0);
        public int ArmorMaxPoint { get; private set; }
        public int ArmorPoint { get; private set; }
        public int Damage { get; set; }
        public int SpeedArmor { get; private set; }
        private int _maxArmors = 2;
        private bool isInBush = false;
        private bool isInSwamp = false;

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

        public Ammor Piu()
        {
            int widthArmor = Convert.ToInt32(0.5 * Position.Width);
            int heightArmor = Convert.ToInt32(0.5 * Position.Height);

            ammors.Add
                (
                    new Ammor
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
            return ammors[ammors.Count - 1];
        }

        public bool IsPiu()
        {
            return ammors.Count <= _maxArmors - 1;
        }


        public void Remove(Ammor armor) => ammors.Remove(armor);

        public void EnterBush()
        {
            isInBush = true;
        }

        public void LeaveBush()
        {
            isInBush = false;
        }
        public bool IsInBush()
        {
            return isInBush;
        }

        public void EnterSwamp()
        {
            isInSwamp = true;
        }

        public void LeaveSwamp()
        {
            isInSwamp = false;
        }
        public bool IsInSwamp()
        {
            return isInSwamp;
        }

    }
}
