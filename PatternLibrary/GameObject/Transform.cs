using Microsoft.Xna.Framework;

namespace PatternLibrary;
    
/// <summary>
/// Class responsible for in world coordinates and translation of coordinates
/// </summary>
public class Transform
{
    /// <summary>
    /// Object position
    /// </summary>
    public Vector2 Position { get; set; }
    
    /// <summary>
    /// Translates object position
    /// </summary>
    /// <param name="translation">Translation amount</param>
    public void Translate(Vector2 translation)
    {
        if (!float.IsNaN(translation.X) && !float.IsNaN(translation.Y))
        {
            Position += translation;
        }
    }
}