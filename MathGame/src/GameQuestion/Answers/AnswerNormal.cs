using MathGame.AbstractBases;

namespace MathGame.GameQuestion.Answers;

public class AnswerNormal(Problem problem) : AnswerBase<string>
{

    public override GameQuestionType QuestionType => GameQuestionType.Normal;
    public int CorrectAnswer { get; } = problem.Answer;

    public override bool ValidateAnswer(string userInput)
    {
        return int.Parse(userInput) == CorrectAnswer;
    }
}