using System;
using UWPMathGame.Data;
using UWPMathGame.Views;
using UWPMathGame.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPMathGame.ViewModels
{
    public class ScoreManagerViewModel
    {
        public int highScore, speed;

        ScoreManager insertManager;
        ScoreManager retrieveManager;
        ScoreManager speedManager;
        ScoreManager setSpeedManager;

        //Overloaded constructors for different tasks
        public ScoreManagerViewModel()
        {
            insertManager = new ScoreManager();
            setSpeedManager = new ScoreManager();
        }

        //Contructor takes index of selected user option
        public int Get(int choosenTable)
        {
            retrieveManager = new ScoreManager(choosenTable);
            highScore = retrieveManager.result;
            return highScore;
        }
        
        public void Add(int difficulty, int score)
        {
            insertManager.Add(difficulty, score);
        }

        public int GetSpeed()
        {
            speedManager = new ScoreManager();
            speed = speedManager.Speed();
            return speed;
        }

        public void SetSpeed(int speedValue)
        {
            setSpeedManager.SetSpeed(speedValue);
        }
    }
}