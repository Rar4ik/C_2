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
using System.Collections.Specialized;

namespace TheFirstWPFRavaev
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Employee> Work = new ObservableCollection<Employee>();
        ObservableCollection<Departments> Dep = new ObservableCollection<Departments>();
        public MainWindow()
        {            
            InitializeComponent();                    
            List.ItemsSource = Work;
            ListDep.ItemsSource = Dep;
        }
        void FillList(object sender, RoutedEventArgs e)
        {
            Work.Add(new Employee() { Id = 1, Surname = "Ivanov", Age = 43, Salary = 12000 });
            Work.Add(new Employee() { Id = 2, Surname = "Petrov", Age = 25, Salary = 12000 });
            Work.Add(new Employee() { Id = 3, Surname = "Sidorov", Age = 68, Salary = 12000 });          
        }
        void FillDep(object sender, RoutedEventArgs e)
        {
            Dep.Add(new Departments() { NameDep = "Accounting" });
            Dep.Add(new Departments() { NameDep = "Marketing" });
            Dep.Add(new Departments() { NameDep = "Programming" });
        }
        private void List_Selected(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(e.Source.ToString());
        }
        private void List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show(e.AddedItems[0].ToString());
        }        
        private void Show_EMP(object sender, RoutedEventArgs e)
        {
            foreach (var item in Work)
            {
                Console.WriteLine(item.Id);
                Console.Write(item.Surname );
                Console.Write(item.Age );
                Console.Write(item.Salary);
            }
        }          
     }
    public class Employee
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public double Salary { get; set; }
        public override string ToString()
        {
            return $"{Id}\t{Surname}\t{Age}\t{Salary}";
        }
    }
    public class Departments
    {
        public string NameDep { get; set; }
        public override string ToString()
        {
            return $"{NameDep}\t";
        }
    }
}
