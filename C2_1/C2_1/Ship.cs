using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace C2_1
{
    class Ship : BaseObj
    {
        private int HP = 100;
        private int _energy = 100;
        public int Energy => _energy;
        public static event Message MessageDie;
        public void EnergyLow(int n)
        {
            _energy -= n;
        }
        public void EnergyUP(int n)
        {
            if (_energy < HP)
                _energy += n;
            else
            {
                _energy = HP;
            }
        }
        public Ship(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.FillEllipse(Brushes.Wheat, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        public override void Update()
        {
        }
        public void Up()
        {
            if (Pos.Y > 0) Pos.Y = Pos.Y - Dir.Y;
        }
        public void Down()
        {
            if (Pos.Y < Game.Hight) Pos.Y = Pos.Y + Dir.Y;
        }
        public void Die()
        {
            MessageDie?.Invoke();
        }
    }
}
