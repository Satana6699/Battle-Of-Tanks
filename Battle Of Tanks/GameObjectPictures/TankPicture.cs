﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Battle_Of_Tanks_Lib.GameObjects;

namespace Battle_Of_Tanks.GameObjectPictures
{
    public class TankPicture : GameObjectPicture
    {
        public Tank Tank { get; set; }
        private Image Image { get; set; }
        public string Name { get; set; }

        public TankPicture(Tank tank, PictureBox pictureBox, string name) : base(tank, pictureBox)
        {
            Tank = tank;
            PictureBox = pictureBox;
            Image = pictureBox.Image;
            Name = name;

        }

        public override void UpdateDate()
        {
            PictureBox.Location = new System.Drawing.Point(Tank.Position.Point.X, Tank.Position.Point.Y);
            Image image = (Image)Image.Clone();
            switch (Tank.movementHelper)
            {
                case MovementHelper.Up:
                    image.RotateFlip(RotateFlipType.Rotate90FlipY);
                    break;
                    
                case MovementHelper.Down:
                    image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    break;
                    
                case MovementHelper.Right:
                    break;
                    
                case MovementHelper.Left:
                    image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    break;

            }
            PictureBox.Image = image;
            base.UpdateDate();
        }
    }
}