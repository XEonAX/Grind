using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Documents;
using System.IO;
using System.Windows.Markup;
using System.Windows.Threading;
using System.Threading;
namespace Grind.Common
{

    public static class Globals
    {
        public static RootObject rootObject;
        public static List<Person> People = new List<Person>();
        public static Session Session = new Session();


        internal static void Deauthorize()
        {
            System.Windows.Forms.MessageBox.Show("Invalid Token. Re-Login!!","Forbidden",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
            Session.token = "";
        }
    }


}
