using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PatternLibrary;
using PatternLibrary.GameObject;
using SPL2_Project;
using SPL2_Project.States;

public class PlayState() : IState
{
    private List<Enemy> enemies = [];
    public static List<Bullet> bullets = [];
    
    
    
    public void Enter()
    {
        GameObject playerObject = Locator.Objects.CreateGameObject("Player", new Vector2(100, 100));
        playerObject.AddComponent(new Player());
        Locator.Objects.CreateGameObject("Enemy", new Vector2(400, 400))
        .AddComponent(new Enemy(playerObject));
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