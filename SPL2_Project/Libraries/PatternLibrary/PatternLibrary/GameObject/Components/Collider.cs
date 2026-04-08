using System.Drawing;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PatternLibrary;

// TODO: Remove dependance on GameWorld
/// <summary>
/// Component responsible for object collision and notification
/// </summary>
public class Collider : IComponent
{
    private GameEvent onCollisionEvent = new GameEvent("Collision");
    private Vector2 size, origin;
    private Texture2D texture;
    
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

    public bool IsEnabled { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public GameObject GameObject { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    /// <summary>
    /// Collider constructor
    /// </summary>
    /// <param name="spriteRenderer">SpriteRenderer reference</param>
    /// <param name="gameListener">GameListener reference</param>
    public Collider(SpriteRenderer spriteRenderer, IGameListener gameListener)
    {
        onCollisionEvent.Attach(gameListener);
        origin = spriteRenderer.Origin;
        size = new Vector2(spriteRenderer.Sprite.Width, spriteRenderer.Sprite.Height);
        texture = GameWorld.Instance.CreateTexture(1, 1, pixel => Color.White);
    }

    /// <summary>
    /// Collider constructor
    /// </summary>
    /// <param name="spriteRenderer">SpriteRenderer reference</param>
    public Collider(SpriteRenderer spriteRenderer)
    {
        this.origin = spriteRenderer.Origin;
        this.size = new Vector2(spriteRenderer.Sprite.Width, spriteRenderer.Sprite.Height);
        texture = GameWorld.Instance.CreateTexture(1, 1, pixel => Color.White);
    }

    public void Awake()
    {
        
    }

    /// <summary>
    /// Start method
    /// </summary>
    public void Start()
    {
        if (Dynamic)
        {
            GameWorld.Instance.DynamicColliders.Add(this);
            GameWorld.Instance.AddCollider(this);
        }
        else
        {
            GameWorld.Instance.AddCollider(this);
        }
    }

    /// <summary>
    /// Notify listener upon entering another collider
    /// </summary>
    /// <param name="other">Other collider collided with</param>
    public void OnCollisionEnter(Collider other)
    {
        if (CheckCollisionEvents)
        {
            if (other != this)
            {
                if (CollisionBox.IntersectsWith(other.CollisionBox))
                {
                    onCollisionEvent.Notify(other);
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
    /// Attaches IGameListener to game event
    /// </summary>
    /// <param name="listener"></param>
    public void AttachListener(IGameListener listener)
    {
        onCollisionEvent.Attach(listener);
    }

    /// <summary>
    /// Collider cleanup
    /// </summary>
    public void Destroy()
    {
        GameWorld.Instance.DynamicColliders.Remove(this); 
        GameWorld.Instance.RemoveCollider(this);
    }

    /// <summary>
    /// Used for referencing component via name
    /// </summary>
    /// <returns>Class name</returns>
    public override string ToString()
    {
        return "Collider";
    }
}