using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace SecondWPF
{
    public class Workers : INotifyPropertyChanged
    {
        public int Id { get; set; }
        private string surname;
        private int age;
        private double salary;
        private Deps _dep;
        public string Surname
        {
            get { return this.surname; }
            set
            {
                if (this.surname != value)
                {
                    this.surname = value;
                    this.NotifyPropertyChanged("Name");
                }
            }
        }
        public int Age
        {
            get { return this.age; }
            set
            {
                if (this.age != value)
                {
                    this.age = value;
                    this.NotifyPropertyChanged("Age");
                }
            }
        }            
        public double Salary
        {
            get { return this.salary; }
            set
            {
                if (this.salary != value)
                {
                    this.salary = value;
                    this.NotifyPropertyChanged("Salary");
                }
            }
        }
        public Deps dep
        {
            get { return this._dep; }
            set
            {
                if (this._dep != value)
                {
                    this._dep = value;
                    this.NotifyPropertyChanged("Department");
                }
            }
        }
        public override string ToString()
        {
            return $"{Id}\t{Surname}\t{Age}\t{Salary}";
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
