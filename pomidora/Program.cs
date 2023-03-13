using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Diagnostics;

namespace pomidora
{
    enum State { 
        Initial,
        Allowed,
        Pause,
        Settings,
        Break,
        Postpone,
        Go,
        Quitting
    }
    static class Program
    {
        // settings
        internal static int m_allowedSeconds;
        internal static int m_breakSeconds;
        internal static int m_postponeSeconds;
        internal static int m_numBeeps;
        internal static int m_maxBeeps;
        internal static int m_beepInterval;
        internal static int m_numPostpones;
        internal static int m_maxPostpones;
        internal static int m_penaltyIncrement;
        // current state
        internal static DateTime m_checkpoint = DateTime.Now;
        internal static TimeSpan m_checkpointDelta = TimeSpan.Zero;
        internal static State m_stateToResume = State.Initial;
        internal static State m_state = State.Initial;
        internal static int m_penalty = 0;
        internal static bool m_isClosing = false;

        static MainForm m_mainForm;

        private static int parseTimeString(string str)
        {
            var splitted = str.Trim().Split(new char[] { ':' }, StringSplitOptions.None);
            switch (splitted.Length)
            {
                case 1:
                    return int.Parse(splitted[0]);
                case 2:
                    return int.Parse(splitted[0]) * 60 + int.Parse(splitted[1]);
                default:
                    throw new Exception("parseTimeString: value parse error.");
            }
        }
        internal static void loadSettings()
        {
            m_allowedSeconds = parseTimeString(Properties.Settings.Default.allowedTime);
            m_breakSeconds = parseTimeString(Properties.Settings.Default.breakTime);
            m_postponeSeconds = parseTimeString(Properties.Settings.Default.postponeTime);
            m_beepInterval = parseTimeString(Properties.Settings.Default.beepInterval);
            m_maxBeeps = Properties.Settings.Default.numBeeps * m_beepInterval;
            m_maxPostpones = Properties.Settings.Default.maxPostpones;
            m_penaltyIncrement = parseTimeString(Properties.Settings.Default.postponePenalty);
#if DEBUG
            m_allowedSeconds = 10;
            m_breakSeconds = 7;
            m_postponeSeconds = 7;
            m_penaltyIncrement = 3;
#endif
        }

        internal static Exception logicError() { return new Exception("Program internal logic error."); }
        private static void beep()
        {
            if (m_numBeeps > 0)
            {
                if (m_numBeeps % m_beepInterval == 0)
                    SystemSounds.Beep.Play();
                m_numBeeps--;
            }
        }
        internal static void onTimer()
        {
            var now = DateTime.Now;
            if (m_checkpoint <= now)
            {
                switch (m_state)
                {
                    case State.Allowed:
                    case State.Postpone:
                        m_state = State.Break;
                        m_checkpoint = m_checkpoint.AddSeconds(m_breakSeconds + m_penalty);
                        break;
                    case State.Break:
                        m_state = State.Go;
                        m_numBeeps = m_maxBeeps;
                        m_numPostpones = 0;
                        beep();
                        break;
                    case State.Go:
                        beep();
                        break;
                    default:
                        throw logicError();
                }
            }
        }
        internal static void takeBreak()
        {
            m_state = State.Break;
            m_checkpoint = DateTime.Now.AddSeconds(m_breakSeconds + m_penalty);
        }

        internal static void postpone()
        {
            if (m_numPostpones < m_maxPostpones)
            {
                m_checkpoint = DateTime.Now.AddSeconds(m_postponeSeconds);
                m_penalty += m_penaltyIncrement;
                m_numPostpones++;
                m_state = State.Postpone;
            }
            else
            {
                SystemSounds.Hand.Play();
            }
            m_mainForm.updateState();
        }
        internal static void go()
        {
            m_checkpoint = DateTime.Now.AddSeconds(m_allowedSeconds);
            m_penalty = 0;
            m_state = State.Allowed;
            m_mainForm.updateState();
        }
        internal static void rewind()
        {
            go();
        }
        internal static void pause()
        {
            Debug.Assert(m_state != State.Pause);
            m_checkpointDelta = m_checkpoint - DateTime.Now;
            m_stateToResume = m_state;
            m_state = State.Pause;
        }
        internal static void resume()
        {
            Debug.Assert(m_state == State.Pause);
            m_checkpoint = DateTime.Now + m_checkpointDelta;
            m_state = m_stateToResume;
            m_stateToResume = State.Initial;
        }
        internal static void quit()
        {
            m_isClosing = true;
            Application.Exit();
        }
        internal static void showSettings()
        {
            var diff = (m_checkpoint - DateTime.Now);
            bool settingsChanged = false;
            var oldState = m_state;
            m_state = State.Settings;
            try
            {
                using (var form = new SettingsForm())
                {
                    settingsChanged = (form.ShowDialog() == DialogResult.OK);
                    if (settingsChanged)
                        form.saveSettings();
                }
            }
            finally
            {
                m_state = oldState;
                if (settingsChanged) 
                    loadSettings();
                var now = DateTime.Now;
                m_checkpoint = now + diff;
                var x = now.AddSeconds(m_allowedSeconds);
                if (x < m_checkpoint)
                    m_checkpoint = x;
                m_mainForm.updateState();
            }
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (Environment.OSVersion.Version.Major >= 6)
                SetProcessDPIAware();

            loadSettings();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            m_state = State.Allowed;
            m_checkpoint = DateTime.Now.AddSeconds(m_allowedSeconds);
            m_mainForm = new MainForm();
            Application.Run(m_mainForm);
        }
    }
}
