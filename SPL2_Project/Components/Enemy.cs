using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PatternLibrary;
using PatternLibrary.GameObject;

namespace SPL2_Project;

public class Enemy : IComponent
{
    Vector2 direction;

    private GameObject playerObject;

    private float enemySpeed = 3f;

    float maxRange = 300;

    int bulletSpeed = 15;

    double shotCooldown = 0;

    GraphicsDevice graphic;
    
    public bool IsEnabled { get; set; }
    public GameObject GameObject { get; set; }


    public Enemy(GameObject _playerObject, GraphicsDevice _graphic)
    {
        playerObject = _playerObject;
        graphic = _graphic;
    }

    public void Awake()
    {
        
    }

    public void Start()
    {
        
    }

    public void Update(GameTime gameTime)
    {
        Vector2 directionLong = playerObject.Transform.Position - GameObject.Transform.Position;
        
        direction = Vector2.Normalize(directionLong);

        float distance = directionLong.Length();
        
        if(distance > maxRange)
        {
            GameObject.Transform.Position += direction * enemySpeed;
        } 


        if(distance <= maxRange)
        {
            shotCooldown += gameTime.ElapsedGameTime.TotalMilliseconds;
            if(shotCooldown >= 1000)
            {
                shoot();
                shotCooldown=0; 
            }
        } else
        {
            shotCooldown=0;
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        //spriteBatch.Draw(Game1._texture, new Rectangle((int)GameObject.Transform.Position.X, (int)GameObject.Transform.Position.Y, 20, 20), Color.White);
    }

    public void shoot()
    {
        GameObject bullet = Locator.Objects.CreateGameObject("Bullet", GameObject.Transform.Position);
        bullet.AddComponent(new Bullet(direction, bulletSpeed));
        SpriteRenderer sprite = new SpriteRenderer(Game1._texture);
        sprite.Scale = 10f;
        bullet.AddComponent(sprite);
        // TODO: Remove collider scale, when we have proper sprites with correct sizes
        bullet.AddComponent(new Collider(true, graphic, sprite) { ColliderScale = new Vector2(10, 10) });
    }

    public void Destroy()
    {
        
    }

    public string ComponentName()
    {
        return this.GetType().Name;;
    }
}