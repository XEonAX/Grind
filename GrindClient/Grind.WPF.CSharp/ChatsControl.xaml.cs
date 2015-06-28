using Grind.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
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
        public Session Session;
        internal void SetSession(Session session)
        {
            Session = session;
        }
        Table msgTable;
        TableRowGroup TX;
        HashSet<string> Targets = new HashSet<string>();
        string tempname;
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //rtbMessages.Document.Blocks.Add(new Paragraph());
            msgTable = new Table();
            rtbMessages.Document.Blocks.Add(msgTable);
            msgTable.CellSpacing = 10;
            msgTable.Background = Brushes.White;
            msgTable.RowGroups.Add(new TableRowGroup());
            TX = msgTable.RowGroups[0];
        }

        void PrintMessage(DateTime TimeStamp, string Name, string Message, eWsMessageType MsgType)
        {

            rtbMessages.WPFUIize(() =>
                {
                    TableRow msgStartRow = new TableRow();
                    TableRow msgContentRow = new TableRow();


                    //TableCell nameCell = new TableCell(new Paragraph(new Run(Name)));
                    TableCell TimestampAndNameCell = new TableCell(new Paragraph(new Run("[" + TimeStamp.ToString() + "]<" + Name + ">")));
                    TableCell msgCell = new TableCell(new Paragraph(new Run(Message)));
                    //msgCell.ColumnSpan = 2;
                    switch (MsgType)
                    {
                        case eWsMessageType.PublicMsg:
                            TimestampAndNameCell.Foreground = Brushes.CadetBlue;
                            break;
                        case eWsMessageType.PrivateMsg:
                            TimestampAndNameCell.Foreground = Brushes.Chocolate;
                            msgStartRow.Background = Brushes.Honeydew;
                            msgContentRow.Background = Brushes.Honeydew;
                            TimestampAndNameCell.BorderThickness = new Thickness(1);
                            TimestampAndNameCell.BorderBrush = Brushes.Violet;
                            msgCell.BorderThickness = new Thickness(1);
                            msgCell.BorderBrush = Brushes.Violet;
                            break;
                        case eWsMessageType.HistoryMsg:
                            TimestampAndNameCell.Foreground = Brushes.DarkGray;
                            msgCell.Foreground = Brushes.Gray;
                            msgStartRow.Background = Brushes.Linen;
                            msgContentRow.Background = Brushes.Linen;
                            msgStartRow.FontSize -= 1;
                            msgContentRow.FontSize -= 1;
                            break;
                        case eWsMessageType.ErrorMsg:
                            TimestampAndNameCell.Foreground = Brushes.DarkRed;
                            msgCell.Foreground = Brushes.Red;
                            break;
                        case eWsMessageType.ServerMsg:
                            TimestampAndNameCell.Foreground = Brushes.CadetBlue;
                            break;
                        case eWsMessageType.XMsg:
                            break;
                        case eWsMessageType.YMsg:
                            break;
                        case eWsMessageType.ZMsg:
                            break;
                        default:
                            break;
                    }
                    //msgStartRow.Cells.Add(nameCell);
                    msgStartRow.Cells.Add(TimestampAndNameCell);
                    msgContentRow.Cells.Add(msgCell);

                    TX.Rows.Add(msgStartRow);
                    TX.Rows.Add(msgContentRow);
                    rtbMessages.ScrollToEnd();
                });



        }


        private void btnCon_Click(object sender, RoutedEventArgs e)
        {
            Session.WebsocketService.BindAndAuthenticate(Session.User.token,
                                    OnOpen,
                                    OnMessage,
                                    OnClose,
                                    OnError);

            Session.WebsocketService.Connect();
        }

        void OnOpen(object sender, EventArgs e)
        {
            Debug.Print("Opened");
        }
        void OnMessage(object sender, MessageEventArgs e)
        {
            WS_Message wsMsg = JsonConvert.DeserializeObject<WS_Message>(e.Data);
            if (wsMsg.messages != null)
            {
                foreach (WS_Message Msg in wsMsg.messages)
                {
                    PrintMessage(Msg.created_at, Globals.GetPersonNameFromId(Msg.sender_id), Msg.messagetext, eWsMessageType.HistoryMsg);
                }
            }
            else
            {
                if (wsMsg.sender_id == 0 && wsMsg.receiver_id == 0)
                {
                    PrintMessage(wsMsg.created_at, "Server", wsMsg.messagetext, eWsMessageType.ServerMsg);
                }
                else if (wsMsg.sender_id != 0 && wsMsg.receiver_id == 0)
                {
                    PrintMessage(wsMsg.created_at, Globals.GetPersonNameFromId(wsMsg.sender_id), wsMsg.messagetext, eWsMessageType.PublicMsg);
                }
                else if (wsMsg.sender_id == 0 && wsMsg.receiver_id != 0)
                {
                    PrintMessage(wsMsg.created_at, "Server=>" + Globals.GetPersonNameFromId(wsMsg.receiver_id), wsMsg.messagetext, eWsMessageType.PrivateMsg);
                }
                else if (wsMsg.sender_id != 0 && wsMsg.receiver_id != 0)
                {
                    PrintMessage(wsMsg.created_at, Globals.GetPersonNameFromId(wsMsg.sender_id) + "=>" + Globals.GetPersonNameFromId(wsMsg.receiver_id), wsMsg.messagetext, eWsMessageType.PrivateMsg);
                }
            }
            if (wsMsg.users != null)
            {
                lbOnlinePeople.WPFUIize(() => lbOnlinePeople.ItemsSource = wsMsg.users);
            }

        }
        void OnClose(object sender, CloseEventArgs e)
        {
            Debug.Print("Close " + e.Reason);
            try
            {

                JToken.Parse(e.Reason);
                RootObject RO = JsonConvert.DeserializeObject<RootObject>(e.Reason);
                if (RO.Error != null)
                {
                    PrintMessage(DateTime.Now, "Server", RO.Error, eWsMessageType.ErrorMsg);
                }
            }
            catch (Exception Ex)
            {

            }
        }
        void OnError(object sender, WebSocketSharp.ErrorEventArgs e)
        {
            Debug.Print("Errored " + e.Message);
            try
            {
                JToken.Parse(e.Message);
                RootObject RO = JsonConvert.DeserializeObject<RootObject>(e.Message);
                if (RO.Error != null)
                {
                    PrintMessage(DateTime.Now, "Server", RO.Error, eWsMessageType.ErrorMsg);
                }
            }
            catch (Exception Ex)
            {

            }


        }



        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            if (Targets.Count > 0)
            {
                tempname = "";
                foreach (string item in Targets)
                {
                    tempname += Globals.DictTrigramToPerson[item].name + Environment.NewLine;
                }
                mniTargets.Header = tempname.Trim();
                ppSend.IsOpen = true;
            }
            else
            {
                Session.WebsocketService.Send(JsonConvert.SerializeObject(new WS_Message { sender_id = Session.User.id, messagetext = txtMessage.Text }));
                txtMessage.Text = "";
            }
        }

        private void btnDis_Click(object sender, RoutedEventArgs e)
        {
            Session.WebsocketService.Close();
            lbOnlinePeople.ItemsSource = null;
            btnSend.IsEnabled = false;
            btnDisc.IsEnabled = false;
        }

        private void mbiSendMsg_Click(object sender, RoutedEventArgs e)
        {
        }

        private void txtMessage_TextChanged(object sender, TextChangedEventArgs e)
        {
            Targets.Clear();
            //foreach (Match item in Regex.Matches(txtMessage.GetLineText(0), @"\B@[a-z0-9_-]+"))
            foreach (Match item in Regex.Matches(txtMessage.GetLineText(0), @"(?<=@)[a-z0-9_-]+"))
                if (item.Length >= 3)
                    if (Globals.DictTrigramToPerson.ContainsKey(item.Value))
                        Targets.Add(item.Value);
        }

        private void mniPersonalMsg_Click(object sender, RoutedEventArgs e)
        {
            if (Targets.Count > 0)
            {
                foreach (string item in Targets)
                {
                    Session.WebsocketService.Send(JsonConvert.SerializeObject(new WS_Message { sender_id = Session.User.id, messagetext = txtMessage.Text, receiver_id = Globals.GetPersonFromTrigram(item).id}));
                }
            }
            txtMessage.Text = "";
        }

        private void mniPublicMsg_Click(object sender, RoutedEventArgs e)
        {
            Session.WebsocketService.Send(JsonConvert.SerializeObject(new WS_Message { sender_id = Session.User.id, messagetext = txtMessage.Text }));
            txtMessage.Text = "";
        }
    }
}