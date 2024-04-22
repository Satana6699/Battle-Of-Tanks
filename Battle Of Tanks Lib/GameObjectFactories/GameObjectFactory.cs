using Battle_Of_Tanks_Lib.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle_Of_Tanks_Lib.GameObjectFactories
{
    public abstract class GameObjectFactory
    {
        protected readonly string _name;
        protected readonly Rectangle _position;
        protected GameObjectFactory(string name, Rectangle rectangle)
        {
            _name = name;
            _position = rectangle;
        }
        public abstract GameObject GetObject();
        public static GameObjectFactory GetFactory(string n, Rectangle rwc)
        {
            switch (n)
            {
                case "1":
                    return new BrickFactory(n, rwc);
                case "w":
                    return new WaterFactory(n, rwc);
                case "b":
                    return new BushFactory(n, rwc);
                case "s":
                    return new SwampFactory(n, rwc);
                case "p1":
                    return new TankPositionFactory(n, rwc);
                case "p2":
                    return new TankPositionFactory(n, rwc);
                default:
                    return null;
                    
            }
        }
    }
}
