using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;

namespace MonoGameWindowsStarter
{
    public class Puck
    {
        Game1 game;
        Texture2D texture;
        Vector2 puckPos;
        Vector2 puckVel;
        SpriteBatch spriteBatch;
        SpriteFont font;
        Random random = new Random();
        Collisions collisions = new Collisions();
        
        SoundEffect hitPaddle;
        SoundEffect hitWall; 
        SoundEffect goooal;
        SoundEffect victory;

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

            hitPaddle = content.Load<SoundEffect>("hitPaddle");
            hitWall = content.Load<SoundEffect>("hitWall");
            goooal = content.Load<SoundEffect>("score");
            victory = content.Load<SoundEffect>("victory");


            //font = content.Load<SpriteFont>("font");  //load font from content here
        }

        public void Update (GameTime gameTime)
        {
            puckPos += (float)gameTime.ElapsedGameTime.TotalMilliseconds * puckVel;

            boundary.X = puckPos.X;
            boundary.Y = puckPos.Y;

            // handles collision for paddles
            if (collisions.Collides(puckPos, game.bluePaddle1.GetBoundary()))
            {
                hitPaddle.Play();
                puckVel.Y = (float)random.NextDouble();
                puckVel.X *= -1;
            }

            if (collisions.Collides(puckPos, game.bluePaddle2.GetBoundary()))
            {
                hitPaddle.Play();
                puckVel.Y = (float)random.NextDouble();
                puckVel.X *= -1;
            }

            if (collisions.Collides(puckPos, game.bluePaddle3.GetBoundary()))
            {
                hitPaddle.Play();
                puckVel.Y = (float)random.NextDouble();
                puckVel.X *= -1;
            }

            if (collisions.Collides(puckPos, game.redPaddle1.GetBoundary()))
            {
                hitPaddle.Play();
                puckVel.Y = (float)random.NextDouble();
                puckVel.X *= -1;
            }

            if (collisions.Collides(puckPos, game.redPaddle2.GetBoundary()))
            {
                hitPaddle.Play();
                puckVel.Y = (float)random.NextDouble();
                puckVel.X *= -1;
            }

            if (collisions.Collides(puckPos, game.redPaddle3.GetBoundary()))
            {
                hitPaddle.Play();
                puckVel.Y = (float)random.NextDouble();
                puckVel.X *= -1;
            }


            // check for mainFrame collisions
            if (puckPos.Y < 0)
            {
                hitWall.Play();
                puckVel.Y *= -1;
                float delta = 0 - puckPos.Y;
                puckPos.Y += 2 * delta;
            }

            if (puckPos.Y > game.GraphicsDevice.Viewport.Height - 35)
            {
                hitWall.Play();
                puckVel.Y *= -1;
                float delta = game.GraphicsDevice.Viewport.Height - 35 - puckPos.Y;
                puckPos.Y += 2 * delta;

            }

            if (puckPos.X < 0)
            {
                hitWall.Play();
                puckVel.X *= -1;
                float delta = 0 - puckPos.X;
                puckPos.X += 2 * delta;
            }

            if (puckPos.X > game.GraphicsDevice.Viewport.Width - 35)
            {
                hitWall.Play();
                puckVel.X *= -1;
                float delta = game.GraphicsDevice.Viewport.Width - 35 - puckPos.X;
                puckPos.X += 2 * delta;
            }

            
            // scoring
            if (collisions.Collides(puckPos, game.blueNet1))
            {
                goooal.Play();
                puckPos.X = 800;
                puckPos.Y = 450;
                score2++;
            }

            if (collisions.Collides(puckPos, game.blueNet2))
            {
                goooal.Play();
                puckPos.X = 800;
                puckPos.Y = 450;
                score2++;
            }

            if (collisions.Collides(puckPos, game.redNet1))
            {
                goooal.Play();
                puckPos.X = 800;
                puckPos.Y = 450;
                score1++;
            }

            if (collisions.Collides(puckPos, game.redNet2))
            {
                goooal.Play();
                puckPos.X = 800;
                puckPos.Y = 450;
                score1++;
            }
        }

        public void Draw ()
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture, boundary, Color.AntiqueWhite);
            spriteBatch.End();

            if (score1 == 3)
            {
                // -- commented out for font testing and learning
                spriteBatch.Begin();
                spriteBatch.GraphicsDevice.Clear(Color.Black);

                spriteBatch.Draw(win1, p1win, Color.AntiqueWhite);
                victory.Play();
                spriteBatch.End();
                

                /*
                //change win screen to use fonts here
                spriteBatch.Begin();
                spriteBatch.GraphicsDevice.Clear(Color.Black);
                spriteBatch.DrawString(font, "Blue Player Wins!", new Vector2(200, 200), Color.Blue);
                spriteBatch.End();
                */
            }

            if (score2 == 3)
            {
                // -- commented out for font testing and learning --
                spriteBatch.Begin();
                spriteBatch.GraphicsDevice.Clear(Color.Black);

                spriteBatch.Draw(win2, p2win, Color.AntiqueWhite);
                victory.Play();
                spriteBatch.End();
                

                /*
                //change win screen to use fonts here
                spriteBatch.Begin();
                spriteBatch.GraphicsDevice.Clear(Color.Black);
                spriteBatch.DrawString(font, "Red Player Wins!", new Vector2(200, 100), Color.Red);
                spriteBatch.End();
                */
            }
        }
    }
}
