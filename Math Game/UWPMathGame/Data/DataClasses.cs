using SQLite.Net.Attributes

namespace UWPMathGame.Data
{
    //This class contains all the class that are used to interact with the database.
    //There are three classes, NormalScore, AdvancedScore, and GameSpeed. 
    //These classes are used to create the database tables hence giving each table a unique name 
    //apon creation, they are also used to insert data.
    public class DataClasses
    {
        public class NormalScore
        {
            //Each high score has an id and score for the database
            [PrimaryKey, AutoIncrement]
            public int id { get; set; }
            public int userscore { get; set; }
        }

        public class AdvancedScore
        {
            //Each high score has an id and score for the database
            [PrimaryKey, AutoIncrement]
            public int id { get; set; }
            public int userscore { get; set; }
        }

        public class GameSpeed
        {
            //The speed has an id and speed value for the database
            [PrimaryKey, AutoIncrement]
            public int id { get; set; }
            public int speed { get; set; }
        }
    }
}