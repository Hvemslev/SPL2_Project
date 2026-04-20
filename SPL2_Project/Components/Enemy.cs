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
    
    public bool IsEnabled { get; set; }
    public GameObject GameObject { get; set; }


    public Enemy(GameObject _playerObject)
    {
        playerObject = _playerObject;
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
        spriteBatch.Draw(Game1._texture, new Rectangle((int)GameObject.Transform.Position.X, (int)GameObject.Transform.Position.Y, 20, 20), Color.White);
    }

    public void shoot()
    {
        Locator.Objects.CreateGameObject("Bullet", GameObject.Transform.Position)
        .AddComponent(new Bullet(direction, bulletSpeed));
    }

    public void Destroy()
    {
        
    }

    public string ComponentName()
    {
        return this.GetType().Name;;
    }
}