using Grind.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WebSocketSharp;

namespace Grind.WPF.CSharp
{
	/// <summary>
	/// Interaction logic for ChatsControl.xaml
	/// </summary>
	public partial class ChatsControl : UserControl
	{
		public ChatsControl()
		{
			this.InitializeComponent();
		}


        private void btnCon_Click(object sender, RoutedEventArgs e)
        {
            WebsocketService.Init(@"ws://localhost:8080/", Globals.Session.token,
                                    OnOpen,
                                    OnMessage,
                                    OnClose,
                                    OnError);

            WebsocketService.Connect();
        }

        void OnOpen(object sender, EventArgs e)
        {
            Debug.Print("Opened");
        }
        void OnMessage(object sender, MessageEventArgs e)
        {
            WS_DisplayMessage X = new WS_DisplayMessage();
            lbMessages.WPFUIize(() =>
            {
                BindingList<WS_DisplayMessage> LS = (BindingList<WS_DisplayMessage>)lbMessages.ItemsSource;// = new BindingList<WS_DisplayMessage>();
                if (e.Data.StartsWith(@"["))
                    LS = JsonConvert.DeserializeObject<BindingList<WS_DisplayMessage>>(e.Data);
                else
                    if (LS == null)
                    {
                        LS = new BindingList<WS_DisplayMessage>();
                        X = JsonConvert.DeserializeObject<WS_DisplayMessage>(e.Data);
                        LS.Add(X);
                    }
                    else
                    {
                        X = JsonConvert.DeserializeObject<WS_DisplayMessage>(e.Data);
                        LS.Add(X);
                    }
                lbMessages.ItemsSource = LS;
            });
            //if (X.users != null)
            //{ 
            
            //}
        }
        void OnClose(object sender, CloseEventArgs e)
        {
            Debug.Print("Close " + e.Reason);
        }
        void OnError(object sender, WebSocketSharp.ErrorEventArgs e)
        {
            Debug.Print("Errored " + e.Message);
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {

            WebsocketService.Send(JsonConvert.SerializeObject(new WS_Message { sender_id = 1, messagetext = rtbMessage.Document.ToBase64String() }));
        }

        private void btnDis_Click(object sender, RoutedEventArgs e)
        {
            WebsocketService.Close();
        }
	}
}