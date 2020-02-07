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

        Texture2D net1, net2, net3, net4;

        public Puck puck;

        public Paddle bluePaddle1;
        public Paddle bluePaddle2;
        public Paddle bluePaddle3;

        public Paddle redPaddle1;
        public Paddle redPaddle2;
        public Paddle redPaddle3;

        public BoundingRectangle blueNet1, blueNet2, redNet1, redNet2;  // scoring boxes

        Texture2D background;
        Rectangle mainFrame = new Rectangle(0, 0, 1600, 900);

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

            bluePaddle1 = new Paddle(this, 250, 175, 1);
            bluePaddle2 = new Paddle(this, 250, 525, 1);
            bluePaddle3 = new Paddle(this, 550, 350, 1);

            redPaddle1 = new Paddle(this, 1350, 175, 2);
            redPaddle2 = new Paddle(this, 1350, 525, 2);
            redPaddle3 = new Paddle(this, 1050, 350, 2);

            blueNet1 = new BoundingRectangle(0, 290, 100, 100);
            blueNet2 = new BoundingRectangle(0, 590, 100, 100);

            redNet1 = new BoundingRectangle(1500, 290, 100, 100);
            redNet2 = new BoundingRectangle(1500, 590, 100, 100);

            puck = new Puck(this);

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
            spriteBatch.Draw(background, mainFrame, Color.AntiqueWhite);
            spriteBatch.End();

            spriteBatch.Begin();
            spriteBatch.Draw(net1, blueNet1, Color.Black);
            spriteBatch.Draw(net2, blueNet2, Color.Black);
            spriteBatch.Draw(net3, redNet1, Color.Black);
            spriteBatch.Draw(net4, redNet2, Color.Black);

            bluePaddle1.Draw();
            bluePaddle2.Draw();
            bluePaddle3.Draw();

            redPaddle1.Draw();
            redPaddle2.Draw();
            redPaddle3.Draw();

            puck.Draw();

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
