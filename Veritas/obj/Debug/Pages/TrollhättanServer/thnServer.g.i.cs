﻿

#pragma checksum "C:\Users\WinRT\Desktop\Tobias_DONT_TOUCH\Veritas\Veritas\Pages\TrollhättanServer\thnServer.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "07C7E2968B70E74ADB7C3FF0BCFE5D66"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Veritas.Pages.TrollhättanServer
{
    partial class thnServer : global::Windows.UI.Xaml.Controls.Page
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Veritas.Controls.HeaderControl headerControl; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Veritas.Controls.CpuStaple cpuControl; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Veritas.Controls.Charts.PieChart hddControl; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Veritas.Controls.Charts.PieChart memControl; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.TextBlock lastUpdate; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Veritas.Controls.Charts.PieChart swapChart; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.TextBlock netIN; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.TextBlock netOUT; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Documents.Run weatherTempLbl; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Documents.Run weatherLbl; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private bool _contentLoaded;

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent()
        {
            if (_contentLoaded)
                return;

            _contentLoaded = true;
            global::Windows.UI.Xaml.Application.LoadComponent(this, new global::System.Uri("ms-appx:///Pages/TrollhättanServer/thnServer.xaml"), global::Windows.UI.Xaml.Controls.Primitives.ComponentResourceLocation.Application);
 
            headerControl = (global::Veritas.Controls.HeaderControl)this.FindName("headerControl");
            cpuControl = (global::Veritas.Controls.CpuStaple)this.FindName("cpuControl");
            hddControl = (global::Veritas.Controls.Charts.PieChart)this.FindName("hddControl");
            memControl = (global::Veritas.Controls.Charts.PieChart)this.FindName("memControl");
            lastUpdate = (global::Windows.UI.Xaml.Controls.TextBlock)this.FindName("lastUpdate");
            swapChart = (global::Veritas.Controls.Charts.PieChart)this.FindName("swapChart");
            netIN = (global::Windows.UI.Xaml.Controls.TextBlock)this.FindName("netIN");
            netOUT = (global::Windows.UI.Xaml.Controls.TextBlock)this.FindName("netOUT");
            weatherTempLbl = (global::Windows.UI.Xaml.Documents.Run)this.FindName("weatherTempLbl");
            weatherLbl = (global::Windows.UI.Xaml.Documents.Run)this.FindName("weatherLbl");
        }
    }
}



