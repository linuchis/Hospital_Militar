﻿#pragma checksum "..\..\..\..\Views\User_Information.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3FEA5122414F452A55BB1E820D9B29C8042C8BA5"
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
    /// User_Information
    /// </summary>
    public partial class User_Information : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 45 "..\..\..\..\Views\User_Information.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Start;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\..\Views\User_Information.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock NombresURGDsuario;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\..\Views\User_Information.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock AreaUsuario;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\..\Views\User_Information.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TelefonoUsuario;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\..\Views\User_Information.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ContraseñaUsuario;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\..\Views\User_Information.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ApellidosUsuario;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\..\..\Views\User_Information.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock CorreoElectronicoUsuario;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\..\..\Views\User_Information.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Save_Survey;
        
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
            System.Uri resourceLocater = new System.Uri("/PoxterMilitar;V1.0.0.0;component/views/user_information.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\User_Information.xaml"
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
            
            #line 51 "..\..\..\..\Views\User_Information.xaml"
            this.Start.Click += new System.Windows.RoutedEventHandler(this.Button_Back_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.NombresURGDsuario = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.AreaUsuario = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.TelefonoUsuario = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.ContraseñaUsuario = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.ApellidosUsuario = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.CorreoElectronicoUsuario = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.Save_Survey = ((System.Windows.Controls.Button)(target));
            
            #line 110 "..\..\..\..\Views\User_Information.xaml"
            this.Save_Survey.Click += new System.Windows.RoutedEventHandler(this.Button_ToEditUserInformation);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

