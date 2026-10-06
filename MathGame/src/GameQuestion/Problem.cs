namespace MathGame.GameQuestion;


// this struct will be embedded to all questions and it size less than 16 byte
public readonly struct Problem
{

    #region fields

    private readonly int _range ; // the maximum range of generations
    private readonly char[] _operation = ['+', '-', '*', '/']; // operator list
    
    #endregion
    
    
    #region Properties
    // this represent a simple operation operands and the answer
    public int FirstNum { get; }
    public char Operation { get; }
    public int SecondNum { get;}
    public int Answer { get; }
    #endregion

    public Problem(Options options)
    {
            // set the difficulty
        var difficulty = options.Difficulty;

        // get the range
        _range = difficulty switch
        {
            GameDifficulty.Easy => 11,
            GameDifficulty.Normal => 101,
            GameDifficulty.Hard => 501,
            GameDifficulty.Insane => 1001,
            GameDifficulty.Impossible => 2001,
            _ => throw new IndexOutOfRangeException()
        };


        Operation = GenerateOperation(options.Operation);
        
        // using tuples to assign multiple values at once [Didn't know that at first]
        (FirstNum,SecondNum,Answer ) = Operation switch
        {
            '+'=>GenerateAdditionProblem(),
            '-' => GenerateSubtractionProblem(),
            '*'=> GenerateMultiplicationProblem(),
            '/' => GenerateDivisionProblem(),    
            _ =>throw new InvalidOperationException("Unsupported operation")
        };
    }

    // get current operation
    private readonly char GenerateOperation(GameOperation operation) => operation switch
    {
        GameOperation.Addition => _operation[0],
        GameOperation.Subtraction => _operation[1],
        GameOperation.Multiplication => _operation[2],
        GameOperation.Division => _operation[3],
        // get a random index for the operation array ranged from 0 to Length
        GameOperation.Random => _operation[Random.Shared.Next(_operation.Length)],
        _ => throw new ArgumentOutOfRangeException($"unknown {nameof(operation)} : {operation} type")
    };
   
    #region Problem Operands Generators
    private (int first,int second,int answer) GenerateAdditionProblem()
    {
        int first = Random.Shared.Next(0, _range);
        int second = Random.Shared.Next(0, _range);
        
        // return a tuple containing all the problem parts
        return (first,second,first+second);
    }
    private (int first,int second,int answer) GenerateSubtractionProblem()
    {
        int first = Random.Shared.Next(0, _range);
        int second = Random.Shared.Next(0, first+1); // to make sure it's alway positive
        
        
        // return a tuple containing all the problem parts
        return (first,second,first-second);
    }
    private (int first,int second,int answer) GenerateMultiplicationProblem()
    {
        int first = Random.Shared.Next(0, _range);
        int second = Random.Shared.Next(0, _range);


        // return a tuple containing all the problem parts
        return (first,second,first*second);
    }
    private (int first,int second,int answer) GenerateDivisionProblem()
    {
        // get the second operand
        int second = Random.Shared.Next(1, 101);

        // it's the maximum possible number to be generated 
        int maxMultiplayer = (_range-1)/ second;
        
        // using the multiplayer to a valid possible random answer
        int answer = Random.Shared.Next(0, maxMultiplayer + 1);
        
        // get the first operand from the second and the answer
        int first = second * answer;

        // return a tuple containing all the problem parts
        return (first,second,answer);
    }
    #endregion


}