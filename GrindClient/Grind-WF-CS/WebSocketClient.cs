using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using WebSocketSharp;
using System.Diagnostics;

namespace Grind_WF_CS
{
    public partial class WebSocketClient : Form
    {
        public WebSocketClient()
        {
            InitializeComponent();
        }



        WebSocket ws;


        private void button1_Click(object sender, EventArgs e)
        {
            ws.Send("HOLASD");
            
        }



        private void WebSocketClient_Load(object sender, EventArgs e)
        {
            ws = new WebSocket("ws://localhost:4567/ws");
            ws.OnOpen += new EventHandler(ws_OnOpen);
            ws.OnMessage += new EventHandler<MessageEventArgs>(ws_OnMessage);
            ws.OnError += new EventHandler<ErrorEventArgs>(ws_OnError);
            ws.OnClose += new EventHandler<CloseEventArgs>(ws_OnClose);
            ws.Connect();
        }

        void ws_OnClose(object sender, CloseEventArgs e)
        {
            Debug.Print("Closed");
        }

        void ws_OnError(object sender, ErrorEventArgs e)
        {
            Debug.Print("Errored");
        }

        void ws_OnMessage(object sender, MessageEventArgs e)
        {
            Debug.Print("Messaged: " +e.Data);
        }

        void ws_OnOpen(object sender, EventArgs e)
        {
            Debug.Print("Opened");
        }
    }
}