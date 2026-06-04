
namespace PatternLibrary.CommandPattern;

/// <summary>
/// Interface for command pattern, used for executing and undoing commands
/// </summary>
public interface ICommand
{
    public void Execute();
    public void Undo();
}