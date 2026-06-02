using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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
    
    protected sealed override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add input update here

        UpdateGame(gameTime);

        base.Update(gameTime);
    }

    protected virtual void UpdateGame(GameTime gameTime) { }

    protected override void Draw(GameTime gameTime)
    {
        // TODO: Add your drawing code here

        //spriteBatch.Begin(sortMode: SpriteSortMode.FrontToBack, null, SamplerState, null, null, null, Camera.Instance.Transform); // Start drawing

        base.Draw(gameTime);
    }
}
