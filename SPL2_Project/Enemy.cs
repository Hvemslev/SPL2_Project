using System;
using System.Numerics;
using Microsoft.Xna.Framework.Input;

namespace SPL2_Project;

public class Enemy
{
    public Vector2 position = new Vector2(100, 100);

    private float enemySpeed = 3f;

    public Enemy(int x, int y)
    {
        position.X = x;
        position.Y = y;
    }

    public void Chase(Player player)
    {
        Vector2 directionLong = player.position-position;
        
        Vector2 direction = Vector2.Normalize(directionLong);
        
        position += direction * enemySpeed;

        
        
    }
}