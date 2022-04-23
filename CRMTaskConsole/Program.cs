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

            string filepath = @"D:\path.txt";

            List<string> names = new List<string>() { "Tomas", "Tiphany", "Tine", "Era", "Trey", "Goph" };
            List<string> names1 = new List<string>() { "Tomas", "Tiphany", "Tine" };
            List<string> names2 = new List<string>() { "Era", "Trey" };

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


            if (File.Exists(filepath) && files.Extension == ".txt" || files.Extension == ".json")
            {
                using (var stream = File.Open(filepath, FileMode.Open))
                {
                    _passiveEmployees.Add(new PassiveEmployee()
                    {
                        Adress = arraylist[random.Next(arraylist.Count)],
                        PassiveName = firstLetterOfThirdString,
                        //EmployeeNames = new Dictionary<string, ActiveEmployee>
                        //{
                        //    ["FromActiveName"] = new ActiveEmployee
                        //    {
                        //        Id = random.Next(3, 40),
                        //        BIN = randomNumber(9),
                        //        Creator = firstLetterOfFirstString,
                        //        AddDate = RandomDay(),
                        //        Rebuilder = firstLetterOfSecondString,
                        //        UpdateDate = RandomDay(),
                        //        ActiveName = "Johnson",
                        //        Surname = "James",
                        //        Middlename = "Johan"
                        //    },
                        //},
                        lists = names1


                    });

                }
                //string pjson = JsonConvert.SerializeObject(_passiveEmployees.ToArray());
                //System.IO.File.AppendAllText(filepath, "\n" + pjson);
            }





            if (File.Exists(filepath) && files.Extension == ".txt" || files.Extension == ".json")
            {
                using (var stream = File.Open(filepath, FileMode.Open))
                {
                    string json = JsonConvert.SerializeObject(_passiveEmployees.ToArray());
                    
                    string readjson = JsonConvert.SerializeObject(_passiveEmployees.ToArray());
                    //IEnumerable<string> queryHighScores =
                    //(IEnumerable<string>)(from score in _passiveEmployees 
                    //orderby score.lists.ToList()
                    //select score.lists.ToList());

                    IEnumerable<string> sortDescendingQuery =
                    from w in readjson.Split('\u002C') 
                    orderby w
                    select w;
                    foreach (string s in sortDescendingQuery)
                    {    
                            Console.WriteLine(s.ToString());
                    }
                    
                    
                }


            }



           

            Console.ReadLine();
        }
    }

           





            

        }
        
    
        

