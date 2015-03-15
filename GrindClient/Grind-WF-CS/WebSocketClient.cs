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

namespace Grind.WF.CS
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
            ws.Connect();
            ws.Send("HOLASD");
            
        }



        private void WebSocketClient_Load(object sender, EventArgs e)
        {
            ws = new WebSocket("ws://localhost:4567/ws?name=asgardian");
            //ws = new WebSocket("ws://localhost:8080/?name=asgardian");

            ws.OnOpen += new EventHandler(ws_OnOpen);
            ws.OnMessage += new EventHandler<MessageEventArgs>(ws_OnMessage);
            ws.OnError += new EventHandler<ErrorEventArgs>(ws_OnError);
            ws.OnClose += new EventHandler<CloseEventArgs>(ws_OnClose);

        }

        void ws_OnClose(object sender, CloseEventArgs e)
        {
            Debug.Print("Closed For");
            Debug.Print(e.Reason);
        }

        void ws_OnError(object sender, ErrorEventArgs e)
        {
            Debug.Print("Errored");
            Debug.Print(e.Message);
        }

        void ws_OnMessage(object sender, MessageEventArgs e)
        {
            Debug.Print("Messaged: " +e.Data);
            //listBox1.Items.Add(e.Data);
        }

        void ws_OnOpen(object sender, EventArgs e)
        {
            Debug.Print("Opened");
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ws.Send(textBox1.Text);
        }
    }
}