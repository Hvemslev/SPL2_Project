
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PatternLibrary.GameObject;

public class NullGameObjectManager : IGameObjectManager
{
    public List<GameObject> GameObjects { get; }
    public List<GameObject> GameObjectsToBeAdded { get; }
    public List<GameObject> GameObjectsToBeRemoved { get; }

    public void CheckGameObjectList()
    {
    }

    public GameObject CreateGameObject(string _tag, Vector2 _position, bool _isUI = false)
    {
        return null;
    }

    public void DestroyGameObject(GameObject _gameObjectToDestroy)
    {
    }

    public void DrawGameObjects(SpriteBatch spriteBatch)
    {
    }

    public void UpdateGameObjects(GameTime gameTime)
    {
    }
}