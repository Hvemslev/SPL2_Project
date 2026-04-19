using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SPL2_Project;
using SPL2_Project.States;

public class PlayState() : IState
{
    private Player player;
    private List<Enemy> enemies = [];
    public static List<Bullet> bullets = [];
    
    
    
    public void Enter()
    {
        player = new Player();
        enemies.Add(new Enemy(400, 400));
    }
    public void Exit(){}
    public void Update(GameTime gameTime)
    {
        player.Update();
        foreach(Enemy e in enemies)
        {
            e.Chase(player, gameTime);
        }
        foreach(Bullet b in bullets)
        {
            b.Update();
        }
    }
    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(Game1._texture, new Rectangle((int)player.position.X, (int)player.position.Y, 20, 20), Color.White);
        foreach(Enemy e in enemies)
        {
            spriteBatch.Draw(Game1._texture, new Rectangle((int)e.position.X, (int)e.position.Y, 20, 20), Color.White);
        }
        foreach(Bullet b in bullets)
        {
            b.Draw(spriteBatch);
        }
        
    }
}