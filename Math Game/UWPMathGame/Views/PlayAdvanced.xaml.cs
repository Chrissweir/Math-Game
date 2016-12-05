using System;
using UWPMathGame.ViewModels;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using UWPMathGame.Models;

namespace UWPMathGame.Views
{
    //This class is responsible for executing all the logic that goes into the advanced difficulty
    //of the game itself. It is the most heavily coded area of the application. It contains methods for
    //creating the equation questions, starting and stopping the timer, incrementing score, 
    //setting game defaults, click event handlers for the operator buttons, and many others.
    public sealed partial class PlayAdvanced : Page
    {
        private Random randomMath = new Random();
        private int Score = 0, State = 1, highScore, staticNumA, staticNumB, staticResult;
        private int difficulty = 1;
        private DispatcherTimer dispatcherTimer;
        private ScoreManagerViewModel scoreManagerVM;

        //Setup the progressbar
        void setupProgressBar()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            dispatcherTimer.Start();

            progressBar.Value = 9999;
        }

        //Progressbar timer tick rate
        private void DispatcherTimer_Tick(object sender, object e)
        {
            //Get the spped variable from the database
            scoreManagerVM = new ScoreManagerViewModel();
            //Subtract the value of the progressbar by the speed variable
            progressBar.Value -= scoreManagerVM.GetSpeed();
            //If the progressbar reaches 0 then launch the GameOver page and pass the score, highscore and difficulty to ScorePasser
            if (progressBar.Value <= 0)
            {
                dispatcherTimer.Stop();
                dispatcherTimer = null;
                Frame.Navigate(typeof(GameOver), new ScorePasser { difficulty = difficulty, score = Score, highScore = highScore });
            }
        }

        //Constructor
        public PlayAdvanced()
        {
            this.InitializeComponent();
        }
        //End Constructor

        //Random number generator from 1-9
        private int randomNumber()
        {
            return randomMath.Next(1, 9);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested -= PlayAdvanced_BackRequested;
        }

        //When the user navigates to this page
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested += PlayAdvanced_BackRequested;
            //get the current highscore from the database depending on the current difficulty
            scoreManagerVM = new ScoreManagerViewModel();
            highScore = scoreManagerVM.Get(difficulty);
            txtHighScore.Text = String.Format("HIGH:{0}",highScore);
            dispatcherTimer = null;
            //Start the game
            Playing();
        }

        //Random math value 0: + , 1: -, 2: *, 3: /
        private int randomMathValue()
        {
            return randomMath.Next(0,3);
        }

        //Play the game
        private void Playing()
        {
            int numberA = randomNumber();
            int numberB = randomMath.Next(0, numberA -1);
            int mathValue = randomMathValue();
            int result = 1;
            
            //The random math value determines what operator will be used
            if(mathValue == 0)
                result = numberA + numberB;
            else if (mathValue == 1)
                result = numberA - numberB;
            else if (mathValue == 2)
                result = numberA * numberB;
            else 
                result = numberA / numberB;

            staticNumA = numberA;
            staticNumB = numberB;
            staticResult = result;
            //Assign the generated numbers to the Xaml
            txtMath.Text = String.Format("{0} ... {1} = {2}", staticNumA, staticNumB, staticResult);
            //Start the progressbar
            setupProgressBar();
        }

        //If the user tries to exit the application asks are they sure
        private async void PlayAdvanced_BackRequested(object sender, BackRequestedEventArgs e)
        {
            e.Handled = true;
            dispatcherTimer.Stop();
            dispatcherTimer = null;

            var msg = new MessageDialog("Do you want to Stop?");
            var okBtn = new UICommand("Yes");
            var cancelBtn = new UICommand("No");
            msg.Commands.Add(okBtn);
            msg.Commands.Add(cancelBtn);
            IUICommand result = await msg.ShowAsync();

            if (result != null && result.Label.Equals("Yes"))
            {
                Frame.Navigate(typeof(GameOver), new ScorePasser { difficulty = difficulty, score = Score, highScore = highScore});
            }
        }

        //Click event handler for the + button
        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            //If this button is the correct answer, play again. If not go to the GameOver page
            if(staticNumA + staticNumB == staticResult)
            {
                txtScore.Text = String.Format("Score:{0}".ToUpper(), ++Score);
                txtState.Text = String.Format("{0}", ++State);
                dispatcherTimer.Stop();
                dispatcherTimer = null;
                Playing();
            }
            else
            {
                dispatcherTimer.Stop();
                dispatcherTimer = null;
                Frame.Navigate(typeof(GameOver), new ScorePasser { difficulty = difficulty, score = Score, highScore = highScore });
            }
        }

        //Click event handler for the - button
        private void btnSub_Click(object sender, RoutedEventArgs e)
        {
            //If this button is the correct answer, play again. If not go to the GameOver page
            if (staticNumA - staticNumB == staticResult)
            {
                txtScore.Text = String.Format("Score:{0}".ToUpper(), ++Score);
                txtState.Text = String.Format("{0}", ++State);
                dispatcherTimer.Stop();
                dispatcherTimer = null;
                Playing();
            }
            else
            {
                dispatcherTimer.Stop();
                dispatcherTimer = null;
                Frame.Navigate(typeof(GameOver), new ScorePasser { difficulty = difficulty, score = Score, highScore = highScore });
            }
        }

        //Click event handler for the * button
        private void btnMulti_Click(object sender, RoutedEventArgs e)
        {
            //If this button is the correct answer, play again. If not go to the GameOver page
            if (staticNumA * staticNumB == staticResult)
            {
                txtScore.Text = String.Format("Score:{0}".ToUpper(), ++Score);
                txtState.Text = String.Format("{0}", ++State);
                dispatcherTimer.Stop();
                dispatcherTimer = null;
                Playing();
            }
            else
            {
                dispatcherTimer.Stop();
                dispatcherTimer = null;
                Frame.Navigate(typeof(GameOver), new ScorePasser { difficulty = difficulty, score = Score, highScore = highScore });
            }
        }

        //Click event handler for the / button
        private void btnDiv_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //If this button is the correct answer, play again. If not go to the GameOver page
                if (staticNumA / staticNumB == staticResult)
                {
                    txtScore.Text = String.Format("Score:{0}".ToUpper(), ++Score);
                    txtState.Text = String.Format("{0}", ++State);
                    dispatcherTimer.Stop();
                    dispatcherTimer = null;
                    Playing();
                }
                else
                {
                    dispatcherTimer.Stop();
                    dispatcherTimer = null;
                    Frame.Navigate(typeof(GameOver), new ScorePasser { difficulty = difficulty, score = Score, highScore = highScore });
                }
            }
            catch(DivideByZeroException)
            {
                Frame.Navigate(typeof(GameOver), new ScorePasser { difficulty = difficulty, score = Score, highScore = highScore });
            }
        }
    }
}
