using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMTaskConsole
{
    public  class PassiveEmployee : Employee
    {
        public string Adress { get; set; }
        public string PassiveName { get; set; }

        public string PhysicFaceOne { get; set; }

        public string PhysicFaceTwo { get; set; }
        public string PhysicFaceThree { get; set; }
      

       /* public void Launch(string Name, string Adress)
        {
            PassiveInfo = PassiveInfo.getInstance(Name, Adress);
        }*/
    }
    /*class PassiveInfo
    {
        private static PassiveInfo instance;

        public string BuilderName { get; private set; }
        public string Adress { get; private set; }

        protected PassiveInfo(string name, string adress)
        {
            this.BuilderName = name;
            this.Adress = adress;
            
        }

        public static PassiveInfo getInstance(string name, string adress)
        {
            if (instance == null)
                instance = new PassiveInfo(name, adress);
            return instance;
        }
    }
    */


}
   

