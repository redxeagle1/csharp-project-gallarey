namespace MathGame.GameQuestion;

/* this will be responsible for the following
    1. counting the specified timer per question
    2. printing the timer out to the user provide by a public static utility
    3. return a signal denoting that the timer is finished
    4. have a public prop to access that return the remaining time on demand
*/
public static class QuestionTimer 
{
    #region Fields
        // we will use that to get the expected end time
        private static DateTime _targetTime;

        // this will be the actual count down
        private static int _lastPrintedTime;
    #endregion 
    
    
    
    #region Properties

        public static int CountDown => _lastPrintedTime; 
        private static int TimerLocationX { get; set; } // the exact print location
        public static bool IsTimeFinished { get; set; } // to declare a timeout event
        private static bool IsActive { get; set; } // internally to

    #endregion
    
    ///////////////////
    
    #region Methods

    // set up the timer countdown and initialize the timer
    public static void StartTimer(int timerLocationX,int countdown)
    {
        TimerLocationX = timerLocationX;
        // calculate the exact end time
        _targetTime = DateTime.Now.AddSeconds(countdown);
        _lastPrintedTime = countdown;
        
        IsTimeFinished = false;
        IsActive = true;
        
        
        PrintTimer(countdown);

    }

    // update the timer countdown till the end
    public static void UpdateTimer()
    {
        // stop if this method isn't in use
        if (!IsActive)
        {
            return;
        }

        // get the time span between the expected time and the current date
        TimeSpan remainingTime =  _targetTime -DateTime.Now;

        // print the difference result according to the nearest value
        // and  If value is halfway between two whole numbers,
        // the even number is returned; that is, 4.5 is converted to 4, and 5.5 is converted to 6
        int currentPrintedTime = Convert.ToInt32(remainingTime.TotalSeconds);


        // check the timer reached zero
        if (currentPrintedTime <= 0)
        {
            IsActive = false;
            IsTimeFinished = true;
            PrintTimer(currentPrintedTime);
            return;
        }
        
        
        // update the timer
        if (currentPrintedTime < _lastPrintedTime)
        {
            _lastPrintedTime = currentPrintedTime;
            PrintTimer(currentPrintedTime);
        }
        
    }
    
    
    
    // print the timer to the user
    private static void PrintTimer(int countdown)
    {
        int tempX = Console.CursorLeft;
        int tempY = Console.CursorTop;

        
        // move to the timer's location
        Console.SetCursorPosition(TimerLocationX,0);
        
        // update the countdown
        Console.Write($"Remaining Time: {(countdown<10 ? $"\e[31m{countdown}\e[0m".PadRight(25, ' ') : countdown)}");
        Console.SetCursorPosition(tempX,tempY);
        
    }
    #endregion
}