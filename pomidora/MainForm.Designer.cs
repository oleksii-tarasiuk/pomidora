namespace pomidora
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.m_panel = new System.Windows.Forms.Panel();
            this.m_timerLabel = new System.Windows.Forms.Label();
            this.m_postponeButton = new System.Windows.Forms.Button();
            this.m_titleLabel = new System.Windows.Forms.Label();
            this.m_timer = new System.Windows.Forms.Timer(this.components);
            this.m_notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.m_contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_settingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_quitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_goButton = new System.Windows.Forms.Button();
            this.m_panel.SuspendLayout();
            this.m_contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panel
            // 
            this.m_panel.Controls.Add(this.m_timerLabel);
            this.m_panel.Controls.Add(this.m_postponeButton);
            this.m_panel.Controls.Add(this.m_titleLabel);
            this.m_panel.Location = new System.Drawing.Point(286, 91);
            this.m_panel.Name = "m_panel";
            this.m_panel.Size = new System.Drawing.Size(400, 328);
            this.m_panel.TabIndex = 0;
            // 
            // m_timerLabel
            // 
            this.m_timerLabel.BackColor = System.Drawing.Color.Black;
            this.m_timerLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_timerLabel.Font = new System.Drawing.Font("Arial", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_timerLabel.ForeColor = System.Drawing.Color.White;
            this.m_timerLabel.Location = new System.Drawing.Point(0, 29);
            this.m_timerLabel.Name = "m_timerLabel";
            this.m_timerLabel.Size = new System.Drawing.Size(400, 263);
            this.m_timerLabel.TabIndex = 2;
            this.m_timerLabel.Text = "label1";
            this.m_timerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_postponeButton
            // 
            this.m_postponeButton.BackColor = System.Drawing.Color.Black;
            this.m_postponeButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_postponeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_postponeButton.ForeColor = System.Drawing.Color.White;
            this.m_postponeButton.Location = new System.Drawing.Point(0, 292);
            this.m_postponeButton.Name = "m_postponeButton";
            this.m_postponeButton.Size = new System.Drawing.Size(400, 36);
            this.m_postponeButton.TabIndex = 1;
            this.m_postponeButton.Text = "Postpone";
            this.m_postponeButton.UseVisualStyleBackColor = false;
            this.m_postponeButton.Click += new System.EventHandler(this.postponeButton_Click);
            // 
            // m_titleLabel
            // 
            this.m_titleLabel.BackColor = System.Drawing.Color.Black;
            this.m_titleLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_titleLabel.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_titleLabel.ForeColor = System.Drawing.Color.White;
            this.m_titleLabel.Location = new System.Drawing.Point(0, 0);
            this.m_titleLabel.Name = "m_titleLabel";
            this.m_titleLabel.Size = new System.Drawing.Size(400, 29);
            this.m_titleLabel.TabIndex = 0;
            this.m_titleLabel.Text = "Time to resume:";
            this.m_titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_timer
            // 
            this.m_timer.Enabled = true;
            this.m_timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // m_notifyIcon
            // 
            this.m_notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.m_notifyIcon.BalloonTipText = "Pomidora BalloonTipText";
            this.m_notifyIcon.BalloonTipTitle = "Pomidora BalloonTipTitle";
            this.m_notifyIcon.ContextMenuStrip = this.m_contextMenuStrip;
            this.m_notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("m_notifyIcon.Icon")));
            this.m_notifyIcon.Text = "Pomidora Text";
            this.m_notifyIcon.Visible = true;
            // 
            // m_contextMenuStrip
            // 
            this.m_contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_settingsMenuItem,
            this.m_quitMenuItem});
            this.m_contextMenuStrip.Name = "m_contextMenuStrip";
            this.m_contextMenuStrip.Size = new System.Drawing.Size(181, 70);
            // 
            // m_settingsMenuItem
            // 
            this.m_settingsMenuItem.Name = "m_settingsMenuItem";
            this.m_settingsMenuItem.Size = new System.Drawing.Size(180, 22);
            this.m_settingsMenuItem.Text = "Settings...";
            this.m_settingsMenuItem.Click += new System.EventHandler(this.SettingsMenuItem_Click);
            // 
            // m_quitMenuItem
            // 
            this.m_quitMenuItem.Name = "m_quitMenuItem";
            this.m_quitMenuItem.Size = new System.Drawing.Size(180, 22);
            this.m_quitMenuItem.Text = "Quit";
            this.m_quitMenuItem.Click += new System.EventHandler(this.QuitMenuItem_Click);
            // 
            // m_goButton
            // 
            this.m_goButton.BackColor = System.Drawing.Color.DarkGreen;
            this.m_goButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_goButton.ForeColor = System.Drawing.Color.White;
            this.m_goButton.Location = new System.Drawing.Point(600, 99);
            this.m_goButton.Name = "m_goButton";
            this.m_goButton.Size = new System.Drawing.Size(234, 171);
            this.m_goButton.TabIndex = 1;
            this.m_goButton.Text = "GO!";
            this.m_goButton.UseVisualStyleBackColor = false;
            this.m_goButton.Visible = false;
            this.m_goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(861, 523);
            this.Controls.Add(this.m_goButton);
            this.Controls.Add(this.m_panel);
            this.Name = "MainForm";
            this.Opacity = 0.9D;
            this.Text = "MainForm1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.m_panel.ResumeLayout(false);
            this.m_contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel m_panel;
        private System.Windows.Forms.Label m_timerLabel;
        private System.Windows.Forms.Button m_postponeButton;
        private System.Windows.Forms.Label m_titleLabel;
        private System.Windows.Forms.Timer m_timer;
        private System.Windows.Forms.NotifyIcon m_notifyIcon;
        private System.Windows.Forms.ContextMenuStrip m_contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem m_settingsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_quitMenuItem;
        private System.Windows.Forms.Button m_goButton;
    }
}

