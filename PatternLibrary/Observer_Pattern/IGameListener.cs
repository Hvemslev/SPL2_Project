using PatternLibrary.GameObject;

namespace PatternLibrary.Event;

/// <summary>
/// Interface for things listening to GameEvents
/// </summary>
public interface IGameListener
{
    /// <summary>
    /// Notifies listeners that event has been triggered
    /// </summary>
    /// <param name="gameEvent">GameEvent that has been triggered</param>
    /// <param name="component">Component reference</param>
    void Notify(GameEvent gameEvent, IComponent component);
}