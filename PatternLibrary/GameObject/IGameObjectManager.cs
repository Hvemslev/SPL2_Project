using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PatternLibrary.GameObject;

public interface IGameObjectManager
{
    public List<GameObject> GameObjects { get; }
    public List<GameObject> GameObjectsToBeAdded { get; }
    public List<GameObject> GameObjectsToBeRemoved { get; }

    /// <summary>
    /// Creates a gameobject and adds it to the main update list duing the next update cycle.
    /// </summary>
    /// <param name="_tag"></param> The object tag for the gameobject
    /// <param name="_position"></param> The world position to be placed
    /// <returns></returns>
    public GameObject CreateGameObject(string _tag, Vector2 _position, bool _isUI = false);

    /// <summary>
    /// Sets gameobjects to be removed duing the next update cycle
    /// </summary>
    /// <param name="_gameObjectToDestroy"></param>
    public void DestroyGameObject(GameObject _gameObjectToDestroy);
    public void UpdateGameObjects(GameTime gameTime);

    public void DrawGameObjects(SpriteBatch spriteBatch);

    /// <summary>
    /// Checks the two temporary lists to add and remove gameobjects before updating
    /// </summary>
    public void CheckGameObjectList();
}