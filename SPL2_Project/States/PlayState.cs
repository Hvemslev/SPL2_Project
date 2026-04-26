using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PatternLibrary;
using PatternLibrary.GameObject;
using SPL2_Project;
using SPL2_Project.States;

public class PlayState() : IState
{
    public GameObject playerObject;
    //private List<Enemy> enemies = [];
    public static List<Bullet> bullets = [];

    GameObject ui;
    public int killCount;

    private double enemySpawnCooldown;
    
    
    
    public void Enter()
    {
        playerObject = Locator.Objects.CreateGameObject("Player", new Vector2(100, 100));
        playerObject.AddComponent(new Player());
        Locator.Objects.CreateGameObject("Enemy", new Vector2(400, 400))
        .AddComponent(new Enemy(playerObject));
        Locator.Objects.CreateGameObject("UI", new Vector2(0,0)).AddComponent(new playUI());
        
        killCount=0;
        enemySpawnCooldown=0;
    }
    public void Exit(){}
    public void Update(GameTime gameTime)
    {
        // TODO: Look into moving object updating to here
        enemySpawnCooldown+=gameTime.ElapsedGameTime.TotalMilliseconds;
        if(enemySpawnCooldown >= 2000)
        {
            Locator.Objects.CreateGameObject("Enemy", RandomSpawnLocation.Generate())
            .AddComponent(new Enemy(playerObject)); 
            enemySpawnCooldown=0;   
        }
        

    }
    public void Draw(SpriteBatch spriteBatch)
    {
        // TODO: Look into moving object drawing to here
    }
}