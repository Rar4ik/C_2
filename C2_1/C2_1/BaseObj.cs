using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;


namespace C2_1
{
    /// <summary>
    /// базовый, абстрактный класс
    /// </summary>
    abstract class  BaseObj: ICollision
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;
        protected BaseObj(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }
        public abstract void Draw();
        public abstract void Update();

        public bool Collision(ICollision o) =>
            o.Rect.IntersectsWith(this.Rect);
        public Rectangle Rect => new Rectangle(Pos, Size);
    }
}
