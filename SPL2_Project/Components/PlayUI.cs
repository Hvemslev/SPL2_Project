using System;
using System.Net.Mime;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PatternLibrary;
using PatternLibrary.GameObject;

namespace SPL2_Project;

public class playUI : IComponent
{
    public bool IsEnabled { get; set; }

    public GameObject GameObject { get; set; }

    //public Player player;

    //SpriteFont font;

    int kills = Game1.GameState.PlayState.killCount;

    public void Awake(){}

    public void Start(){}

    public void Update(GameTime gameTime){}

    public void Draw(SpriteBatch spriteBatch)
    {
        //bullet count
        //for(int i = 0; i < player.chamberMax; i++)
        /*for(int i = 0; i < 6; i++)
        {
           spriteBatch.Draw(Game1._texture, new Rectangle(10+(20*i), 10, 15, 15), Color.Black); 
        }
        spriteBatch.DrawString(font, $"{kills}", new Vector2(100,100), Color.White);*/
        
    }

    public void Destroy(){}

    public string ComponentName()
    {
        return this.GetType().Name;;
    }
}