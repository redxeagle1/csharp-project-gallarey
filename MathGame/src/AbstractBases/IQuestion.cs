using MathGame.GameQuestion;

namespace MathGame.AbstractBases;

// this is to orchestrate all the questions in the game window
public interface IQuestion
{
    GameQuestionType QuestionType { get; }
    string QuestionPrompt { get; }
    bool CheckAnswer(string userInput);
}