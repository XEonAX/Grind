using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Design.PluralizationServices;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Threading;
using System.Reflection;
using System.Collections;
using System.Data;
namespace Grind.Common
{
    public static class Extensions
    {

        public static Hashtable reflectionProperties = new Hashtable();
        public static Hashtable reflectionDBTypeProperties = new Hashtable();
        public static string Pluralize(this string s)
        {
            PluralizationService plural =
                PluralizationService.CreateService(
                    CultureInfo.GetCultureInfo("en-us"));
            return plural.Pluralize(s);
        }



        public static string ToBase64String(this FlowDocument FD)
        {
            //return XamlWriter.Save(FD);
            TextRange tr = new TextRange(FD.ContentStart, FD.ContentEnd);
            MemoryStream ms = new MemoryStream();
            tr.Save(ms, System.Windows.DataFormats.XamlPackage);

            return Convert.ToBase64String(ms.ToArray());
            //SQLData = ASCIIEncoding.Default.GetString(ms.ToArray());
            //You can save this data to SQLServer 
        }

        public static FlowDocument FlowDocumentFromBase64String(this string data)
        {

            FlowDocument FD = new FlowDocument();//Need to fix Possible MemLeak
            if (data == null) return FD;
            //FD = (FlowDocument)XamlReader.Parse(data);

            byte[] content;
            TextRange tr = new TextRange(FD.ContentStart, FD.ContentEnd);
            //convert string to MemoryStream   
            if (data.StartsWith("{"))
            {
                content = new byte[data.Length + sizeof(char)];
                Buffer.BlockCopy(data.ToCharArray(), 0, content, 0, content.Length);
                MemoryStream ms = new MemoryStream(content);
                tr.Load(ms, System.Windows.DataFormats.Rtf);
            }
            else
            {
                content = Convert.FromBase64String(data);
                MemoryStream ms = new MemoryStream(content);
                tr.Load(ms, System.Windows.DataFormats.XamlPackage);
            }
            return FD;
            //SQLData = ASCIIEncoding.Default.GetString(ms.ToArray());
            //You can save this data to SQLServer 
        }




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






        /// <summary>
        /// Simple helper extension method to marshall to correct
        /// thread if its required
        /// </summary>
        /// <param name="control">The source control like "Textbox1"</param>
        /// <param name="methodcall">The method to call like "() => Textbox1.text="Zango";"</param>
        /// <param name="priorityForCall">The thread priority</param>
        public static void WPFUIize(
            this DispatcherObject control,
            Action methodcall,
            DispatcherPriority priorityForCall = DispatcherPriority.ApplicationIdle)
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




        public static DbType DataTypetoDBType(string DataType)
        {
            switch (DataType)
            {
                case "byte": return DbType.Byte;
                case "sbyte": return DbType.SByte;
                case "short": return DbType.Int16;
                case "ushort": return DbType.UInt16;
                case "int": return DbType.Int32;
                case "uint": return DbType.UInt32;
                case "long": return DbType.Int64;
                case "ulong": return DbType.UInt64;
                case "float": return DbType.Single;
                case "double": return DbType.Double;
                case "decimal": return DbType.Decimal;
                case "bool": return DbType.Boolean;
                case "string": return DbType.String;
                case "char": return DbType.StringFixedLength;
                case "Guid": return DbType.Guid;
                case "DateTime": return DbType.DateTime;
                case "DateTimeOffset": return DbType.DateTimeOffset;
                case "byte[]": return DbType.Binary;
                case "byte?": return DbType.Byte;
                case "sbyte?": return DbType.SByte;
                case "short?": return DbType.Int16;
                case "ushort?": return DbType.UInt16;
                case "int?": return DbType.Int32;
                case "uint?": return DbType.UInt32;
                case "long?": return DbType.Int64;
                case "ulong?": return DbType.UInt64;
                case "float?": return DbType.Single;
                case "double?": return DbType.Double;
                case "decimal?": return DbType.Decimal;
                case "bool?": return DbType.Boolean;
                case "char?": return DbType.StringFixedLength;
                case "Guid?": return DbType.Guid;
                case "DateTime?": return DbType.DateTime;
                case "DateTimeOffset?": return DbType.DateTimeOffset;
                case "System.Data.Linq.Binary": return DbType.Binary;
                default: return DbType.Object;
            }
        }


        /// <summary>
        /// Caches PropertyInfo of given Datatype to a HashTable for better performance.
        /// </summary>
        /// <param name="targetType">DataType who's PropertyInfo is to be Cached</param>
        public static void LoadProperties(Type targetType)
        {
            if (reflectionProperties[targetType.FullName] == null)
            {
                List<PropertyInfo> propertyList = new List<PropertyInfo>();
                PropertyInfo[] objectProperties = targetType.GetProperties(/*BindingFlags.Public*/);
                foreach (PropertyInfo currentProperty in objectProperties)
                {
                    if (reflectionDBTypeProperties[currentProperty.Name] == null)
                        reflectionDBTypeProperties.Add(currentProperty.Name,
                            DataTypetoDBType(currentProperty.PropertyType.ToString()));
                    //propertyList.Add(currentProperty);
                }
                reflectionProperties.Add(targetType.FullName, objectProperties.ToList<PropertyInfo>());
                //reflectionproperties[targetObject] = propertyList;
            }
        }



        //public static TaskListItem AsTaskListItem(this Task task)
        //{
        //    var dsttype = typeof(TaskListItem);
        //    var srctype = typeof(Task);
        //    LoadProperties(dsttype);
        //    LoadProperties(srctype);
        //    var instance = Activator.CreateInstance(dsttype);

        //    List<PropertyInfo> dstproperties = reflectionProperties[dsttype.FullName] as List<PropertyInfo>;
        //    List<PropertyInfo> srcproperties = reflectionProperties[srctype.FullName] as List<PropertyInfo>;

        //    foreach (var property in dstproperties)
        //        if (property.CanWrite && srcproperties.Contains(property))
        //        {
        //            property.SetValue(instance, property.GetValue(task, null), null);
        //        }
        //    return (TaskListItem)instance;
        //}
    }
}
