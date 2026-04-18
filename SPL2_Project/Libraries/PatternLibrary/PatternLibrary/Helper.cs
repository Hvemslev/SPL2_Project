


using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PatternLibrary;


public static class Helper
{
    /// <summary>
        /// Procedurally generating a texture2D sprite (helper method)
        /// Kilde: https://stackoverflow.com/questions/32429219/procedurally-generating-a-texture2d-in-xna-monogame
        /// </summary>
        /// <param name="device">GraphicsDevice reference</param>
        /// <param name="width">Texture width</param>
        /// <param name="height">Texture height</param>
        /// <param name="paint">Syntax: pixel => Color</param>
        /// <returns></returns>
        public static Texture2D CreateTexture(GraphicsDevice graphicsDevice,  int width, int height, Func<int, Color> paint)
        {
            // Initialize a texture
            Texture2D texture = new Texture2D(graphicsDevice, width, height);

            // The array holds the color for each pixel in the texture
            Color[] data = new Color[width * height];
            for (int pixel = 0; pixel < data.Count(); pixel++)
            {
                // The function applies the color according to the specified pixel
                data[pixel] = paint(pixel);
            }

            // Set the color
            texture.SetData(data);

            return texture;
        }
}