﻿#pragma checksum "..\..\AdminControlPanel.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "AEEDF92371A45AAE361F5D1F5040D4FF0BE1323C27ABC12C9826742E90166512"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Diploma;
using Dragablz;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace Diploma {
    
    
    /// <summary>
    /// AdminControlPanel
    /// </summary>
    public partial class AdminControlPanel : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 36 "..\..\AdminControlPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox usertodis;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\AdminControlPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox tasktodis;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\AdminControlPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button disaddbutton;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\AdminControlPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid TaskGrid;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\AdminControlPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid notegridview;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\AdminControlPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button GanttChartButton;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\AdminControlPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid TaskEditGrid;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\AdminControlPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid taskgridview;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\AdminControlPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Updatebutton;
        
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
            System.Uri resourceLocater = new System.Uri("/Diploma;component/admincontrolpanel.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AdminControlPanel.xaml"
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
            
            #line 24 "..\..\AdminControlPanel.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.usertodis = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.tasktodis = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.disaddbutton = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\AdminControlPanel.xaml"
            this.disaddbutton.Click += new System.Windows.RoutedEventHandler(this.disaddbutton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.TaskGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 6:
            this.notegridview = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 7:
            this.GanttChartButton = ((System.Windows.Controls.Button)(target));
            
            #line 52 "..\..\AdminControlPanel.xaml"
            this.GanttChartButton.Click += new System.Windows.RoutedEventHandler(this.GanttChartButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.TaskEditGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 9:
            this.taskgridview = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 10:
            this.Updatebutton = ((System.Windows.Controls.Button)(target));
            
            #line 65 "..\..\AdminControlPanel.xaml"
            this.Updatebutton.Click += new System.Windows.RoutedEventHandler(this.Updatebutton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

