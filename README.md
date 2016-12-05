#_Mad Math_

**Student Name:** Christopher Weir </br>
**Student ID:** G00309429 </br>
**Course:** Software Development </br>
**Current Year:** 4th Year </br>
**Module:** Mobile Application Development </br>
**Lecturer:** Martin Kenirons </br>

## _Introduction_
This is a question game called Mad Math built for the Universal Windows Platform. The game consists of two difficulty settings, normal and advanced. The questions will be asked differetnly
depending on the difficulty. Normal will present the player with an equation and allow them to choose true of false if the equations answer is coreect or not. Advanced will present the player
with an equation again but without the operation being visible, the player must choose the right operator that corresponds with the equation.<br><br>
To play the game you firstly choose which difficulty you wish to play on. When the game starts for either difficulty a timer will begin, promting the player
to answer the question before the timer runs out. Each time a player chooses the correct answer the timer resets. The speed of this timer can be changed by going into the settings
page of the application. If the timer runs out the game ends showing the players score and asking them if they with to try again. If the players score is greater than the current highscore then 
it will then replace the current highscore. These scores are stored in an SQLite database and the table they are saved into depends
on which difficulty the player has choosen.

## **Techical Summary**

### **XAML**
XAML is used to the design the User Interface or "Views" of the application. These are the areas the user interacts with. The pages that have been created using XAML in this project are as follows:

XAML Page | Description
------------ | -------------
MainPage.xaml | This is the home page of the application, from here the user can choose to play a game.
GameModeMenu.xaml | This is the page where the user selects what difficulty the wish to play on. This page also contains a button to go to the Settings page.
Settings.xaml | This page allows the user to alter the speed of the timer.
PlayNormal.xaml | This page is where the user plays the game on the normal difficulty. This page also displays the current highscore for the normal difficulty.
PlayAdvanced.xaml | This page is where the user plays the game on the advanced difficulty. This page also displays the current highscore for the advanced difficulty.
Settings.xaml | On this page the user can change the speed of the timer.

### **C#**
The C# Programming language is what provides this application with its functionality. The logic behind all the XAML page views and more is all written using the C# language, hence every XAML page has a corresponding C# class behind it.
A breakdown of the indiviual C# classes for this project is as follows:

Class | Description
------------ | -------------
(MVVM) Views/MainPage.xaml.cs | This class is simple enough it is the logic for the Main(Home) page of the application. It contains a click events to handle the play button which will bring the user onto the GameModeMenu page.
(MVVM) Views/GameModeMenu.xaml.cs | This class is another simple class, it holds click events for the menu buttons Noraml, Advanced, and Settings.
(MVVM) Views/PlayNormal.xaml.cs | This class is responsible for executing all the logic that goes into the normal difficulty of the game itself. It contains methods for creating the equation questions, starting and stopping the timer, incrementing score, setting game defaults, click event handlers for true and false buttons, and many others.
(MVVM) Views/PlayAdvanced.xaml.cs | This class is responsible for executing all the logic that goes into the advanced difficulty of the game itself. It is the most heavily coded area of the application. It contains methods for creating the equation questions, starting and stopping the timer, incrementing score, setting game defaults, click event handlers for the operator buttons, and many others.
(MVVM) Views/Settings.xaml.cs | This class is responible for changing the time speed setting of the game. The timer speed value is stored in the SQLite Database so this setting does not change when the app is closed. The class also contains navigation handler for the Back button.
(MVVM) Views/GameOver.xaml.cs | This class handles sending the difficulty and the score to the ScoreManagerViewModel.cs, along with some click event handlers for navigation.
(MVVM) ViewModels/ScoreManagerViewModel.cs | This class is responible for wrapping the ScoreManager.cs class. It retrieves the highscore and speed values from the ScoreManager.cs and passes them back to the PlayNormal.xaml.cs, PlayAdvanced.xaml.cs, and Settings.xaml.cs classes. It also takes in values for the speed, difficulty, and score from the Settings.xaml.cs class and the GameOver.xaml.cs class to pass them to the ScoreManager.cs class.
(MVVM) Models/ScorePasser.cs | This class has two instance variables for difficulty and score. It is used to pass game information from the PlayNormal and PlayAdvanced page to the GameOver page once the player ends the game.
(MVVM) Models/ScoreManager.cs | This class works at the model layer and has the sole responsibility of communicating with the data layer. Inside this class we have score and speed variables which are managed within this class.
(MVVM) Data/DataService.cs | This class is at the data layer of the MVVM model. This class is responible for managing the score and speed data in the SQLite database and contains methods to both read and write from them.
(MVVM) Data/DataClasses.cs | This class contains all the class that are used to interact with the database. There are three classes, NormalScore, AdvancedScore, and GameSpeed. These classes are used to create the database tables hence giving each table a unique name apon creation, they are also used to insert data.

### **SQLite**
The SQLite database saves the scores and the game speed on a local database.
The database called madmath.db consists of three tables which are as follows:

Table Name | Description
------------ | -------------
NormalScore | Holds high scores for the normal difficulty.
AdvancedScore | Holds high scores for the advanced difficulty.
GameSpeed | Holds the game speed which is used to determine the speed of the timer.

## **SQLite Data Storage**
To install SQLite for a project on Visual Studio 2015 you must do the following:
- First you need to go to the SQLite download site at [https://www.sqlite.org/download.html](https://www.sqlite.org/download.html)
- Download SQLite for **Universal Windows Platform**
- Open up Visual Studio 2015
- The first thing we must do once Visual Studio 2015 is opened is add a reference to SQLite
- Right click on the **References** folder in your project on **Solution Explorer** and then click **Add Reference**
- On the pop up window, navigate to the **Universal Windows section** on the left and click **Extensions** 
- Tick the **SQLite for Universal App platform** box, and also the **C++ Runtime 2015** then click **OK**
- In your project in solution explorer once again right click on the **References** folder and select **Manage Nuget Packages**
- Select **Browse** and then type the following into the search area: **SQLite.Net-PCL**
- You should see the package, then click **install**
- Thats it, SQLite is now installed into the project

## **Deployment For Visual Studio 2015**
- Download the zip file provided.
- Open the project .sln file using Visual Studio 2015.
- You may need to follow the steps to install SQLite that were decribed earlier. Id imagine though that it will come as part of the project.
- Run the project.

## **References**
1. [MVVM basics (https://www.codeproject.com/Articles/81484/A-Practical-Quick-start-Tutorial-on-MVVM-in-WPF)]
2. [Xaml Grid Rows and Columns (http://www.wpf-tutorial.com/panels/grid-rows-and-columns/)]
3. [SQLite Visual Studio Setup (http://blog.tigrangasparian.com/2012/02/09/getting-started-with-sqlite-in-c-part-one/)]
4. MVVM structure - Lab exercise
5. [SQLite queries (https://code.msdn.microsoft.com/windowsapps/Local-Data-Base-SQLite-for-5e6146aa)]
6. [SQLite Classes (http://stackoverflow.com/questions/29454502/how-do-you-create-an-sqlite-database-with-c-sharp-in-visual-studio)]
7. [Progress Bar Timer (https://www.youtube.com/watch?v=xUV4L8wtR7k)]
