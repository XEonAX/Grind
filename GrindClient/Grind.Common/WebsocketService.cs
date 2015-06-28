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
    public class WebsocketService
    {
        public WebSocket ws;
        public EventHandler wsOnOpen;
        public EventHandler<MessageEventArgs> wsOnMessage;
        public EventHandler<CloseEventArgs> wsOnClose;
        public EventHandler<ErrorEventArgs> wsOnError;
        private Action<eAction, object, object, object> callbackFn;
        private string WebSocketServiceEndpointUrl;
        private Callbacker Callbacker;

        public WebsocketService(string WebSocketServiceEndpointUrl, Callbacker Callbacker)
        {
            // TODO: Complete member initialization
            this.WebSocketServiceEndpointUrl = WebSocketServiceEndpointUrl;
            this.Callbacker = Callbacker;
        }
        private void callbackFunction(eAction action, object obj1 = null, object obj2 = null, object obj3 = null)
        {
            if (callbackFn == null) throw new NullReferenceException();
            callbackFn(action, obj1, obj2, obj3);
        }
        public void BindAndAuthenticate(string token,
                                EventHandler OnOpen,
                                EventHandler<MessageEventArgs> OnMessage,
                                EventHandler<CloseEventArgs> OnClose,
                                EventHandler<ErrorEventArgs> OnError)
        {
            if (ws != null && ws.IsAlive)
            {
                ws.Close();
            }
            ws = new WebSocket(WebSocketServiceEndpointUrl);//ws://localhost:8080/?name=
            if (token == null) token = "";
            ws.SetCookie(new WebSocketSharp.Net.Cookie("token", token));
            ws.OnOpen += new EventHandler(OnOpen);
            ws.OnMessage += new EventHandler<MessageEventArgs>(OnMessage);
            ws.OnClose += new EventHandler<CloseEventArgs>(OnClose);
            ws.OnError += new EventHandler<ErrorEventArgs>(OnError);
            ws.Connect();
        }
        public void Init(string path,
                        string id)
        {
            if (ws != null && ws.IsAlive)
                ws.Close();
            ws = new WebSocket(path + id);//ws://localhost:8080/?name=
            ws.OnOpen += new EventHandler(ws_OnOpen);
            ws.OnMessage += new EventHandler<MessageEventArgs>(ws_OnMessage);
            ws.OnClose += new EventHandler<CloseEventArgs>(ws_OnClose);
            ws.OnError += new EventHandler<ErrorEventArgs>(ws_OnError);
        }

        void ws_OnOpen(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        void ws_OnMessage(object sender, MessageEventArgs e)
        {
            throw new NotImplementedException();
        }
        void ws_OnClose(object sender, CloseEventArgs e)
        {
            throw new NotImplementedException();
        }
        void ws_OnError(object sender, ErrorEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Send(string data)
        {
            ws.Send(data);
        }

        public void SendAsync(string data, Action<bool> action)
        {
            ws.SendAsync(data, action);
        }

        public void Connect()
        {
            if (!ws.IsAlive)
                ws.Connect();
        }

        public void Close()
        {
            ws.CloseAsync();
        }

    }
}
