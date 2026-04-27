using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PatternLibrary;
using PatternLibrary.GameObject;
using SPL2_Project;
using SPL2_Project.States;

public class PlayState(GraphicsDevice _graphic) : IState
{
    private List<Enemy> enemies = [];
    public static List<Bullet> bullets = [];
    private GraphicsDevice graphic = _graphic;
    
    
    
    public void Enter()
    {
        // TODO: Remove collider scale, when we have proper sprites with correct sizes

        GameObject playerObject = Locator.Objects.CreateGameObject("Player", new Vector2(100, 100));
        playerObject.AddComponent(new Player(graphic));
        SpriteRenderer sprite = new SpriteRenderer(Game1._texture);
        sprite.Scale = 20f;
        playerObject.AddComponent(sprite);
        playerObject.AddComponent(new Collider(true, graphic, sprite) { ColliderScale = new Vector2(20, 20) });

        GameObject enemyObject = Locator.Objects.CreateGameObject("Enemy", new Vector2(400, 400));
        enemyObject.AddComponent(new Enemy(playerObject, graphic));
        sprite = new SpriteRenderer(Game1._texture);
        sprite.Scale = 20f;
        enemyObject.AddComponent(sprite);
        enemyObject.AddComponent(new Collider(true, graphic, sprite) { ColliderScale = new Vector2(20, 20) });
    }
    public void Exit(){}
    public void Update(GameTime gameTime)
    {
        // TODO: Look into moving object updating to here
    }
    public void Draw(SpriteBatch spriteBatch)
    {
        // TODO: Look into moving object drawing to here
    }
}