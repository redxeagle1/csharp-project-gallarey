using MathGame.AbstractBases;
using MathGame.CoreUtilities;

namespace MathGame.GameWindows;

public class MainMenu : WindowBase
{

    // window drawing
    public override void Render()
    {
        InputHandler.SetActiveOptions = "abc";
        // set the input handler's valid options to
        InputHandler.CurrentErrorLocation = 17;
        // game components
        string[] gameLabel = [
            @"███╗   ███╗ █████╗ ████████╗██╗  ██╗     ██████╗  █████╗ ███╗   ███╗███████╗",
            @"████╗ ████║██╔══██╗╚══██╔══╝██║  ██║    ██╔════╝ ██╔══██╗████╗ ████║██╔════╝",
            @"██╔████╔██║███████║   ██║   ███████║    ██║  ███╗███████║██╔████╔██║█████╗"  ,
            @"██║╚██╔╝██║██╔══██║   ██║   ██╔══██║    ██║   ██║██╔══██║██║╚██╔╝██║██╔══╝  ",
            @"██║ ╚═╝ ██║██║  ██║   ██║   ██║  ██║    ╚██████╔╝██║  ██║██║ ╚═╝ ██║███████╗",
            @"╚═╝     ╚═╝╚═╝  ╚═╝   ╚═╝   ╚═╝  ╚═╝     ╚═════╝ ╚═╝  ╚═╝╚═╝     ╚═╝╚══════╝"
        ];

        string[] menu = 
        [
            "\t\t\t   A. Start the game",
            "\t\t\t   B. History records",
            "\t\t\t   C. About the game",
        ];

        // printing the game components
        Console.Write(string.Join("\r\n", gameLabel));

        // separation to avoid cluttering the window
        Console.Write("\r\n\r\n");
        Console.Write(string.Join("\r\n", menu));

        
        // input tips
        string[] notes = ["to end the program type [q] soft exit or [ctrl+c] hard exit"]; 
        // input prompt
        InputHandler.InputPrompt(notes);
    }
    
    // process the user input
    public override WindowMap ProcessInput(string userInput)
    {
        switch (userInput)
        {
            case "a":
                return WindowMap.SetupMenu;
            case "b":
                if (GameEngine.TotalGamesPlayed == 0)
                {
                    InputHandler.HasError = true;
                    // Push a completely custom error to the handler on demand
                    InputHandler.ShowErrorMessage("No history found. You must play a game first.");
                    
                    // Return the same state so the window doesn't switch
                    return WindowMap.MainMenu; 
                }
                return WindowMap.HistoryWindow;
            case "c":
                return WindowMap.AboutWindow;
            case "q":
                return WindowMap.QuitBanner;
            default:
                return WindowMap.MainMenu;
                
        }

    }    
}

