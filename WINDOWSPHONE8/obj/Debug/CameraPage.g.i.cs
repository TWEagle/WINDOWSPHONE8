﻿#pragma checksum "C:\GitProjects\WINDOWSPHONE8\WINDOWSPHONE8\CameraPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "993C36865B078E270A9EB743B33193E5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34003
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace WINDOWSPHONE8 {
    
    
    public partial class CameraPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Canvas viewfinderCanvas;
        
        internal System.Windows.Media.VideoBrush viewfinderBrush;
        
        internal System.Windows.Media.CompositeTransform viewfinderTransform;
        
        internal System.Windows.Controls.TextBlock focusBrackets;
        
        internal System.Windows.Controls.TextBlock txtMessage;
        
        internal System.Windows.Controls.Button AFButton;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/WINDOWSPHONE8;component/CameraPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.viewfinderCanvas = ((System.Windows.Controls.Canvas)(this.FindName("viewfinderCanvas")));
            this.viewfinderBrush = ((System.Windows.Media.VideoBrush)(this.FindName("viewfinderBrush")));
            this.viewfinderTransform = ((System.Windows.Media.CompositeTransform)(this.FindName("viewfinderTransform")));
            this.focusBrackets = ((System.Windows.Controls.TextBlock)(this.FindName("focusBrackets")));
            this.txtMessage = ((System.Windows.Controls.TextBlock)(this.FindName("txtMessage")));
            this.AFButton = ((System.Windows.Controls.Button)(this.FindName("AFButton")));
        }
    }
}

