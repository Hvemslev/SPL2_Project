
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SPL2_Project;

public interface Component
{
    /// <summary>
        /// Is component enabled
        /// </summary>
        public bool IsEnabled { get; set; }

        /// <summary>
        /// Main GameObject reference
        /// </summary>
        public GameObject GameObject { get; set; }

        /// <summary>
        /// Awake method
        /// </summary>
        public void Awake();

        /// <summary>
        /// Awake method
        /// </summary>
        public void Start();

        /// <summary>
        /// Runs code and methodes every cycle.
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime);

        /// <summary>
        /// Draws components to screen.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch);

        /// <summary>
        /// Removes a game object.
        /// </summary>
        public void Destroy();
}