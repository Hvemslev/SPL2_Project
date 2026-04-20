using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using SPL2_Project.States;
using PatternLibrary;
using PatternLibrary.Audio;
using PatternLibrary.Collider;
using PatternLibrary.GameObject;
using PatternLibrary.Tweening;

namespace SPL2_Project;

public class Game1 : GameLogic
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    public static Texture2D _texture;

    public static List<Bullet> bullets = new List<Bullet>();

    public static GameTime gameTime;

    
    public StateMachine GameState { get; set; }

    public Game1() : base()
    {
    }

    protected override void Initialize()
    {
        Locator.Provide(new GameObjectManager());
        Locator.Provide(new SoundManager());
        Locator.Provide(new TweenManager());
        Locator.Provide(new CollisionManager());
        
        base.Initialize();
        _texture = new(GraphicsDevice, 1, 1);
        _texture.SetData([Color.White]);
        gameTime = new GameTime();



        GameState = new StateMachine();
        GameState.ChangeState(GameState.PlayState);
    }

    protected override void LoadContent()
    {
        base.LoadContent();

        // TODO: use this.Content to load your game content here
    }

    protected override void UpdateGame(GameTime gameTime)
    {
        // TODO: Add your update logic here
        GameState.Update(gameTime);

    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();

        GameState.Draw(_spriteBatch);
        
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
