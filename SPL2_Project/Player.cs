using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SPL2_Project;

public class Player
{
    public Vector2 position = new Vector2(100, 100);
    private Vector2 currentLookDirection;
    private float lookAngleRadians = 0;
    private Texture2D line;


    public Player(GraphicsDeviceManager _graphic)
    {
        line = new Texture2D(_graphic.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
        line.SetData(new[] {Color.White});
    }

    public void Update()
    {
       currentLookDirection = GetAimDirection();
       lookAngleRadians = (float)Math.Atan2(currentLookDirection.Y, currentLookDirection.X);
    }

    public void Draw(SpriteBatch _spriteBatch)
    {
        _spriteBatch.Begin();
        _spriteBatch.Draw(line, new Rectangle((int)position.X, (int)position.Y, 200, 1), null, Color.White, lookAngleRadians, new Vector2(0, 0), SpriteEffects.None, 0);
        _spriteBatch.End();
    }

    private Vector2 GetAimDirection()
    {
        MouseState mouse = Mouse.GetState();
        Vector2 mousePosition = new Vector2(mouse.X, mouse.Y);

        return Vector2.Normalize(mousePosition - position);
    }
}