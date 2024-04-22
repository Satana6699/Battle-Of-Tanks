using Battle_Of_Tanks.GameObjectPictures;
using Battle_Of_Tanks_Lib;
using Battle_Of_Tanks_Lib.GameObjects;
using System.Diagnostics;
using System.Numerics;
using Rectangle = Battle_Of_Tanks_Lib.Rectangle;
using Battle_Of_Tanks.Decorators;
using Microsoft.VisualBasic;

namespace Battle_Of_Tanks
{
    public partial class Form1 : Form
    {
        private (SettingsPlayer first, SettingsPlayer second) playerSettings;
        private (TankPicture first, TankPicture second) player;
        private (List<ArmorPicture> first, List<ArmorPicture> second) armors = new(new List<ArmorPicture>(0), new List<ArmorPicture>(0));
        private List<GameObjectPicture> gameObjectsPicture = new List<GameObjectPicture>(0);
        private ((bool Up, bool Left, bool Down, bool Right) first, (bool Up, bool Left, bool Down, bool Right) second) click;
        private List<GameObject> gameObjects;
        private (char first, char second) Piu = ('c', 'n');
        private (TankInfo first, TankInfo second) playerInfo;
        private (bool first, bool second) registerPlayer = (false, false);

        private List<TankInfo> availableTanks = new List<TankInfo>();

        // Компоненты контролера
        private Panel _gamePanel;
        private (ProgressBar first, ProgressBar second) _progressBar;
        private (Label first, Label second) _label;
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
        }

        private void FormLoad(object sender, EventArgs e)
        {
            playerBox.Dispose();
            InitializeAvailableTanks();
        }

        private void MapGenerate()
        {
            string[,] strings = MapManager.Reed(@"D:\Семестр 4 (полигон)\Курсовая работа\Battle Of Tanks\Battle Of Tanks\data\maps\mapa.txt");

            int unitObject = 37;
            _gamePanel.Location = new System.Drawing.Point(12, 52);
            _gamePanel.BackColor = Color.AliceBlue;
            _gamePanel.Width = unitObject * strings.GetLength(1);
            _gamePanel.Height = unitObject * strings.GetLength(0);

            gameObjects = MapManager.Generate(strings, _gamePanel.Width, _gamePanel.Height);
            foreach (var gameObject in gameObjects)
            {
                Image image = null;
                if (gameObject is Brick)
                    image = Properties.Resources.brick;
                else if (gameObject is Water)
                    image = Properties.Resources.water;
                else if (gameObject is Bush)
                    image = Properties.Resources.bush;
                else { }

                PictureBox box = new PictureBox();
                box.Image = image;

                if (gameObject is TankPosition tank && tank.name == "p1")
                {
                    player.first = GeneratePLayer
                        (
                            tank.Position.Point,
                            playerSettings.first.armorPoint,
                            playerSettings.first.damage,
                            playerSettings.first.speed,
                            playerSettings.first.speedArmor,
                            playerSettings.first.image,
                            playerSettings.first.name
                        );
                    player.first.Tank.Position.Width = gameObject.Position.Width - gameObject.Position.Width / 4;
                    player.first.Tank.Position.Height = gameObject.Position.Height - gameObject.Position.Height / 4;
                    player.first.UpdateDate();
                    box.Visible = false;
                }

                if (gameObject is TankPosition tank2 && tank2.name == "p2")
                {
                    player.second = GeneratePLayer
                        (
                            tank2.Position.Point,
                            playerSettings.second.armorPoint,
                            playerSettings.second.damage,
                            playerSettings.second.speed,
                            playerSettings.second.speedArmor,
                            playerSettings.second.image,
                            playerSettings.second.name
                        );
                    player.second.Tank.Position.Width = gameObject.Position.Width - gameObject.Position.Width / 4;
                    player.second.Tank.Position.Height = gameObject.Position.Height - gameObject.Position.Height / 4;
                    player.second.UpdateDate();
                    box.Visible = false;
                }
                gameObjectsPicture.Add(new BlockPicture(gameObject, box));
                gameObjectsPicture[gameObjectsPicture.Count - 1].UpdateDate();
                _gamePanel.Controls.Add(gameObjectsPicture[gameObjectsPicture.Count - 1].PictureBox);
                if (gameObject is Bush)
                    // Отрисовка сверху
                    gameObjectsPicture[gameObjectsPicture.Count - 1].PictureBox.BringToFront();
            }

        }

