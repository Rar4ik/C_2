using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace C2_1
{
    class Asteroid : BaseObj, ICloneable, IComparable<Asteroid>
    {
        public interface IComparable<T>
        {
            int CompareTo(T obj);
        }
        public int CompareTo(Asteroid obj)
        {
            if (Power > obj.Power)
                return 1;
            if (Power < obj.Power)
                return -1;
            return 0;
        }
        public int Power { get; set; } = 3;
        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Power = 1;
        }
        public object Clone()
        {
            Asteroid asteroid = new Asteroid(new Point(Pos.X, Pos.Y), new Point(Dir.X, Dir.Y), new Size(Size.Width, Size.Height)) { Power = Power };
            return asteroid;
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
            Pos.X = Pos.X - Dir.X;
            if (Pos.X < 0) Pos.X = Game.Widht + Size.Width;
        }
        /// <summary>
        /// Добавлена возможность регенирировать метеоры в разных участках карты
        /// </summary>
        public void CollisionObj()
        {
            Pos.X = Pos.X - Dir.X;
            if (Pos.X < 0) Pos.X = Game.Widht + Size.Width;
        }
    }
}
