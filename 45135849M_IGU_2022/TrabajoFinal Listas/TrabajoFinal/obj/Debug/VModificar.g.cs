﻿#pragma checksum "..\..\VModificar.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "FEDA8B43A851FFC44D7FA2BE262E99CBEBDAF1D15FBE7EC469A42B3BC8A379F7"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
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
using TrabajoFinal;


namespace TrabajoFinal {
    
    
    /// <summary>
    /// VModificar
    /// </summary>
    public partial class VModificar : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 33 "..\..\VModificar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Titulo;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\VModificar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView listamat;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\VModificar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Matricula;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\VModificar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox MatrículaBox;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\VModificar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock MarcaBlock;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\VModificar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox MarcaBox;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\VModificar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Modificar;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\VModificar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ModificarR;
        
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
            System.Uri resourceLocater = new System.Uri("/TrabajoFinal;component/vmodificar.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\VModificar.xaml"
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
            this.Titulo = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.listamat = ((System.Windows.Controls.ListView)(target));
            
            #line 34 "..\..\VModificar.xaml"
            this.listamat.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.listamat_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Matricula = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.MatrículaBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.MarcaBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.MarcaBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.Modificar = ((System.Windows.Controls.Button)(target));
            
            #line 48 "..\..\VModificar.xaml"
            this.Modificar.Click += new System.Windows.RoutedEventHandler(this.Modificar_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.ModificarR = ((System.Windows.Controls.Button)(target));
            
            #line 57 "..\..\VModificar.xaml"
            this.ModificarR.Click += new System.Windows.RoutedEventHandler(this.ModificarR_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
