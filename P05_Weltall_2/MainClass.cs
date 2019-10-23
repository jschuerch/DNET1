using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P05_Weltall_2
{
    public partial class MainClass : Form
    {
        List<Orb> space = new List<Orb>();
        Timer timer1 = new Timer();
        List<Orb> delete = new List<Orb>();

        public MainClass()
        {
            InitializeComponent();

            this.timer1.Enabled = true;
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);

            /* 2-Körperproblem
            orbs.Add(new Planet("jupiter", 600, 400, -0.038, 0, 100));
            orbs.Add(new Planet("mars", 600, 600, 3.8, 0, 5));*/
            space.Add(new Spaceship(600, 230, 3, 0, 1));
            space.Add(new Planet("jupiter", 600, 400, -0.099, 0, 100));
            space.Add(new Planet("mars", 300, 400, 0, 1.5, 4));
            space.Add(new Planet("merkur", 200, 200, 0, -1.5, 4));

            space.ForEach(s => s.Deleter += new OrbDeleteHandler(destroy));
        }

        void destroy(Orb o1)
        {
            delete.Add(o1);
            //bitmap = new Bitmap("explosion.gif");
            //bitmap.MakeTransparent(bitmap.GetPixel(1, 1));

            //Console.WriteLine("boom");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            delete.ForEach(d => space.Remove(d));
            space.ForEach(f => f.CalcPosNew(space));
            space.ForEach(f => { f.Move(); f.Draw(e.Graphics); });
        }
    }
}
