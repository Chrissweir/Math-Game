using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPMathGame.Data
{
    public class DataClasses
    {
        //Score classes acts as a basic model to hold score objects for each score table, 
        //need a different class for each SQLite table because whatever the class name will be same name for the table
        public class NormalScore
        {
            //Each high score has a username and score and id for the database
            [PrimaryKey, AutoIncrement]
            public int id { get; set; }
            public int userscore { get; set; }
        }

        public class AdvancedScore
        {
            //Each high score has a username and score and id for the database
            [PrimaryKey, AutoIncrement]
            public int id { get; set; }
            public int userscore { get; set; }
        }

        public class GameSpeed
        {
            [PrimaryKey, AutoIncrement]
            public int id { get; set; }
            public int speed { get; set; }
        }
    }
}