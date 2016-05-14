﻿#pragma checksum "..\..\..\Views\StartDialogWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D7C3547BC84C86EFB38AD7DC824447A1"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
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


namespace PacmanGame.MVVM.Views {
    
    
    /// <summary>
    /// StartDialogWindow
    /// </summary>
    public partial class StartDialogWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\Views\StartDialogWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock userTextBlock;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Views\StartDialogWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox nameTextBox;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Views\StartDialogWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock modeTextBlock;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Views\StartDialogWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox modeComboBox;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Views\StartDialogWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button startButton;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Views\StartDialogWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ContentPresenter DialogPresenter;
        
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
            System.Uri resourceLocater = new System.Uri("/PacmanMVVM;component/views/startdialogwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\StartDialogWindow.xaml"
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
            this.userTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.nameTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 16 "..\..\..\Views\StartDialogWindow.xaml"
            this.nameTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.nameTextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.modeTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.modeComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 19 "..\..\..\Views\StartDialogWindow.xaml"
            this.modeComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.modeComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.startButton = ((System.Windows.Controls.Button)(target));
            return;
            case 6:
            this.DialogPresenter = ((System.Windows.Controls.ContentPresenter)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
