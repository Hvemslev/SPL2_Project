

namespace PatternLibrary.CommandPattern;


public class NullCommand : ICommand
{
    public void Execute()
    {
        // Do nothing
    }

    public void Undo()
    {
        // Do nothing
    }
}