﻿#pragma checksum "H:\College\Mobile Applications Development 3\Project\Math-Game\Math Game\Math Game\View\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "941A695A7BBE68B911B44F17194841EE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Math_Game
{
    partial class MainPage : 
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
                    this.btnStart = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 29 "..\..\..\View\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnStart).Click += this.btnStart_Click;
                    #line default
                }
                break;
            case 2:
                {
                    this.btnOption = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 31 "..\..\..\View\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnOption).Click += this.btnOption_Click;
                    #line default
                }
                break;
            case 3:
                {
                    this.txtHighScore = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 4:
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

