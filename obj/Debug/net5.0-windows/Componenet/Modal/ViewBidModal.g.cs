﻿#pragma checksum "..\..\..\..\..\Componenet\Modal\ViewBidModal.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "14B22D15FC13C9E8FFAB7E66A3001A4EBC13521B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ForGreen_Aelf.Componenet.Modal;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace ForGreen_Aelf.Componenet.Modal {
    
    
    /// <summary>
    /// ViewBidModal
    /// </summary>
    public partial class ViewBidModal : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\..\..\Componenet\Modal\ViewBidModal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border SizeBox;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\..\Componenet\Modal\ViewBidModal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock HeaderTitle;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\..\Componenet\Modal\ViewBidModal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CloseBTN;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\..\Componenet\Modal\ViewBidModal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel AlertBox;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\..\Componenet\Modal\ViewBidModal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock AlertMessage;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\..\Componenet\Modal\ViewBidModal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid HistoryGrid;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ForGreen Aelf;component/componenet/modal/viewbidmodal.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Componenet\Modal\ViewBidModal.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 11 "..\..\..\..\..\Componenet\Modal\ViewBidModal.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Rectangle_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.SizeBox = ((System.Windows.Controls.Border)(target));
            return;
            case 3:
            this.HeaderTitle = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.CloseBTN = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\..\..\Componenet\Modal\ViewBidModal.xaml"
            this.CloseBTN.Click += new System.Windows.RoutedEventHandler(this.CloseBTN_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.AlertBox = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 6:
            this.AlertMessage = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.HistoryGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

