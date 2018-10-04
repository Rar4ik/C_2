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
        public static BaseObj[] _objsM;

        public static int Widht { get; set; }
        public static int Hight { get; set; }
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
            //LoadImage(); //ссылка на метод
            Timer timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;
        }
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            //Buffer.Graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200, 200)); //убрал прямоугольник
            Buffer.Graphics.FillEllipse(Brushes.Wheat, new Rectangle(600, 75, 75, 75));
            Buffer.Render();

            //Buffer.Graphics.Clear(Color.Black); // убрал мерцание луны
            foreach (BaseObj obj in _objs)
                obj.Draw();
            //foreach (BaseObj obj in _objsM) // попытка нарисовать картинку вместо круга 
            //    obj.CreateImage();
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
        }
        public static void Load()
        {
            _objs = new BaseObj[100];
            for (int i = 0; i < _objs.Length; i++)
                _objs[i] = new BaseObj(new Point(i * 2, i * 2), new Point(10-i, 10+i), new Size(20 - i, 20 - i));
            for (int i = _objs.Length / 2; i < _objs.Length; i++)
                _objs[i] = new Star(new Point(600, i * 6), new Point(i / 2, 0), new Size(5, 5));
            for (int i = _objs.Length / 4; i < _objs.Length / 2; i++)
                _objs[i] = new StarWay(new Point(10*i, 800), new Point(0, i), new Size(7, 7));
        }
        //public static void LoadImage()// попытка нарисовать картинку вместо круга 
        //{
        //    _objsM = new BaseObj[10];
        //    for (int i = 0; i < _objsM.Length; i++)
        //        _objsM[i] = new Star(new Point(600, i * 6), new Point(i / 2, 0), new Size(5, 5));
        //}
    }
}
