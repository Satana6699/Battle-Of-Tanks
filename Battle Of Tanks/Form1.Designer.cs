namespace Battle_Of_Tanks
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Timer = new System.Windows.Forms.Timer(components);
            armorPointLabel1 = new Label();
            armorPointLabel2 = new Label();
            armorPointProgressBarFirst = new ProgressBar();
            armorPointProgressBarSecond = new ProgressBar();
            gamePanel = new Panel();
            playerBox = new PictureBox();
            gamePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)playerBox).BeginInit();
            SuspendLayout();
            // 
            // Timer
            // 
            Timer.Enabled = true;
            Timer.Interval = 10;
            Timer.Tick += MainTimerEvent;
            // 
            // armorPointLabel1
            // 
            armorPointLabel1.AutoSize = true;
            armorPointLabel1.Font = new Font("Segoe UI", 11F);
            armorPointLabel1.Location = new Point(9, 21);
            armorPointLabel1.Name = "armorPointLabel1";
            armorPointLabel1.Size = new Size(161, 25);
            armorPointLabel1.TabIndex = 0;
            armorPointLabel1.Text = "armorPointLabel1";
            // 
            // armorPointLabel2
            // 
            armorPointLabel2.AutoSize = true;
            armorPointLabel2.Font = new Font("Segoe UI", 11F);
            armorPointLabel2.Location = new Point(1024, 21);
            armorPointLabel2.Name = "armorPointLabel2";
            armorPointLabel2.Size = new Size(161, 25);
            armorPointLabel2.TabIndex = 1;
            armorPointLabel2.Text = "armorPointLabel2";
            // 
            // armorPointProgressBarFirst
            // 
            armorPointProgressBarFirst.ForeColor = SystemColors.ControlDarkDark;
            armorPointProgressBarFirst.Location = new Point(176, 21);
            armorPointProgressBarFirst.Name = "armorPointProgressBarFirst";
            armorPointProgressBarFirst.Size = new Size(179, 25);
            armorPointProgressBarFirst.TabIndex = 2;
            // 
            // armorPointProgressBarSecond
            // 
            armorPointProgressBarSecond.ForeColor = SystemColors.ControlDarkDark;
            armorPointProgressBarSecond.Location = new Point(1191, 21);
            armorPointProgressBarSecond.Name = "armorPointProgressBarSecond";
            armorPointProgressBarSecond.Size = new Size(179, 25);
            armorPointProgressBarSecond.TabIndex = 3;
            // 
            // gamePanel
            // 
            gamePanel.BackColor = Color.Transparent;
            gamePanel.Controls.Add(playerBox);
            gamePanel.Location = new Point(12, 52);
            gamePanel.Name = "gamePanel";
            gamePanel.Size = new Size(1505, 805);
            gamePanel.TabIndex = 5;
            // 
            // playerBox
            // 
            playerBox.BackColor = SystemColors.ControlDark;
            playerBox.Image = Properties.Resources.water;
            playerBox.Location = new Point(3, 3);
            playerBox.Name = "playerBox";
            playerBox.Size = new Size(125, 62);
            playerBox.TabIndex = 0;
            playerBox.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = SystemColors.ActiveCaption;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(1582, 953);
            Controls.Add(gamePanel);
            Controls.Add(armorPointProgressBarSecond);
            Controls.Add(armorPointProgressBarFirst);
            Controls.Add(armorPointLabel2);
            Controls.Add(armorPointLabel1);
            Name = "Form1";
            Text = "Form1";
            Load += FormLoad;
            KeyDown += KeyIsDown;
            KeyPress += KeyIsPress;
            KeyUp += KeyIsUp;
            gamePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)playerBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer Timer;
        private Label armorPointLabel1;
        private Label armorPointLabel2;
        private ProgressBar armorPointProgressBarFirst;
        private ProgressBar armorPointProgressBarSecond;
        private Panel gamePanel;
        private PictureBox playerBox;
    }
}
