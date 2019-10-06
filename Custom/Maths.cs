using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

namespace Pirates.Custom
{
    public static class Maths
    {
        public static Vector2 RotateVector(Vector2 vector, float angle)
        {
            float x = (float)(Math.Cos(angle) * vector.X - Math.Sin(angle) * vector.Y);
            float y = (float)(Math.Sin(angle) * vector.X + Math.Cos(angle) * vector.Y);
            return new Vector2(x, y);
        }

    }
}
