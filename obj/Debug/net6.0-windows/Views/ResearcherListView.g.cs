﻿#pragma checksum "..\..\..\..\Views\ResearcherListView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5D3BC1B6F07F46D2D23BCF05BEC8DB8036D2A31D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using KIT206A3WPF.Controllers;
using KIT206A3WPF.Views;
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


namespace KIT206A3WPF.Views {
    
    
    /// <summary>
    /// ResearcherListView
    /// </summary>
    public partial class ResearcherListView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\..\..\Views\ResearcherListView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid researcher_list_view;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\Views\ResearcherListView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxNameFilter;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\Views\ResearcherListView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboBoxLevelFilter;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\Views\ResearcherListView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox researcher_list;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.8.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/KIT206A3WPF;component/views/researcherlistview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\ResearcherListView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.8.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.researcher_list_view = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.textBoxNameFilter = ((System.Windows.Controls.TextBox)(target));
            
            #line 36 "..\..\..\..\Views\ResearcherListView.xaml"
            this.textBoxNameFilter.KeyUp += new System.Windows.Input.KeyEventHandler(this.OnSearcherBoxNameFilterEnter);
            
            #line default
            #line hidden
            return;
            case 3:
            this.comboBoxLevelFilter = ((System.Windows.Controls.ComboBox)(target));
            
            #line 40 "..\..\..\..\Views\ResearcherListView.xaml"
            this.comboBoxLevelFilter.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.OnComboBoxLevelFilterSelect);
            
            #line default
            #line hidden
            return;
            case 4:
            this.researcher_list = ((System.Windows.Controls.ListBox)(target));
            
            #line 54 "..\..\..\..\Views\ResearcherListView.xaml"
            this.researcher_list.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.OnResearcherSelect);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

