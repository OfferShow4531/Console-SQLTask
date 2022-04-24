using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMTaskConsole
{
    // Ввести зависимость от имени физического лица
    public class ActiveEmployee : Employee
    {
        public string ActiveName { get; set; }    
        public string Surname { get; set; }
        public string Middlename { get; set; }
    
     }
    
    

}
    

