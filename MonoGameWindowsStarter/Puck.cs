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

        public int score1;
        public int score2;

        Texture2D win1, win2;
        public Rectangle p1win, p2win;

        BoundingRectangle boundary;

        public Puck (Game1 game)
        {
            this.game = game;

            puckPos.X = 800;
            puckPos.Y = 450;
            puckVel = new Vector2(
            (float)random.NextDouble(),
            (float)random.NextDouble()
            );

            puckVel.Normalize();

            boundary.X = 800;
            boundary.Y = 450;
            boundary.Width = 35;
            boundary.Height = 35;

            p1win = new Rectangle(0, 0, 1600, 900);
            p2win = new Rectangle(0, 0, 1600, 900);

            score1 = 0;
            score2 = 0;
        }

        public BoundingRectangle GetBounds()
        {
            return boundary;
        }

        public void LoadContent (ContentManager content)
        {
            spriteBatch = new SpriteBatch(game.GraphicsDevice);
            texture = content.Load<Texture2D>("puck");
            win1 = content.Load<Texture2D>("player1win");
            win2 = content.Load<Texture2D>("player2win");
        }

        public void Update (GameTime gameTime)
        {
            puckPos += (float)gameTime.ElapsedGameTime.TotalMilliseconds * puckVel;

            boundary.X = puckPos.X;
            boundary.Y = puckPos.Y;

            // handles collision for paddles
            if (puckPos.Collides(game.bluePaddle1.GetBoundary()))
            {
                puckVel = new Vector2((float)random.NextDouble(), (puckVel.Y * -1));
            }

            if (puckPos.Collides(game.bluePaddle2.GetBoundary()))
            {
                puckVel = new Vector2((float)random.NextDouble(), (puckVel.Y * -1));
            }

            if (puckPos.Collides(game.bluePaddle3.GetBoundary()))
            {
                puckVel = new Vector2((float)random.NextDouble(), (puckVel.Y * -1));
            }

            if (game.redPaddle1.GetBoundary().Collides(puckPos))
            {
                puckVel = new Vector2((float)random.NextDouble(), (puckVel.Y * -1));
            }

            if (game.redPaddle2.GetBoundary().Collides(puckPos))
            {
                puckVel = new Vector2((float)random.NextDouble(), (puckVel.Y * -1));
            }

            if (game.redPaddle3.GetBoundary().Collides(puckPos))
            {
                puckVel = new Vector2((float)random.NextDouble(), (puckVel.Y * -1));
            }


            // check for wall collisions
            if (puckPos.Y < 0)
            {
                puckVel.Y *= -1;
                float delta = 0 - puckPos.Y;
                puckPos.Y += 2 * delta;
            }

            if (puckPos.Y > game.GraphicsDevice.Viewport.Height - 35)
            {
                puckVel.Y *= -1;
                float delta = game.GraphicsDevice.Viewport.Height - 35 - puckPos.Y;
                puckPos.Y += 2 * delta;

            }

            if (puckPos.X < 0)
            {
                puckVel.X *= -1;
                float delta = 0 - puckPos.X;
                puckPos.X += 2 * delta;
            }

            if (puckPos.X > game.GraphicsDevice.Viewport.Width - 35)
            {
                puckVel.X *= -1;
                float delta = game.GraphicsDevice.Viewport.Width - 35 - puckPos.X;
                puckPos.X += 2 * delta;
            }

            
            // scoring
            if (puckPos.Collides(game.blueNet1))
            {
                puckPos.X = 800;
                puckPos.Y = 450;
                score2++;
            }

            if (puckPos.Collides(game.blueNet2))
            {
                puckPos.X = 800;
                puckPos.Y = 450;
                score2++;
            }

            if (puckPos.Collides(game.redNet1))
            {
                puckPos.X = 800;
                puckPos.Y = 450;
                score1++;
            }

            if (puckPos.Collides(game.redNet2))
            {
                puckPos.X = 800;
                puckPos.Y = 450;
                score1++;
            }
        }

        public void Draw ()
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture, boundary, Color.White);

            if (score1 == 3)
            {
                spriteBatch.GraphicsDevice.Clear(Color.Black);

                spriteBatch.Draw(win1, p1win, Color.AntiqueWhite);
            }

            if (score2 == 3)
            {
                spriteBatch.GraphicsDevice.Clear(Color.Black);

                spriteBatch.Draw(win2, p2win, Color.AntiqueWhite);
            }

            spriteBatch.End();
        }
    }
}
