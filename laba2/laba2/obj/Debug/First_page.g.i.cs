﻿#pragma checksum "..\..\First_page.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "6970C5B089A8F8A969B6CA38D859D9E526ECC7657031670F4EE53AEE7B11D04B"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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
using laba2;


namespace laba2 {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\First_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Parcer_xlsx;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\First_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGrid;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\First_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox enter_text;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\First_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_save;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\First_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button find_file;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\First_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_update;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\First_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_save_as;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\First_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Menu menu;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\First_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_download;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\First_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_download_test;
        
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
            System.Uri resourceLocater = new System.Uri("/laba2;component/first_page.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\First_page.xaml"
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
            this.Parcer_xlsx = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.dataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 10 "..\..\First_page.xaml"
            this.dataGrid.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dataGrid_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.enter_text = ((System.Windows.Controls.TextBox)(target));
            
            #line 22 "..\..\First_page.xaml"
            this.enter_text.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.enter_text_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.button_save = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\First_page.xaml"
            this.button_save.Click += new System.Windows.RoutedEventHandler(this.Button_save_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.find_file = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\First_page.xaml"
            this.find_file.Click += new System.Windows.RoutedEventHandler(this.find_file_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.button_update = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\First_page.xaml"
            this.button_update.Click += new System.Windows.RoutedEventHandler(this.Button_update_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.button_save_as = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\First_page.xaml"
            this.button_save_as.Click += new System.Windows.RoutedEventHandler(this.Button_save_as_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.menu = ((System.Windows.Controls.Menu)(target));
            return;
            case 9:
            this.button_download = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\First_page.xaml"
            this.button_download.Click += new System.Windows.RoutedEventHandler(this.Button_download_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.button_download_test = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\First_page.xaml"
            this.button_download_test.Click += new System.Windows.RoutedEventHandler(this.button_download_test_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

