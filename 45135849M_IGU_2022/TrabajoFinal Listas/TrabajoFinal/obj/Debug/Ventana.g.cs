﻿#pragma checksum "..\..\Ventana.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1F797BE718E9DC15A93C79F3586C235916F190657A006E66CB81316C9A22BB89"
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
    /// Ventana
    /// </summary>
    public partial class Ventana : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\Ventana.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Tabla_1;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\Ventana.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Tabla_2;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\Ventana.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView Lista1;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\Ventana.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView Lista2;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\Ventana.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Borrar_datos;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\Ventana.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Borrar_repostaje;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\Ventana.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Añadirtxt;
        
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
            System.Uri resourceLocater = new System.Uri("/TrabajoFinal;component/ventana.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Ventana.xaml"
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
            this.Tabla_1 = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.Tabla_2 = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.Lista1 = ((System.Windows.Controls.ListView)(target));
            
            #line 32 "..\..\Ventana.xaml"
            this.Lista1.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Lista1_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Lista2 = ((System.Windows.Controls.ListView)(target));
            
            #line 45 "..\..\Ventana.xaml"
            this.Lista2.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Lista2_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Borrar_datos = ((System.Windows.Controls.Button)(target));
            
            #line 56 "..\..\Ventana.xaml"
            this.Borrar_datos.Click += new System.Windows.RoutedEventHandler(this.Borrar_datos_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Borrar_repostaje = ((System.Windows.Controls.Button)(target));
            
            #line 68 "..\..\Ventana.xaml"
            this.Borrar_repostaje.Click += new System.Windows.RoutedEventHandler(this.Borrar_repostaje_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Añadirtxt = ((System.Windows.Controls.Button)(target));
            
            #line 80 "..\..\Ventana.xaml"
            this.Añadirtxt.Click += new System.Windows.RoutedEventHandler(this.Añadirtxt_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

