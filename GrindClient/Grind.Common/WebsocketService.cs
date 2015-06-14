using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using Newtonsoft.Json;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Controls;


namespace Grind.Common
{
    public static class WebsocketService
    {
        public static WebSocket ws;
        public static EventHandler wsOnOpen;
        public static EventHandler<MessageEventArgs> wsOnMessage;
        public static EventHandler<CloseEventArgs> wsOnClose;
        public static EventHandler<ErrorEventArgs> wsOnError;
        public static void Init(string path, string token,
                                EventHandler OnOpen,
                                EventHandler<MessageEventArgs> OnMessage,
                                EventHandler<CloseEventArgs> OnClose,
                                EventHandler<ErrorEventArgs> OnError)
        {
            if (ws != null)
            {
                ws.Close();
            }
            ws = new WebSocket(path);//ws://localhost:8080/?name=
            if (token == null) token = "";
            ws.SetCookie(new WebSocketSharp.Net.Cookie("token", token));
            ws.OnOpen += new EventHandler(OnOpen);
            ws.OnMessage += new EventHandler<MessageEventArgs>(OnMessage);
            ws.OnClose += new EventHandler<CloseEventArgs>(OnClose);
            ws.OnError += new EventHandler<ErrorEventArgs>(OnError);
        }
        public static void Init(string path,
                        string id)
        {
            if (ws != null) return;
            ws = new WebSocket(path + id);//ws://localhost:8080/?name=
            ws.OnOpen += new EventHandler(ws_OnOpen);
            ws.OnMessage += new EventHandler<MessageEventArgs>(ws_OnMessage);
            ws.OnClose += new EventHandler<CloseEventArgs>(ws_OnClose);
            ws.OnError += new EventHandler<ErrorEventArgs>(ws_OnError);
        }

        static void ws_OnOpen(object sender, EventArgs e)
        {
            
        }
        static void ws_OnMessage(object sender, MessageEventArgs e)
        {
           
        }
        static void ws_OnClose(object sender, CloseEventArgs e)
        {
        }
        static void ws_OnError(object sender, ErrorEventArgs e)
        {
        }

        public static void Send(string data)
        {
            ws.Send(data);
        }

        public static void SendAsync(string data, Action<bool> action)
        {
            ws.SendAsync(data,action);
        }

        public static void Connect()
        {
            if (!ws.IsAlive)
                ws.Connect();     
        }

        public static void Close()
        {
            ws.CloseAsync();
        }

    }
}
