using System;
using System.Collections.Generic;
using System.Drawing;

namespace P04_Weltall
{
    abstract class Orb
    {
        const double G = 30; //6.673e-11

        protected Bitmap bitmap;
        protected Vector posNew, pos;
        protected Vector v0;
        protected string name;
        protected double masse;

        public Vector Pos
        {
            get { return pos; }
        }

        public Vector Velocity
        {
            get { return v0; }
        }

        public double Mass
        {
            get { return masse; }
        }
        public abstract void Draw(Graphics g);

        public void Move()
        {
            pos = posNew;
        }

        public Orb(string name, double x, double y, double vx, double vy, double m)
        {
            bitmap = new Bitmap(name + ".gif");
            bitmap.MakeTransparent(bitmap.GetPixel(1, 1));
            pos = new Vector(x, y, 0);
            v0 = new Vector(vx, vy, 0);
            masse = m;
            this.name = name;
        }

        public virtual void CalcPosNew(IList<Orb> space)
        {
            var a = new Vector();

            foreach(var orb in space)
            {
                if (orb.Equals(this))
                    continue;
                var direction = orb.Pos - Pos;
                a += G * orb.Mass * direction / Math.Pow(direction.Norm(), 3);
            }

            //neue Position berechnen
            double t = 3;
            posNew = pos + v0*t + (t*t)*a;
            v0 = v0 + t*a;
        }

        public override string ToString()
        {
            return name;
        }



    }
}
