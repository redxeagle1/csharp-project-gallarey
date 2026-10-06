using MathGame.AbstractBases;
using MathGame.CoreUtilities;
using MathGame.GameQuestion;

namespace MathGame.GameWindows.SetupMenu;

public class SetupWindow : WindowBase
{
    private bool IsOptionsSet { get; set; }
    // private GameOptions _gameOptions = GameEngine.SGameOptions;
    private Options _gameOptions = GameEngine.SGameOptionsRecord;
    // process inputs
    public override WindowMap ProcessInput(string userInput)
    {
        // smart trick so instead of handling or the input I just checks the mean three keys [q,w,r]
        // and based on the IsOptionsSet I move one to the next option
        switch (userInput)
        {
            case "w" :
                SetupOptionHandler.ResetOptions(ref _gameOptions);
                IsOptionsSet = false;
                return WindowMap.SetupMenu;
            case "q":
                return WindowMap.MainMenu;
            case "y":
                // saves all our selection back to the Game Engine to utilize it in the game mech
                GameEngine.SGameOptionsRecord = _gameOptions;
                return WindowMap.GameWindow;
            default:
                if (!IsOptionsSet)
                {
                    IsOptionsSet = SetupOptionHandler.SetQuestionOptions(userInput, ref _gameOptions);
                }
                return WindowMap.SetupMenu;
        }
    }

    public override void Render()
    {
        // checks if IsOptionsSet is true to print out special format for it and return guard then 
        if (IsOptionsSet)
        {
            InputHandler.CurrentErrorLocation = 20;
            // change the Active Options to 
            InputHandler.SetActiveOptions = "yw";
            // A final display of user input
            Console.Write($"Difficulty : {_gameOptions.Difficulty}\t\tOperation : {_gameOptions.Operation}\t\tQuestion Type : {_gameOptions.QuestionType}\r\n");

            // Confirming the input
            Console.Write("Are you sure about your inputs");


            InputHandler.InputPrompt(
                [
                "- type [q] to go back to main menu",
                "- type [y] to Confirm",
                "- type [w] to wipe all selections",
                "- press [ctrl+c] to hard exit"
                ]
            );
            return;
        }
        
        // configure the input handle's active inputs and error location
        InputHandler.SetActiveOptions = "abcdew";
        InputHandler.CurrentErrorLocation = 20;
        Console.Write($"Choose From The Following Options:\r\n");
        Console.Write("\r\n");
        // render the options only
        SetupOptionHandler.RenderQuestionsSetup(_gameOptions);
        // ask for user input
        InputHandler.InputPrompt(
        [
            "- type [q] to go back to main menu",
            "- type [w] to wipe all selections",
            "- press [ctrl+c] to hard exit"
        ]
        );

    }
   
}