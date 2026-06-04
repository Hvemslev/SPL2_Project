using PatternLibrary.CommandPattern;


namespace SPL2_Project.CommandPattern;


public class ShootCommand : ICommand
{
    private Player player;


    public ShootCommand(Player _player)
    {
        player = _player;
    }

    public void Execute()
    {
        // Code to execute when the command is executed
        player.shoot();
    }

    public void Undo()
    {
        // Code to execute when the command is undone
    }
}