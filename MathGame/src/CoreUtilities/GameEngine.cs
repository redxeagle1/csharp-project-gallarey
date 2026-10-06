using MathGame.GameQuestion;
using MathGame.GameWindows;

namespace MathGame.CoreUtilities;

public static class GameEngine
// this class handle the window control as well as orchestration the gameplay
{
    
    #region  Fields
        // our shared game option storage
        // public static GameOptions SGameOptions = new(); 
        public static Options SGameOptionsRecord = new();
        // this will act as an id for our history handling
        public static int STotalNumberOfQuestions;
        
        // to track weather a game finished or not yet so it can commit it safely
        public static bool SFinishedGame;
        
        // our game history List or dynamic array
        public static readonly List<GameRecord> GameHistoryTable = new List<GameRecord>(1000);
        
        // Global tracker for both the record id and detection of array current size 
        public static int TotalGamesPlayed = 0;
    
    #endregion
    
    #region Properties
        // this is one-time use property to retrieve the game info from the window in which we play in
        // to commit it to a record and store it in the array
        public static DateTime StartTime{get;set;} // the date in which we start playing
        public static int Score{get;set;} // the game score
    #endregion

    #region Records
        // this will be our record for storage
        public record GameRecord(int Id,DateTime PlayedDate, int TotalScore, GameDifficulty Difficulty,GameOperation Operation,GameQuestionType QuestionType,int TotalNumberOfQuestions);
        
    #endregion
    
    #region Methods
    public static void GameSetup()
        // a setup method to set the environment before entering the loop
    {
        // Clear the Terminal
        Console.Clear();
        
        // preload the main window in advance
        WindowManager.SwitchState(WindowMap.MainMenu);
        WindowManager.ActiveWindow.Render();
    }
    public static void Render()
    // this will be our game loop
    {
        GameSetup();   
        while (true)
        {
            WindowManager.UpdateWindow();
            
            if (WindowManager.CurrentWindow == WindowMap.QuitBanner)
            {
                return;
            }
            
            // to make sure that our next logic is executed correctly
            // we need to execute the following if the screen is valid
            if (WindowManager.CurrentWindow == WindowMap.GameWindow)
            {
                QuestionTimer.UpdateTimer();
            }

            // skip the iteration if the screen doesn't fulfill the minimal required screen size
            if (!WindowManager.CheckValidScreen()) continue;
            
            
            //  true if a key press is available
            if (Console.KeyAvailable) 
            {
                /* Why Not ReadLine()
                 this was better than readline method since it stop the code execution and
                 for my code implementation it was unforgiving since it's single-threaded execution
                 and I didn't want to start learning about the multi-threading and processing at least
                 not yet and I felt it will be a shortcut for execution which for a beginner like
                 me nah it will be bad
                */
                
                // listen to user's keystroke
                ConsoleKeyInfo keyInfo = Console.ReadKey(true); // true hide the automatic key echoing
                Console.TreatControlCAsInput = false; // so to prevent accidental catch of the control 
                
                // this return a string weather it's 1 char or a full string
                string userInput = InputHandler.HandleUserInput(keyInfo);
                
                // of course, I handled nullability in the InputHandler, 
                // but it will result System.IndexOutOfRangeException once typing in the game
                // if not handled
                if (!string.IsNullOrEmpty(userInput))
                {
                    
                    // receive ActiveWindow's ProcessInput method output state
                    WindowMap nextState = WindowManager.ActiveWindow.ProcessInput(userInput : userInput);
                    
                    // if state has change pass the new state to the window manager to handle it
                    if (WindowManager.CurrentWindow != nextState)
                    {
                        WindowManager.SwitchState(nextState);
                    }
                    
                    // this to force update our window if there is an error next time
                    // user enters something why to clear that error as well internally
                    else if (!InputHandler.HasError)
                    {
                        Console.Clear();
                        WindowManager.ActiveWindow.Render();
                    }
                }

            }
            
            
            // Force penalty on timeout
            else if (WindowManager.CurrentWindow == WindowMap.GameWindow && QuestionTimer.IsTimeFinished)
            {
                // pass a special flag to denote it
                WindowManager.ActiveWindow.ProcessInput("TIMEOUT");
                
                // reset the timer and console
                QuestionTimer.IsTimeFinished = false; 
                Console.Clear();
                
                // refresh the game window to move to the next question
                WindowManager.ActiveWindow.Render();
            }
            
            // checks if a game is finished to save the result
            if (SFinishedGame)
            {
                CommitHistory();
                SFinishedGame = false;
            }
        }

    }

    public static void CommitHistory()
    // this method creates and push a GameRecord object to the history table
    {
            GameRecord record = new GameRecord(TotalGamesPlayed, StartTime, Score, SGameOptionsRecord.Difficulty,
                SGameOptionsRecord.Operation, SGameOptionsRecord.QuestionType, STotalNumberOfQuestions);
            GameHistoryTable.Add(record);
    }


    #endregion

}