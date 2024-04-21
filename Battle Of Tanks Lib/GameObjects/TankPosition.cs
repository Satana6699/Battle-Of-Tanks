﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle_Of_Tanks_Lib.GameObjects
{
    public class TankPosition : GameObject
    {
        public string name;
        public TankPosition(string name, Rectangle rectangle) : base(rectangle)
        {
            this.name = name;
        }
    }
}
