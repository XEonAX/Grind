﻿#pragma checksum "..\..\ChatsControl.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E4A7DDCA7E706053382C9DB82DA35561"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Grind.WPF.CSharp {
    
    
    /// <summary>
    /// ChatsControl
    /// </summary>
    public partial class ChatsControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\ChatsControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Grind.WPF.CSharp.ChatsControl UserControl;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\ChatsControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid LayoutRoot;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\ChatsControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RichTextBox rtbMessage;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\ChatsControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCon;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\ChatsControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSend;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\ChatsControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDis;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\ChatsControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RichTextBox rtbMessages;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\ChatsControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Documents.Table tableMessages;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\ChatsControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Documents.TableColumn metaColumn;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\ChatsControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Documents.TableColumn msgColumn;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\ChatsControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lbOnlinePeople;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Grind.WPF.CSharp;component/chatscontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ChatsControl.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.UserControl = ((Grind.WPF.CSharp.ChatsControl)(target));
            return;
            case 2:
            this.LayoutRoot = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.rtbMessage = ((System.Windows.Controls.RichTextBox)(target));
            return;
            case 4:
            this.btnCon = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\ChatsControl.xaml"
            this.btnCon.Click += new System.Windows.RoutedEventHandler(this.btnCon_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnSend = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\ChatsControl.xaml"
            this.btnSend.Click += new System.Windows.RoutedEventHandler(this.btnSend_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnDis = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\ChatsControl.xaml"
            this.btnDis.Click += new System.Windows.RoutedEventHandler(this.btnDis_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.rtbMessages = ((System.Windows.Controls.RichTextBox)(target));
            return;
            case 8:
            this.tableMessages = ((System.Windows.Documents.Table)(target));
            return;
            case 9:
            this.metaColumn = ((System.Windows.Documents.TableColumn)(target));
            return;
            case 10:
            this.msgColumn = ((System.Windows.Documents.TableColumn)(target));
            return;
            case 11:
            this.lbOnlinePeople = ((System.Windows.Controls.ListBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
