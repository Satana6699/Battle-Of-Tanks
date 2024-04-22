using Battle_Of_Tanks_Lib.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battle_Of_Tanks.GameObjectPictures
{
    public abstract class GameObjectPicture
    {
        public GameObject GameObject { get; set; }
        public PictureBox PictureBox { get; set; }

        public GameObjectPicture(GameObject gameObject, PictureBox pictureBox)
        {
            GameObject = gameObject;
            PictureBox = pictureBox;
        }
        public virtual void UpdateDate()
        {
            PictureBox.Location = new System.Drawing.Point(GameObject.Position.Point.X, GameObject.Position.Point.Y);
            PictureBox.Width = GameObject.Position.Width;
            PictureBox.Height = GameObject.Position.Height;
            PictureBox.Padding = new Padding(0);
            PictureBox.Margin = new Padding(0);

            PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBox.BackColor = Color.Transparent;

            PictureBox.BorderStyle = BorderStyle.None;
        }

    }
}
