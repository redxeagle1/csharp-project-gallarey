using System;
using MathGame.AbstractBases;
using MathGame.CoreUtilities;
using MathGame.GameWindows;

namespace MathGame.src.GameWindows;

public class AboutWindow : WindowBase
{
    public override WindowMap ProcessInput(string userInput)
    {
        return userInput switch
        {
            "q" => WindowMap.MainMenu,
            _ => throw new ArgumentOutOfRangeException($"what is {userInput} ???"),
        };
    }

    public override void Render()
    {
        Console.Write("this project was developed as part of csharp-academy challenge and doesn't represent a core or a useful business product however you can use it to play with your children and young siblings who happened to be a computer nerd but will not receive any further core update but pull requests are welcomed");
        InputHandler.SetActiveOptions = "";
        InputHandler.CurrentErrorLocation = 9;
        InputHandler.InputPrompt(["press q to go back to the main menu","press ctrl+c to force stop the program"]);

    }
}
