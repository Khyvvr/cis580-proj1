﻿using System;
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
    public class Paddle
    {
        Game1 game;
        Texture2D texture;
        SpriteBatch spriteBatch;
        BoundingRectangle boundary;
        int p;

        public BoundingRectangle GetBoundary()
        {
            return boundary;
        }

        /// <summary>
        /// Creates a paddle
        /// </summary>
        /// <param name="game"></param>
        public Paddle(Game1 game, int X, int Y, int player)
        {
            this.game = game;
            boundary.X = X;
            boundary.Y = Y;
            boundary.Width = 30;
            boundary.Height = 150;
            p = player;
        }

        public void LoadContent(ContentManager content)
        {
            spriteBatch = new SpriteBatch(game.GraphicsDevice);

            //determine paddle color based on team
            if (p == 1)
            {
                texture = content.Load<Texture2D>("bluePaddle");
            }

            if (p == 2)
            {
                texture = content.Load<Texture2D>("redPaddle");
            }
        }

        public void Update(GameTime gameTime)
        {

            var keyboardState = Keyboard.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                game.Exit();

            if (keyboardState.IsKeyDown(Keys.Escape))
                game.Exit();

            if (p == 1)
            {
                if (keyboardState.IsKeyDown(Keys.W))
                {
                    boundary.Y -= (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                }

                if (keyboardState.IsKeyDown(Keys.S))
                {
                    boundary.Y += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                }
            }

            if (p == 2)
            {
                if (keyboardState.IsKeyDown(Keys.I))
                {
                    boundary.Y -= (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                }

                if (keyboardState.IsKeyDown(Keys.K))
                {
                    boundary.Y += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                }
            }
            

            // some collision handling
            if (game.bluePaddle1.boundary.Y < 0) 
            {
                game.bluePaddle1.boundary.Y = 0;
                game.bluePaddle2.boundary.Y = 350;
            }

            if (game.bluePaddle2.boundary.Y > game.GraphicsDevice.Viewport.Height - boundary.Height)
            { 
                game.bluePaddle1.boundary.Y = 425;
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

            // red paddles fix
            if (game.redPaddle1.boundary.Y < 0)
            {
                game.redPaddle1.boundary.Y = 0;
                game.redPaddle2.boundary.Y = 350;
            }

            if (game.redPaddle2.boundary.Y > game.GraphicsDevice.Viewport.Height - boundary.Height)
            {
                game.redPaddle1.boundary.Y = 425;
                game.redPaddle2.boundary.Y = game.GraphicsDevice.Viewport.Height - boundary.Height;
            }

            if (game.redPaddle3.boundary.Y < 175)
            {
                game.redPaddle3.boundary.Y = 175;
            }

            if (game.redPaddle3.boundary.Y > 625)
            {
                game.redPaddle3.boundary.Y = 625;
            }

        }

        public void Draw()
        {
            spriteBatch.Begin();

            if (p ==1)
                spriteBatch.Draw(texture, boundary, Color.AntiqueWhite);

            if (p == 2)
                spriteBatch.Draw(texture, boundary, Color.AntiqueWhite);

            spriteBatch.End();
        }
    }
}
