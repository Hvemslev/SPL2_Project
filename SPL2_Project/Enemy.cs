using System;
using System.Numerics;
using Microsoft.Xna.Framework.Input;
//using System.Windows;

namespace SPL2_Project;

public class Enemy
{
    public Vector2 position = new Vector2(100, 100);

    private float enemySpeed = 0.005f;

    public Enemy(int x, int y)
    {
        position.X=x;
        position.Y=y;
    }

    public void Chase(Player player)
    {
        Vector2 direction = player.position-position;
        //Vector2 startPos = position;
        
        Vector2.Normalize(direction);
        
        position+=direction*enemySpeed;

        
        
    }
}