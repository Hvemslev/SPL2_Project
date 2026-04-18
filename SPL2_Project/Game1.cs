using Microsoft.Xna.Framework;
using PatternLibrary;
using PatternLibrary.Audio;
using PatternLibrary.Collider;
using PatternLibrary.GameObject;
using PatternLibrary.Tweening;

namespace SPL2_Project;

public class Game1 : GameLogic
{
    public Game1() : base()
    {
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        Locator.Provide(new GameObjectManager());
        Locator.Provide(new SoundManager());
        Locator.Provide(new TweenManager());
        Locator.Provide(new CollisionManager());

        base.Initialize();

        GameObject thePlayer = Locator.Objects.CreateGameObject("Player", new Vector2(100, 100));
        thePlayer.AddComponent(new Player(graphics));
    }

    protected override void LoadContent()
    {
        base.LoadContent();

        // TODO: use this.Content to load your game content here
    }

    protected override void UpdateGame(GameTime gameTime)
    {
        // TODO: Add your update logic here

    }

    protected override void Draw(GameTime gameTime)
    {
        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}
