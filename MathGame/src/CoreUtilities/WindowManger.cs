// using System.Collections;

using MathGame.AbstractBases;
using MathGame.GameWindows;
using MathGame.GameWindows.SetupMenu;
using MathGame.src.GameWindows;

namespace MathGame.CoreUtilities
{
    public static class WindowManager
    // A static utility class solely for managing window size update and switching
    {
        #region Fields
            // a constant array to define our minimum valid screen
            static readonly byte[] MinWindowCoordinates = [25, 85]; // (height,width) (y,x)


            // this field dictionary to be a general way to invoke and work with the windows rather than
            // handling each window separately
            private static readonly Dictionary<WindowMap, WindowBase> SWindows = new()
            {
                { WindowMap.MainMenu, new MainMenu() },
                {WindowMap.QuitBanner, new QuitWindow()},
                {WindowMap.SetupMenu,new SetupWindow()},
                { WindowMap.GameWindow , new GameWindow()},
                { WindowMap.GameOverWindow , new GameOverWindow()},
                { WindowMap.HistoryWindow , new HistoryWindow()},
                {WindowMap.AboutWindow , new AboutWindow()}
            };
        #endregion
        
        #region Properties
            // Track the current window and change it on demand
            public static WindowMap CurrentWindow { get; set; } = WindowMap.MainMenu;

            // this property get the active window based on the CurrentWindow Property 
            public static WindowBase ActiveWindow { get => SWindows[CurrentWindow]; }

            // Stores the current window height or what equivalent to the Y axis
            private static int UserWindowHeight { get; set; } = Console.WindowHeight;
            // Stores the current window width or what equivalent to the X axis
            private static int UserWindowWidth { get; set; } = Console.WindowWidth;

        #endregion
        
        #region Methods
            // it checks if the user window width[x] and height[y] exceeds the minium required Coordinates
            public static bool CheckValidScreen()
            {
                // store the current user window size and did that to minimize the props invoke
                // since they still technically methods
                int y = Console.WindowHeight;
                int x = Console.WindowWidth;


                // stored the minium window size in arrays for simplicity of use as well
                int minY = MinWindowCoordinates[0];
                int minX = MinWindowCoordinates[1];

                // compares between the current size the minimum window size
                if (y < minY || x < minX)
                {
                    // clear the window to properly display the message
                    Console.Clear();

                    // a string variable to tell the user what coordinate needs adjusting
                    var whatToAdjust = (y < minY, x < minX) switch
                    // used tuple expression to simplify the logic and make it more readable
                    {
                        (true, true) => $"both of Windows'Height and Width so (y: {y}) be >= {minY} and (x: {x}) be >= {minX}",
                        (false, true) => $"the Window Width so (x: {x}) be >= {minX}",
                        (true, false) => $"the Window Hight so (y: {y}) be >= {minY}",
                        (false, false) => string.Empty

                    };

                    // printing the message to the user
                    Console.WriteLine($"Window must be greater than or equal to  ({minY} x {minX}) please adjust {whatToAdjust}");
                    Thread.Sleep(100); // Prevents high CPU usage and 100 for me was the sweet spot
                    return false; // this method utilize the new c# 14's return guard for simplicity 
                }
                return true;
            }


            // A method that update the window size on demand 
            public static void UpdateWindow()
            {
                // if there is a change on the width or height clear console and redraw it with
                // the new width or height
                if (Console.WindowWidth != UserWindowWidth || Console.WindowHeight != UserWindowHeight )
                {
                    Console.Clear();
                    int newX = Console.WindowWidth;
                    int newY = Console.WindowHeight;
                    if (!CheckValidScreen())
                    {
                        return; // Halt the execution flow until the user fixes the window size 
                    }
                    
                    // update the stored width or height
                    UserWindowWidth = newX;
                    UserWindowHeight = newY;
                    
                    
                    Thread.Sleep(30); // Prevents high CPU usage
                    
                    // force a redraw for the user screen after resize
                    ActiveWindow.Render();
                }

            }
           
            
            // this method handle the switching mechanism
            public static void SwitchState(WindowMap newState)
            {
                
                if(CurrentWindow == newState)
                // check if the state have been change or still the same
                {
                    // return if that is there is no change
                    return;
                }
                // assign the new state to the CurrentWindow property
                CurrentWindow = newState;
                // clear the console for the new window
                Console.Clear();

                // renders the new window
                ActiveWindow.Render();
                
            }
        #endregion
    }
}