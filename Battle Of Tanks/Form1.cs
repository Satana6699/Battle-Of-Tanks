using Battle_Of_Tanks.GameObjectPictures;
using Battle_Of_Tanks_Lib;
using Battle_Of_Tanks_Lib.GameObjects;
using System.Diagnostics;
using System.Numerics;
using Rectangle = Battle_Of_Tanks_Lib.Rectangle;

namespace Battle_Of_Tanks
{
    public partial class Form1 : Form
    {
        (TankPicture first, TankPicture second) player;
        (List<ArmorPicture> first, List<ArmorPicture> second) armors = new (new List<ArmorPicture>(0), new List<ArmorPicture>(0));
        List<GameObjectPicture> gameObjectsPicture = new List<GameObjectPicture>(0);
        ((bool Up, bool Left, bool Down, bool Right) first, (bool Up, bool Left, bool Down, bool Right) second) click;
        List<GameObject> gameObjects;
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void FormLoad(object sender, EventArgs e)
        {
            playerBox.Dispose();

            Image imageFirst = Properties.Resources.first;
            Battle_Of_Tanks_Lib.Point pointFirst = new(100, 100);
            player.first = GeneratePLayer(pointFirst, 100, 10, 10, 20, imageFirst, "Семка");

            Battle_Of_Tanks_Lib.Point pointSecond = new(200, 200);
            Image imageSecond = Properties.Resources.second;
            player.second = GeneratePLayer(pointSecond, 100, 10, 10, 20, imageSecond, "Спичка");
            

            player.first.UpdateDate();
            player.second.UpdateDate();
            MapGenerate();
        }

        private void MapGenerate()
        {
            string[,] strings = MapManager.Reed(@"D:\Семестр 4 (полигон)\Курсовая работа\Battle Of Tanks\Battle Of Tanks\data\maps\mapa.txt");

            int unitObject = 37;
            gamePanel.Width = unitObject * strings.GetLength(1);
            gamePanel.Height = unitObject * strings.GetLength(0);

            gameObjects = MapManager.Generate(strings, gamePanel.Width, gamePanel.Height);
            foreach (var gameObject in gameObjects)
            {
                PictureBox box = new PictureBox();
                Image image = Properties.Resources.brick;
                if (gameObject is Brick) 
                    image = Properties.Resources.brick;
                else if (gameObject is Water) 
                   image = Properties.Resources.water;
                box.Image = image;

                gameObjectsPicture.Add(new BlockPicture(gameObject, box));
                gameObjectsPicture[gameObjectsPicture.Count - 1].UpdateDate();
                gamePanel.Controls.Add(gameObjectsPicture[gameObjectsPicture.Count - 1].PictureBox);
            }

            foreach (var gameObject in gameObjects)
            {

                if (gameObject is Brick brick)
                {
                    int width = brick.Position.Width - brick.Position.Width / 3;
                    int height = brick.Position.Height - brick.Position.Height / 3;

                    player.first.Tank.Position.Width = width;
                    player.first.Tank.Position.Height = height;
                    player.first.UpdateDate();

                    player.second.Tank.Position.Width = width;
                    player.second.Tank.Position.Height = height;
                    player.second.UpdateDate();
                    break;
                }
            }
        }

        private void MainTimerEvent(object sender, EventArgs e)
        {
            if (player.first.Tank.ProcentHP() <= 0)
            {
                Vinner(player.first);
                armorPointProgressBarFirst.Value = 0;
            }
            else
            {
                armorPointProgressBarFirst.Value = player.first.Tank.ProcentHP();
            }

            if (player.second.Tank.ProcentHP() <= 0)
            {
                Vinner(player.second);
                armorPointProgressBarSecond.Value = 0;
            }
            else
            {
                armorPointProgressBarSecond.Value = player.second.Tank.ProcentHP();
            }

            ArmorManager();
            MovePLayer();
        }

        public void MovePLayer()
        {
            Rectangle rectangleFirst = (Rectangle)player.first.Tank.Position.Clone();
            if (click.first.Up) player.first.Tank.Movement(MovementHelper.Up);
            else if (click.first.Left) player.first.Tank.Movement(MovementHelper.Left);
            else if(click.first.Down) player.first.Tank.Movement(MovementHelper.Down);
            else if(click.first.Right) player.first.Tank.Movement(MovementHelper.Right);

            
            Rectangle rectangleSecond = (Rectangle)player.second.Tank.Position.Clone();
            if (click.second.Up) player.second.Tank.Movement(MovementHelper.Up);
            else if (click.second.Left) player.second.Tank.Movement(MovementHelper.Left);
            else if(click.second.Down) player.second.Tank.Movement(MovementHelper.Down);
            else if(click.second.Right) player.second.Tank.Movement(MovementHelper.Right);


            Colisions(rectangleFirst, rectangleSecond);
            player.first.UpdateDate();
            player.second.UpdateDate();
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            KeyIsDownFirst(e);
            KeyIsDownSecond(e);
        }
        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            KeyIsUpFirst(e);
            KeyIsUpSecond(e);
        }

        public TankPicture GeneratePLayer(Battle_Of_Tanks_Lib.Point point, int arborPoint, int damage, int speed, int speedArmor, Image image, string name)
        {
            TankPicture tankPicture;
            PictureBox tankBox = new PictureBox();
            tankBox.Image = image;
            gamePanel.Controls.Add(tankBox);
            tankPicture = new
                (
                    new Tank
                    (
                        new Rectangle
                        (
                            point,
                            Properties.Resources.tank.Width,
                            Properties.Resources.tank.Height
                        ),
                        arborPoint,
                        damage,
                        speed,
                        speedArmor),
                    tankBox,
                    name
                );

            return tankPicture;
        }

