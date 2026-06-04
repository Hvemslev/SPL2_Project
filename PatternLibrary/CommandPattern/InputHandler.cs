using Microsoft.Xna.Framework.Input;
using PatternLibrary.Input;


namespace PatternLibrary.CommandPattern;


/// <summary>
/// Class responsible for handling input
/// </summary>
public class InputHandler
{
    private ICommand W_Command;
    private ICommand A_Command;
    private ICommand S_Command;
    private ICommand D_Command;
    private ICommand LeftMouse_Command;

    public InputHandler(ICommand w_Command, ICommand a_Command, ICommand s_Command, ICommand d_Command, ICommand leftMouse_Command)
    {
        W_Command = w_Command;
        A_Command = a_Command;
        S_Command = s_Command;
        D_Command = d_Command;
        LeftMouse_Command = leftMouse_Command;
    }

    /// <summary>
    /// Checks for input and executes commands
    /// </summary> <param name="gameTime"></param>
    public virtual void HandleInput(KeyboardInfo keyboardInfo)
    {
        if (keyboardInfo.IsKeyDown(Keys.W))
        {
            W_Command.Execute();
        }

        if (keyboardInfo.IsKeyDown(Keys.A))
        {
            A_Command.Execute();
        }

        if (keyboardInfo.IsKeyDown(Keys.S))
        {
            S_Command.Execute();
        }

        if (keyboardInfo.IsKeyDown(Keys.D))
        {
            D_Command.Execute();
        }

        if (Mouse.GetState().LeftButton == ButtonState.Pressed)
        {
            LeftMouse_Command.Execute();
        }
    }
}