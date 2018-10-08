using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace C2_1
{
    static class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;

        public static BaseObj[] _objs;

        private static Bullet _bullet;
        private static Asteroid[] _asteroid;
        private static int widht;
        private static int hight;
        /// <summary>
        /// попытка сделать исключение, не работает :(
        /// </summary>
        public static int Widht {
            get
            {
                return widht;
            }

            set
            {
                if (widht > 1000 || widht < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else widht = value;
            }
           
        }
        /// <summary>
        /// попытка сделать исключение, не работает :(
        /// </summary>
        public static int Hight
        {
            get
            {
                return hight;
            }

            set
            {
                if (hight > 1000 || hight < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else hight = value;
            }
        }
        static Game()
        {      
        }
        public static void Init(Form form)
        {
            Graphics g;
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            Widht = form.ClientSize.Width;
            Hight = form.ClientSize.Height;
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Widht, Hight));

            Load();
            Timer timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;
        }
        public static void Draw()
        {

            Buffer.Graphics.Clear(Color.Black);
            //Buffer.Graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200, 200)); 
            Buffer.Graphics.FillEllipse(Brushes.Wheat, new Rectangle(600, 75, 75, 75));
            Buffer.Render();

            //Buffer.Graphics.Clear(Color.Black); 
            foreach (BaseObj obj in _objs)
                obj.Draw();
            Buffer.Render();

            foreach (Asteroid obj in _asteroid)
                obj.Draw();
            _bullet.Draw();
            Buffer.Render();

        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
        public static void Update()
        {
            foreach (BaseObj obj in _objs)
                obj.Update();
            
            foreach (Asteroid obj in _asteroid)
            {
                obj.Update();
                if (obj.Collision(_bullet))
                {
                    System.Media.SystemSounds.Hand.Play();
                    obj.CollisionObj();
                }
            }
            _bullet.Update();           
        }
        public static void Load()
        {            
            _objs = new BaseObj[10];
            _bullet = new Bullet(new Point(0, 300), new Point(5, 0), new Size(4, 1));
            _asteroid = new Asteroid[5];
            var rnd = new Random();
            for (int i = 0; i < _objs.Length; i++)
            {
                int r = rnd.Next(5,50);
                _objs[i] = new Meteor(new Point(300, rnd.Next(0, Hight)), new Point(r, r), new Size(10, 10));
            }
            for (var i = 0; i < _asteroid.Length; i++)
            {
                int r = rnd.Next(5, 50);
                _asteroid[i] = new Asteroid(new Point(500, rnd.Next(0, Hight)), new Point(r , r), new Size(50, 50));
            }
            //for (int i = _objs.Length / 2; i < _objs.Length; i++)
            //    _objs[i] = new Star(new Point(600, i * 6), new Point(i / 2, 0), new Size(5, 5));
            //for (int i = _objs.Length / 4; i < _objs.Length / 2; i++)
            //    _objs[i] = new StarWay(new Point(10*i, 800), new Point(0, i), new Size(7, 7));            
        }        
    }
}
