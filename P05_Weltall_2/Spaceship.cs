using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05_Weltall_2
{
    [Explodable]
    class Spaceship : Orb
    {
        public Spaceship(double x, double y, double vx, double vy, double m) : base("enterprise", x, y, vx, vy, m)
        {
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(bitmap, (float)pos.X, (float)pos.Y);
        }
    }
}
