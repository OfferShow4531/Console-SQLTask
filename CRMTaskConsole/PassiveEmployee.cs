using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMTaskConsole
{
    
    public class PassiveEmployee 
    {

        
        public string Adress { get; set; }
        public string PassiveName { get; set; }

        public Dictionary<string, ActiveEmployee> EmployeeNames { get; set; }
        
        public List<string> lists { get; set; } 
        
        

    }

   
}
   

