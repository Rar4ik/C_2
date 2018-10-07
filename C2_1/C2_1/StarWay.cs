using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace C2_1
{
    class StarWay: BaseObj
    {
        public StarWay(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        public override void Draw()//создание стрелочек
        {
            Game.Buffer.Graphics.DrawLine(Pens.Purple, Pos.X, Pos.Y, Pos.X + Size.Width,  Pos.Y + Size.Height);
            Game.Buffer.Graphics.DrawLine(Pens.Purple, Pos.X , Pos.Y, Pos.X,  Pos.Y + Size.Height);
        }
        public override void Update()// направление - вверх
        {
            //Pos.X = Pos.X - Dir.X;
            Pos.Y = Pos.Y - Dir.Y;
            //if (Pos.X < 0) Pos.X = Game.Widht + Size.Width;
            if (Pos.Y < 0) Pos.Y = Game.Hight + Size.Height;
        }
    }
}
