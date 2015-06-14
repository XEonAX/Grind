using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;

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


        public static string ToBase64String(this FlowDocument FD)
        {
            //return XamlWriter.Save(FD);
            TextRange tr = new TextRange(FD.ContentStart, FD.ContentEnd);
            MemoryStream ms = new MemoryStream();
            tr.Save(ms, DataFormats.XamlPackage);

            return Convert.ToBase64String(ms.ToArray());
            //SQLData = ASCIIEncoding.Default.GetString(ms.ToArray());
            //You can save this data to SQLServer 
        }

        public static FlowDocument FlowDocumentFromBase64String(this string data)
        {

            FlowDocument FD = new FlowDocument();//Need to fix Possible MemLeak
            if (data == null) return FD;
            //FD = (FlowDocument)XamlReader.Parse(data);

            byte[] content;
            TextRange tr = new TextRange(FD.ContentStart, FD.ContentEnd);
            //convert string to MemoryStream   
            if (data.StartsWith("{"))
            {
                content = new byte[data.Length + sizeof(char)];
                Buffer.BlockCopy(data.ToCharArray(), 0, content, 0, content.Length);
                MemoryStream ms = new MemoryStream(content);
                tr.Load(ms, DataFormats.Rtf);
            }
            else
            {
                content = Convert.FromBase64String(data);
                MemoryStream ms = new MemoryStream(content);
                tr.Load(ms, DataFormats.XamlPackage);
            }
            return FD;
            //SQLData = ASCIIEncoding.Default.GetString(ms.ToArray());
            //You can save this data to SQLServer 
        }

        public static RootObject Authorize(this RootObject RO)
        {
            if (Globals.Session.token != null)
                RO.token = Globals.Session.token;
            else
            {
                System.Windows.Forms.MessageBox.Show("Please Login");
            }
            return RO;
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
