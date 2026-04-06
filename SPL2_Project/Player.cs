using System.Numerics;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework.Input;

namespace SPL2_Project;

public class Player
{
    public Vector2 position = new Vector2(100, 100);

    

    private int playerSpeed = 4;

    public void Update()
    {
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
            movement.X=1;
        } else {movement.X=0;}




        position+=movement*playerSpeed;
        

        
    }
}