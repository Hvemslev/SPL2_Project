using System;
using System.Drawing;
using Microsoft.Xna.Framework;
using PatternLibrary.Event;
using PatternLibrary.GameObject;


namespace PatternLibrary.Collider;


public enum CollisionType
{
    Rectangle,
    Circle
}

public interface ICollider
{
    /// <summary>
    /// Send out event notification when collision is detected
    /// </summary>
    public GameEvent OnCollisionEvent { get; }
    public Action<string> OnCollisionEvent2 { get; }

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
    public ICollider LastCollision { get; set; }

    /// <summary>
    /// Is collider gonna be moving
    /// </summary>
    public bool Dynamic { get; set; }

    // TODO: This is a lazy solution that makes the interface dependant on IComponent
    /// <summary>
    /// The component this interface is attached to
    /// </summary>
    public IComponent ColliderComponent { get; }
    public CollisionType ColliderType { get; }


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
    public void AttachColliderListener(Action<string> collisionCallback);

    public void DetachColliderListener(IGameListener listener);
    public void DetachColliderListener(Action<string> collisionCallback);
}