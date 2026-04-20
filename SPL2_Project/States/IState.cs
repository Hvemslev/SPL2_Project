using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SPL2_Project.States;

public interface IState
{
    void Enter();
    void Exit();
    void Update(GameTime gameTime);
    void Draw(SpriteBatch spriteBatch);
}