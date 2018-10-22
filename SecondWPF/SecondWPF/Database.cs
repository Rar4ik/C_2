using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace SecondWPF
{
    static class Database
    {
        static public ObservableCollection<Workers> Workers { get; set; }
        static public ObservableCollection<Deps> Deps { get; set; }
        static Database()
        {            
        }           
    }    
}
