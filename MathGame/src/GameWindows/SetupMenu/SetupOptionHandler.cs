using MathGame.GameQuestion;

namespace MathGame.GameWindows.SetupMenu
{
    internal static class SetupOptionHandler
    {
        // this method returns bool denoting that the user have entered all the options 
        // and it also modified the Setup window's stored option variable 
        public static bool SetQuestionOptions(string userInput,ref Options options)
        {
            if (options.Difficulty == GameDifficulty.None)
            {
                options.Difficulty = SetGameDifficulty(userInput);
            }
            else if (options.Operation == GameOperation.None)
            {
                options.Operation = SetGameOperation(userInput);
            }
            else if (options.QuestionType == GameQuestionType.None)
            {
                options.QuestionType = SetGameQuestionType(userInput);
                // to indicate that the all options is set
                if (options.QuestionType != GameQuestionType.None)
                {
                    return true;
                }
            }
            return false;
        }
        
        // this method render the next option set and their options 
        public static void RenderQuestionsSetup(Options options)
        {
            string infoPanel = $"Difficulty : {options.Difficulty}\t\tOperation : {options.Operation}\t\tQuestion Type : {options.QuestionType}";
            if (options.Difficulty == GameDifficulty.None)
            {
                RenderDifficultyOptions();
            }
            else if (options.Operation == GameOperation.None)
            {
                RenderOperationOptions();
            }
            else if (options.QuestionType == GameQuestionType.None)
            {
                RenderQuestionTypeOptions();
            }
            // an info panel to display the selection summary
            Console.Write("\r\n");
            Console.WriteLine($"{infoPanel}\r\n");
        }

        // this region is responsible for printing out all options based on the current option type 
        #region Rendering Options
        private static void RenderDifficultyOptions()
        {
            Console.Write("\tchoose a difficulty}\r\n");
            Console.Write("\t\ta. easy (digits from 0 to 10)\r\n");
            Console.Write("\t\tb. normal (digits from 0 to 100)\r\n");
            Console.Write("\t\tc. hard (digits from 0 to 500)\r\n");
            Console.Write("\t\td. insane (digits from 0 to 1000)\r\n");
            Console.Write("\t\te. impossible (digits from 0 to 2000)\r\n");
        }
        private static void RenderOperationOptions()
        {
            Console.Write("\tchoose the operation}\r\n");
            Console.Write($"\t\ta. addition (+)\r\n");
            Console.Write($"\t\tb. subtraction (-)\r\n");
            Console.Write($"\t\tc. multiplication (x)\r\n");
            Console.Write($"\t\td. division (÷)\r\n");
            Console.Write($"\t\te. random operation\r\n");
        }
        private static void RenderQuestionTypeOptions()
        {
            Console.Write("\tchoose the question type\r\n");
            Console.Write("\t\ta. MCQ\r\n");
            Console.Write("\t\tb. true or false\r\n");
            Console.Write("\t\tc. fill the gaps\r\n");
            Console.Write("\t\td. normal\r\n");
            Console.Write("\t\te. random\r\n");
        }
        #endregion
        
        // this region is responsible for processing input based on the current option type 
        #region Process Input Options

            // these method return a difficulty based on the input 
            private static GameDifficulty SetGameDifficulty(string userInput) => userInput switch
            {
                "a" => GameDifficulty.Easy,
                "b" => GameDifficulty.Normal,
                "c" => GameDifficulty.Hard,
                "d" => GameDifficulty.Insane,
                "e" => GameDifficulty.Impossible,
                _ => GameDifficulty.None
            };
            // these method return a Operation based on the input 
            private static GameOperation SetGameOperation(string userInput) => userInput switch
            {
                "a" => GameOperation.Addition,
                "b" => GameOperation.Subtraction,
                "c" => GameOperation.Multiplication,
                "d" => GameOperation.Division,
                "e" => GameOperation.Random,
                _ => GameOperation.None
            };
            // these method return a QuestionType based on the input 
            private static GameQuestionType SetGameQuestionType(string userInput) => userInput switch
            {
                "a" => GameQuestionType.Mcq,
                "b" => GameQuestionType.TrueFalse,
                "c" => GameQuestionType.FillGaps,
                "d" => GameQuestionType.Normal,
                "e" => GameQuestionType.Random,
                _ => GameQuestionType.None
            };
        
        #endregion
        
        // this method reset the options
        public static void ResetOptions(ref Options options)
        {
            options.Difficulty = GameDifficulty.None;
            options.Operation = GameOperation.None;
            options.QuestionType = GameQuestionType.None;
        }
    }
}
