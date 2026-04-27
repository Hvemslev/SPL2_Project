using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SPL2_Project;
using SPL2_Project.States;
using PatternLibrary;
using PatternLibrary.GameObject;

public class TitleState() : IState
{
    public GameObject UI;
    public void Enter()
    {
        UI = Locator.Objects.CreateGameObject("UI", new Vector2(0,0));
        UI.AddComponent(new titleUI());
    }
    public void Exit(){}
    public void Update(GameTime gameTime)
    {
        if (Keyboard.GetState().IsKeyDown(Keys.Enter))
        {
            Game1.GameState.ChangeState(Game1.GameState.PlayState);
        }
    }
    public void Draw(SpriteBatch spriteBatch)
    {

    }
}