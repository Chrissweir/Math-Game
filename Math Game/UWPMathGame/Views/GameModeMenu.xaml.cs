using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using UWPMathGame.Views;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPMathGame.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GameModeMenu : Page
    {
        public GameModeMenu()
        {
            this.InitializeComponent();
        }

        private void btnNormal_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(PlayNormal));
        }

        private void btnAdvanced_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(PlayAdvanced));
        }

        private void btnOption_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Option));
        }
    }
}
