namespace UWPMathGame.Models
{
    //This class has two instance variables for difficulty and score.
    //It is used to pass game information from the PlayNormal and PlayAdvanced 
    //page to the GameOver page once the player ends the game.
    class ScorePasser
    {
        public int difficulty { get; set; }
        public int score { get; set; }
        public int highScore { get; set; }
    }
}
