﻿#pragma checksum "..\..\UserControlLogin.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "CC41B3F6D2B2289FFC1D3AB7DCA6146DC1091374983E5891FE7B07DA61AA59E1"
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
    /// UserControlLogin
    /// </summary>
    public partial class UserControlLogin : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 31 "..\..\UserControlLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox LoginTB;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\UserControlLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox pasentertb;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\UserControlLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button enterbt;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\UserControlLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Closebt;
        
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
            System.Uri resourceLocater = new System.Uri("/Diploma;component/usercontrollogin.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\UserControlLogin.xaml"
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
            this.LoginTB = ((System.Windows.Controls.TextBox)(target));
            
            #line 32 "..\..\UserControlLogin.xaml"
            this.LoginTB.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.LoginTB_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.pasentertb = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 44 "..\..\UserControlLogin.xaml"
            this.pasentertb.PasswordChanged += new System.Windows.RoutedEventHandler(this.pasentertb_PasswordChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.enterbt = ((System.Windows.Controls.Button)(target));
            
            #line 50 "..\..\UserControlLogin.xaml"
            this.enterbt.Click += new System.Windows.RoutedEventHandler(this.enterbt_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Closebt = ((System.Windows.Controls.Button)(target));
            
            #line 55 "..\..\UserControlLogin.xaml"
            this.Closebt.Click += new System.Windows.RoutedEventHandler(this.Closebt_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

