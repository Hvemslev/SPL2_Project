using Microsoft.Xna.Framework;
using PatternLibrary.CommandPattern;


namespace SPL2_Project.CommandPattern;


public class MoveCommand : ICommand
{
    private Vector2 direction;
    private Player player;


    public MoveCommand(Vector2 _direction, Player _player)
    {
        player = _player;
        direction = _direction;
    }

    public void Execute()
    {
        // Code to execute when the command is executed
        player.Move(direction);
    }

    public void Undo()
    {
        // Code to execute when the command is undone
    }
}