using System;
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
        public Image Image { get; set; }
        public string Name { get; set; }

        public TankPicture(Tank tank, PictureBox pictureBox, string name) : base(tank, pictureBox)
        {
            Tank = tank;
            PictureBox = pictureBox;
            Name = name;
        }

        public void UpdateImage(Image image)
        {
            Image = image;
        }
        public override void UpdateDate()
        {
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
