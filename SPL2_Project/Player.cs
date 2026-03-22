using System.Numerics;
using Microsoft.Xna.Framework.Input;

namespace SPL2_Project;

public class Player
{
    public Vector2 position = new Vector2(100, 100);

    private int playerSpeed = 4;

    public void Update()
    {
        if (Keyboard.GetState().IsKeyDown(Keys.W))
        {
            position.Y-=playerSpeed;
        }

        if (Keyboard.GetState().IsKeyDown(Keys.S))
        {
            position.Y+=playerSpeed;
        }

        if (Keyboard.GetState().IsKeyDown(Keys.A))
        {
            position.X-=playerSpeed;
        }

        if (Keyboard.GetState().IsKeyDown(Keys.D))
        {
            position.X+=playerSpeed;
        }
    }
}