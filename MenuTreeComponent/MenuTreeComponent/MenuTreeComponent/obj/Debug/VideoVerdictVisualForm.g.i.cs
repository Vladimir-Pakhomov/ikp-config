﻿#pragma checksum "..\..\VideoVerdictVisualForm.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9DDB3F3AE9BC999E2239FB7910409B715D2CE54D"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using MahApps.Metro.Controls;
using MenuTreeComponent;
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


namespace MenuTreeComponent {
    
    
    /// <summary>
    /// VideoVerdictVisualForm
    /// </summary>
    public partial class VideoVerdictVisualForm : MahApps.Metro.Controls.MetroWindow, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 28 "..\..\VideoVerdictVisualForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TreeView verdictTreeView;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\VideoVerdictVisualForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button verdictAddBtn;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\VideoVerdictVisualForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button verdictEditBtn;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\VideoVerdictVisualForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button verdictRemoveBtn;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\VideoVerdictVisualForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button okBtn;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\VideoVerdictVisualForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cancelBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/MenuTreeComponent;component/videoverdictvisualform.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\VideoVerdictVisualForm.xaml"
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
            this.verdictTreeView = ((System.Windows.Controls.TreeView)(target));
            return;
            case 3:
            this.verdictAddBtn = ((System.Windows.Controls.Button)(target));
            
            #line 49 "..\..\VideoVerdictVisualForm.xaml"
            this.verdictAddBtn.Click += new System.Windows.RoutedEventHandler(this.verdictAddBtn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.verdictEditBtn = ((System.Windows.Controls.Button)(target));
            
            #line 63 "..\..\VideoVerdictVisualForm.xaml"
            this.verdictEditBtn.Click += new System.Windows.RoutedEventHandler(this.verdictEditBtn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.verdictRemoveBtn = ((System.Windows.Controls.Button)(target));
            
            #line 77 "..\..\VideoVerdictVisualForm.xaml"
            this.verdictRemoveBtn.Click += new System.Windows.RoutedEventHandler(this.verdictRemoveBtn_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.okBtn = ((System.Windows.Controls.Button)(target));
            
            #line 91 "..\..\VideoVerdictVisualForm.xaml"
            this.okBtn.Click += new System.Windows.RoutedEventHandler(this.okBtn_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.cancelBtn = ((System.Windows.Controls.Button)(target));
            
            #line 92 "..\..\VideoVerdictVisualForm.xaml"
            this.cancelBtn.Click += new System.Windows.RoutedEventHandler(this.cancelBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 2:
            
            #line 31 "..\..\VideoVerdictVisualForm.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.verdictTreeView_SelectedItemChanged);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}
