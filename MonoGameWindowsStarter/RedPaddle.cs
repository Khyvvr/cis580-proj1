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
    public class RedPaddle
    {
        Game1 game;
        Texture2D texture;
        SpriteBatch spriteBatch;

        BoundingRectangle boundary;

        /// <summary>
        /// Creates a paddle
        /// </summary>
        /// <param name="game"></param>
        public RedPaddle(Game1 game, int X, int Y)
        {
            this.game = game;
            boundary.X = X;
            boundary.Y = Y;
            boundary.Width = 50;
            boundary.Height = 200;
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

            if (keyboardState.IsKeyDown(Keys.I))
            {
                boundary.Y -= (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            }

            if (keyboardState.IsKeyDown(Keys.K))
            {
                boundary.Y += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            }

            // stops pixel from moving out of game's window
            if (boundary.Y < 0) boundary.Y = 0;
            if (boundary.Y > game.GraphicsDevice.Viewport.Height - boundary.Height)
                boundary.Y = game.GraphicsDevice.Viewport.Height - boundary.Height;
        }

        public void Draw()
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture, boundary, Color.Red);
            spriteBatch.End();
        }
    }
}
