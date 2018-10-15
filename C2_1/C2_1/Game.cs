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

        private static List<Bullet> _bullets = new List<Bullet>();
        private static Asteroid[] _asteroid;
        private static Healing[] _heals;
        private static int widht;
        private static int hight;
        private static Ship _ship = new Ship(new Point(10, 400), new Point(5, 5), new Size(10, 10));
        private static Timer timer = new Timer { Interval = 100 };
            
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
            try
            {
                Widht = form.ClientSize.Width;
                Hight = form.ClientSize.Height;
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Ширина или высота поля указана некорректно");
            }
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Widht, Hight));
            timer.Start();
            timer.Tick += Timer_Tick;
            Load();
            form.KeyDown += Form_KeyDown;
            Ship.MessageDie += Finish;
        }
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            Buffer.Graphics.FillEllipse(Brushes.Wheat, new Rectangle(600, 75, 75, 75));  
            foreach (BaseObj obj in _objs)
                obj.Draw();
            foreach (Asteroid obj in _asteroid)
                obj?.Draw();
            //_bullet?.Draw();
            _ship?.Draw();
            foreach (Healing obj in _heals)
                obj?.Draw();
            foreach (Bullet b in _bullets)
                b.Draw();
            //_bullets?.Draw();
            _ship?.Draw();
            if (_ship != null)
                Buffer.Graphics.DrawString("Energy:" + _ship.Energy, SystemFonts.DefaultFont, Brushes.White, 0, 0);
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
            //_bullet?.Update();
            foreach (Bullet item in _bullets)
                item.Update();
            for (var i = 0; i < _asteroid.Length; i++)
            {
                if (_asteroid[i] == null) continue;
                _asteroid[i].Update();
                for (int j = 0; j < _bullets.Count; j++)
                {
                    if (_asteroid[i] != null && _bullets[j].Collision(_asteroid[i]))
                    {
                        System.Media.SystemSounds.Hand.Play();
                        _asteroid[i] = null;
                        _bullets.RemoveAt(j);
                        j--;
                        Logger.LogtoConsole(Logger.LogThis(Logs.DestroyAst, 0), Logger.Method);
                    }
                }                
                if (_asteroid[i] == null || !_ship.Collision(_asteroid[i])) continue;
                {                    
                    int rnd = 5;
                    _ship?.EnergyLow(rnd);
                    Logger.LogtoConsole(Logger.LogThis(Logs.GetDMG, rnd), Logger.Method);
                    System.Media.SystemSounds.Asterisk.Play();
                    if (_ship.Energy <= 0)  _ship.Die(); 
                }                           
            }
            for (var i = 0; i < _heals.Length; i++)
            {
                if (_heals[i] == null) continue;
                _heals[i].Update();                
                if (!_ship.Collision(_heals[i])) continue;
                {
                    int rnd = 3;
                    _ship?.EnergyUP(rnd);
                    Logger.LogtoConsole(Logger.LogThis(Logs.GetHeal, rnd), Logger.Method);
                    System.Media.SystemSounds.Beep.Play();
                }
            }
        }
        public static void Load()
        {            
            _objs = new BaseObj[10];
            _asteroid = new Asteroid[5];
            _heals = new Healing[4];
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
            for (int i = 0; i < _heals.Length; i++)
            {
                int r = rnd.Next(5, 50);
                _heals[i] = new Healing(new Point(500, rnd.Next(0, Hight)), new Point(r, r), new Size(50, 50));
            }         
        }
        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space) _bullets.Add (new Bullet(new Point(_ship.Rect.X + 10, _ship.Rect.Y + 4), new Point(4, 0), new Size(4, 1)));
            if(e.KeyCode == Keys.Up) _ship.Up();
            if(e.KeyCode == Keys.Down) _ship.Down();            
        }
        public static void Finish()
        {
            timer.Stop();
            Logger.LogtoConsole(Logger.LogThis(Logs.Die, 0), Logger.Method);
            Buffer.Graphics.DrawString("The End", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Underline), Brushes.White, 200, 100);
            Buffer.Render();
        }                
    }
}
