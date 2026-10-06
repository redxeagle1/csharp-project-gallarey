using MathGame.AbstractBases;

namespace MathGame.GameWindows;

// goofy simple goodbye display
public class QuitWindow :  WindowBase
{

    public override WindowMap ProcessInput(string userInput)
    {
        return WindowMap.None;
    }

    public override void Render()
    {
        Console.WriteLine("Goodbye");
        Thread.Sleep(1000);
    }
}
