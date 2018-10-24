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
using System.Collections.ObjectModel;

namespace SecondWPF
{
    /// <summary>
    /// Interaction logic for Editing.xaml
    /// </summary>
    public partial class Editing : Window
    {
        public ObservableCollection<Deps> Departs { get; }
        public Editing(Workers e, ObservableCollection<Deps> Departs)
        {
            this.Departs = Departs;
            InitializeComponent();           
            mainStackPanel.DataContext = e;            
        }
    }
}
