using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using UWPMathGame.ViewModels;
using UWPMathGame.Models;


namespace UWPMathGame.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GameOver : Page
    {
        private ScorePasser scoreResult;
        private ScoreManagerViewModel scoreManagerVM;

        public GameOver()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested -= GameOver_BackRequested;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested += GameOver_BackRequested;
            scoreResult = e.Parameter as ScorePasser;
            scoreManagerVM = new ScoreManagerViewModel();           
            int difficulty =  scoreResult.difficulty;
            int score = scoreResult.score;
            int highScore = scoreResult.highScore;
            if (score > highScore)
            {
                scoreManagerVM.Add(difficulty, score);
            }
            
            Score.Text = scoreResult.score.ToString();
        }

        private async void GameOver_BackRequested(object sender, Windows.UI.Core.BackRequestedEventArgs e)
        {
            e.Handled = true;
            var msg = new MessageDialog("Do you want to exit?");
            var okBtn = new UICommand("Yes");
            var cancelBtn = new UICommand("No");
            msg.Commands.Add(okBtn);
            msg.Commands.Add(cancelBtn);
            IUICommand result = await msg.ShowAsync();

            if (result != null && result.Label.Equals("Yes"))
            {
                Application.Current.Exit();
            }
        }

        private void btnTryAgain_Click(object sender, RoutedEventArgs e)
        {
            if (scoreResult.difficulty == 1)
                Frame.Navigate(typeof(PlayAdvanced));
            else
                Frame.Navigate(typeof(PlayNormal));
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(GameModeMenu));
        }
    }
}
