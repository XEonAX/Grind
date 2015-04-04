using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Documents;
using System.IO;
using System.Windows.Markup;
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

        //public static string WPFRichTextToXamlPackage(FlowDocument FD)
        //{
        //    //return XamlWriter.Save(FD);
        //    TextRange tr = new TextRange(FD.ContentStart, FD.ContentEnd);
        //    MemoryStream ms = new MemoryStream();
        //    tr.Save(ms, DataFormats.Xaml);

        //    return Convert.ToBase64String(ms.ToArray());
        //    //SQLData = ASCIIEncoding.Default.GetString(ms.ToArray());
        //    //You can save this data to SQLServer 
        //}

        //public static FlowDocument XamlPackageToWPFRichText(string data)
        //{

        //    FlowDocument FD = new FlowDocument();//Need to fix Possible MemLeak
        //    if (data == null) return FD;
        //    //FD = (FlowDocument)XamlReader.Parse(data);

        //    byte[] content;
        //    TextRange tr = new TextRange(FD.ContentStart, FD.ContentEnd);
        //    //convert string to MemoryStream   
        //    if (data.StartsWith("{"))
        //    {
        //        content = new byte[data.Length + sizeof(char)];
        //        Buffer.BlockCopy(data.ToCharArray(), 0, content, 0, content.Length);
        //        MemoryStream ms = new MemoryStream(content);
        //        tr.Load(ms, DataFormats.Rtf);
        //    }
        //    else
        //    {
        //        content = Convert.FromBase64String(data);
        //        MemoryStream ms = new MemoryStream(content);
        //        tr.Load(ms, DataFormats.Xaml);
        //    }



        //    return FD;
        //    //SQLData = ASCIIEncoding.Default.GetString(ms.ToArray());
        //    //You can save this data to SQLServer 
        //}


    }
}
