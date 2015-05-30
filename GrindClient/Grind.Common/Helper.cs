using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Grind.Common
{
    public static class Helper
    {


        public static string Message;
        public static StatusBarItem xbMessage;
        public static StatusBarItem xbState;
        private static string lastMessage, lastState;
        public static void Init(StatusBarItem sbiMessage, StatusBarItem sbiState, CheckBox chkOffline)
        {
            xbMessage = sbiMessage;
            xbState = sbiState;
            State.xchkOffline = chkOffline;
            if (State.xchkOffline.IsChecked == true) State.IsOnline = false;
        }
        public static void SetMessage(string Message)
        {

            if (xbMessage != null && lastMessage != Message)
                xbMessage.Content = Message + Environment.NewLine + xbMessage.Content;
            lastMessage = Message;
        }

        public static void SetState(string State)
        {
            if (xbState != null && lastState != State)
                xbState.Content = State + Environment.NewLine + xbState.Content;
            lastState = State;
        }


    }

    public static class State
    {
        public static CheckBox xchkOffline;
        private static bool online;

        public static bool IsOnline
        {
            get { return online; }
            set
            {
                if (value)
                {
                    if (xchkOffline != null) xchkOffline.IsChecked = false;
                }
                else
                    if (xchkOffline != null) xchkOffline.IsChecked = true;

                online = value;
            }
        }
    }
}
