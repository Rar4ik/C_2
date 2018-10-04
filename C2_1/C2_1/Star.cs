using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace C2_1
{
    class Star: BaseObj
    {
        public Star(Point pos, Point dir, Size size): base(pos,dir,size)
        {
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawLine(Pens.DarkRed, Pos.X, Pos.Y, Pos.X + Size.Width, Pos.Y + Size.Height);
            Game.Buffer.Graphics.DrawLine(Pens.DarkRed, Pos.X + Size.Width, Pos.Y, Pos.X, Pos.Y + Size.Height);
        }
        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            //Pos.Y = Pos.Y - Dir.Y;
            if (Pos.X < 0) Pos.X = Game.Widht + Size.Width;
            //if (Pos.Y < 0) Pos.Y = Game.Hight + Size.Height;
        }
    }
}
