﻿#pragma checksum "..\..\inventoryview.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "63043DDA1CCE490F3C0D648130E5D19B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
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


namespace pokego {
    
    
    /// <summary>
    /// inventoryview
    /// </summary>
    public partial class inventoryview : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\inventoryview.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas cvclose;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\inventoryview.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas cvpokeworldDrawing;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\inventoryview.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas cvinfoDrawing;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\inventoryview.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtTrainerInfo;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\inventoryview.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas cvoptionDrawing;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\inventoryview.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtOptionInfo;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\inventoryview.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtOptionPowerup;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\inventoryview.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtOptionHeal;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\inventoryview.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtOptionSell;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\inventoryview.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas cvlistboxDrawing;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\inventoryview.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lbPokemon;
        
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
            System.Uri resourceLocater = new System.Uri("/pokego;component/inventoryview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\inventoryview.xaml"
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
            
            #line 4 "..\..\inventoryview.xaml"
            ((pokego.inventoryview)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.cvclose = ((System.Windows.Controls.Canvas)(target));
            
            #line 12 "..\..\inventoryview.xaml"
            this.cvclose.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.cvclose_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.cvpokeworldDrawing = ((System.Windows.Controls.Canvas)(target));
            return;
            case 4:
            this.cvinfoDrawing = ((System.Windows.Controls.Canvas)(target));
            return;
            case 5:
            this.txtTrainerInfo = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.cvoptionDrawing = ((System.Windows.Controls.Canvas)(target));
            return;
            case 7:
            this.txtOptionInfo = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.txtOptionPowerup = ((System.Windows.Controls.TextBlock)(target));
            
            #line 33 "..\..\inventoryview.xaml"
            this.txtOptionPowerup.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.txtOptionPowerup_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 9:
            this.txtOptionHeal = ((System.Windows.Controls.TextBlock)(target));
            
            #line 34 "..\..\inventoryview.xaml"
            this.txtOptionHeal.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.txtOptionHeal_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 10:
            this.txtOptionSell = ((System.Windows.Controls.TextBlock)(target));
            
            #line 35 "..\..\inventoryview.xaml"
            this.txtOptionSell.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.txtOptionSell_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 11:
            this.cvlistboxDrawing = ((System.Windows.Controls.Canvas)(target));
            return;
            case 12:
            this.lbPokemon = ((System.Windows.Controls.ListBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
