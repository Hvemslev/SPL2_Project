//using System.Numerics;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using PatternLibrary.GameObject;


namespace SPL2_Project;

public class Bullet : IComponent
{
    Vector2 direction;
    int bulletSpeed;

    public bool IsEnabled { get; set; }
    public GameObject GameObject { get; set; }

    public Bullet(Vector2 direction, int bulletSpeed)
    {
        this.direction = direction;
        this.bulletSpeed = bulletSpeed;
    }
    
    public void Awake()
    {
        
    }

    public void Start()
    {
        
    }

    public void Update(GameTime gameTime)
    {
        GameObject.Transform.Position += direction * bulletSpeed;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(Game1._texture, new Rectangle((int)GameObject.Transform.Position.X, (int)GameObject.Transform.Position.Y, 10, 10), Color.White);
    }

    public void Destroy()
    {
        
    }

    public string ComponentName()
    {
        return this.GetType().Name;
    }
}