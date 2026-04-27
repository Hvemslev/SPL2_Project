using System;
using System.Numerics;

public static class RandomSpawnLocation
{
    public static Vector2 Generate()
    {
        Random rnd = new Random();
        return new Vector2(rnd.Next(-10,800),rnd.Next(-10,800));
    }


}