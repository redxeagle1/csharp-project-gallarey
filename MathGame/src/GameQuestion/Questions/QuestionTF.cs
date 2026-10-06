using MathGame.AbstractBases;
using MathGame.GameQuestion.Answers;

namespace MathGame.GameQuestion.Questions;

public class QuestionTf : QuestionBase<char> , IQuestion
{
    public QuestionTf(Problem problem) : base(problem)
    {
        _answer = new(problem);
        var questionHeaderTypeHint =  "Is This True or False ?";
        var questionCaption =  $"\r\n{Problem.FirstNum} {Problem.Operation} {Problem.SecondNum} = {_answer.AnswerContainer}";
        var questionAnswers = $"\r\n- True[t]\r\n- False[f]\r\n";
        QuestionPrompt = questionHeaderTypeHint + questionCaption + questionAnswers;
    }

    public override GameQuestionType QuestionType => GameQuestionType.TrueFalse;

    public override string QuestionPrompt {get;}
    public override bool CheckAnswer(string answer) => _answer.ValidateAnswer(answer[0]);

    public override AnswerBase<char> Answer => _answer;
    #region fields
    private readonly AnswerTf _answer;
    #endregion

}
