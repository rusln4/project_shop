﻿#pragma checksum "..\..\..\item_update.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "27655DE5B9A439C182062A0E7E10E5B3F180FEE4"
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
    /// item_update
    /// </summary>
    public partial class item_update : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 56 "..\..\..\item_update.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ImageBtn;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\item_update.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TitleTextBox;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\item_update.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PriceTextBox;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\item_update.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CountTextBox;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\item_update.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/Perfume_Shop;V1.0.0.0;component/item_update.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\item_update.xaml"
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
            
            #line 8 "..\..\..\item_update.xaml"
            ((Perfume_Shop.item_update)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 53 "..\..\..\item_update.xaml"
            ((System.Windows.Controls.Grid)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Grid_MouseDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ImageBtn = ((System.Windows.Controls.Button)(target));
            
            #line 56 "..\..\..\item_update.xaml"
            this.ImageBtn.Click += new System.Windows.RoutedEventHandler(this.ImageBtn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.TitleTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 57 "..\..\..\item_update.xaml"
            this.TitleTextBox.GotFocus += new System.Windows.RoutedEventHandler(this.Get_foc);
            
            #line default
            #line hidden
            
            #line 57 "..\..\..\item_update.xaml"
            this.TitleTextBox.LostFocus += new System.Windows.RoutedEventHandler(this.TitleTextBox_LostFocus);
            
            #line default
            #line hidden
            return;
            case 5:
            this.PriceTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 58 "..\..\..\item_update.xaml"
            this.PriceTextBox.GotFocus += new System.Windows.RoutedEventHandler(this.Get_foc);
            
            #line default
            #line hidden
            
            #line 58 "..\..\..\item_update.xaml"
            this.PriceTextBox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.PriceTextBox_PreviewTextInput);
            
            #line default
            #line hidden
            
            #line 58 "..\..\..\item_update.xaml"
            this.PriceTextBox.LostFocus += new System.Windows.RoutedEventHandler(this.PriceTextBox_LostFocus);
            
            #line default
            #line hidden
            return;
            case 6:
            this.CountTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 59 "..\..\..\item_update.xaml"
            this.CountTextBox.GotFocus += new System.Windows.RoutedEventHandler(this.Get_foc);
            
            #line default
            #line hidden
            
            #line 59 "..\..\..\item_update.xaml"
            this.CountTextBox.LostFocus += new System.Windows.RoutedEventHandler(this.CountTextBox_LostFocus);
            
            #line default
            #line hidden
            
            #line 59 "..\..\..\item_update.xaml"
            this.CountTextBox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.CountTextBox_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 7:
            this.AddBtn = ((System.Windows.Controls.Button)(target));
            
            #line 60 "..\..\..\item_update.xaml"
            this.AddBtn.Click += new System.Windows.RoutedEventHandler(this.AddBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

