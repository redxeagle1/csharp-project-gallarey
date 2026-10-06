using MathGame.GameWindows;

namespace MathGame.AbstractBases;

// A generic class to hold all the windows and unifying the handling for modularity and simplicity
public abstract class WindowBase
{
    
    // the method to draw and construct the current window
    public abstract void Render();

    // method to process the user's option if they enters [a,b,c] based on the active valid options
    public abstract WindowMap ProcessInput(string userInput);
}
