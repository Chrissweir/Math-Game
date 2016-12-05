using SQLite.Net;
using System;
using System.Collections.Generic;
using System.IO;
using static UWPMathGame.Data.DataClasses;

namespace UWPMathGame.Data
{
    // This class is at the data layer of the MVVM model.
    //This class is responible for managing the score and speed data in
    //the SQLite database and contains methods to both read and write from them.
    public class DataService
    {
        public static int choosenTable;          //This variable is set by the view model so we know which table to read from
        private static SQLiteConnection con;    //Connection object for SQLite database
        private static string path;            //The path of the database in the file system
        private static int id;                
        private static int result;
        private static int speed;

        //Retrieves data(scores from the database depending on which scores user choose to see)
        public static int GetScores()
        {
            //Connect to the database in windows local folder, specify the platform being used
            path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "madmath.sqlite");
            con = new SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);

            //Perfrom a switch depending on user choice made to select a certain high score table
            switch (choosenTable)
            {
                case 0:
                    con.CreateTable<NormalScore>();//creates a table called 'NormalScore' 
                    var normalQuery = con.Table<NormalScore>();
                    foreach (var message in normalQuery)
                    {
                        id = message.id;
                        result = message.userscore;
                    }
                    con.Close();//close the connection after scores have been retrieved
                    break;
                case 1:
                    con.CreateTable<AdvancedScore>();//creates a table called 'AdvancedScore'
                    var advancedQuery = con.Table<AdvancedScore>();
                    foreach (var message in advancedQuery)
                    {
                        id = message.id;
                        result = message.userscore;
                    }
                    con.Close();//close the connection after scores have been retrieved
                    break;
            }//end switch

            return result;//return the querys results

        }//end getScores()
        
        public static void Insert(int difficulty, int score)
        {
            //Connect to the database in windows local folder, specify the platform being used
            path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "madmath.sqlite");
            con = new SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);

            //If difficulty setting of the game is Normal
            if (difficulty == 0)
            {
                con.CreateTable<NormalScore>();
                con.Insert(new NormalScore() { userscore = score });
                con.Close();
            }
            //If difficulty setting of the game is Advanced
            else if (difficulty == 1)
            {
                con.CreateTable<AdvancedScore>();
                con.Insert(new AdvancedScore() { userscore = score });
                con.Close();
            }
        }

        public static int GetSpeed()
        {
            //Connect to the database in windows local folder, specify the platform being used
            path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "madmath.sqlite");
            con = new SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);

            con.CreateTable<GameSpeed>();//creates a table called 'GameSpeed' 
            var speedQuery = con.Table<GameSpeed>();
            foreach (var message in speedQuery)
            {
                speed = message.speed;
            }
            con.Close();//close the connection after speed has been retrieved

            return speed;         //return results

        }//end getScores()

        public static void SetSpeed(int speedValue)
        {
            //Connect to the database in windows local folder, specify the platform being used
            path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "madmath.sqlite");
            con = new SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);

            //Create a table called 'GameSpeed' 
            con.CreateTable<GameSpeed>();
            con.Insert(new GameSpeed() { speed = speedValue });
            con.Close();
        }
    }
}
