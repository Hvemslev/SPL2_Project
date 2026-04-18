using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PatternLibrary.GameObject;

namespace PatternLibrary;

public class GameLogic : Game
{
    protected GraphicsDeviceManager graphics;
    protected SpriteBatch spriteBatch;


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

    // The engine owns the per-frame order: input first, then game logic.
    // Derived games override UpdateGame instead of Update so they always see
    // the newest input snapshot.
    protected sealed override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add input update here

        Locator.Objects.CheckGameObjectList();
        Locator.Objects.UpdateGameObjects(gameTime);

        Locator.Collisions.CheckColliderList();
        Locator.Collisions.UpdateColliders();

        UpdateGame(gameTime);

        base.Update(gameTime);
    }

    protected virtual void UpdateGame(GameTime gameTime) { }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here

        //spriteBatch.Begin(sortMode: SpriteSortMode.FrontToBack, null, SamplerState, null, null, null, Camera.Instance.Transform); // Start drawing
        spriteBatch.Begin();

        Locator.Objects.DrawGameObjects(spriteBatch);

        spriteBatch.End(); // Stop drawing

        base.Draw(gameTime);
    }
}
