using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PatternLibrary;

namespace SPL2_Project;

public class Game1 : GameLogic
{
    private GameObject thePlayer;

    public Game1() : base()
    {
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();


        thePlayer = new GameObject();
        thePlayer.Transform.Position = new Vector2(100, 100);
        thePlayer.AddComponent(new Player(graphics));
    }

    protected override void LoadContent()
    {
        base.LoadContent();

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        // TODO: Add your update logic here

        base.Update(gameTime);

        thePlayer.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        // TODO: Add your drawing code here

        base.Draw(gameTime);

        thePlayer.Draw(spriteBatch);
    }
}
