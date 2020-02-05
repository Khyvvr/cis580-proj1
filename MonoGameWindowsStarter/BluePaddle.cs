using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MonoGameWindowsStarter
{
    public class BluePaddle
    {
        Game1 game;
        Texture2D texture;
        SpriteBatch spriteBatch;
        BoundingRectangle boundary;

        public BoundingRectangle GetBoundary()
        {
            return boundary;
        }

        /// <summary>
        /// Creates a paddle
        /// </summary>
        /// <param name="game"></param>
        public BluePaddle(Game1 game, int X, int Y)
        {
            this.game = game;
            boundary.X = X;
            boundary.Y = Y;
            boundary.Width = 20;
            boundary.Height = 100;
        }

        public void LoadContent(ContentManager content)
        {
            spriteBatch = new SpriteBatch(game.GraphicsDevice);
            texture = content.Load<Texture2D>("pixel");
        }

        public void Update(GameTime gameTime)
        {

            var keyboardState = Keyboard.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                game.Exit();

            if (keyboardState.IsKeyDown(Keys.Escape))
                game.Exit();

            if (keyboardState.IsKeyDown(Keys.W))
            {
                boundary.Y -= (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            }

            if (keyboardState.IsKeyDown(Keys.S))
            {
                boundary.Y += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            }

            // some collision handling
            if (game.bluePaddle1.boundary.Y < 0) 
            {
                game.bluePaddle1.boundary.Y = 0;
                game.bluePaddle2.boundary.Y = 350;
            }

            if (game.bluePaddle2.boundary.Y > game.GraphicsDevice.Viewport.Height - boundary.Height)
            { 
                game.bluePaddle1.boundary.Y = 450;
                game.bluePaddle2.boundary.Y = game.GraphicsDevice.Viewport.Height - boundary.Height;
            }

            if (game.bluePaddle3.boundary.Y < 175)
            {
                game.bluePaddle3.boundary.Y = 175;
            }

            if (game.bluePaddle3.boundary.Y > 625)
            {
                game.bluePaddle3.boundary.Y = 625;
            }
                
        }

        public void Draw()
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture, boundary, Color.Blue);
            spriteBatch.End();
        }
    }
}
