namespace MathGame.GameQuestion;

// our game options
public enum GameDifficulty : byte {None,Easy,Normal,Hard,Insane,Impossible,}
public enum GameOperation : byte {None,Addition,Subtraction,Multiplication,Division,Random}
public enum GameQuestionType : byte {None,Mcq,TrueFalse,FillGaps,Normal,Random,}




// I deliberately record structs that as I used ENUMs [less than 16bytes]
// , embeddable , mutable , represent single type, and
// lastly I'm sure it won't be boxed
public record struct Options(GameDifficulty Difficulty, GameOperation Operation, GameQuestionType QuestionType);
