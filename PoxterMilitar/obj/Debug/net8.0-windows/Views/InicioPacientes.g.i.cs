﻿#pragma checksum "..\..\..\..\Views\InicioPacientes.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3A022FD37558BF1FD4187701E4E7C58FD18A86E4"
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


namespace PoxterMilitar.Views {
    
    
    /// <summary>
    /// InicioPacientes
    /// </summary>
    public partial class InicioPacientes : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 230 "..\..\..\..\Views\InicioPacientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image ImgInicio;
        
        #line default
        #line hidden
        
        
        #line 234 "..\..\..\..\Views\InicioPacientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image ImgPacientes;
        
        #line default
        #line hidden
        
        
        #line 238 "..\..\..\..\Views\InicioPacientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image ImgUsuarios;
        
        #line default
        #line hidden
        
        
        #line 332 "..\..\..\..\Views\InicioPacientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button NewPaciente;
        
        #line default
        #line hidden
        
        
        #line 346 "..\..\..\..\Views\InicioPacientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataPacientes;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.8.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/PoxterMilitar;component/views/iniciopacientes.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\InicioPacientes.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.8.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.ImgInicio = ((System.Windows.Controls.Image)(target));
            return;
            case 2:
            this.ImgPacientes = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.ImgUsuarios = ((System.Windows.Controls.Image)(target));
            return;
            case 4:
            this.NewPaciente = ((System.Windows.Controls.Button)(target));
            
            #line 332 "..\..\..\..\Views\InicioPacientes.xaml"
            this.NewPaciente.Click += new System.Windows.RoutedEventHandler(this.Btn_NewPaciente);
            
            #line default
            #line hidden
            return;
            case 5:
            this.DataPacientes = ((System.Windows.Controls.DataGrid)(target));
            
            #line 346 "..\..\..\..\Views\InicioPacientes.xaml"
            this.DataPacientes.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DataPacientes_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