        private void Colisions(Rectangle first, Rectangle second)
        {
            if (player.first.Tank.Position.Intersects(player.second.Tank.Position))
            {
                player.first.Tank.Position = (Rectangle)first.Clone();
                player.second.Tank.Position = (Rectangle)second.Clone();
            }

            foreach (var obj in gameObjects)
            {
                if (!obj.CanMove)
                {
                    if (player.first.Tank.Position.Intersects(obj.Position))
                    {
                        player.first.Tank.Position = (Rectangle)first.Clone();
                    }

                    if (player.second.Tank.Position.Intersects(obj.Position))
                    {
                        player.second.Tank.Position = (Rectangle)second.Clone();
                    }
                }
            }

        }

        private void ArmorManager()
        {
            foreach(var armor in armors.first)
            {
                armor.Armor.Move();
                armor.UpdateDate();
                

                if (armor.Armor.Position.Intersects(player.second.Tank.Position))
                {
                    player.second.Tank.TakeDamage(player.first.Tank.Damage);
                    gamePanel.Controls.Remove(armor.PictureBox);
                    armor.PictureBox.Dispose();
                    player.first.Tank.Remove(armor.Armor);
                    armors.first.Remove(armor);
                    break;
                }
            }

            foreach (var armor in armors.second)
            {
                armor.Armor.Move();
                armor.UpdateDate();
                
                if (armor.Armor.Position.Intersects(player.first.Tank.Position))
                {
                    player.first.Tank.TakeDamage(player.second.Tank.Damage);
                    gamePanel.Controls.Remove(armor.PictureBox);
                    armor.PictureBox.Dispose();
                    player.second.Tank.Remove(armor.Armor);
                    armors.second.Remove(armor);
                    break;
                }
            }
            foreach (var obj in gameObjects)
            {
                foreach (var armor in armors.first)
                {
                    if (armor.Armor.Position.Intersects(obj.Position) && obj.IsSolid)
                    {
                        gamePanel.Controls.Remove(armor.PictureBox);
                        armor.PictureBox.Dispose();
                        player.first.Tank.Remove(armor.Armor);
                        armors.first.Remove(armor);
                        break;
                    }
                }

                foreach (var armor in armors.second)
                {
                    if (armor.Armor.Position.Intersects(obj.Position) && obj.IsSolid)
                    {
                        gamePanel.Controls.Remove(armor.PictureBox);
                        armor.PictureBox.Dispose();
                        player.second.Tank.Remove(armor.Armor);
                        armors.second.Remove(armor);
                        break;
                    }
                }
            }
        }
        private void KeyIsPress(object? sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ' && player.first.Tank.IsPiu())
            {
                ArmorPicture armorPicture;
                Image armor = Properties.Resources.armor;
                PictureBox box = new PictureBox();
                box.Image = armor;
                gamePanel.Controls.Add(box);
                armorPicture = new
                    (
                        player.first.Tank.Piu(),
                        box
                    );
                armorPicture.UpdateDate();
                armorPicture.PictureBox.BringToFront();
                armors.first.Add(armorPicture);
            }

            if (e.KeyChar == '+' && player.second.Tank.IsPiu())
            {
                ArmorPicture armorPicture;
                Image armor = Properties.Resources.armor;
                PictureBox box = new PictureBox();
                box.Image = armor;
                gamePanel.Controls.Add(box);
                armorPicture = new
                    (
                        player.second.Tank.Piu(),
                        box
                    );
                armorPicture.UpdateDate();
                armorPicture.PictureBox.BringToFront();
                armors.second.Add(armorPicture);
            }
        }

        public void Vinner(TankPicture tank)
        {
            gamePanel.Controls.Remove(tank.PictureBox);
            tank.PictureBox.Dispose();
        }
        private void KeyIsUpFirst(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D)
            {
                click.first.Right = false;
            }

            else if (e.KeyCode == Keys.A)
            {
                click.first.Left = false;
            }

            else if (e.KeyCode == Keys.W)
            {
                click.first.Up = false;
            }

            else if (e.KeyCode == Keys.S)
            {
                click.first.Down = false;
            }
        }

        private void KeyIsUpSecond(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.L)
            {
                click.second.Right = false;
            }

            else if (e.KeyCode == Keys.J)
            {
                click.second.Left = false;
            }

            else if (e.KeyCode == Keys.I)
            {
                click.second.Up = false;
            }

            else if (e.KeyCode == Keys.K)
            {
                click.second.Down = false;
            }
        }

        private void KeyIsDownFirst(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D)
            {
                click.first.Right = true;
            }

            else if (e.KeyCode == Keys.A)
            {
                click.first.Left = true;
            }

            else if (e.KeyCode == Keys.W)
            {
                click.first.Up = true;
            }

            else if (e.KeyCode == Keys.S)
            {
                click.first.Down = true;
            }
        }

        private void KeyIsDownSecond(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.L)
            {
                click.second.Right = true;
            }

            else if (e.KeyCode == Keys.J)
            {
                click.second.Left = true;
            }

            else if (e.KeyCode == Keys.I)
            {
                click.second.Up = true;
            }

            else if (e.KeyCode == Keys.K)
            {
                click.second.Down = true;
            }
        }
    }
}
