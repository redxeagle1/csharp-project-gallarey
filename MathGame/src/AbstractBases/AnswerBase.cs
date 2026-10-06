using MathGame.GameQuestion;

namespace MathGame.AbstractBases;

// a generic abstract class and each class name represent its purpose
public abstract class AnswerBase<T>
{
    // Store the question Type Itself
    public abstract GameQuestionType QuestionType {get;}



    // Validate the Answer either with a string or a char
    public abstract bool ValidateAnswer(T userInput);

}