using MathGame.AbstractBases;
using MathGame.GameQuestion.Answers;

namespace MathGame.GameQuestion.Questions;

public class QuestionMcq : QuestionBase<char> , IQuestion
{
    private readonly AnswerMcq _answer;
    public override GameQuestionType QuestionType => GameQuestionType.Mcq;

    public QuestionMcq(Problem problem) : base(problem)
    {
        _answer = new(problem);
        var questionHeaderTypeHint = "Choose the Correct Answer";
        var questionCaption =  $"\r\n{Problem.FirstNum} {Problem.Operation} {Problem.SecondNum} = ?";
        var questionAnswers = $"\r\na) {_answer[0]}\r\nb) {_answer[1]}\r\nc) {_answer[2]}\r\nd) {_answer[3]}\r\n";
        QuestionPrompt = questionHeaderTypeHint + questionCaption + questionAnswers;
    }
    public override string QuestionPrompt { get; }
    public override bool CheckAnswer(string answer) => _answer.ValidateAnswer(answer[0]);

    public override AnswerBase<char> Answer => _answer;
    

}
