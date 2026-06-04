using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using PatternLibrary;
using PatternLibrary.CommandPattern;
using PatternLibrary.GameObject;
using PatternLibrary.Graphics;
using PatternLibrary.Input;
using SPL2_Project.CommandPattern;


namespace SPL2_Project.States;


public class PlayState(GraphicsDevice _graphic, ContentManager _content) : IState
{
    public GameObject playerObject;
    //private List<Enemy> enemies = [];
    public static List<Bullet> bullets = [];
<<<<<<< HEAD

    public int killCount;

    private double enemySpawnCooldown;
    
=======
    private GraphicsDevice graphic = _graphic;
    private InputManager inputManager = new InputManager();
    private InputHandler inputHandler;
>>>>>>> origin/Martin
    
    
    public void Enter()
    {
<<<<<<< HEAD
        playerObject = Locator.Objects.CreateGameObject("Player", new Vector2(100, 100));
        playerObject.AddComponent(new Player());
        Locator.Objects.CreateGameObject("Enemy", new Vector2(400, 400))
        .AddComponent(new Enemy(playerObject));
        Locator.Objects.CreateGameObject("UI", new Vector2(0,0)).AddComponent(new playUI());
        
        killCount=0;
        enemySpawnCooldown=0;
=======
        // TODO: Remove collider scale, when we have proper sprites with correct sizes

        GameObject playerObject = Locator.Objects.CreateGameObject("Player", new Vector2(100, 100));
        Player player = new Player(graphic);

        // Create commands for player actions and pass the player reference to them
        MoveCommand moveUpCommand = new MoveCommand(new Vector2(0, -1), player);
        MoveCommand moveDownCommand = new MoveCommand(new Vector2(0, 1), player);
        MoveCommand moveLeftCommand = new MoveCommand(new Vector2(-1, 0), player);
        MoveCommand moveRightCommand = new MoveCommand(new Vector2(1, 0), player);
        ShootCommand shootCommand = new ShootCommand(player);
        inputHandler = new InputHandler(moveUpCommand, moveLeftCommand, moveDownCommand, moveRightCommand, shootCommand);

        playerObject.AddComponent(player);
        SpriteRenderer sprite = new SpriteRenderer(Game1._texture);
        sprite.Scale = 20f;
        playerObject.AddComponent(sprite);
        playerObject.AddComponent(new Collider(true, graphic, sprite) { ColliderScale = new Vector2(20, 20) });

        //TextureAtlas atlas = TextureAtlas.FromFile(_content, "atlas-definition.xml");
        //AnimatedSprite enemySprite = atlas.CreateAnimatedSprite("bat-animation");

        GameObject enemyObject = Locator.Objects.CreateGameObject("Enemy", new Vector2(400, 400));
        enemyObject.AddComponent(new Enemy(playerObject, graphic));
        sprite = new SpriteRenderer(Game1._texture);
        sprite.Scale = 20f;
        enemyObject.AddComponent(sprite);
        //enemyObject.AddComponent(new Collider(true, graphic, enemySprite.Origin, new Vector2(enemySprite.Width, enemySprite.Height)) { ColliderScale = new Vector2(20, 20) });
        enemyObject.AddComponent(new Collider(true, graphic, sprite) { ColliderScale = new Vector2(20, 20) });
>>>>>>> origin/Martin
    }

    public void Exit()
    {
        inputHandler = null; // Clear input handler to prevent drawing issues with commands that hold references to game objects
    }

    // The engine owns the per-frame order: input first, then game logic.
    public void Update(GameTime gameTime)
    {
<<<<<<< HEAD
        // TODO: Look into moving object updating to here
        enemySpawnCooldown+=gameTime.ElapsedGameTime.TotalMilliseconds;
        if(enemySpawnCooldown >= 2000)
        {
            Locator.Objects.CreateGameObject("Enemy", RandomSpawnLocation.Generate())
            .AddComponent(new Enemy(playerObject)); 
            enemySpawnCooldown=0;   
        }
        

=======
        inputManager.Update(); // Update input manager to refresh key states
        inputHandler.HandleInput(inputManager.Keyboard); // Pass keyboard info to input handler

        Locator.Objects.CheckGameObjectList();
        Locator.Objects.UpdateGameObjects(gameTime);

        Locator.Collisions.CheckColliderList();
        Locator.Collisions.UpdateColliders();
>>>>>>> origin/Martin
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        Locator.Objects.DrawGameObjects(spriteBatch);
    }
}