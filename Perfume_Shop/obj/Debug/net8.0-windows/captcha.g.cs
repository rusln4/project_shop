﻿#pragma checksum "..\..\..\captcha.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7AFDB181517A2B254C2DF7B871E478B9E701BA5D"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Perfume_Shop;
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


namespace Perfume_Shop {
    
    
    /// <summary>
    /// captcha
    /// </summary>
    public partial class captcha : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 55 "..\..\..\captcha.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox num1_textBox;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\captcha.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox num2_textBox;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\captcha.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label digit_textBox;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\captcha.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ans_textBox;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\captcha.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button new_nums_but;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\captcha.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ans_but;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Perfume_Shop;component/captcha.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\captcha.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.num1_textBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.num2_textBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.digit_textBox = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.ans_textBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.new_nums_but = ((System.Windows.Controls.Button)(target));
            
            #line 60 "..\..\..\captcha.xaml"
            this.new_nums_but.Click += new System.Windows.RoutedEventHandler(this.new_nums_but_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ans_but = ((System.Windows.Controls.Button)(target));
            
            #line 61 "..\..\..\captcha.xaml"
            this.ans_but.Click += new System.Windows.RoutedEventHandler(this.ans_but_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

