﻿#pragma checksum "C:\Users\chris\Documents\GitHub\Math-Game\Math Game\UWPMathGame\Views\Settings.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "1345D49E4449B8EA7A1FEC2E9EFE00CC"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UWPMathGame.Views
{
    partial class Settings : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.backBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 223 "..\..\..\Views\Settings.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.backBtn).Click += this.backBtn_Click;
                    #line default
                }
                break;
            case 2:
                {
                    this.slider = (global::Windows.UI.Xaml.Controls.Slider)(target);
                    #line 219 "..\..\..\Views\Settings.xaml"
                    ((global::Windows.UI.Xaml.Controls.Slider)this.slider).ValueChanged += this.slider_ValueChanged;
                    #line default
                }
                break;
            case 3:
                {
                    this.Title = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

