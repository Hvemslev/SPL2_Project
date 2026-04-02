using System;
using System.Collections;
using System.Numerics;
using Microsoft.Xna.Framework.Input;

namespace SPL2_Project;

public class Enemy
{
    public Vector2 position = new Vector2(100, 100);

    Vector2 direction;

    private float enemySpeed = 3f;

    float maxRange = 300;

    float rateOfFire = 5f;
    

    public Enemy(int x, int y)
    {
        position.X = x;
        position.Y = y;
    }

    public void Chase(Player player)
    {
        
        Vector2 directionLong = player.position-position;
        
        direction = Vector2.Normalize(directionLong);

        float distance = directionLong.Length();
        
        if(distance > maxRange)
        {
            position += direction * enemySpeed;
        } 
        
        
        if(distance < maxRange)
        {
            shoot();
        } 
    }

    public void shoot()
    {
        Game1.bullets.Add(new Bullet(position, direction, 4));
    }
}