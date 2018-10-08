using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace C2_1
{
    class Asteroid: BaseObj
    {
        public int Power { get; set; }
        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Power = 1;
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawEllipse(Pens.White, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        /// <summary>
        /// отражение астероидов от стен
        /// </summary>
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y + Dir.Y;
            if (Pos.X < 0) Dir.X = -Dir.X;
            if (Pos.X > Game.Widht) Dir.X = -Dir.X;
            if (Pos.Y < 0) Dir.Y = -Dir.Y;
            if (Pos.Y > Game.Hight) Dir.Y = -Dir.Y;
            //Pos.X = Pos.X - Dir.X;
            //if (Pos.X < 0) Pos.X = Game.Widht + Size.Width;

        }
        /// <summary>
        /// Добавлена возможность регенирировать метеоры в разных участках карты
        /// </summary>
        public void CollisionObj()
        {
            var rnd = new Random();
            int r = rnd.Next(0, 600);
            Pos.X = r - Dir.X;
            Pos.Y = r - Dir.X;
            if (Pos.X < 0) Dir.X = -Dir.X;
            if (Pos.X > Game.Widht) Dir.X = -Dir.X;
            if (Pos.Y < 0) Dir.Y = -Dir.Y;
            if (Pos.Y > Game.Hight) Dir.Y = -Dir.Y;
        }
    }
}
