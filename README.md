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
(MVVM) Views/Settings.xaml.cs | 
(MVVM) Views/GameOver.xaml.cs | 
(MVVM) ViewModels/ScoreManagerViewModel.xaml.cs | 
(MVVM) Models/GameModeMenu.xaml.cs | 
(MVVM) Models/GameModeMenu.xaml.cs | 
(MVVM) Data/GameModeMenu.xaml.cs | 
(MVVM) Data/GameModeMenu.xaml.cs | 





