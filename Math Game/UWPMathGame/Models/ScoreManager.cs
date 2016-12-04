using System;
using System.Collections.Generic;
using System.Linq;
using UWPMathGame.Data;
using UWPMathGame.ViewModels;
using System.Threading.Tasks;

namespace UWPMathGame.Models
{
    //Class is responsible for speaking to the data class (Score) and the data service which holds database communication
    public class ScoreManager
    {
        public int result, speed;

        //Overloaded constructors for different tasks
        public ScoreManager()//adding a score
        { }

        //Contructor gets list of scores from the data service depending on user choice made.
        public ScoreManager(int choosenTable)//getting a score - offline
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

        public int Speed()
        {
            speed = DataService.GetSpeed();
            return speed;
        }

        public void SetSpeed(int speedValue)
        {
            DataService.SetSpeed(speedValue);
        }
    }
}
