using System.Collections;
using System.Runtime.InteropServices;
using MathGame.AbstractBases;

namespace MathGame.GameQuestion.Answers;

public class AnswerMcq : AnswerBase<char>, IEnumerable
{

    #region Fields
    // A list that contains our answers
    private readonly List<int> _answerList = new(4);

    // Important for using string.Join
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    #endregion

    #region Properties
    public override GameQuestionType QuestionType => GameQuestionType.Mcq;

    // Important for using string.Join
    public IEnumerator GetEnumerator() => _answerList.GetEnumerator();

        #region Indexer
            // indexer to iterate through the answers
            public int this[int index] => _answerList[index];
            public int AnswerIndex {get;set;}
        #endregion
    #endregion

    #region Constructor
    public AnswerMcq(Problem problem)
    {
        var answer = problem.Answer;

        // add the answers
        _answerList.AddRange(GenerateAnswerCandidates(answer));

        // shuffle the elements in place
        Random.Shared.Shuffle(CollectionsMarshal.AsSpan(_answerList));        
        AnswerIndex = _answerList.IndexOf(answer);
    }
    #endregion

    #region Methods
    private List<int> GenerateAnswerCandidates(int a)
    // this method generate the keys and there values in the dictionary
    {
        int spreadBound = Math.Max(0, a - 10);
        // basically using to 
        // generate 21 number starting from the spread bound
        return
        [
            .. Enumerable.Range(spreadBound, 21)
                .Where(x => x != a) // exclude any real answer from the generation
                .OrderBy(x => Random.Shared.Next()) // shuffle
                .Take(3), // take 3 of that group 

            a
        ];
         
    }

    
    // check if the answer is correct without mapping overhead 
    public override bool ValidateAnswer(char userInput) => (char)(AnswerIndex + 97) == userInput;
    #endregion

}