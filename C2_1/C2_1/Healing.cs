using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C2_1
{    
        class Healing : BaseObj, ICloneable, IComparable<Healing>
        {
            public interface IComparable<T>
            {
                int CompareTo(T obj);
            }
            public int CompareTo(Healing obj)
            {
                if (Power > obj.Power)
                    return 1;
                if (Power < obj.Power)
                    return -1;
                return 0;
            }
            public int Power { get; set; } = 3;
            public Healing(Point pos, Point dir, Size size) : base(pos, dir, size)
            {
                Power = 1;
            }
            public object Clone()
            {
                Healing heals = new Healing(new Point(Pos.X, Pos.Y), new Point(Dir.X, Dir.Y), new Size(Size.Width, Size.Height)) { Power = Power };
                return heals;
            }

            public override void Draw()
            {
                Game.Buffer.Graphics.DrawEllipse(Pens.Red, Pos.X, Pos.Y, Size.Width, Size.Height);
            }            
            public override void Update()
            {
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y + Dir.Y;
            if (Pos.X < 0) Dir.X = -Dir.X;
            if (Pos.X > Game.Widht) Dir.X = -Dir.X;
            if (Pos.Y < 0) Dir.Y = -Dir.Y;
            if (Pos.Y > Game.Hight) Dir.Y = -Dir.Y;
        }
    }
}
