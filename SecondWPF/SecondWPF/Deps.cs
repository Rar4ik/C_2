using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondWPF
{
    public class Deps
    {
        public string NameDep { get; set; }
        public override string ToString()
        {
            return $"{NameDep}\t";
        }
    }
}
