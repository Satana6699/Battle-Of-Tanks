using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Battle_Of_Tanks
{
    public partial class TankSelectionForm : Form
    {
        // Создаем список доступных танков
        private List<TankInfo> availableTanks = new List<TankInfo>();
        private FlowLayoutPanel tankSelectionFlowLayoutPanel;
        private Form parentForm;
        public TankSelectionForm(Form parent)
        {
            InitializeComponent();

            this.parentForm = parent; // Сохраняем ссылку на родительскую форму
            this.Size = new Size(500, 500);

            // Центрируем форму относительно родительской формы
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(parent.Left + (parent.Width - this.Width) / 2, parent.Top + (parent.Height - this.Height) / 2);

            CreateTankSelectionFlowLayoutPanel();
            // Заполняем информацию о доступных танках
            InitializeAvailableTanks();

            // Отображаем информацию о танках на форме
            DisplayAvailableTanks();
        }
        private void CreateTankSelectionFlowLayoutPanel()
        {
            tankSelectionFlowLayoutPanel = new FlowLayoutPanel();
            tankSelectionFlowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            tankSelectionFlowLayoutPanel.WrapContents = false;
            tankSelectionFlowLayoutPanel.AutoScroll = true;
            tankSelectionFlowLayoutPanel.Dock = DockStyle.Fill;
            Controls.Add(tankSelectionFlowLayoutPanel);
        }
        // Метод для заполнения информации о доступных танках
        private void InitializeAvailableTanks()
        {
            // Добавляем информацию о каждом танке в список доступных танков
            // Здесь вы можете заполнить информацию о танках из вашей игры
            // Например, вы можете добавить изображения, названия и характеристики танков
            availableTanks.Add(new TankInfo("Дефолтный", "Дефолтный", Properties.Resources.first, 100, 10, 10, 50));
            availableTanks.Add(new TankInfo("Средняк", "Средняк", Properties.Resources.first, 120, 12, 12, 60));
            availableTanks.Add(new TankInfo("Сбалансированный", "Сбалансированный", Properties.Resources.first, 150, 15, 15, 70));
            availableTanks.Add(new TankInfo("Слабый", "Слабый", Properties.Resources.first, 80, 8, 8, 40));
            availableTanks.Add(new TankInfo("Живучий", "Живучий", Properties.Resources.first, 200, 20, 20, 80));
        }

        // Метод для отображения информации о танках на форме
        private void DisplayAvailableTanks()
        {
            // Для каждого доступного танка создаем элемент управления и отображаем его на форме
            foreach (var tankInfo in availableTanks)
            {
                // Создаем панель для отображения информации о танке
                Panel tankPanel = new Panel();
                tankPanel.BorderStyle = BorderStyle.FixedSingle;
                tankPanel.Size = new Size(300, 300);
                tankPanel.Margin = new Padding(10);

                // Создаем изображение танка
                PictureBox tankPictureBox = new PictureBox();
                tankPictureBox.Image = Properties.Resources.tank;
                tankPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                tankPictureBox.Size = new Size(80, 80);
                tankPictureBox.Location = new Point(10, 10);

                // Создаем метку с названием танка
                Label nameLabel = new Label();
                nameLabel.Text = tankInfo.Name;
                nameLabel.Location = new Point(100, 10);
                nameLabel.AutoSize = true;

                // Создаем метку с описанием танка
                Label descriptionLabel = new Label();
                descriptionLabel.Text = tankInfo.Description;
                descriptionLabel.Location = new Point(100, 30);
                descriptionLabel.AutoSize = true;

                // Добавляем элементы управления на панель
                tankPanel.Controls.Add(tankPictureBox);
                tankPanel.Controls.Add(nameLabel);
                tankPanel.Controls.Add(descriptionLabel);

                // Создаем метку с характеристиками танка
                Label armorLabel = new Label();
                armorLabel.Text = "Armor Points: " + tankInfo.ArmorPoints.ToString();
                armorLabel.Location = new Point(100, 50);
                armorLabel.AutoSize = true;

                Label damageLabel = new Label();
                damageLabel.Text = "Damage: " + tankInfo.Damage.ToString();
                damageLabel.Location = new Point(100, 70);
                damageLabel.AutoSize = true;

                Label speedLabel = new Label();
                speedLabel.Text = "Speed: " + tankInfo.Speed.ToString();
                speedLabel.Location = new Point(100, 90);
                speedLabel.AutoSize = true;

                Label speedArmorLabel = new Label();
                speedArmorLabel.Text = "Speed Armor: " + tankInfo.SpeedArmor.ToString();
                speedArmorLabel.Location = new Point(100, 110);
                speedArmorLabel.AutoSize = true;

                // Добавляем метки с характеристиками на панель
                tankPanel.Controls.Add(armorLabel);
                tankPanel.Controls.Add(damageLabel);
                tankPanel.Controls.Add(speedLabel);
                tankPanel.Controls.Add(speedArmorLabel);

                Button selectButton = new Button();
                selectButton.Text = "Выбрать";
                selectButton.Size = new Size(150, 30); // Устанавливаем размер кнопки
                selectButton.Location = new Point((tankPanel.Width - selectButton.Width) / 2, tankPanel.Height - 40); // Располагаем кнопку по центру внизу панели

                selectButton.BackColor = Color.FromArgb(46, 204, 113); // Задаем цвет фона кнопки
                selectButton.ForeColor = Color.White; // Задаем цвет текста на кнопке
                selectButton.FlatStyle = FlatStyle.Flat; // Устанавливаем плоский стиль кнопки
                selectButton.FlatAppearance.BorderSize = 0; // Убираем границу кнопки
                selectButton.Font = new Font("Arial", 10, FontStyle.Bold); // Задаем шрифт и стиль текста на кнопке

                selectButton.Click += (sender, e) =>
                {
                    TankInfo.SetPlayer(tankInfo);
                    //this.Close();
                    DialogResult = DialogResult.OK;
                };

                tankPanel.Controls.Add(selectButton);

                // Добавляем панель с информацией о танке на форму
                tankSelectionFlowLayoutPanel.Controls.Add(tankPanel);
            }
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // TankSelectionForm
            // 
            ClientSize = new Size(282, 253);
            Name = "TankSelectionForm";
            ResumeLayout(false);
        }
    }
}
