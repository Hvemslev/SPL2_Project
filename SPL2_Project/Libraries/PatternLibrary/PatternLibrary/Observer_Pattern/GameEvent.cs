using System.Collections.Generic;
using PatternLibrary.GameObject;

namespace PatternLibrary.Event;

/// <summary>
/// Class responsible for handling specific game event
/// </summary>
public class GameEvent
{
    // List of listeners that should be notified when event triggers
    private List<IGameListener> listeners = new List<IGameListener>();

    /// <summary>
    /// Event title
    /// </summary>
    public string Title { get; private set; }


    /// <summary>
    /// GameEvent constructor
    /// </summary>
    /// <param name="title">Event title</param>
    public GameEvent(string title)
    {
        this.Title = title;
    }

    /// <summary>
    /// Attach GameListener to event
    /// </summary>
    /// <param name="listener">GameListener to attach</param>
    public void Attach(IGameListener listener)
    {
        listeners.Add(listener);
    }

    /// <summary>
    /// Detach GameListener from event
    /// </summary>
    /// <param name="listener">GameListener to detach</param>
    public void Detach(IGameListener listener)
    {
        listeners.Remove(listener);
    }

    /// <summary>
    /// Notify listeners when event is triggered
    /// </summary>
    /// <param name="other">Component reference</param>
    public void Notify(IComponent other)
    {
        foreach (IGameListener listener in listeners)
        {
            listener.Notify(this, other);
        }
    }
}