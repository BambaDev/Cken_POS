using System;
using System.Windows.Forms;

namespace cypos
{
    public class SessionManager : IMessageFilter
    {
        private static SessionManager _instance;
        private DateTime _lastActivity;
        private Timer _timer;
        private int _timeoutMinutes;
        private Form _mainForm;
        private bool _locked;

        public static SessionManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SessionManager();
                return _instance;
            }
        }

        public bool IsLocked { get { return _locked; } }

        public void Start(Form mainForm, int timeoutMinutes = 15)
        {
            _mainForm = mainForm;
            _timeoutMinutes = timeoutMinutes;
            _lastActivity = DateTime.Now;
            _locked = false;

            Application.AddMessageFilter(this);

            _timer = new Timer();
            _timer.Interval = 30000; // check every 30 seconds
            _timer.Tick += CheckTimeout;
            _timer.Start();
        }

        public void Stop()
        {
            if (_timer != null)
            {
                _timer.Stop();
                _timer.Dispose();
                _timer = null;
            }
            Application.RemoveMessageFilter(this);
        }

        public bool PreFilterMessage(ref Message m)
        {
            // WM_MOUSEMOVE, WM_KEYDOWN, WM_LBUTTONDOWN
            if (m.Msg == 0x0200 || m.Msg == 0x0100 || m.Msg == 0x0201)
            {
                _lastActivity = DateTime.Now;
            }
            return false;
        }

        private void CheckTimeout(object sender, EventArgs e)
        {
            if (_locked)
                return;

            TimeSpan idle = DateTime.Now - _lastActivity;
            if (idle.TotalMinutes >= _timeoutMinutes)
            {
                LockSession();
            }
        }

        private void LockSession()
        {
            _locked = true;
            _timer.Stop();

            AuditLog.Log("SESSION_TIMEOUT", string.Format("User {0} timed out after {1} min", UserInfo.UserName, _timeoutMinutes));

            if (_mainForm != null && !_mainForm.IsDisposed)
            {
                _mainForm.Invoke((MethodInvoker)delegate
                {
                    Stop();
                    _mainForm.Hide();
                    frmLogin loginForm = new frmLogin();
                    loginForm.Show();
                    _mainForm.Close();
                });
            }
        }

        public void ResetTimeout()
        {
            _lastActivity = DateTime.Now;
        }
    }
}
