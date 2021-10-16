using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pomidora
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        internal void updateState()
        {
            switch (Program.m_state) 
            {
                case State.Break:
                    m_goButton.Hide();
                    m_panel.Top = (Height - m_panel.Height) / 2;
                    m_panel.Left = (Width - m_panel.Width) / 2;
                    m_panel.Show();
                    m_postponeButton.Enabled = (Program.m_numPostpones < Program.m_maxPostpones);
                    Show();
                    break;
                case State.Go:
                    m_panel.Hide();
                    m_goButton.SetBounds(
                        m_panel.Left, m_panel.Top, m_panel.Width, m_panel.Height
                    );
                    m_goButton.Show();
                    break;
                default:
                    Hide();
                    break;
            }
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            TopMost = true;
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            Program.onTimer();
            var now = DateTime.Now;
            var diff = (Program.m_checkpoint - now);
            var str = $"{diff.Minutes:00}:{diff.Seconds:00}";
            switch (Program.m_state)
            {
                case State.Break:
                    m_timerLabel.Text = str;
                    break;
                default:
                    m_notifyIcon.Text = str;
                    break;
            }
            updateState();
        }

        private void postponeButton_Click(object sender, EventArgs e)
        {
            Program.postpone();
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            Program.go();
        }
        private void QuitMenuItem_Click(object sender, EventArgs e)
        {
            Program.quit();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Program.m_isClosing && (e.CloseReason == CloseReason.UserClosing || e.CloseReason == CloseReason.TaskManagerClosing))
                e.Cancel = true;
        }

        private void SettingsMenuItem_Click(object sender, EventArgs e)
        {
            m_timer.Enabled = false;
            m_settingsMenuItem.Enabled = false;
            try
            {
                Program.showSettings();
            }
            finally 
            {
                m_timer.Enabled = true;
                m_settingsMenuItem.Enabled = true;
            }
        }
    }
}
