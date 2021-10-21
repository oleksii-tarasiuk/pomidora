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
            var now = DateTime.Now;
            var diff = (Program.m_state != State.Pause)
                ? Program.m_checkpoint - now
                : Program.m_checkpointDelta;
            var str = $"{diff.Minutes:00}:{diff.Seconds:00}";
            switch (Program.m_state)
            {
                case State.Break:
                    m_timerLabel.Text = str;
                    break;
                case State.Pause:
                    m_notifyIcon.Text = str + " (paused)";
                    break;
                default:
                    m_notifyIcon.Text = str;
                    break;
            }

            switch (Program.m_state) 
            {
                case State.Break:
                    m_freezeMenuItem.Enabled = true;
                    m_resumeMenuItem.Enabled = false;
                    m_goButton.Hide();
                    m_panel.Top = (Height - m_panel.Height) / 2;
                    m_panel.Left = (Width - m_panel.Width) / 2;
                    m_panel.Show();
                    m_postponeButton.Enabled = (Program.m_numPostpones < Program.m_maxPostpones);
                    Show();
                    break;
                case State.Go:
                    m_freezeMenuItem.Enabled = true;
                    m_resumeMenuItem.Enabled = false;
                    m_panel.Hide();
                    m_goButton.SetBounds(
                        m_panel.Left, m_panel.Top, m_panel.Width, m_panel.Height
                    );
                    m_goButton.Show();
                    break;
                case State.Pause:
                    m_freezeMenuItem.Enabled = false;
                    m_resumeMenuItem.Enabled = true;
                    break;
                default:
                    m_freezeMenuItem.Enabled = true;
                    m_resumeMenuItem.Enabled = false;
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
            if (Program.m_state == State.Pause)
                return;
            Program.onTimer();
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

        private void BreakMenuItem_Click(object sender, EventArgs e)
        {
            Program.takeBreak();
        }

        private void RewindMenuItem_Click(object sender, EventArgs e)
        {
            Program.rewind();
        }

        private void FreezeMenuItem_Click(object sender, EventArgs e)
        {
            Program.pause();
            updateState();
        }

        private void ResumeMenuItem_Click(object sender, EventArgs e)
        {
            Program.resume();
            updateState();
        }
    }
}
