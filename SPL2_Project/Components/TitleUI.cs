using System;
using System.Net.Mime;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PatternLibrary;
using PatternLibrary.GameObject;

namespace SPL2_Project;

public class titleUI : IComponent
{
    public bool IsEnabled { get; set; } = true;

    public GameObject GameObject { get; set; }

    SpriteFont font = Game1.font;
    SpriteFont fontBig = Game1.fontBig;

    int kills = Game1.GameState.PlayState.killCount;

    public void Awake(){}

    public void Start(){}

    public void Update(GameTime gameTime)
    {
        if (Keyboard.GetState().IsKeyDown(Keys.Enter))
        {
            this.IsEnabled=false;
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.DrawString(fontBig, $"SHOOTY MCSHOOTFACE", new Vector2(100,200), Color.White);
        spriteBatch.DrawString(font, $"Press enter", new Vector2(300,300), Color.White);
    }

    public void Destroy(){}

    public string ComponentName()
    {
        return this.GetType().Name;;
    }
}