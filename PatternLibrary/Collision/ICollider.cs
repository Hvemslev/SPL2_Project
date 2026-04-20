using System.Drawing;
using Microsoft.Xna.Framework;
using PatternLibrary.Event;
using PatternLibrary.GameObject;


namespace PatternLibrary.Collider;


public interface ICollider
{
    /// <summary>
    /// Send out event notification when collision is detected
    /// </summary>
    public GameEvent OnCollisionEvent { get; }

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
    public Vector2 ColliderScale { get; set; }
    
    /// <summary>
    /// Has object collided with anything
    /// </summary>
    public RectangleF LastCollisionBox { get; set; }

    /// <summary>
    /// Is collider gonna be moving
    /// </summary>
    public bool Dynamic { get; set; }

    /// <summary>
    /// Rectangle used as collider reference
    /// </summary>
    public RectangleF CollisionBox { get; }

    // TODO: This is a lazy solution that makes the interface dependant on IComponent
    /// <summary>
    /// The component this interface is attached to
    /// </summary>
    public IComponent ColliderComponent { get; }


    /// <summary>
    /// Notify listener upon entering another collider
    /// </summary>
    /// <param name="other">Other collider collided with</param>
    public void OnCollisionEnter(ICollider other);

    /// <summary>
    /// Attaches IGameListener to be notified on collision
    /// </summary>
    /// <param name="listener"></param>
    public void AttachColliderListener(IGameListener listener);

    public void DetachColliderListener(IGameListener listener);
}