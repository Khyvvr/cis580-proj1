using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MonoGameWindowsStarter
{
    public class Puck
    {
        Game1 game;
        Texture2D texture;
        Vector2 puckVel;
        SpriteBatch spriteBatch;
        Random random = new Random();

        BoundingRectangle boundary;

        public Puck (Game1 game)
        {
            puckVel = new Vector2(
            (float)random.NextDouble(),
            (float)random.NextDouble()
            );

            puckVel.Normalize();

            this.game = game;
            boundary.X = 800;
            boundary.Y = 450;
            boundary.Width = 50;
            boundary.Height = 50;
        }

        public void LoadContent (ContentManager content)
        {
            spriteBatch = new SpriteBatch(game.GraphicsDevice);
            texture = content.Load<Texture2D>("puck");
        }

        public void Update (GameTime gameTime)
        {
            // if statements to determine collision - now figure out scoring(maybe in main)
            if (boundary.Y < 0)
            {
                puckVel.Y *= -1;
                float delta = 0 - boundary.Y;
                boundary.Y += 2 * delta;
            }

            if (boundary.Y > game.GraphicsDevice.Viewport.Height - 40)
            {
                puckVel.Y *= -1;
                float delta = game.GraphicsDevice.Viewport.Height - 40 - boundary.Y;
                boundary.Y += 2 * delta;

            }

            if (boundary.X < 0)
            {
                puckVel.X *= -1;
                float delta = 0 - boundary.X;
                boundary.X += 2 * delta;
            }

            if (boundary.X > game.GraphicsDevice.Viewport.Width - 50)
            {
                puckVel.X *= -1;
                float delta = game.GraphicsDevice.Viewport.Width - 50 - boundary.X;
                boundary.X += 2 * delta;
            }
        }

        public void Draw ()
        {
            spriteBatch.Draw(texture, boundary, Color.White);
        }
    }
}
