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
