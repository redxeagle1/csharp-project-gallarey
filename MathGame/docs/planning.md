# project

## Requirements

- You need to create a game that **consists** of asking the player what's the result of a math question (i.e. 9 x 9 = ?), collecting the input and adding a point in case of a correct answer.

<!-- ### solution -->

- A game needs to have at least 5 questions.
- The divisions should result on INTEGERS ONLY and dividends should go from 0 to 100. Example: Your app shouldn't present the division 7/2 to the user, since it doesn't result in an integer.
- Users should be presented with a menu to choose an operation
- You should record previous games in a List and there should be an option in the menu for the user to visualize a history of previous games.
- You don't need to record results on a database. Once the program is closed the results will be deleted.

## challenges

- Try to implement levels of difficulty.
- Add a timer to track how long the user takes to finish the game.
- Create a 'Random Game' option where the players will be presented with questions from random operations
- To follow the DRY Principle, try using just one method for all games. Additionally, double check your project and try to find opportunities to achieve the same functionality with less code, avoiding repetition when possible.

## Main menu

- the window must be constantly update to much the screen (18 X 80)

```text
███╗   ███╗ █████╗ ████████╗██╗  ██╗     ██████╗  █████╗ ███╗   ███╗███████╗
████╗ ████║██╔══██╗╚══██╔══╝██║  ██║    ██╔════╝ ██╔══██╗████╗ ████║██╔════╝
██╔████╔██║███████║   ██║   ███████║    ██║  ███╗███████║██╔████╔██║█████╗
██║╚██╔╝██║██╔══██║   ██║   ██╔══██║    ██║   ██║██╔══██║██║╚██╔╝██║██╔══╝
██║ ╚═╝ ██║██║  ██║   ██║   ██║  ██║    ╚██████╔╝██║  ██║██║ ╚═╝ ██║███████╗
╚═╝     ╚═╝╚═╝  ╚═╝   ╚═╝   ╚═╝  ╚═╝     ╚═════╝ ╚═╝  ╚═╝╚═╝     ╚═╝╚══════╝ [this will take about 6 X 76]


    a. Start The Game
    b. History Record
    c. About The Game
    d. Exit



[this will be in the end of the screen]
[hint of how the user will choose]                                                  [this will take about  1 X 50]
Type your answer :  [your choice] (MUST TRIM AND LOWER THE USER'INPUT)          [this will take about  1 X 37]
```

### logic

- the update loop must check if window width and hight are (18 X 80) if not it will pause the execution until the user follow the instructions
- there should be an option in the menu for the user to **visualize a history of previous games**.
- there should be an option for **starting the game which** which will give the following set of question to answer
  - choose a difficulty (type the Menu Keys:[a,b,c,d])
    - a. easy (digits from 0 to 10)
    - b. normal (digits from 0 to 100)
    - c. hard (digits from 0 to 10 + TIMED 10s)
    - d. insane (digits from 0 to 100 + TIMED 10s and 15s if random)
    - e. impossible (digits from 0 to 100 + TIMED 5s and 10s if random)
  > upon choosing the difficulty it will then show the type of operation
  - choose operation
    - a. addition (+)
    - b. subtraction (-)
    - c. multiplication (×)
    - d. division (÷)
    - e. random operation
  > upon choosing the operation it will then choose the type of question
  - choose your type of question
    - a. MCQ
    - b. true or false
    - c. fill the gaps
    - d. normal
    - e. random

## setup menu

- the window of the start setup Which will define how the game will work

```text
Choose From The Following Options

choose a difficulty

        a. easy (digits from 0 to 10)     4
        b. normal (digits from 0 to 100)
        c. hard (digits from 0 to 10 + TIMED 10s)
        d. insane (digits from 0 to 100 + TIMED 10s and 15s if random operation)
        e. impossible (digits from 0 to 100 + TIMED 5s and 10s if random operation)             8


Difficulty : NONE               Operation : NONE                Question Type : NONE


██  ██ ▄▄ ▄▄  ▄▄ ▄▄▄▄▄▄ ▄▄▄▄
██████ ██ ███▄██   ██  ███▄▄
██  ██ ██ ██ ▀██   ██  ▄▄██▀

- type a letter from [a, b, c, d, e]
- to go back to main menu [q] soft exit
- type [w] to wipe all selections
- press [ctrl+c] to hard exit


Type your answer :      23
```

### logic and design

- hight from 4 to 8 is the selection place and the maximum width is 76 the maximum that the window could reach is 23 rows and 76 columns
- add a method to wipe-out all the selection upon selection
- Add a method to print the current selection then print the user selection in a different location
- define How would you deal with q, w and general user input
- handle the input process correctly
