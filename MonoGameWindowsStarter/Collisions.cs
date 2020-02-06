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
    public static class Collisions
    {
        public static bool Collides(this BoundingRectangle a, BoundingRectangle b)
        {
            return !(a.X > a.X + b.Width        // a is to the left of b
                  || a.X + a.Width < b.X        // a is to the right of b
                  || a.Y > b.Y + b.Height       // a is above b
                  || a.Y + a.Height < b.Y);     // a is below b
        }

        public static bool Collides(this Vector2 v, Vector2 other)
        {
            return v == other;
        }

        public static bool Collides(this Vector2 v, BoundingRectangle r)
        {
            return (r.X <= v.X && v.X <= r.X + r.Width)
                && (r.Y <= v.Y && v.Y <= r.Y + r.Height);
        }

        public static bool Collides(this BoundingRectangle r, Vector2 v)
        {
            return v.Collides(r);
        }
    }
}
