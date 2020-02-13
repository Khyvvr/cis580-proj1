using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace MonoGameWindowsStarter
{
    public class Collisions
    {
        public bool Collides(BoundingRectangle a, BoundingRectangle b)
        {
            return !(a.X + a.Width <= b.X                     // a is to the left of b
                || a.X + a.Width >= b.X + b.Width            // a is to the right of b
                || a.Y + a.Height <= b.Y                    // a is above b
                || a.Y + a.Height >= b.X + b.Height);      // a is below b
        }

        public bool Collides(Vector2 v, BoundingRectangle r)
        {
            return (r.X <= v.X && v.X <= r.X + r.Width)
                && (r.Y <= v.Y && v.Y <= r.Y + r.Height);
        }

        public bool Collides(BoundingRectangle r, Vector2 v)
        {
            return Collides(v, r);
        }
    }
}
