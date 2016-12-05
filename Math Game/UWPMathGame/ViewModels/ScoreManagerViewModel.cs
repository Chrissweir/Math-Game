using UWPMathGame.Models;

namespace UWPMathGame.ViewModels
{
    //This class is responible for wrapping the ScoreManager.cs class. 
    //It retrieves the highscore and speed values from the ScoreManager.cs and 
    //passes them back to the PlayNormal.xaml.cs, PlayAdvanced.xaml.cs, and Settings.xaml.cs classes. 
    //It also takes in values for the speed, difficulty, and score from the Settings.xaml.cs class and
    //the GameOver.xaml.cs class to pass them to the ScoreManager.cs class.
    public class ScoreManagerViewModel
    {
        public int highScore, speed;

        ScoreManager insertManager;
        ScoreManager retrieveManager;
        ScoreManager speedManager;
        ScoreManager setSpeedManager;
        
        public ScoreManagerViewModel()
        {
            insertManager = new ScoreManager();
            setSpeedManager = new ScoreManager();
        }

        //Get the highscore depending on the difficulty selected
        public int Get(int choosenTable)
        {
            retrieveManager = new ScoreManager(choosenTable);
            highScore = retrieveManager.result;
            return highScore;
        }
        
        //Add the new highscore to the difficuly selected
        public void Add(int difficulty, int score)
        {
            insertManager.Add(difficulty, score);
        }

        //Get the speed from the database
        public int GetSpeed()
        {
            speedManager = new ScoreManager();
            speed = speedManager.Speed();
            return speed;
        }

        //Set the new Speed but the updatated speedValue
        public void SetSpeed(int speedValue)
        {
            setSpeedManager.SetSpeed(speedValue);
        }
    }
}