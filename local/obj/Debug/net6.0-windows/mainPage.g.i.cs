﻿#pragma checksum "..\..\..\mainPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4F60FA99077FD88A3A8745FF4E7200ACB70DE205"
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
using local;


namespace local {
    
    
    /// <summary>
    /// mainPage
    /// </summary>
    public partial class mainPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\mainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox nameTbx;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\mainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ipTbx;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\mainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button createBtn;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\mainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button joinBtn;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\mainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame menuFrame;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.9.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/local;component/mainpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\mainPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.9.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.nameTbx = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.ipTbx = ((System.Windows.Controls.TextBox)(target));
            
            #line 22 "..\..\..\mainPage.xaml"
            this.ipTbx.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.ipTbx_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 3:
            this.createBtn = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\mainPage.xaml"
            this.createBtn.Click += new System.Windows.RoutedEventHandler(this.createBtn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.joinBtn = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\mainPage.xaml"
            this.joinBtn.Click += new System.Windows.RoutedEventHandler(this.joinBtn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.menuFrame = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

