using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SPL2_Project;

/// <summary>
/// Lavet i tidligere projekt (se rapport "Design Patterns Projekt Repulse" i afleveringsmappen på bilag 15)
/// Class responsible for rendering sprite
/// </summary>
public class SpriteRenderer : Component
{
    /// <summary>
    /// Object sprite
    /// </summary>
    public Texture2D Sprite { get; set; }
    /// <summary>
    /// Object origin
    /// </summary>
    public Vector2 Origin { get; set; }
    /// <summary>
    /// Object tint
    /// </summary>
    public Color Tint { get; set; } = Color.White;
    /// <summary>
    /// Object sortinglayer
    /// </summary>
    public float SortingLayer { get; set; } = 0.5f;
    /// <summary>
    /// Object opacity
    /// </summary>
    public float Opacity { get; set; } = 1;
    /// <summary>
    /// Object rotation
    /// </summary>
    public float Rotation { get; set; } = 0;
    /// <summary>
    /// Object scale
    /// </summary>
    public float Scale { get; set; } = 1;
    /// <summary>
    /// Object scale with Vector
    /// </summary>
    public Vector2 VectorScale { get; set; } = new Vector2(1, 1);
    /// <summary>
    /// Sets spriterendere to draw with VectorScale
    /// </summary>
    public bool UseVectorScale { get; set; } = false;
    /// <summary>
    /// Sprite effects
    /// </summary>
    public SpriteEffects SpriteEffects { get; set; } = SpriteEffects.None;
    public bool IsEnabled { get; set; }
    public GameObject GameObject { get; set; }

    /// <summary>
    /// SpriteRenderer constructor
    /// </summary>
    public SpriteRenderer()
    {
    }

    /// <summary>
    /// SpriteRenderer constructor with preloaded sprite via name
    /// </summary>
    /// <param name="spriteName"></param>
    public SpriteRenderer(string spriteName)
    {
        //Sprite = GameWorld.Instance.Content.Load<Texture2D>(spriteName);
    }

    /// <summary>
    /// SpriteRenderer constructor with preloaded sprite via texture
    /// </summary>
    /// <param name="sprite"></param>
    public SpriteRenderer(Texture2D sprite)
    {
        Sprite = sprite;
    }

    public void Awake()
    {
        
    }

    public void Start()
    {
        
    }

    /// <summary>
    /// Makes clone of component
    /// </summary>
    /// <returns></returns>
    public SpriteRenderer Clone()
    {
        return (SpriteRenderer)this.MemberwiseClone();
    }

    /// <summary>
    /// Draws game object
    /// </summary>
    /// <param name="spriteBatch"></param>
    public void Draw(SpriteBatch spriteBatch)
    {
        // TODO: Meybe find a better way to switch between Vector and float scale
        if(UseVectorScale)
		{
            spriteBatch.Draw(Sprite, GameObject.Transform.Position, null, Tint * Opacity, Rotation, Origin, VectorScale, SpriteEffects, SortingLayer);
        }
        else
		{
            spriteBatch.Draw(Sprite, GameObject.Transform.Position, null, Tint * Opacity, Rotation, Origin, Scale, SpriteEffects, SortingLayer);
        }           
    }

    public void Update(GameTime gameTime)   
    {
        
    }

    public void Destroy()
    {
        
    }

    /// <summary>
    /// Used for referencing component via name
    /// </summary>
    /// <returns>Class name</returns>
    public override string ToString()
    {
        return ToString();
    }
}