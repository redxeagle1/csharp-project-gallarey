
using MathGame.AbstractBases;
using MathGame.GameQuestion.Answers;

namespace MathGame.GameQuestion.Questions;

public class QuestionFillGaps : QuestionBase<string>
{
    public QuestionFillGaps(Problem problem) : base(problem)
    {
        _answer = new(problem);
        _problemList =
        [
            problem.FirstNum.ToString(),
            problem.Operation.ToString(),
            problem.SecondNum.ToString(),
        ];
        var questionHeaderTypeHint = "Fill The Gaps";
        var questionCaption = $"\r\n{GetQuestionCaption()}= {Problem.Answer}";
        var questionAnswers = $"\r\nWhat must be written to satisfy the problem?";
        QuestionPrompt = questionHeaderTypeHint + questionCaption + questionAnswers;
    }

    public override GameQuestionType QuestionType => GameQuestionType.FillGaps;

    public override string QuestionPrompt{get;}

    public override AnswerBase<string> Answer => _answer;

    public override bool CheckAnswer(string answer) => _answer.ValidateAnswer(answer);

    

    private readonly AnswerFillGap _answer;
    private readonly string[] _problemList;


    private string GetQuestionCaption()
    {
        string temp = "";
        for (int i = 0; i < 3; i++)
        {
            temp += _answer.TargetGabIndex == i ? "?" : $"{_problemList[i]}";
            temp += " ";
        }

        return temp;
    }
}
