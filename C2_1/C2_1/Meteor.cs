using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace C2_1
{
/// <summary>
/// создание объекта "планета - метеорит"
/// </summary>
    class Meteor: BaseObj
    {
        Image meteor;
        public Meteor(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            meteor = Image.FromFile("meteor.jpg");
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(meteor, Pos.X, Pos.Y, Size.Width, Size.Height);
            
        }
        /// <summary>
        /// перемещение метеоритов по прямой
        /// </summary>
        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            if (Pos.X < 0) Pos.X = Game.Widht + Size.Width;
        }
    }
}
