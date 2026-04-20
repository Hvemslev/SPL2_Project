using System.Collections.Generic;
using System.Drawing;
using Microsoft.Xna.Framework;
using PatternLibrary.Event;


namespace PatternLibrary.Collider;

public interface ICollisionManager
{
    public List<ICollider> CollidersToRemove { get; }
    public List<ICollider> CollidersToAdd { get; }
    public List<ICollider> Colliders { get; }

    /// <summary>
    /// List of colliders able to move around
    /// </summary>
    public List<ICollider> DynamicColliders { get; }


    public void AddCollider(ICollider _colliderToAdd);
    public void RemoveCollider(ICollider _colliderToRemove);
    public void UpdateColliders();
    public void CheckColliderList();
}