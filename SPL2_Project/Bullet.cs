using System;
//using System.Numerics;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;


namespace SPL2_Project;

public class Bullet
{
    

    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D _texture;

    
    
    Vector2 position;
    Vector2 direction;
    int bulletSpeed;
    
    public Bullet(Vector2 position, Vector2 direction, int bulletSpeed)
    {
        
        
        
        this.position=position;
        this.direction=direction;
        this.bulletSpeed=bulletSpeed;
    }
    
    public void Update()
    {
        position+=direction*bulletSpeed;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(Game1._texture, new Rectangle((int)position.X, (int)position.Y, 10, 10), Color.White);
    }
}