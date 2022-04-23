using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;




namespace CRMTaskConsole
{
    //Контрагент 
    public class Employee
    {
        [Newtonsoft.Json.JsonProperty("Id")]
        public int Id { get; set; }
        [Newtonsoft.Json.JsonProperty("BIN")]
        public int BIN { get; set; }
        [Newtonsoft.Json.JsonProperty("Creator")]
        public string Creator { get; set; }
        [Newtonsoft.Json.JsonProperty("AddDate")]
        public DateTime AddDate { get; set; }
        [Newtonsoft.Json.JsonProperty("Rebuilder")]
        public string Rebuilder { get; set; }
        [Newtonsoft.Json.JsonProperty("UpdateDate")]
        public DateTime UpdateDate { get; set; }


    }
    


}
