using MathGame.AbstractBases;
using MathGame.CoreUtilities;
using MathGame.GameQuestion;
using MathGame.GameQuestion.Questions;

namespace MathGame.GameWindows;

public class GameWindow : WindowBase
{

    
    private IQuestion? _question; // an interface for all the Questions
    private Options _options; // this is need 
    private int _chances = 5; // let the user at least have 5 chances each game
    private int _score; // user score
    private int _totalQuestionNumbers=1; // this must be one
    private int _totalQuestionNumbersSnapshot; // a snapshot of the total for comparison
    
    public override WindowMap ProcessInput(string userInput)
    {
        // check if the user didn't force quit or lost all the chances if so move to the GameOver
        if (_chances != 0 && userInput[0] != 'q')
        {
            // check either the time out occurred or is the answer wrong
            bool isAnswerWrong = userInput == "TIMEOUT" || !(_question != null && _question.CheckAnswer(userInput));
            
            // if the user answered correctly
            if (!isAnswerWrong)
            {
                // increment the total number
                _totalQuestionNumbers++;

                // increment the score based on timing 
                _score += QuestionTimer.CountDown + 1;
            }
            // if the user answered wrongly
            else
            {
                _totalQuestionNumbers++;
                _chances--;
            }
            // if there is any chances left keep the window
            if (_chances > 0)
            {
                // reload another question
                return WindowMap.GameWindow;
            }
            
        }
        // commit if five or more games are played
        if (_totalQuestionNumbers >= 5)
        {
            GameEngine.TotalGamesPlayed++;
            GameEngine.Score = _score;
            GameEngine.STotalNumberOfQuestions =  _totalQuestionNumbers;
            GameEngine.SFinishedGame = true;

        }
        else
        {
            GameEngine.SFinishedGame = false;
        }

        // reset the Game Window
        _chances = 5;
        _score = 0;
        _totalQuestionNumbers = 1;
        _totalQuestionNumbersSnapshot = 0;
        return WindowMap.GameOverWindow;
    }

    // copy the main option into a temp variable

    private void CheckTimer()
    {
        switch (_options.Difficulty)
        {
            case GameDifficulty.Easy:
                QuestionTimer.StartTimer(60, _options.Operation== GameOperation.Random ? 15:10);
                break;
            case GameDifficulty.Normal:
                QuestionTimer.StartTimer(60, _options.Operation== GameOperation.Random ? 15:20);
                break;
            case GameDifficulty.Hard:
                QuestionTimer.StartTimer(60, _options.Operation== GameOperation.Random ? 45:30);
                break;
            case GameDifficulty.Insane:
                QuestionTimer.StartTimer(60, _options.Operation== GameOperation.Random ? 60:45);
                break;
            case GameDifficulty.Impossible:
                QuestionTimer.StartTimer(60, _options.Operation== GameOperation.Random ? 75:60);
                break;
            default:
                throw new IndexOutOfRangeException($"add {_options.Difficulty} please");
        }
    }

    // print out the menu
    public override void Render()
    {
        // store the date for archiving
        GameEngine.StartTime = DateTime.Now;

        // store the current global option into a temp one
        _options = GameEngine.SGameOptionsRecord;

        // this check is crucial to prevent wiping and resetting the game window accidentally
        // on refreshes 
        if (_totalQuestionNumbers - _totalQuestionNumbersSnapshot == 1)
        {
            // update the snapshot to the new number
            _totalQuestionNumbersSnapshot = _totalQuestionNumbers;
            
            // get a new question
            _question = GetQuestion();
            
            // reset the timer
            CheckTimer();

        }
        // prepare the input settings
        ConfigureInputSettings(_question?.QuestionType);

        // print the screen
        Console.Write($"Question numbers: {_totalQuestionNumbers}\r\n");
        Console.Write(_question?.QuestionPrompt);
        Console.Write("\r\n");
        Console.Write($"\r\nChances Left: {_chances}");
        Console.Write($"\r\nCurrent Score: {_score}");
        InputHandler.InputPrompt(["type [q] to end the game"]);
    }

    // return an interface of the question based on the game options
    private IQuestion GetQuestion()
    {
        // using a ternary operator we check if the question type is random or no 
        // if it's select a random num from 1 to 5 then turn it into a question
        // else set it the presented type
        var type = _options.QuestionType == GameQuestionType.Random
            ? (GameQuestionType)Random.Shared.Next(1, 5)
            : _options.QuestionType;

        // generate a new problem struct
        var problem = new Problem(_options);
        // pass it to the returned object
        switch (type)
        {
            case GameQuestionType.Mcq:
                return new QuestionMcq(problem);
            case GameQuestionType.Normal:
                return new QuestionNormal(problem);
            case GameQuestionType.FillGaps:
                return new QuestionFillGaps(problem);
            case GameQuestionType.TrueFalse:
                return new QuestionTf(problem);
            default:
                throw new IndexOutOfRangeException($"the hell you mean {type}???");
        }
    }


    // set the input settings
    private void ConfigureInputSettings(GameQuestionType? questionType)
    {
        InputHandler.CurrentErrorLocation = 17;
        InputHandler.QuestionMode = false;
        switch (questionType)
        {
            case GameQuestionType.Mcq:
                InputHandler.SetActiveOptions = "abcd";
                break;
            case GameQuestionType.TrueFalse:
                InputHandler.SetActiveOptions = "tf";
                break;
            case GameQuestionType.Normal:
                InputHandler.QuestionMode = true;
                InputHandler.SetActiveOptions = "0123456789";
                break;
            case GameQuestionType.FillGaps:
                InputHandler.QuestionMode = true;
                InputHandler.SetActiveOptions = "0123456789+-*/";
                break;
            default:
                throw new Exception("unknown question type");
        }
    }
}