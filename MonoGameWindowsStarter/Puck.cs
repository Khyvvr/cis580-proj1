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
        Vector2 puckPos;
        Vector2 puckVel;
        SpriteBatch spriteBatch;
        Random random = new Random();
        Collisions collisions = new Collisions();

        BoundingRectangle boundary;

        public Puck (Game1 game)
        {
            this.game = game;

            //puckPos.X = 800;
            //puckPos.Y = 450;
            puckVel = new Vector2(
            (float)random.NextDouble(),
            (float)random.NextDouble()
            );

            puckVel.Normalize();

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
            puckPos += (float) gameTime.ElapsedGameTime.TotalMilliseconds * 2 * puckVel;

            boundary.X = puckPos.X;
            boundary.Y = puckPos.Y;

            // handles collision for paddles
            if (collisions.Collides(boundary, game.bluePaddle1.GetBoundary()))
                puckVel *= -1;

            if (collisions.Collides(boundary, game.bluePaddle2.GetBoundary()))
                puckVel *= -1;

            if (collisions.Collides(boundary, game.bluePaddle3.GetBoundary()))
                puckVel *= -1;

            if (collisions.Collides(boundary, game.redPaddle1.GetBoundary()))
                puckVel *= -1;

            if (collisions.Collides(boundary, game.redPaddle2.GetBoundary()))
                puckVel *= -1;

            if (collisions.Collides(boundary, game.redPaddle3.GetBoundary()))
                puckVel *= -1;


            // check for wall collisions
            if (puckPos.Y < 0)
            {
                puckVel.Y *= -1;
                float delta = 0 - puckPos.Y;
                puckPos.Y += 2 * delta;
            }

            if (puckPos.Y > game.GraphicsDevice.Viewport.Height - 100)
            {
                puckVel.Y *= -1;
                float delta = game.GraphicsDevice.Viewport.Height - 100 - puckPos.Y;
                puckPos.Y += 2 * delta;

            }

            if (puckPos.X < 0)
            {
                puckVel.X *= -1;
                float delta = 0 - puckPos.X;
                puckPos.X += 2 * delta;
            }

            if (puckPos.X > game.GraphicsDevice.Viewport.Width - 100)
            {
                puckVel.X *= -1;
                float delta = game.GraphicsDevice.Viewport.Width - 100 - puckPos.X;
                puckPos.X += 2 * delta;
            }

        }

        public void Draw ()
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture, puckPos, Color.White);
            spriteBatch.Draw(texture, boundary, Color.Red);
            spriteBatch.End();
        }
    }
}
