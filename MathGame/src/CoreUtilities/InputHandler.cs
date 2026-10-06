using System.Text;

namespace MathGame.CoreUtilities
{
    // A unified utility class for handling user input effectively  
    public static class InputHandler
    {
        #region fields
            // this was preferred since I wanted to make most of my functions modular and window
            // agnostic our buffer char array which will hold our current ongoing valid options
            private static char[] _sActiveOptionsBuffer = ['a', 'b', 'c'];
        #endregion
        
        #region Properties
            
            // our buffer holder
            private static StringBuilder? InputBuffer { get; set; } = new();
            public static bool QuestionMode { get; set; } 
            
            // saving the input location
            private static int InputX{get; set;}

            private static int InputY{get; set;}
        
            // this is for controlling s_activeOptionBuffer it reset the current options into new ones
            public static string? SetActiveOptions
        {
            set
            {
                // ReSharper disable once PropertyFieldKeywordIsNeverUsed
                field = value; // Saves the string text into the hidden string aka field

                // I know this isn't a best practice
                // but window updates happens one a time not in a constant loop  
                // so it's better to go with that option for easy modularity and extensibility  
                _sActiveOptionsBuffer = (value ?? "").ToCharArray();
            }
        } = "abc";


            // indicators for wrong typing or invalid inputs 
            public static bool HasError { get; set; }

            // the place in which will display our errors in the current active window
            public static int CurrentErrorLocation { get; set; }
        
        #endregion
        
        #region Methods
        
        
            // this method handles the input buffer itself
            public static string HandleUserInput(ConsoleKeyInfo key)
            {
                var userInput = ""; // this is the return variable
                
                // based on the given key it will handle these cases
                switch (key.Key)
                {
                    // to submit the userInput to process it in the windows and handle any possible
                    // error like empty inputs
                    case ConsoleKey.Enter:
                        // store this input into the string we are returning
                        userInput = InputBuffer?.ToString() ?? "";

                        // to check for empty input before submitting the string
                        if (string.IsNullOrEmpty(userInput))
                        {
                            HasError = true;
                            ShowErrorMessage("You didn't type anything please enter something");
                        }
                        // clear the submitted input for reusing 
                        for (int i = 0; i < userInput.Length; i++)
                        {
                            Console.Write("\b \b");
                        }
                        // clear the buffer to reuse it again
                        InputBuffer?.Clear();
                        // check if there has been any errors flagged or no
                        if (HasError)
                        {
                            // if true fallback the default case
                            goto default;
                        }
                        break;
                    
                    // to add back spacing logic since we give up ReadLine
                    case ConsoleKey.Backspace: 
                        
                        // checking the length of the input buffer to avoid accidental invalid indexing  
                        if (InputBuffer?.Length > 0  )
                        {
                            
                            // remove the element once from the buffer
                            InputBuffer.Remove(InputBuffer.Length - 1, 1);
                            Console.Write("\b \b"); // Erase character visually from console screen

                            // Clean errors if spotted
                            if (HasError)
                            {
                                CleanErrors();
                            }
                        }
                        break;
                    
                    // pass the key itself to be check in handle key method
                    default:
                        HandleInputKeys(key);
                        break;
                }
                return userInput;
            }


            // this method handles the user keystrokes and store it in the InputBuffer
            private static void HandleInputKeys(ConsoleKeyInfo key)
            {
                // since the keys are capitalized I decided to lower them for easy processing
                var loweredKey = char.ToLower(key.KeyChar);
                // checking if our key is one of the valid options or a "q" and its length is 0
                bool isValidOptions = _sActiveOptionsBuffer.Contains(loweredKey) || loweredKey == 'q';

                // check generally if there is a wrong input and return if so
                if (!isValidOptions)
                {
                    if (!HasError)
                    {
                        // print the error message for the user
                        ShowErrorMessage(
                            $"You type wrong option you can only use[{string.Join(", ", _sActiveOptionsBuffer)}, q]");
                        // flip the error flag to true
                        HasError = true;
                    }
                    return;
                }
                
                // to check if the length is greater than 1 and question mode is off and return if so
                if (InputBuffer?.Length >= 1 && !QuestionMode)
                {
                    if (!HasError)
                    {
                        // print the error message for the user
                        ShowErrorMessage($"You Cannot type more than 1 letter option");
                        HasError = true;
                    }
                    return;
                }
                
                // to clean errors and proceed if nothing wrong was done
                if (HasError)
                {
                    CleanErrors();
                }
                
                
                // if everything is ok append this key to the buffer and visually prints it 
                InputBuffer?.Append(loweredKey);
                Console.Write(loweredKey);
                
            }

            // to check and clear any error
            private static void CleanErrors()
            {
                
                // passing an empty string will clear the error as well
                ShowErrorMessage("");

                // reset all the error flags as well
                HasError = false;
            }
            
            
            // just to show the user what is wrong
            public static void ShowErrorMessage(string currentErrorType)
            {
                

                // setting the cursor into the specified location to display the message 
                Console.SetCursorPosition(0, CurrentErrorLocation);
                // return a padded version to overWrite it
                string paddedError = currentErrorType.PadRight(Console.WindowWidth - 1, ' ');
                // print the message and over-write the rest of the line with blanks  
                Console.Write($"\e[31m{paddedError}\e[0m");
                // reset the cursor back to the old position
                int returnX = InputX + (InputBuffer?.Length ?? 0);
                Console.SetCursorPosition(returnX, InputY); 
            }
            
            
            // Rather than ask for input in each time the user move to a new menu this method
            // will handle this Idea as well as displaying tips to the user
            public static void InputPrompt(string[]? inputTips = null)
            {
                // separation to avoid cluttering the input area with the menu of the current window
                Console.Write("\r\n\r\n");


                // to address the null array I used null coalescing operator
                // if it founds that the array is null assign it to an empty array 
                inputTips ??= [];
                if (inputTips is not { Length: 0 })
                {
                    Console.Write($"NOTES:\r\n");
                    Console.Write($"\t{string.Join("\r\n\t", inputTips)}\r\n");
                }
                

                // this to hold the current active options
                string inputHints = $"type a letter from [{string.Join(", ", _sActiveOptionsBuffer)}, q]\r\n";
                // a prompt to encourage the user to type here  
                string askForInput = "\r\nType your answer : \t";
                Console.Write(inputHints);
                Console.Write(askForInput);
                // the null check is for safety, but this will just show what the user has typed
                InputX = Console.CursorLeft;
                InputY = Console.CursorTop;
                
                Console.Write(InputBuffer?.ToString().ToLower());
            }
        #endregion
    }
}