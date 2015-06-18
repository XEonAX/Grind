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
            rtbMessages.WPFUIize(() =>
            {
                rtbMessages.Document.Blocks.Add(new Paragraph(new Run("Zango")));
                Table table1 = new Table();
                // ...and add it to the FlowDocument Blocks collection.
                rtbMessages.Document.Blocks.Add(table1);


                // Set some global formatting properties for the table.
                table1.CellSpacing = 10;
                table1.Background = Brushes.White;
                table1.Columns.Add(new TableColumn());
                table1.Columns[0].Width = new GridLength(100, GridUnitType.Pixel);
                table1.Columns.Add(new TableColumn());
                table1.Columns[1].Width = new GridLength(1, GridUnitType.Auto);

                // = new BindingList<WS_DisplayMessage>();// = (BindingList<WS_DisplayMessage>)lbMessages.ItemsSource;// = new BindingList<WS_DisplayMessage>();
                if (e.Data.StartsWith(@"["))
                {
                    List<WS_DisplayMessage> LS = JsonConvert.DeserializeObject<List<WS_DisplayMessage>>(e.Data);
                    foreach (WS_DisplayMessage item in LS)
                    {
                        TableRowGroupCollection TRC = tableMessages.RowGroups;
                        table1.RowGroups.Add(new TableRowGroup());
                        TableRowGroup TX = table1.RowGroups[0];
                        TableRow TR1 = new TableRow();
                        TableRow TR2 = new TableRow();
                        

                        TableCell nameCell = new TableCell(new Paragraph(new Run(item.sender_name)));
                        TableCell timestampCell = new TableCell(new Paragraph(new Run(item.created_at.ToString())));
                        TableCell msgCell = new TableCell((Paragraph)XamlReader.Parse(XamlWriter.Save(item.flow_message.Blocks.FirstBlock)));
                        //msgCell.Blocks.AddRange(item.flow_message.Blocks);
                        msgCell.RowSpan = 2;

                        TR1.Cells.Add(nameCell);
                        TR1.Cells.Add(msgCell);
                        TR2.Cells.Add(timestampCell);
                        TX.Rows.Add(TR1);
                        TX.Rows.Add(TR2);
                    }
                }
                else
                    //if (LS == null)
                    {
                        //LS = new BindingList<WS_DisplayMessage>();
                        X = JsonConvert.DeserializeObject<WS_DisplayMessage>(e.Data);
                        TableRowGroupCollection TRC = tableMessages.RowGroups;
                        TableRowGroup TX = new TableRowGroup();
                        TableRow TR1 = new TableRow();
                        TableRow TR2 = new TableRow();
                        TX.Rows.Add(TR1);
                        TX.Rows.Add(TR2);
                        TableCell nameCell = new TableCell(new Paragraph(new Run(X.sender_name)));
                        TableCell tsCell = new TableCell(new Paragraph(new Run(X.created_at.ToLongDateString())));
                        TableCell msgCell = new TableCell();
                        if (X.sender_id != 0)
                            msgCell.Blocks.AddRange(X.flow_message.Blocks);
                        else
                            msgCell.Blocks.Add(new Paragraph(new Run(X.messagetext)));
                        msgCell.RowSpan = 2;
                        TR1.Cells.Add(nameCell);
                        TR1.Cells.Add(msgCell);
                        TR2.Cells.Add(tsCell);
                        //LS.Add(X);
                    }
                    //else
                    //{
                    //    X = JsonConvert.DeserializeObject<WS_DisplayMessage>(e.Data);
                    //    TableRowCollection TRC = new TableRowCollection();
                    //    TableRow TR1 = new TableRow();
                    //    TableRow TR2 = new TableRow();
                    //    TRC.Add(TR1);
                    //    TRC.Add(TR2);
                    //    TableCell nameCell = new TableCell(new Paragraph(new Run(item.sender_name)));
                    //    TableCell tsCell = new TableCell(new Paragraph(new Run(item.created_at.ToLongDateString())));
                    //    TableCell msgCell = new TableCell();
                    //    msgCell.Blocks.AddRange(item.flow_message.Blocks);
                    //    msgCell.RowSpan = 2;
                    //    TR1.Cells.Add(nameCell);
                    //    TR1.Cells.Add(msgCell);
                    //    TR2.Cells.Add(tsCell);
                    //    //LS.Add(X);
                    //}
                //lbMessages.ItemsSource = LS;
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