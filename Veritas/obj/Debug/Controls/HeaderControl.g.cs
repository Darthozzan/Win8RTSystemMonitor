﻿

#pragma checksum "C:\Users\WinRT\Desktop\Tobias_DONT_TOUCH\Veritas\Veritas\Controls\HeaderControl.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "18F595B9A986E8E7DFACBE6998F5265F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Veritas.Controls
{
    partial class HeaderControl : global::Windows.UI.Xaml.Controls.UserControl, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 12 "..\..\Controls\HeaderControl.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.onBackBtn_Click;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 13 "..\..\Controls\HeaderControl.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.onHistoryBtn_Click;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


