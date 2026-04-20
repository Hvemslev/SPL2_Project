using System.Collections.Generic;
using System.Drawing;
using Microsoft.Xna.Framework;
using PatternLibrary.Event;


namespace PatternLibrary.Collider;

public class NullCollisionManager : ICollisionManager
{
    public List<ICollider> Colliders { get; }

    public List<ICollider> DynamicColliders { get; }

    public List<ICollider> CollidersToRemove { get; }

    public List<ICollider> CollidersToAdd { get; }


    public void AddCollider(ICollider _colliderToAdd)
    {
        
    }

    public void CheckColliderList()
    {
        
    }

    public void RemoveCollider(ICollider _colliderToRemove)
    {
        
    }

    public void UpdateColliders()
    {
        
    }
}