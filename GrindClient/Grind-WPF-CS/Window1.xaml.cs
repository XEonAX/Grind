using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using mshtml;

namespace Grind_WPF_CS
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            
            webBrowser1.Navigate(AppDomain.CurrentDomain.BaseDirectory + "Blank.htm");
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            webBrowser1.InvokeScript("InitEditor");
            //var doc = webBrowser1.Document as IHTMLDocument2;
            //doc.write("<html><body/></html>");
            //((HTMLBody)doc.body).contentEditable = "true";
        }
    }
}
