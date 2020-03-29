using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameWindowsStarter
{
    public struct Particle
    {
        public Vector2 Velocity;        //current particle velocity
        public Vector2 Position;        //current paritcle position
        public Vector2 Acceleration;    //current particle acceleration
        public float Scale;             //current scale of particle
        public float Life;              //current particle life(time)
        public Color Color;             //current particle color
    }
}