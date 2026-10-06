
using MathGame.AbstractBases;

namespace MathGame.GameQuestion.Answers;

public class AnswerFillGap : AnswerBase<string>
{
    #region Fields
    private int[] _operationList = new int[3];
    #endregion
    
    #region Properties
    public int TargetGabAnswer{get;} // this will store the target gap's answer
    public int TargetGabIndex{get;} // this will store the gap's index
    public override GameQuestionType QuestionType => GameQuestionType.FillGaps;
    #endregion
    
    #region Constructor
    public AnswerFillGap(Problem problem)
    {
        _operationList = [problem.FirstNum,problem.Operation,problem.SecondNum];
        TargetGabAnswer = GetTheTargetGapValue();
        TargetGabIndex = GetTheTargetGapIndex();
    }

    #endregion

    #region Methods
    private int GetTheTargetGapValue()
    // get the target's Value
    {
        int gap = Random.Shared.GetItems(_operationList,1)[0];
        return gap;
    }
    private int GetTheTargetGapIndex()
    {
        int gapIndex = _operationList.IndexOf(TargetGabAnswer);
        return gapIndex;
    }

    public override bool ValidateAnswer(string userInput)
    {
        if (userInput is "+" or "-" or "*" or "/")
        {
            return userInput[0] == TargetGabAnswer;
        }
        if (int.TryParse(userInput, out int answer))
        {
            return answer == TargetGabAnswer;
        }
        return false ;
    }
        
    #endregion

}
