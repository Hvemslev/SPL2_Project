using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PatternLibrary.GameObject;

public class GameObjectManager : IGameObjectManager
{
    public List<GameObject> GameObjects { get; private set; } = new List<GameObject>();
    public List<GameObject> GameObjectsToBeAdded { get; private set; } = new List<GameObject>();
    public List<GameObject> GameObjectsToBeRemoved { get; private set; } = new List<GameObject>();


    /// <summary>
    /// Creates a gameobject and adds it to the main update list duing the next update cycle.
    /// </summary>
    /// <param name="_tag"></param> The object tag for the gameobject
    /// <param name="_position"></param> The world position to be placed
    /// <returns></returns>
    public GameObject CreateGameObject(string _tag, Vector2 _position, bool _isUI = false)
    {
        GameObject newGameObject = new GameObject(_tag, _isUI);
        newGameObject.Transform.Position = _position;

        newGameObject.Awake();

        GameObjectsToBeAdded.Add(newGameObject);

        return newGameObject;
    }

    /// <summary>
    /// Sets gameobjects to be removed duing the next update cycle
    /// </summary>
    /// <param name="_gameObjectToDestroy"></param>
    public void DestroyGameObject(GameObject _gameObjectToDestroy)
    {
        if(!GameObjects.Contains(_gameObjectToDestroy))
        {
            Debug.WriteLine("Object tagged " + _gameObjectToDestroy.Tag + "can not be found in update loop!");
            return;
        }
        
        GameObjectsToBeRemoved.Add(_gameObjectToDestroy);
    }

    public void UpdateGameObjects(GameTime gameTime)
    {
        // Update all GameObjects
        foreach (GameObject gameObject in GameObjects)
        {
            gameObject.Update(gameTime);
        }
    }

    public void DrawGameObjects(SpriteBatch spriteBatch)
    {
        // Draw all GameObjects
        foreach (GameObject gameObject in GameObjects)
        {
            if (!gameObject.IsUI)
            {
                gameObject.Draw(spriteBatch);
            }
        }
    }

    /// <summary>
    /// Checks the two temporary lists to add and remove gameobjects before updating
    /// </summary>
    public void CheckGameObjectList()
    {
        GameObjects.AddRange(GameObjectsToBeAdded);
        GameObjectsToBeAdded.Clear();

        foreach (GameObject goToRemove in GameObjectsToBeRemoved)
        {
            GameObjects.Remove(goToRemove);
        }

        GameObjectsToBeRemoved.Clear();
    }
}