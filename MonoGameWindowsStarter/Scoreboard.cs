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
    public enum State
    {
        toOne = 1,
        One = 2,

        toTwo = 3,
        Two = 4,

        toThree = 5,
        Three = 6,

        Idle = 7
    }
    public class Scoreboard
    {
        Game1 game;
        Texture2D texture;
        State state;
        TimeSpan timer;
        int frame;
        Vector2 position;
        Puck puck;
        int player;


        const int ANIMATION_FRAMERATE = 124;
        const int FRAME_WIDTH = 52;
        const int FRAME_HEIGHT = 52;

        public Scoreboard(int x, int y, Game1 game, Puck puck, int player)
        {
            this.game = game;
            this.puck = puck;
            timer = new TimeSpan(0);
            position = new Vector2(x, y);
            state = State.Idle;
            this.player = player;
        }

        public void LoadContent()
        {
            texture = game.Content.Load<Texture2D>("newScoreboard");
        }

        public void Update(GameTime gameTime)
        {
            if (player == 1)
            {
                if (puck.score2 == 0)
                {
                    state = State.Idle;
                }

                if (puck.score2 == 1)   
                {
                    state = State.toOne;
                }

                if (state == State.toOne)
                {
                    state = State.One;
                }

                if (state == State.One)
                {
                    if (puck.score2 == 2)
                    {
                        state = State.toTwo;
                    }
                }
                
                if (state == State.toTwo)
                {
                    state = State.Two;
                }

                if (state == State.Two)
                {
                    if (puck.score2 == 3)
                    {
                        state = State.toThree;
                    }
                }

                if (state == State.toThree)
                {
                    state = State.Three;
                }
            }

            if (player == 2)
            {
                if (puck.score1 == 0)
                {
                    state = State.Idle;
                }

                if (puck.score1 == 1)
                {
                    state = State.toOne;
                }

                if (state == State.toOne)
                {
                    state = State.One;
                }

                if (state == State.One)
                {
                    if (puck.score1 == 2)
                    {
                        state = State.toTwo;
                    }
                }

                if (state == State.toTwo)
                {
                    state = State.Two;
                }

                if (state == State.Two)
                {
                    if (puck.score1 == 3)
                    {
                        state = State.toThree;
                    }
                }

                if (state == State.toThree)
                {
                    state = State.Three;
                }
            }

            if (state != State.Idle) timer += gameTime.ElapsedGameTime;

            while (timer.TotalMilliseconds > ANIMATION_FRAMERATE)
            {
                // increase by one frame
                frame++;
                // reduce the timer by one frame duration
                timer -= new TimeSpan(0, 0, 0, 0, ANIMATION_FRAMERATE);
            }

            frame %= 4;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            var source = new Rectangle(
                                        frame * FRAME_WIDTH,
                                        (int)state % 7 * FRAME_HEIGHT,
                                        FRAME_WIDTH,
                                        FRAME_HEIGHT
                                        );

            spriteBatch.Draw(texture, position, source, Color.AntiqueWhite);
        }
    }
}