        private void MainTimerEvent(object sender, EventArgs e)
        {
            if (player.first.Tank.ProcentHP() <= 0)
            {
                Vinner(player.second);
                _progressBar.first.Value = 0;
            }
            else
            {
                _progressBar.first.Value = player.first.Tank.ProcentHP();
            }

            if (player.second.Tank.ProcentHP() <= 0)
            {
                Vinner(player.first);
                _progressBar.second.Value = 0;
            }
            else
            {
                _progressBar.second.Value = player.second.Tank.ProcentHP();
            }

            ArmorManager();
            MovePLayer();
        }

        public void MovePLayer()
        {
            if (player.first.Tank.IsInBush() && player.first is not DamageDown)
            {
                player.first = new DamageDown(player.first);
                player.first.UpdateImage(playerInfo.first.Image);
            }
            else if (!player.first.Tank.IsInBush() && player.first is DamageDown)
            {
                player.first = new DamageUp(player.first);
                player.first.UpdateImage(playerInfo.first.Image);
            }

            if (player.second.Tank.IsInBush() && player.second is not DamageDown)
            {
                player.second = new DamageDown(player.second);
                player.second.UpdateImage(playerInfo.second.Image);
            }
            else if (!player.second.Tank.IsInBush() && player.second is DamageDown)
            {
                player.second = new DamageUp(player.second);
                player.second.UpdateImage(playerInfo.second.Image);
            }


            Rectangle rectangleFirst = (Rectangle)player.first.Tank.Position.Clone();
            if (click.first.Up) player.first.Tank.Movement(MovementHelper.Up);
            else if (click.first.Left) player.first.Tank.Movement(MovementHelper.Left);
            else if (click.first.Down) player.first.Tank.Movement(MovementHelper.Down);
            else if (click.first.Right) player.first.Tank.Movement(MovementHelper.Right);


            Rectangle rectangleSecond = (Rectangle)player.second.Tank.Position.Clone();
            if (click.second.Up) player.second.Tank.Movement(MovementHelper.Up);
            else if (click.second.Left) player.second.Tank.Movement(MovementHelper.Left);
            else if (click.second.Down) player.second.Tank.Movement(MovementHelper.Down);
            else if (click.second.Right) player.second.Tank.Movement(MovementHelper.Right);


            Colisions(rectangleFirst, rectangleSecond);

            player.first.UpdateDate();
            player.second.UpdateDate();
        }

        private void KeyIsDown(object? sender, KeyEventArgs e)
        {
            KeyIsDownFirst(e);
            KeyIsDownSecond(e);
        }
        private void KeyIsUp(object? sender, KeyEventArgs e)
        {
            KeyIsUpFirst(e);
            KeyIsUpSecond(e);
        }

