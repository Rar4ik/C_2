using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace C2_1
{
    class Bullet: BaseObj
    {
        public int Power { get; set; } = 1;
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Power = 1;
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawRectangle(Pens.OrangeRed, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        /// <summary>
        /// перемещение пули по прямой
        /// </summary>
        public override void Update()
        {
            Pos.X = Pos.X + 10;         
        }
    }
}
