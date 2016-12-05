using UWPMathGame.Data;

namespace UWPMathGame.Models
{
    //This class works at the model layer and has the sole responsibility of communicating with the data layer.
    //Inside this class we have score and speed variables which are managed within this class.
     public class ScoreManager
    {
        public int result, speed;

        public ScoreManager()
        { }
        
        //Get the Score from the requested table (difficulty) and return the result
        public ScoreManager(int choosenTable)
        {
            DataService.choosenTable = choosenTable;
            result = DataService.GetScores();
        }

        //Add to the database by passing the needed variables from score organizer view model to the data service
        //the data service will then add the score to the correct table
        public void Add(int difficulty, int score)
        {
            DataService.Insert(difficulty, score);
        }

        //Get the Speed from the database and return the result
        public int Speed()
        {
            speed = DataService.GetSpeed();
            return speed;
        }

        //Set the new speed
        public void SetSpeed(int speedValue)
        {
            DataService.SetSpeed(speedValue);
        }
    }
}
