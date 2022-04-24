using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMTaskConsole
{
    internal class Program
    {

        static void Main(string[] args)
        {

            string filepath = @"D:\path.json";

            List<string> names = new List<string>() { "Tomas", "Tiphany", "Tine", "Era", "Trey", "Goph", "Ora", "Test", "Jean" };
            List<string> names1 = new List<string>() { "Tomas", "Tiphany", "Tine" };
            List<string> names2 = new List<string>() { "Era", "Trey" };

            List<List<string>> namesList = new List<List<string>>();
            namesList.Add(names);
            namesList.Add(names1);
            namesList.Add(names2);

            FileInfo files = new FileInfo(filepath);
            Console.WriteLine(files.Name);
            Console.WriteLine(files.Extension);

            //Function with generate random: number, date and name
            Random random = new Random();
            List<string> arraylist = new List<string>() { "Georgia", "Santa-Luisiano", "Los Angeles", "Santa-Maria", "China", "UK", "Finland", "Ireland" };
            int randomNumber(int n)
            {
                for (int i = 1; i <= 10; i++)
                {
                    i = random.Next();
                    n = i;

                }
                return n;

            }

            DateTime RandomDay()
            {
                DateTime start = new DateTime(1995, 1, 1);
                int range = (DateTime.Today - start).Days;
                return start.AddDays(random.Next(range));
            }

            int length = 9;
            string rString = "";
            string lString = "";
            string wString = "";

            // random name
            for (var i = 0; i < length; i++)
            {

                rString += ((char)(random.Next(1, 26) + 64)).ToString().ToLower();
            }
            string firstLetterOfFirstString = rString.Substring(0, 1).ToUpper() + rString.Substring(1);
            //random surname
            for (var i = 0; i < length; i++)
            {
                lString += ((char)(random.Next(1, 26) + 64)).ToString().ToLower();
            }
            string firstLetterOfSecondString = lString.Substring(0, 1).ToUpper() + lString.Substring(1);
            //random middlename
            for (var i = 0; i < length; i++)
            {
                wString += ((char)(random.Next(1, 26) + 64)).ToString().ToLower();
            }
            string firstLetterOfThirdString = wString.Substring(0, 1).ToUpper() + wString.Substring(1);

           
           
            //1. Не учитывать данные с класса контрагента
            //2. Не брать данные контрагента с класса Физ.лица
            //3. Зависимость физ.лица от региона компании юр.лица (USA - > ['fsf','fsfsf'], Canada -> ['fs','fsaf']
            //4. ActiveEmployees -> ActiveEmployees.Active = PassiveEmployees.EmployeeNames


            List<PassiveEmployee> _passiveEmployees = new List<PassiveEmployee>();
           
            for(int i = 0; i < 10; i++)
            {

                _passiveEmployees.Add(new PassiveEmployee()
                {
                    Adress = arraylist[random.Next(arraylist.Count)],
                    PassiveName = firstLetterOfThirdString,
                    EmployeeNames = new Dictionary<string, ActiveEmployee>
                    {
                        ["FromActiveName"] = new ActiveEmployee
                        {
                            Id = random.Next(3, 40),
                            BIN = randomNumber(9),
                            Creator = firstLetterOfFirstString,
                            AddDate = RandomDay(),
                            Rebuilder = firstLetterOfSecondString,
                            UpdateDate = RandomDay(),
                            ActiveName = "Johnson",
                            Surname = "James",
                            Middlename = "Johan"
                        },
                    },
                    lists = namesList[random.Next(0, 2)] 
                });
            }

            if (File.Exists(filepath) && files.Extension == ".txt" || files.Extension == ".json")
            {
                string pjson;
                using (var stream = File.OpenWrite(filepath))
                {
                    pjson = JsonConvert.SerializeObject(_passiveEmployees);                                       
                }
                System.IO.File.WriteAllText(filepath, pjson);
            }


            if (File.Exists(filepath) && files.Extension == ".txt" || files.Extension == ".json")
            {
                using (StreamReader r = new StreamReader(filepath))
                {                    
                    string json = r.ReadToEnd();                    
                    List<PassiveEmployee> items = JsonConvert.DeserializeObject<List<PassiveEmployee>>(json);
                 
                    IEnumerable<PassiveEmployee> sortDescendingQuery =
                    (from w in items
                     orderby w.lists.Count descending
                     select w).Take(5);

                    foreach (var s in sortDescendingQuery)
                    {
                        Console.WriteLine($"\n Adress: {s.Adress} ; \n\nPassiveNames: {s.PassiveName}\n\n");
                        foreach(var item in s.lists)
                        {
                            Console.WriteLine("listOfName : " + item);
                        }              
                    }
                }
            }
            Console.ReadLine();
        }
    }

}
        
    
        

