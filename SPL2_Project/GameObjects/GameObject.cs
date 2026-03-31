
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SPL2_Project;

/// <summary>
/// Template for game objects
/// </summary>
public class GameObject
{
    /// <summary>
    /// Should object follow camera or not
    /// </summary>
    public bool IsUI { get; set; } = false;
    /// <summary>
    /// Object world location
    /// </summary>
    public Transform Transform { get; }
    /// <summary>
    /// Dictionary containing components accessed by their name
    /// </summary>
    private Dictionary<string, Component> components = new Dictionary<string, Component>();
    /// <summary>
    /// GameObject tag
    /// </summary>
    public string Tag { get; set; }
    /// <summary>
    /// GameObject constructor
    /// </summary>
    public GameObject()
    {
        Transform = new Transform();
    }
    /// <summary>
    /// Adds component to game object
    /// </summary>
    /// <param name="component"></param>
    public void AddComponent(Component component)
    {
        components.Add(component.ToString(), component);
        component.GameObject = this;
        component.IsEnabled = true;
    }
    /// <summary>
    /// Gets specific component from game object
    /// </summary>
    /// <param name="component">Component name</param>
    /// <returns></returns>
    public Component GetComponent(string component)
    {
        if (components.ContainsKey(component))
        {
            return components[component];
        }
        else
        {
            return null;
        }
    }
    /// <summary>
    /// Calls awake method on all components
    /// </summary>
    public void Awake()
    {
        foreach (Component component in components.Values)
        {
            component.Awake();
        }
    }
    /// <summary>
    /// Calls start method on all components
    /// </summary>
    public void Start()
    {
        foreach (Component component in components.Values)
        {
            component.Start();
        }
    }
    /// <summary>
    /// Calls update method on all components
    /// </summary>
    public void Update(GameTime gameTime)
    {
        foreach (Component component in components.Values)
        {
            if (component.IsEnabled)
            {
                component.Update(gameTime);
            }
        }
    }
    /// <summary>
    /// Calls draw method on all components
    /// </summary>
    public void Draw(SpriteBatch spriteBatch)
    {
        foreach (Component component in components.Values)
        {
            if (component.IsEnabled)
            {
                component.Draw(spriteBatch);
            }
        }
    }
    /// <summary>
    /// Calls destroy method on all components and removes game object from world
    /// </summary>
    public void Destroy()
    {
        foreach (Component component in components.Values)
        {
            component.Destroy();
        }
        // TODO: Figure out how to destroy the object
        //Game1.Instance.Destroy(this);
    }
}