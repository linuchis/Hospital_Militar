﻿#pragma checksum "..\..\..\..\Views\page_new_patients.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "BED832855774BF345ED961CDBF730CCAA66CADA0"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using PoxterMilitar.Views;
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
    /// Page_New_Patients
    /// </summary>
    public partial class Page_New_Patients : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 537 "..\..\..\..\Views\page_new_patients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Start;
        
        #line default
        #line hidden
        
        
        #line 572 "..\..\..\..\Views\page_new_patients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBox1;
        
        #line default
        #line hidden
        
        
        #line 618 "..\..\..\..\Views\page_new_patients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Sexo;
        
        #line default
        #line hidden
        
        
        #line 635 "..\..\..\..\Views\page_new_patients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox CheckAmputacion;
        
        #line default
        #line hidden
        
        
        #line 660 "..\..\..\..\Views\page_new_patients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Extremidad1;
        
        #line default
        #line hidden
        
        
        #line 680 "..\..\..\..\Views\page_new_patients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SavePatient;
        
        #line default
        #line hidden
        
        
        #line 689 "..\..\..\..\Views\page_new_patients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GridAmputacion;
        
        #line default
        #line hidden
        
        
        #line 700 "..\..\..\..\Views\page_new_patients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Extremidad2;
        
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
            System.Uri resourceLocater = new System.Uri("/PoxterMilitar;component/views/page_new_patients.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\page_new_patients.xaml"
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
            this.Start = ((System.Windows.Controls.Button)(target));
            return;
            case 2:
            this.ComboBox1 = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.Sexo = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.CheckAmputacion = ((System.Windows.Controls.CheckBox)(target));
            
            #line 644 "..\..\..\..\Views\page_new_patients.xaml"
            this.CheckAmputacion.Checked += new System.Windows.RoutedEventHandler(this.CheckBox_Checked);
            
            #line default
            #line hidden
            
            #line 645 "..\..\..\..\Views\page_new_patients.xaml"
            this.CheckAmputacion.Unchecked += new System.Windows.RoutedEventHandler(this.CheckBox_Unchecked);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Extremidad1 = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.SavePatient = ((System.Windows.Controls.Button)(target));
            
            #line 683 "..\..\..\..\Views\page_new_patients.xaml"
            this.SavePatient.Click += new System.Windows.RoutedEventHandler(this.Button_IniciarSesion_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.GridAmputacion = ((System.Windows.Controls.Grid)(target));
            return;
            case 8:
            this.Extremidad2 = ((System.Windows.Controls.ComboBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

