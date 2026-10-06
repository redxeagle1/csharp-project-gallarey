using MathGame.AbstractBases;
using MathGame.CoreUtilities;

namespace MathGame.GameWindows;

public class GameOverWindow : WindowBase
{

    public override void Render()
    {

        // input handling configuration
        InputHandler.CurrentErrorLocation = 14;
        InputHandler.SetActiveOptions = "rc";

        // menu construction
        string label =
            """
               ▄▄                      ▗▄▖                
              █▀▀▌                     █▀█                
             ▐▌    ▟██▖▐█▙█▖ ▟█▙      ▐▌ ▐▌▐▙ ▟▌ ▟█▙  █▟█▌
             ▐▌▗▄▖ ▘▄▟▌▐▌█▐▌▐▙▄▟▌     ▐▌ ▐▌ █ █ ▐▙▄▟▌ █▘  
             ▐▌▝▜▌▗█▀▜▌▐▌█▐▌▐▛▀▀▘     ▐▌ ▐▌ ▜▄▛ ▐▛▀▀▘ █   
              █▄▟▌▐▙▄█▌▐▌█▐▌▝█▄▄▌      █▄█  ▐█▌ ▝█▄▄▌ █   
               ▀▀  ▀▀▝▘▝▘▀▝▘ ▝▀▀       ▝▀▘   ▀   ▝▀▀  ▀   
            """;                                      
        Console.Write($"{label}\r\n");
        
        // input tips
        string[] inputTips =
        [
            "[q] will wipe all the game data and exit",
            "[r] will reset the game with the settings",
            "[c] will go back to the main menu",
            $"{(GameEngine.SFinishedGame ? "your data was save successfully\r\n\t\tcheck the game history to find out" : "Couldn't Save Your Last Game's Data\r\nplease play at least 5 games to save your game")}"
        ];
        InputHandler.InputPrompt(inputTips);
    }

    // process input
    public override WindowMap ProcessInput(string userInput)
    {
        return userInput switch
        {
            "q"=>WindowMap.QuitBanner,
            "r"=>WindowMap.GameWindow,
            "c"=> WindowMap.MainMenu,
            _ => throw new ArgumentOutOfRangeException(nameof(userInput), userInput, null)
        };
    }
}