        public TankPicture GeneratePLayer(Battle_Of_Tanks_Lib.Point point, int armorPoint, int damage, int speed, int speedArmor, Image image, string name)
        {
            TankPicture tankPicture;
            PictureBox tankBox = new PictureBox();
            tankBox.Image = image;
            _gamePanel.Controls.Add(tankBox);
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
                        armorPoint,
                        damage,
                        speed,
                        speedArmor),
                    tankBox,
                    name
                );
            tankPicture.UpdateImage(image);
            return tankPicture;
        }
        private void Colisions(Rectangle first, Rectangle second)
        {

            if (player.first.Tank.Position.Intersects(player.second.Tank.Position) &&
                player.second.Tank.Position.Intersects(player.first.Tank.Position))
            {
                player.first.Tank.Position = (Rectangle)first.Clone();
                player.second.Tank.Position = (Rectangle)second.Clone();
            }
            foreach (var obj in gameObjects)
            {
                if (obj.CanMove == false)
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

            foreach (var obj in gameObjects)
            {
                if (obj is Bush bush)
                {
                    if (player.first.Tank.Position.Intersects(bush.Position))
                    {
                        player.first.Tank.EnterBush();
                        break;
                    }
                    else
                    {
                        player.first.Tank.LeaveBush();
                    }
                }
            }
            foreach (var obj in gameObjects)
            {
                if (obj is Bush bush)
                {
                    if (player.second.Tank.Position.Intersects(bush.Position))
                    {
                        player.second.Tank.EnterBush();
                        break;
                    }
                    else
                    {
                        player.second.Tank.LeaveBush();
                    }
                }
            }
        }

        private void ArmorManager()
        {
            foreach (var armor in armors.first)
            {
                armor.Armor.Move();
                armor.UpdateDate();


                if (armor.Armor.Position.Intersects(player.second.Tank.Position))
                {
                    player.second.Tank.TakeDamage(player.first.Tank.Damage);
                    _gamePanel.Controls.Remove(armor.PictureBox);
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
                    _gamePanel.Controls.Remove(armor.PictureBox);
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
                        _gamePanel.Controls.Remove(armor.PictureBox);
                        armor.PictureBox.Dispose();
                        player.first.Tank.Remove(armor.Armor);
                        armors.first.Remove(armor);
                        break;
                    }
                }
            }

            foreach (var obj in gameObjects)
            {
                foreach (var armor in armors.second)
                {
                    if (armor.Armor.Position.Intersects(obj.Position) && obj.IsSolid)
                    {
                        _gamePanel.Controls.Remove(armor.PictureBox);
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
            if (e.KeyChar == Piu.first && player.first.Tank.IsPiu())
            {
                ArmorPicture armorPicture;
                Image armor = Properties.Resources.armor;
                PictureBox box = new PictureBox();
                box.Image = armor;
                _gamePanel.Controls.Add(box);
                armorPicture = new
                    (
                        player.first.Tank.Piu(),
                        box
                    );
                armorPicture.UpdateDate();
                armorPicture.PictureBox.BringToFront();
                armors.first.Add(armorPicture);
            }

            if (e.KeyChar == Piu.second && player.second.Tank.IsPiu())
            {
                ArmorPicture armorPicture;
                Image armor = Properties.Resources.armor;
                PictureBox box = new PictureBox();
                box.Image = armor;
                _gamePanel.Controls.Add(box);
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
            _gamePanel.Controls.Remove(tank.PictureBox);
            tank.PictureBox.Dispose();
            Timer.Stop();
            MessageBox.Show("Выиграл игрок: " + tank.Name);
            foreach (Control control in _gamePanel.Controls)
            {
                control.Dispose();
            }
            _gamePanel.Dispose();
            EndGame();
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

        private void StartGame(object sender, EventArgs e)
        {
            // Игра запустить только если 2 игрока зарегистрируют свои танки
            if (registerPlayer.first && registerPlayer.second)
            {
                this.KeyDown += KeyIsDown;
                this.KeyPress += KeyIsPress;
                this.KeyUp += KeyIsUp;
                InitializePlayers();
                InitializeGameComponent();
                MapGenerate();
                Timer.Start();
            }
        }
        private void InitializePlayers()
        {
            playerSettings.first = new
                (
                playerInfo.first.ArmorPoints,
                playerInfo.first.Damage,
                playerInfo.first.Speed,
                playerInfo.first.SpeedArmor,
                playerInfo.first.Image,
                playerInfo.first.Name);
            playerSettings.second = new
                (
                playerInfo.second.ArmorPoints,
                playerInfo.second.Damage,
                playerInfo.second.Speed,
                playerInfo.second.SpeedArmor,
                playerInfo.second.Image,
                playerInfo.second.Name);
        }
        private void InitializeGameComponent()
        {
            CreateGamePanel();
            CreateProgressBar();
            CreateLabel();
        }

        private void CreateGamePanel()
        {
            _gamePanel = new Panel();
            _gamePanel.Location = new System.Drawing.Point(12, 52);
            _gamePanel.BackColor = System.Drawing.Color.AliceBlue;
            _gamePanel.Width = 1;
            _gamePanel.Height = 1;
            Controls.Add(_gamePanel);
            _gamePanel.BringToFront();
            this.Focus();
        }
        private void CreateProgressBar()
        {
            int widthProgressBar = 180;
            int heightProgressBar = 25;

            _progressBar.first = new ProgressBar();
            _progressBar.first.Location = new System.Drawing.Point(176, 21);
            _progressBar.first.Width = widthProgressBar;
            _progressBar.first.Height = heightProgressBar;
            Controls.Add(_progressBar.first);

            _progressBar.second = new ProgressBar();
            _progressBar.second.Location = new System.Drawing.Point(1338, 21);
            _progressBar.second.Width = widthProgressBar;
            _progressBar.second.Height = heightProgressBar;
            Controls.Add(_progressBar.second);

        }
        private void CreateLabel()
        {

            int widthLabel = 160;
            int heightLabel = 25;

            _label.first = new Label();
            _label.first.Location = new System.Drawing.Point(9, 21);
            _label.first.Width = widthLabel;
            _label.first.Height = heightLabel;
            _label.first.Text = playerSettings.first.name;
            Controls.Add(_label.first);

            _label.second = new Label();
            _label.second.Location = new System.Drawing.Point(1170, 21);
            _label.second.Width = widthLabel;
            _label.second.Height = heightLabel;
            _label.second.Text = playerSettings.second.name;
            Controls.Add(_label.second);
        }


        private void enterPlayerFirstButton_Click(object sender, EventArgs e)
        {
            TankSelectionForm tankSelectionForm = new TankSelectionForm(this, availableTanks);
            if (tankSelectionForm.ShowDialog() == DialogResult.OK)
            {
                playerInfo.first = TankInfo.TankInFoForPLayer;
                enterPlayerFirstButton.BackColor = Color.Green;
                registerPlayer.first = true;
            }
        }

        private void enterPlayerSecondButton_Click(object sender, EventArgs e)
        {
            TankSelectionForm tankSelectionForm = new TankSelectionForm(this, availableTanks);
            if (tankSelectionForm.ShowDialog() == DialogResult.OK)
            {
                playerInfo.second = TankInfo.TankInFoForPLayer;
                enterPlayerSecondButton.BackColor = Color.Green;
                registerPlayer.second = true;
            }
        }

        private void InitializeAvailableTanks()
        {
            // Добавляем информацию о каждом танке в список доступных танков
            // Здесь вы можете заполнить информацию о танках из вашей игры
            // Например, вы можете добавить изображения, названия и характеристики танков
            availableTanks.Add(new TankInfo("Дефолтный", "Дефолтный", Properties.Resources.first, 100, 10, 10, 50));
            availableTanks.Add(new TankInfo("Средняк", "Средняк", Properties.Resources.second, 120, 12, 12, 60));
            availableTanks.Add(new TankInfo("Сбалансированный", "Сбалансированный", Properties.Resources.third, 150, 15, 15, 70));
            availableTanks.Add(new TankInfo("Слабый", "Слабый", Properties.Resources.fourth, 80, 8, 8, 40));
            availableTanks.Add(new TankInfo("Живучий", "Живучий", Properties.Resources.fifth, 200, 20, 20, 80));
        }

        private void EndGame()
        {
            availableTanks.Clear();
            InitializeAvailableTanks();
            registerPlayer = (false, false);
            enterPlayerFirstButton.BackColor = Color.Red;
            enterPlayerSecondButton.BackColor = Color.Red;
            _progressBar.first.Dispose();
            _progressBar.second.Dispose();
            _label.first.Dispose();
            _label.second.Dispose();
        }
    }
}
