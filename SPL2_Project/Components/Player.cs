using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PatternLibrary;
using PatternLibrary.GameObject;

namespace SPL2_Project;

public class Player : IComponent
{
    private Vector2 currentLookDirection;
    private float lookAngleRadians = 0;

    private int playerSpeed = 4;

    private int playerBulletSpeed = 20;

    bool justFired = false;

    public int chamberMax = 6; 
    public int chamberCurrent;

    private bool reloading;
    private double reload;

    public bool IsEnabled { get; set; }
    public GameObject GameObject { get; set; }

    public Player()
    {
        chamberCurrent = chamberMax;
    }

    public void Awake()
    {
        
    }

    public void Start()
    {
        //chamberCurrent = chamberMax;
    }

    public void Update(GameTime gameTime)
    {
       currentLookDirection = GetAimDirection();
       lookAngleRadians = (float)Math.Atan2(currentLookDirection.Y, currentLookDirection.X);

       //Vector2 movementDirection = new Vector2(0,0);
        Vector2 movement = new Vector2(0,0);
        //movement = Vector2.Normalize(movementDirection);
        
        


        if(Keyboard.GetState().IsKeyDown(Keys.W))
        {
            movement.Y=(-1);
        } 
        else if(Keyboard.GetState().IsKeyDown(Keys.S))
        {
            movement.Y=1;
        } 
        else {movement.Y=0;}

        if(Keyboard.GetState().IsKeyDown(Keys.A))
        {
            movement.X=(-1);
        } 
        else if(Keyboard.GetState().IsKeyDown(Keys.D))
        {
            movement.X = 1;
        } else {movement.X = 0;}


        GameObject.Transform.Position += movement * playerSpeed;

        
        if (Mouse.GetState().LeftButton==ButtonState.Pressed)
        {
            if (justFired == false && chamberCurrent > 0 && reloading == false)
            {
                shoot();
                justFired = true;
                chamberCurrent--;
            }
        } else {justFired = false;}

        
        if(Keyboard.GetState().IsKeyDown(Keys.R) && reloading == false)
        {
            reloading=true;
            reload=0;
        }
        if (reloading)
        {
            reload+=gameTime.ElapsedGameTime.TotalMilliseconds;
            if(reload > 1000)
            {
                chamberCurrent = chamberMax;
                reloading=false;
            }
        }

        Console.WriteLine(reload);

    }

    public void Draw(SpriteBatch _spriteBatch)
    {
        _spriteBatch.Draw(Game1._texture, new Rectangle((int)GameObject.Transform.Position.X, (int)GameObject.Transform.Position.Y, 20, 20), Color.LimeGreen);

        //bulletCapacity
        for(int i = 0; i < chamberMax; i++)
        {
           _spriteBatch.Draw(Game1._texture, new Rectangle(10+(20*i), 10, 15, 15), Color.Black); 
        }
        //bulletCount
        for(int i = 0; i < chamberCurrent; i++)
        {
           _spriteBatch.Draw(Game1._texture, new Rectangle(10+(20*i), 10, 15, 15), Color.White); 
        }
    }

    public void shoot()
    {
        Vector2 mousePos;
        mousePos.X=Mouse.GetState().Position.X;
        mousePos.Y=Mouse.GetState().Position.Y;
        Vector2 directionLong = mousePos - GameObject.Transform.Position;
        Vector2 direction = Vector2.Normalize(directionLong);

        Locator.Objects.CreateGameObject("Bullet", GameObject.Transform.Position)
        .AddComponent(new Bullet(direction, playerBulletSpeed));
    }

    private Vector2 GetAimDirection()
    {
        MouseState mouse = Mouse.GetState();
        Vector2 mousePosition = new Vector2(mouse.X, mouse.Y);

        return Vector2.Normalize(mousePosition - GameObject.Transform.Position);
    }

    public void Destroy()
    {
        
    }

    /// <summary>
    /// Used for referencing component via name
    /// </summary>
    /// <returns>Class name</returns>
    public string ComponentName()
    {
        return this.GetType().Name;;
    }
}