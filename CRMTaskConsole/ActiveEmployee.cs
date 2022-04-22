using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMTaskConsole
{
    public class ActiveEmployee : Employee
    {
        public string ActiveName { get; set; }    
        public string Surname { get; set; }
        public string Middlename { get; set; }
        
           /* public ActiveInfo ActiveInfo { get; set; }
            public void Launch(string Name, string Surname, string Middlename)
            {
                ActiveInfo = ActiveInfo.getInstance(Name, Surname, Middlename);
            }*/
        }
        /*class ActiveInfo
        {
            private static ActiveInfo instance;

            public string Name { get; private set; }
            public string Surname { get; private set; } 
            public string Middlename { get; private set; }  

            protected ActiveInfo(string name, string surname, string middlename)
            {
                this.Name = name;
                this.Surname = surname;
                this.Middlename = middlename;   
            }

            public static ActiveInfo getInstance(string name, string surname, string middlename)
            {
                if (instance == null)
                    instance = new ActiveInfo(name, surname, middlename);
                return instance;
            }
        }

    */

    }
    

