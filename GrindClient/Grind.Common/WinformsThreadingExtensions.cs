using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace Grind.Common
{
    public static class WinformsThreadingExtensions
    {
        /// <summary>
        /// Invokes Action on Ui Thread
        /// </summary>
        /// <param name="obj">Control like "Textbox1"</param>
        /// <param name="action">Action like "() => Textbox1.text="Zango";"</param>
        public static void WFUIize(this ISynchronizeInvoke obj,
                                                 MethodInvoker action)
        {
            if (obj.InvokeRequired)
            {
                var args = new object[0];
                obj.Invoke(action, args);
            }
            else
            {
                action();
            }
        }
        //Example:
        //richEditControl1.UIize(() =>
        //{
        //    // Do anything you want with the control here
        //    richEditControl1.RtfText = value;
        //    RtfHelpers.AddMissingStyles(richEditControl1);
        //});
    }
}
