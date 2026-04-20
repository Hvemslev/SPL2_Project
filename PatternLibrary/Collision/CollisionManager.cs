using System.Collections.Generic;
using System.Drawing;
using Microsoft.Xna.Framework;
using PatternLibrary.Event;


namespace PatternLibrary.Collider;

public class CollisionManager : ICollisionManager
{
    public List<ICollider> Colliders { get; }

    /// <summary>
    /// List of colliders able to move around
    /// </summary>
    public List<ICollider> DynamicColliders { get; } = new List<ICollider>();

    public List<ICollider> CollidersToRemove { get; } = new List<ICollider>();

    public List<ICollider> CollidersToAdd { get; } = new List<ICollider>();


    public void UpdateColliders()
    {
        foreach(ICollider collider in DynamicColliders)
        {
            foreach(ICollider otherCollider in Colliders)
            {
                collider.OnCollisionEnter(otherCollider);
            }
        }
    }

    public void CheckColliderList()
    {
        foreach(ICollider collider in CollidersToAdd)
        {
            if(collider.Dynamic) DynamicColliders.Add(collider); 
            else Colliders.Add(collider);
        }

        CollidersToAdd.Clear();

        foreach(ICollider collider in CollidersToRemove)
        {
            if(collider.Dynamic) DynamicColliders.Remove(collider); 
            else Colliders.Remove(collider);
        }

        DynamicColliders.Clear();
    }

    public void AddCollider(ICollider _colliderToAdd)
    {
        CollidersToAdd.Add(_colliderToAdd);
    }

    public void RemoveCollider(ICollider _colliderToRemove)
    {
        CollidersToRemove.Add(_colliderToRemove);
    }

    
}