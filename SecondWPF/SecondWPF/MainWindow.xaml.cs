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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace SecondWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Workers> Worker = new ObservableCollection<Workers>();
        ObservableCollection<Deps> Dep = new ObservableCollection<Deps>();
        Random r = new Random();
        public MainWindow()
        {
            InitializeComponent();            
        }
        void FillDeps(object sender, RoutedEventArgs e)
        {
            Dep.Add(new Deps("Accounting"));
            Dep.Add(new Deps("Marketing"));
            Dep.Add(new Deps("Programming"));
            ShowWorkers();
        }
        void ShowWorkers()
        {
            Worker.Add(new Workers() { Id = 1, Surname = "Ivanov", Age = 43, Salary = 12000, dep = Dep[r.Next(0, Dep.Count)] });
            Worker.Add(new Workers() { Id = 2, Surname = "Petrov", Age = 25, Salary = 12000, dep = Dep[r.Next(0, Dep.Count)] });
            Worker.Add(new Workers() { Id = 3, Surname = "Sidorov", Age = 68, Salary = 12000, dep = Dep[r.Next(0, Dep.Count)] });
            Emploey.ItemsSource = Worker;
        }

        private void Emploey_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            new Editing(Emploey.SelectedItem as Workers, Dep).ShowDialog();
        }

        private void addWorker_Click(object sender, RoutedEventArgs e)
        {
            Worker.Add(new Workers() { Id = 1, Surname = "Yarik", Age = 43, Salary = 12000, dep = Dep[r.Next(0, Dep.Count)] });
        }

        private void removeWorker_Click(object sender, RoutedEventArgs e)
        {
            if (Emploey.SelectedItem != null)
                Worker.Remove(Emploey.SelectedItem as Workers);
        }        
    }
}
