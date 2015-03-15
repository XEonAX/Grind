using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Documents;
using System.IO;
namespace Grind.Common
{
    public class Globals
    {
        public static RootObject rootObject;
        public static List<Person> People;
        public Globals()
        {
            People = new List<Person>();
        }

        public static string WPFRichTextToXamlPackage(FlowDocument FD)
        {
            TextRange tr = new TextRange(FD.ContentStart, FD.ContentEnd);
            MemoryStream ms = new MemoryStream();
            tr.Save(ms, DataFormats.XamlPackage);
            return Convert.ToBase64String(ms.ToArray());
            //SQLData = ASCIIEncoding.Default.GetString(ms.ToArray());
            //You can save this data to SQLServer 
        }

        public static FlowDocument  XamlPackageToWPFRichText(string data)
        {   
            
            FlowDocument FD = new FlowDocument();//Need to fix Possible MemLeak
            if (data == null) return FD;
            byte[] content = Convert.FromBase64String(data);
            
            TextRange tr = new TextRange(FD.ContentStart, FD.ContentEnd);
            //convert string to MemoryStream 
            MemoryStream ms =new MemoryStream(content);
            tr.Load(ms, DataFormats.XamlPackage);
            return FD;
            //SQLData = ASCIIEncoding.Default.GetString(ms.ToArray());
            //You can save this data to SQLServer 
        }


    }
}
