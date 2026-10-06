using MathGame.AbstractBases;
using MathGame.GameQuestion.Answers;

namespace MathGame.GameQuestion.Questions;

public class QuestionNormal : QuestionBase<string>,IQuestion
{
    public QuestionNormal(Problem problem) : base(problem)
    {
        _answer =new(problem);
        var questionHeaderTypeHint = "What Is The Output Of The Following Problem ?";
        var questionCaption = $"\r\n{problem.FirstNum} {problem.Operation} {problem.SecondNum} = ?";
        var questionAnswers = "";
        QuestionPrompt = questionHeaderTypeHint + questionCaption + questionAnswers;
    }

    public override GameQuestionType QuestionType =>GameQuestionType.Normal;

    public override string QuestionPrompt {get;}
    public override bool CheckAnswer(string answer) => _answer.ValidateAnswer(answer);

    public override AnswerBase<string> Answer => _answer;
    
    private readonly AnswerNormal _answer;

}
