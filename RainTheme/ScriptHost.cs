using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Browser;

namespace RainTheme
{
    
    public class ScriptHost
    {
        private Action _navUp;
        private Action _navDown;
        private Action _navLeft;
        private Action _navRight;
        private Action _navBack;
        private Action _navForward;
        private Action _onExitEmulator;
        public ScriptHost(Action navUp, Action navDown, Action navLeft, Action navRight,
            Action navForward, Action navBackward, Action onExitEmulator)
        {
            _navUp = navUp;
            _navDown = navDown;
            _navLeft = navLeft;
            _navRight = navRight;
            _navBack = navBackward;
            _navForward = navForward;
            _onExitEmulator = onExitEmulator;
        }

        [ScriptableMember]
        public void NavUp()
        {
            
            _navUp();
        }
        [ScriptableMember]
        public void NavDown()
        {
            _navDown();
        }
        [ScriptableMember]
        public void NavLeft()
        {
            _navLeft();
        }
        [ScriptableMember]
        public void NavRight()
        {
            _navRight();
        }
        [ScriptableMember]
        public void NavBack()
        {
            _navBack();
        }
        [ScriptableMember]
        public void NavForward()
        {
            _navForward();
        }
        [ScriptableMember]
        public void OnExitEmulator()
        {
            _onExitEmulator();
        }
    }
}
