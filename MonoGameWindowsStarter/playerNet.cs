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
    public class playerNet
    {
        Game1 game;
        Texture2D texture;
        SpriteBatch spriteBatch;
        Random random = new Random();
        BoundingRectangle boundary;
        int player;
        Vector2 netPosition;
        Vector2 netVelocity;

        public BoundingRectangle GetBoundary()
        {
            return boundary;
        }

        public playerNet(Game1 game, int x, int y, int player)
        {
            this.game = game;
            netPosition.X = x;
            netPosition.Y = y;

            boundary.X = x;
            boundary.Y = y;
            boundary.Width = 50;
            boundary.Height = 350;
            this.player = player;

            netVelocity = new Vector2(
                                        (float)random.NextDouble(),
                                        (float)random.NextDouble()
                                      );
            netVelocity.Normalize();
        }

        public void LoadContent (ContentManager content)
        {
            spriteBatch = new SpriteBatch(game.GraphicsDevice);

            if (player == 1)
            {
                texture = content.Load<Texture2D>("blueNet");
            }

            if (player == 2)
            {
                texture = content.Load<Texture2D>("redNet");
            }
        }

        public void Update(GameTime gameTime)
        {
            if (player == 1)
            {
                netPosition += (float)gameTime.ElapsedGameTime.TotalMilliseconds * netVelocity;

                boundary.Y = netPosition.Y;
            }

            if (player == 2)
            {
                netPosition -= (float)gameTime.ElapsedGameTime.TotalMilliseconds * netVelocity;

                boundary.Y = netPosition.Y;
            }

            if (netPosition.Y < 0)
            {
                netVelocity.Y *= -1;
                float delta = 0 - netPosition.Y;
                netPosition.Y += 2 * delta;
            }

            if (netPosition.Y > game.GraphicsDevice.Viewport.Height - 350)
            {
                netVelocity.Y *= -1;
                float delta = game.GraphicsDevice.Viewport.Height - 350 - netPosition.Y;
                netPosition.Y += 2 * delta;
            }
        }

        public void Draw()
        {
            spriteBatch.Begin();

            if (player == 1)
            {
                spriteBatch.Draw(texture, boundary, Color.AntiqueWhite);
            }

            if (player == 2)
            {
                spriteBatch.Draw(texture, boundary, Color.AntiqueWhite);
            }

            spriteBatch.End();
        }
    }
}
