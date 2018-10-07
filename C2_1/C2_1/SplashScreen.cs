using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace C2_1
{
    class SplashScreen
    {
        static Form SPS = new Form();
        static Button a = new Button();
        static Button b = new Button();
        static Button c = new Button();
        static Form form = new Form();
        private static void Screen(Button Start, Button Records, Button Exit)
        {
            SPS.Controls.Add(Start);
            SPS.Controls.Add(Records);
            SPS.Controls.Add(Exit);
        }
        private static void CreateButton(Button Start, Button Records, Button Exit)
        {
            Start.Text = "Start";
            Records.Text = "Records";
            Exit.Text = "Exit";
        }
        private static void LocateButton(Button Start, Button Records, Button Exit)
        {
            Start.Location = new Point(10, 10);
            Records.Location = new Point(Start.Left, Start.Height + Start.Top + 10);
            Exit.Location = new Point(Records.Left, Records.Height + Records.Top + 10);

        }
        private static void ButtonClick(object sender, EventArgs e)
        {
            string text = (sender as Button).Text.ToString();
            if (text == "Start")
            {
                MessageBox.Show("Начали");
                form.Width = 800;
                form.Height = 600;
                Game.Init(form);
                form.Show();
                Game.Draw();
            }
            if (text == "Records") MessageBox.Show("...Рекорды пока не записывались...");
            if (text == "Exit")
            {
                MessageBox.Show("Hasta luego");
                Application.Exit();
            }
        }
        public static void Run()
        { 
            Screen(a, b, c);
            CreateButton(a, b, c);
            LocateButton(a, b, c);
            a.Click += ButtonClick;
            b.Click += ButtonClick;
            c.Click += ButtonClick;
            SPS.ShowDialog();
        }
    }
}
