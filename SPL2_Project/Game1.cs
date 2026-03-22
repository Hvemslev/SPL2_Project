using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SPL2_Project;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D _texture;

    private Player player;
    private Enemy enemy;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        base.Initialize();
        _texture = new(GraphicsDevice, 1, 1);
        _texture.SetData([Color.White]);
        player = new Player();
        enemy = new Enemy(500, 500);
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        player.Update();
        enemy.Chase(player);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();
        _spriteBatch.Draw(_texture, new Rectangle((int)player.position.X, (int)player.position.Y, 20, 20), Color.White);
        _spriteBatch.Draw(_texture, new Rectangle((int)enemy.position.X, (int)enemy.position.Y, 20, 20), Color.White);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
