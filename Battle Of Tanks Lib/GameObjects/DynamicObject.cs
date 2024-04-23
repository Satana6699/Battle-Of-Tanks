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
    public abstract class DynamicObject : GameObject
    {
        public MovementHelper movementHelper = MovementHelper.Right;
        public int Speed { get; set; }
        public DynamicObject(Rectangle rectangle, int speed) : base(rectangle)
        {
            Speed = speed;
        }
        public void Movement(MovementHelper movementHelper)
        {
            switch (movementHelper)
            {
                case MovementHelper.Left:
                    Position.Point.X -= Speed;
                    this.movementHelper = movementHelper;
                    break;
                case MovementHelper.Right:
                    Position.Point.X += Speed;
                    this.movementHelper = movementHelper;
                    break;
                case MovementHelper.Up:
                    Position.Point.Y -= Speed;
                    this.movementHelper = movementHelper;
                    break;
                case MovementHelper.Down:
                    Position.Point.Y += Speed;
                    this.movementHelper = movementHelper;
                    break;
            }
        }
    }
}
