using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PatternLibrary;

public class GameLogic : Game
{
    protected GraphicsDeviceManager graphics;
    protected SpriteBatch spriteBatch;
    
    private List<Collider> colliders = new List<Collider>();
    public static GameObjectManager ObjectManager = new GameObjectManager();


    public GameLogic()
    {
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        ObjectManager.CheckGameObjectList();

        ObjectManager.UpdateGameObjects(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here

        //spriteBatch.Begin(sortMode: SpriteSortMode.FrontToBack, null, SamplerState, null, null, null, Camera.Instance.Transform); // Start drawing
        spriteBatch.Begin();

        ObjectManager.DrawGameObjects(spriteBatch);

        spriteBatch.End(); // Stop drawing

        base.Draw(gameTime);
    }
}
