using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SecondWPF
{
    /// <summary>
    /// Interaction logic for Editing.xaml
    /// </summary>
    public partial class Editing : Window
    {
        public Editing(Workers e)
        {
            InitializeComponent();
            Deps d = new Deps();
            mainStackPanel.DataContext = e;
            DepsList.Items.Add(d);
        }
    }
}
