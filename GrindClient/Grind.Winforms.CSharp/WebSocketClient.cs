using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Grind.Common;
using WebSocketSharp;
using System.Diagnostics;
using Newtonsoft.Json;

namespace Grind.Winforms.CSharp
{
    public partial class WebSocketClient : Form
    {

        public class Msg
        {
            public string nickname { get; set; }
            public string message { get; set; }
            public DateTime timestamp { get; set; }   
        }

        public WebSocketClient()
        {
            InitializeComponent();
        }

        WebSocket ws;

        private void button1_Click(object sender, EventArgs e)
        {
            ws = new WebSocket("ws://localhost:8080/?name=" + txtName.Text);

            ws.OnOpen += new EventHandler(ws_OnOpen);
            ws.OnMessage += new EventHandler<MessageEventArgs>(ws_OnMessage);
            ws.OnError += new EventHandler<ErrorEventArgs>(ws_OnError);
            ws.OnClose += new EventHandler<CloseEventArgs>(ws_OnClose);
            ws.Connect();

        }



        private void WebSocketClient_Load(object sender, EventArgs e)
        {
            //ws = new WebSocket("ws://localhost:4567/ws?name=asgardian");
        }

        void ws_OnClose(object sender, CloseEventArgs e)
        {
            Debug.Print("Closed For" + e.Reason);
            listBox1.UIize(() => listBox1.Items.Add("Errored: " + e.Reason));
        }

        void ws_OnError(object sender, ErrorEventArgs e)
        {
            Debug.Print("Errored");
            listBox1.UIize(() => listBox1.Items.Add("Errored: " + e.Message));
        }

        void ws_OnMessage(object sender, MessageEventArgs e)
        {
            Debug.Print("Messaged: " + e.Data);
            listBox1.UIize(() => listBox1.Items.Add("New message: " + e.Data));
        }

        void ws_OnOpen(object sender, EventArgs e)
        {
            Debug.Print("Opened");
            listBox1.UIize(() => listBox1.Items.Add("Opened"));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ws.Send(JsonConvert.SerializeObject(new Msg {nickname=txtName.Text,message=txtMessage.Text}));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ws.Close(CloseStatusCode.Normal, "Zango");

        }
    }
}