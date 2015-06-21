using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Grind.Common
{
    public static class WPFThreadingExtensions
    {
        /// <summary>
        /// Simple helper extension method to marshall to correct
        /// thread if its required
        /// </summary>
        /// <param name="control">The source control</param>
        /// <param name="methodcall">The method to call</param>
        /// <param name="priorityForCall">The thread priority</param>
        public static void WPFUIize(
            this DispatcherObject control,
            Action methodcall,
            DispatcherPriority priorityForCall=DispatcherPriority.ApplicationIdle)
        {
            //see if we need to Invoke call to Dispatcher thread
            if (control.Dispatcher.Thread != Thread.CurrentThread)
                control.Dispatcher.Invoke(priorityForCall, methodcall);
            else
                methodcall();
        }
        //this.InvokeIfRequired(() =>
        //{
        //    lstItems.Items.Add(
        //        String.Format(“Count {0}”, currentCount));
        //},
        //    DispatcherPriority.Background);

    }
}
