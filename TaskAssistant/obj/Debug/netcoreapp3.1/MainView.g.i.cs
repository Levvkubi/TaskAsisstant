﻿#pragma checksum "..\..\..\MainView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2F3E51D8D14B27E3A3DD34217E9E64D739C68220"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DBTaskAssistant.ViewModels;
using DevExpress.Xpf.DXBinding;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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
using TaskAssistant;


namespace TaskAssistant {
    
    
    /// <summary>
    /// MainView
    /// </summary>
    public partial class MainView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 274 "..\..\..\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox SortBox;
        
        #line default
        #line hidden
        
        
        #line 284 "..\..\..\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EditButt;
        
        #line default
        #line hidden
        
        
        #line 291 "..\..\..\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteButt;
        
        #line default
        #line hidden
        
        
        #line 298 "..\..\..\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Exit;
        
        #line default
        #line hidden
        
        
        #line 316 "..\..\..\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button UserEdit;
        
        #line default
        #line hidden
        
        
        #line 321 "..\..\..\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel Menu;
        
        #line default
        #line hidden
        
        
        #line 325 "..\..\..\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox Listbox;
        
        #line default
        #line hidden
        
        
        #line 357 "..\..\..\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddButt;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TaskAssistant;component/mainview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MainView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.SortBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 278 "..\..\..\MainView.xaml"
            this.SortBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.SortBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.EditButt = ((System.Windows.Controls.Button)(target));
            
            #line 285 "..\..\..\MainView.xaml"
            this.EditButt.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.DeleteButt = ((System.Windows.Controls.Button)(target));
            
            #line 292 "..\..\..\MainView.xaml"
            this.DeleteButt.Click += new System.Windows.RoutedEventHandler(this.DeleteButt_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Exit = ((System.Windows.Controls.Button)(target));
            
            #line 304 "..\..\..\MainView.xaml"
            this.Exit.Click += new System.Windows.RoutedEventHandler(this.Exit_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.UserEdit = ((System.Windows.Controls.Button)(target));
            
            #line 318 "..\..\..\MainView.xaml"
            this.UserEdit.Click += new System.Windows.RoutedEventHandler(this.UserEdit_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Menu = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 7:
            this.Listbox = ((System.Windows.Controls.ListBox)(target));
            return;
            case 8:
            this.AddButt = ((System.Windows.Controls.Button)(target));
            
            #line 365 "..\..\..\MainView.xaml"
            this.AddButt.Click += new System.Windows.RoutedEventHandler(this.AddButt_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

