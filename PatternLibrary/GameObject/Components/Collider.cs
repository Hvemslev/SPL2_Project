using System.Drawing;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PatternLibrary.Collider;
using PatternLibrary.Event;


namespace PatternLibrary.GameObject;


/// <summary>
/// Component responsible for object collision and notification
/// </summary>
public class Collider : IComponent, ICollider
{
    private Vector2 size, origin;
    private Texture2D texture;
    
    /// <summary>
    /// Send out event notification when collision is detected
    /// </summary>
    public GameEvent OnCollisionEvent { get; } = new GameEvent("Collision");

    /// <summary>
    /// Should object check collision events
    /// </summary>
    public bool CheckCollisionEvents { get; set; }

    /// <summary>
    /// Collider position offset
    /// </summary>
    public Vector2 PositionOffset { get; set; }

    /// <summary>
    /// Collider scaling
    /// </summary>
    public Vector2 ColliderScale { get; set; } = new Vector2(1,1);

    /// <summary>
    /// Has object collided with anything
    /// </summary>
    public RectangleF LastCollisionBox { get; set; }

    /// <summary>
    /// Is collider gonna be moving
    /// </summary>
    public bool Dynamic { get; set; }

    /// <summary>
    /// Collider collisionbox
    /// </summary>
    public RectangleF CollisionBox {
        get {
            return new RectangleF
            (
                GameObject.Transform.Position.X - origin.X + PositionOffset.X,
                GameObject.Transform.Position.Y - origin.Y + PositionOffset.Y,
                size.X * ColliderScale.X,
                size.Y * ColliderScale.Y
            );
        }
    }

    /// <summary>
    /// The component this interface is attached to
    /// </summary>
    public IComponent ColliderComponent { get; private set; }

    public bool IsEnabled { get; set; }
    public GameObject GameObject { get; set; }


    /// <summary>
    /// Collider constructor
    /// </summary>
    /// <param name="spriteRenderer">SpriteRenderer reference</param>
    /// <param name="gameListener">GameListener reference</param>
    public Collider(bool isDynamic, GraphicsDevice graphicsDevice, SpriteRenderer spriteRenderer, IGameListener gameListener)
    {
        Dynamic = isDynamic;
        OnCollisionEvent.Attach(gameListener);
        origin = spriteRenderer.Origin;
        size = new Vector2(spriteRenderer.Sprite.Width, spriteRenderer.Sprite.Height);
        texture = Helper.CreateTexture(graphicsDevice, 1, 1, pixel => Microsoft.Xna.Framework.Color.White);
    }

    /// <summary>
    /// Collider constructor
    /// </summary>
    /// <param name="spriteRenderer">SpriteRenderer reference</param>
    public Collider(bool isDynamic, GraphicsDevice graphicsDevice, SpriteRenderer spriteRenderer)
    {
        Dynamic = isDynamic;
        this.origin = spriteRenderer.Origin;
        this.size = new Vector2(spriteRenderer.Sprite.Width, spriteRenderer.Sprite.Height);
        texture = Helper.CreateTexture(graphicsDevice, 1, 1, pixel => Microsoft.Xna.Framework.Color.White);
    }

    public void Awake()
    {
        
    }

    /// <summary>
    /// Start method
    /// </summary>
    public void Start()
    {
        Locator.Collisions.AddCollider(this);
        ColliderComponent = this;
    }

    /// <summary>
    /// Notify listener upon entering another collider
    /// </summary>
    /// <param name="other">Other collider collided with</param>
    public void OnCollisionEnter(ICollider other)
    {
        if (CheckCollisionEvents)
        {
            if (other != this)
            {
                if (CollisionBox.IntersectsWith(other.CollisionBox))
                {
                    OnCollisionEvent.Notify(other.ColliderComponent);
                }
            }
        }
    }

    public void Update(GameTime gameTime)
    {
        
    }

    /// <summary>
    /// Draw collisionbox
    /// </summary>
    /// <param name="spriteBatch">SpriteBatch reference</param>
    public void Draw(SpriteBatch spriteBatch)
    {
        //Microsoft.Xna.Framework.Rectangle tmp = new Microsoft.Xna.Framework.Rectangle((int)CollisionBox.X, (int)CollisionBox.Y, (int)CollisionBox.Width, (int)CollisionBox.Height);
        //spriteBatch.Draw(texture, new Vector2(CollisionBox.X, CollisionBox.Y), tmp, Color.HotPink * 0.6f, 0, Vector2.Zero, 1, SpriteEffects.None, 1);
    }

    /// <summary>
    /// Attaches IGameListener to be notified on collision
    /// </summary>
    /// <param name="listener"></param>
    public void AttachColliderListener(IGameListener listener)
    {
        OnCollisionEvent.Attach(listener);
    }

    public void DetachColliderListener(IGameListener listener)
    {
        OnCollisionEvent.Detach(listener);
    }

    /// <summary>
    /// Collider cleanup
    /// </summary>
    public void Destroy()
    {
        Locator.Collisions.RemoveCollider(this);
    }

    /// <summary>
    /// Used for referencing component via name
    /// </summary>
    /// <returns>Class name</returns>
    public string ComponentName()
    {
        return this.GetType().Name;
    }
}