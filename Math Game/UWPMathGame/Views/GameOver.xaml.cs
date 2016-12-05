using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using UWPMathGame.ViewModels;
using UWPMathGame.Models;


namespace UWPMathGame.Views
{
    //This class handles sending the difficulty and the score to the 
    //ScoreManagerViewModel.cs, along with some click event handlers for navigation.
    public sealed partial class GameOver : Page
    {
        //Global variables
        private ScorePasser scoreResult;
        private ScoreManagerViewModel scoreManagerVM;

        //Constructor
        public GameOver()
        {
            this.InitializeComponent();
        }
        //End Constructor

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested -= GameOver_BackRequested;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested += GameOver_BackRequested;

            // Get the data fro ScorePasser
            scoreResult = e.Parameter as ScorePasser;
            scoreManagerVM = new ScoreManagerViewModel();    
            
            //Assign variables from ScorePasser to local variables
            int difficulty =  scoreResult.difficulty;
            int score = scoreResult.score;
            int highScore = scoreResult.highScore;

            //Check if the new score is greater than the current highscore
            if (score > highScore)
            {
                //If so then replace the highscore with the current score
                scoreManagerVM.Add(difficulty, score);
            }
            //Display the players score to the Score textbox
            Score.Text = scoreResult.score.ToString();
        }

        //If the user tries to exit the application asks are they sure
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

        //Click event handler for the try again button
        private void btnTryAgain_Click(object sender, RoutedEventArgs e)
        {
            //Check what difficulty the player was just playing and return them to that page
            if (scoreResult.difficulty == 1)
                Frame.Navigate(typeof(PlayAdvanced));
            else
                Frame.Navigate(typeof(PlayNormal));
        }

        //Click event handler for the home button to return to the menu page
        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(GameModeMenu));
        }
    }
}
