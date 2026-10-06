using MathGame.AbstractBases;

namespace MathGame.GameQuestion.Answers;

public class AnswerTf : AnswerBase<char>
{
    #region Properties
    // the type of question of which the answer hold
    public override GameQuestionType QuestionType => GameQuestionType.TrueFalse;
    
    // the answer
    public bool StateAnswer{get;} 
    
    // the wrong or correct answer in which it be displayed
    public int AnswerContainer{get;}
    #endregion


    #region Fields
    private const int WrongAnswerChances = 70;
    #endregion
    #region Constructor
    public AnswerTf(Problem problem)
    {
        // to make the hard chances more common had to come with this
        // tbh I did use an LLM to construct this logic but almost 95% of code is written by me
        StateAnswer =Random.Shared.Next(100) >= WrongAnswerChances; 
        int answer = problem.Answer; // get the correct answer
        if (StateAnswer)
        {
            // if state is true
            AnswerContainer = answer;
            return;
        }
        // if not generate wrong answer
        AnswerContainer = GenerateWrongAnswer(answer);
    }
    #endregion

    #region Methods

    private int GenerateWrongAnswer(int correct)
    {
        int wrongAnswer=0;
        do
        {
            // get an offset near the correct answer by ranged 1 to 5 
            int offset = Random.Shared.Next(1,6); 
            // Randomly add or subtract offset but never go below zero
            wrongAnswer =
                Random.Shared.Next(2) == 0 ? 
                    correct + offset :
                    Random.Shared.Next(0,Math.Abs(correct-offset));  
        } while (wrongAnswer == correct); // iterate till the wrong and correct answer are unequal
        return wrongAnswer;
    }
    public override bool ValidateAnswer(char userInput)
    {
        // map userInput to boolean
        bool checkCorrectInput = userInput switch
        {
            't'=> true,
            'f'=> false,
            _ => throw new InvalidOperationException("received unknown input")
        };
        // validate
        return StateAnswer == checkCorrectInput;
    }
    #endregion

}