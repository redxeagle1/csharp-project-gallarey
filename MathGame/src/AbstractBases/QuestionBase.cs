using MathGame.GameQuestion;

namespace MathGame.AbstractBases;

// a generic abstract class and each class name represent its purpose
public abstract class QuestionBase<T>(Problem problem) : IQuestion
{
    // they will hold our problem itself
    protected Problem Problem = problem;
    // to define the type Effectively
    public abstract GameQuestionType QuestionType{get;}
    
    
    // question prompt
    public abstract string QuestionPrompt { get; }
    // Answer Holder
    public abstract AnswerBase<T> Answer{get;} // note the T must be of the same type 
    public abstract bool CheckAnswer(string answer);  
    
    // this method will use the Problem Object in Order to prepare the question text
}
