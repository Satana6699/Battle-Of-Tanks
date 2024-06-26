﻿namespace Battle_Of_Tanks
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
            playButton = new Button();
            playerBox = new PictureBox();
            enterPlayerFirstButton = new Button();
            enterPlayerSecondButton = new Button();
            ((System.ComponentModel.ISupportInitialize)playerBox).BeginInit();
            SuspendLayout();
            // 
            // Timer
            // 
            Timer.Interval = 15;
            Timer.Tick += MainTimerEvent;
            // 
            // playButton
            // 
            playButton.BackgroundImage = Properties.Resources.tank;
            playButton.Font = new Font("Showcard Gothic", 30F);
            playButton.ForeColor = SystemColors.ActiveCaptionText;
            playButton.Location = new Point(650, 818);
            playButton.Name = "playButton";
            playButton.Size = new Size(259, 78);
            playButton.TabIndex = 6;
            playButton.Text = "Play";
            playButton.UseVisualStyleBackColor = true;
            playButton.Click += StartGame;
            // 
            // playerBox
            // 
            playerBox.BackColor = SystemColors.ControlDark;
            playerBox.Image = Properties.Resources.swamp;
            playerBox.Location = new Point(12, 49);
            playerBox.Name = "playerBox";
            playerBox.Size = new Size(125, 62);
            playerBox.TabIndex = 0;
            playerBox.TabStop = false;
            // 
            // enterPlayerFirstButton
            // 
            enterPlayerFirstButton.BackColor = Color.FromArgb(255, 128, 0);
            enterPlayerFirstButton.Location = new Point(650, 603);
            enterPlayerFirstButton.Name = "enterPlayerFirstButton";
            enterPlayerFirstButton.Size = new Size(259, 78);
            enterPlayerFirstButton.TabIndex = 7;
            enterPlayerFirstButton.Text = "Регистрация игрока 1";
            enterPlayerFirstButton.UseVisualStyleBackColor = false;
            enterPlayerFirstButton.Click += enterPlayerFirstButton_Click;
            // 
            // enterPlayerSecondButton
            // 
            enterPlayerSecondButton.BackColor = Color.FromArgb(255, 128, 0);
            enterPlayerSecondButton.Location = new Point(650, 711);
            enterPlayerSecondButton.Name = "enterPlayerSecondButton";
            enterPlayerSecondButton.Size = new Size(259, 78);
            enterPlayerSecondButton.TabIndex = 8;
            enterPlayerSecondButton.Text = "Регистрация игрока 2";
            enterPlayerSecondButton.UseVisualStyleBackColor = false;
            enterPlayerSecondButton.Click += enterPlayerSecondButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = SystemColors.ActiveCaption;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(1582, 953);
            Controls.Add(enterPlayerSecondButton);
            Controls.Add(enterPlayerFirstButton);
            Controls.Add(playerBox);
            Controls.Add(playButton);
            Name = "Form1";
            Text = "Form1";
            Load += FormLoad;
            ((System.ComponentModel.ISupportInitialize)playerBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Timer Timer;
        private Button playButton;
        private PictureBox playerBox;
        private Button enterPlayerFirstButton;
        private Button enterPlayerSecondButton;
    }
}
