using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameWindowsStarter;

namespace MonoGameWindowsStarter
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Collisions collisions = new Collisions();
        int score1 = 0;
        int score2 = 0;

        Texture2D net1, net2, net3, net4;
        Texture2D win1, win2;

        public Puck puck;

        public BluePaddle bluePaddle1;
        public BluePaddle bluePaddle2;
        public BluePaddle bluePaddle3;

        public RedPaddle redPaddle1;
        public RedPaddle redPaddle2;
        public RedPaddle redPaddle3;

        public BoundingRectangle blueNet1, blueNet2, redNet1, redNet2;  // scoring boxes 
        public BoundingRectangle p1win, p2win;

        Texture2D background;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            graphics.PreferredBackBufferWidth = 1600;
            graphics.PreferredBackBufferHeight = 900;
            graphics.ApplyChanges();

            bluePaddle1 = new BluePaddle(this, 250, 175);
            bluePaddle2 = new BluePaddle(this, 250, 525);
            bluePaddle3 = new BluePaddle(this, 550, 350);

            redPaddle1 = new RedPaddle(this, 1350, 175);
            redPaddle2 = new RedPaddle(this, 1350, 525);
            redPaddle3 = new RedPaddle(this, 1050, 350);

            blueNet1 = new BoundingRectangle(0, 290, 100, 100);
            blueNet2 = new BoundingRectangle(0, 590, 100, 100);

            redNet1 = new BoundingRectangle(1500, 290, 100, 100);
            redNet2 = new BoundingRectangle(1500, 590, 100, 100);

            puck = new Puck(this);

            p1win = new BoundingRectangle();    // create sizes here
            p2win = new BoundingRectangle();    // create sizes here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            background = Content.Load<Texture2D>("background");

            net1 = Content.Load<Texture2D>("pixel");
            net2 = Content.Load<Texture2D>("pixel");
            net3 = Content.Load<Texture2D>("pixel");
            net4 = Content.Load<Texture2D>("pixel");

            puck.LoadContent(Content);

            bluePaddle1.LoadContent(Content);
            bluePaddle2.LoadContent(Content);
            bluePaddle3.LoadContent(Content);

            redPaddle1.LoadContent(Content);
            redPaddle2.LoadContent(Content);
            redPaddle3.LoadContent(Content);

            win1 = Content.Load<Texture2D>("player1win");
            win2 = Content.Load<Texture2D>("player2win");

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            puck.Update(gameTime);

            bluePaddle1.Update(gameTime);
            bluePaddle2.Update(gameTime);
            bluePaddle3.Update(gameTime);

            redPaddle1.Update(gameTime);
            redPaddle2.Update(gameTime);
            redPaddle3.Update(gameTime);

            //collisions
            

            // Scoring with boundary rectangle??

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            spriteBatch.Draw(background, new Rectangle(0, 0, 1600, 900), Color.Transparent);

            spriteBatch.Draw(net1, blueNet1, Color.Black);
            spriteBatch.Draw(net2, blueNet2, Color.Black);
            spriteBatch.Draw(net3, redNet1, Color.Black);
            spriteBatch.Draw(net4, redNet2, Color.Black);

            puck.Draw();

            bluePaddle1.Draw();
            bluePaddle2.Draw();
            bluePaddle3.Draw();

            redPaddle1.Draw();
            redPaddle2.Draw();
            redPaddle3.Draw();

            spriteBatch.End();

            base.Draw(gameTime);
        }

        public void Score(GameTime gameTime)
        {
            if (collisions.Collides(puck.GetBounds(), blueNet1))
            {
                score2++;
            }

            if (collisions.Collides(puck.GetBounds(), blueNet2))
            {
                score2++;
            }

            if (collisions.Collides(puck.GetBounds(), redNet1))
            {
                score1++;
            }

            if (collisions.Collides(puck.GetBounds(), redNet2))
            {
                score1++;
            }

            if (score1 == 3)
            {
                GraphicsDevice.Clear(Color.Black);

                spriteBatch.Begin();
                spriteBatch.Draw(win1, p1win, Color.Transparent);
                spriteBatch.End();
            }

            if (score2 == 3)
            {
                GraphicsDevice.Clear(Color.Black);

                spriteBatch.Begin();
                spriteBatch.Draw(win2, p2win, Color.Transparent);
                spriteBatch.End();
            }

        }
    }
}
