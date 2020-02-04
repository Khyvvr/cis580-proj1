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

        public Puck puck;

        public BluePaddle bluePaddle1;
        public BluePaddle bluePaddle2;
        public BluePaddle bluePaddle3;

        public RedPaddle redPaddle1;
        public RedPaddle redPaddle2;
        public RedPaddle redPaddle3;

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

            bluePaddle1 = new BluePaddle(this, 175, 75);
            bluePaddle2 = new BluePaddle(this, 175, 725);
            bluePaddle3 = new BluePaddle(this, 600, 350);

            redPaddle1 = new RedPaddle(this, 1425, 75);
            redPaddle2 = new RedPaddle(this, 1425, 725);
            redPaddle3 = new RedPaddle(this, 950, 350);

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
    }
}
