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

            List<string> names = new List<string>() {"Tomas", "Tiphany", "Tine", "Era", "Trey", "Goph"};
            List<string> names1 = new List<string>() { "Tomas", "Tiphany", "Tine" };
            List<string> names2 = new List<string>() { "Era", "Trey"};

            FileInfo files = new FileInfo(filepath);
            Console.WriteLine(files.Name);
            Console.WriteLine(files.Extension);
            

            Random random = new Random();
            List<string> arraylist = new List<string>() { "Georgia", "Santa-Luisiano", "Los Angeles", "Santa-Maria", "China", "UK", "Finland", "Ireland"};
            int randomNumber(int n)
            {
                for (int i = 1; i <= 10; i++)
                {
                    Console.WriteLine("{0} -> {1}", i, random.Next());
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


            for (var i = 0; i < length; i++)
            {
                wString += ((char)(random.Next(1, 26) + 64)).ToString().ToLower();
            }
            string firstLetterOfThirdString = wString.Substring(0, 1).ToUpper() + wString.Substring(1);

            List<string> list = new List<string>();
            List<string> outputs = new List<string>();
            //List<Employee> _employee = new List<Employee>();
            List<ActiveEmployee> _activeEmployee = new List<ActiveEmployee>();
            
            ActiveEmployee active = new ActiveEmployee();
            
            //if (File.Exists(filepath) && files.Extension == ".txt" || files.Extension == ".json")
            //{
            //    _employee.Add(new Employee()
            //    {
            //        Id = random.Next(3, 40),
            //        BIN = randomNumber(9),
            //        Creator = firstLetterOfFirstString,
            //        AddDate = RandomDay(),
            //        Rebuilder = firstLetterOfSecondString,
            //        UpdateDate = RandomDay(),
                    

            //    });

            //    string json = JsonConvert.SerializeObject(_employee.ToArray());




            //    System.IO.File.WriteAllText(filepath, json);


            //    //open file stream
            //    using (StreamWriter file = File.CreateText(@"D:\path.txt"))
            //    {
            //        JsonSerializer serializer = new JsonSerializer();
            //        //serialize object directly into file stream
            //        serializer.Serialize(file, _employee);

            //    }
            //    Console.WriteLine(json);





            //}
            //if (File.Exists(filepath) && files.Extension == ".txt" || files.Extension == ".json")
            //{
            //    _activeEmployee.Add(new ActiveEmployee()
            //    {
            //        ActiveName = firstLetterOfFirstString,
            //        Surname = firstLetterOfSecondString,
            //        Middlename = "Always",


            //    });
            //    string ajson = JsonConvert.SerializeObject(_activeEmployee.ToArray());
            //    System.IO.File.WriteAllText(filepath, ajson);

            //    using (StreamWriter file = File.CreateText(@"D:\path.txt"))
            //    {
            //        JsonSerializer serializer = new JsonSerializer();
            //        //serialize object directly into file stream

            //        serializer.Serialize(file, _activeEmployee);

            //    }
            //    Console.WriteLine(ajson);
            //    foreach (var activepar in _activeEmployee)
            //    {
            //        outputs.Add($"{activepar.ActiveName}; {activepar.Surname}; {activepar.Middlename}");
            //    }

            //    File.WriteAllLines(filepath, outputs);
            //}

            //1. Не учитывать данные с класса контрагента
            //2. Не брать данные контрагента с класса Физ.лица
            //3. Зависимость физ.лица от региона компании юр.лица (USA - > ['fsf','fsfsf'], Canada -> ['fs','fsaf']
            //4. ActiveEmployees -> ActiveEmployees.Active = PassiveEmployees.EmployeeNames


            List<PassiveEmployee> _passiveEmployees = new List<PassiveEmployee>();
            

            if (File.Exists(filepath) && files.Extension == ".txt" || files.Extension == ".json")
            {
                _passiveEmployees.Add(new PassiveEmployee()
                {
                    PassiveName = firstLetterOfThirdString,
                    Adress = arraylist[random.Next(arraylist.Count)], 
                    EmployeeNames = new Dictionary<string, ActiveEmployee>
                    {
                        ["FromActiveName"] = new ActiveEmployee { 
                            Id = random.Next(3, 40), 
                            BIN = randomNumber(9), 
                            Creator = firstLetterOfFirstString,
                            AddDate = RandomDay(),
                            Rebuilder = firstLetterOfSecondString,
                            UpdateDate = RandomDay(),
                            ActiveName = "Johnson", Surname = "James", Middlename = "Johan"},    
                    },  
                    lists = names1
                   
                    
                });;
               
                string pjson = JsonConvert.SerializeObject(_passiveEmployees.ToArray());

                //for(int i = 1; i<7; i++)
                //{
                //    for(int j = 0; j<7-i-1; j++)
                //    {
                //        if (_passiveEmployees[j].lists.Count > _passiveEmployees[j + 1].lists.Count)
                //        {
                //            PassiveEmployee loh = _passiveEmployees[j];
                //            _passiveEmployees[j] = _passiveEmployees[j+1];
                //            _passiveEmployees[j+1] = loh;
                //        }

                //    }


                //}
                string AscMyJson(string json)
                {
                    var listOb = JsonConvert.DeserializeObject<List<PassiveEmployee>>(json);
                    var descListOb = listOb.OrderBy(x => x.lists);
                    return JsonConvert.SerializeObject(descListOb);
                }
                AscMyJson(pjson);

                var ordered = from i in pjson orderby i descending select i;

                System.IO.File.AppendAllText(filepath, pjson);



                //using (StreamWriter file = File.CreateText(@"D:\path.txt"))
                //{
                //    JsonSerializer serializer = new JsonSerializer();
                //    //serialize object directly into file stream
                //    serializer.Serialize(file, _passiveEmployees);

                //}
                

            }
            Console.ReadLine();


            


            /*Console.WriteLine(files.Name);
            Console.WriteLine(files.Extension);
            List<Employee> employees = new List<Employee>();    
            List<ActiveEmployee> activeEmployees = new List<ActiveEmployee>();  
            List<PassiveEmployee> passiveEmployees = new List<PassiveEmployee>();
            if (File.Exists(filepath) && files.Extension == ".txt")
            {
                List<string> line = File.ReadAllLines(filepath).ToList();



                Console.WriteLine("File Size in Bytes: {0}", files.Length);


                //passive.Launch(passive.PassiveInfo.Adress, passive.PassiveInfo.BuilderName);
                foreach (String lines in line)
                {
                    string[] entry = lines.Split(';');
                    Employee newemployee = new Employee();


                    newemployee.Id = entry.ToString()[0];
                    newemployee.BIN = entry.ToString()[1];
                    newemployee.Creator = entry[2];
                    newemployee.AddDate = entry[3];
                    newemployee.Rebuilder = entry[4];
                    newemployee.UpdateDate = entry[5];

                    employees.Add(newemployee);


                }



                foreach (var employee in employees)
                {
                    Console.WriteLine($"{employee.Id} {employee.BIN} {employee.Creator}: {employee.AddDate} {employee.Rebuilder}: {employee.UpdateDate}");
                }


                employees.Add(new Employee { Id = random.Next(3,40), BIN = 52151421, Creator = firstLetterOfFirstString, AddDate = "05.01.2020", Rebuilder = firstLetterOfSecondString, UpdateDate = "05.07.2021" });


                File.WriteAllLines(filepath, line);

                List<string> outputs = new List<string>();

                foreach(var paragraph in employees)
                {

                    outputs.Add($"{paragraph.Id}; {paragraph.BIN}; {paragraph.Creator}; {paragraph.AddDate}; {paragraph.Rebuilder}; {paragraph.UpdateDate};");
                }


                File.WriteAllLines(filepath, outputs);




                Console.ReadLine();
            }
            string activefile = @"D:\Active.txt";
            FileInfo actfile = new FileInfo(activefile);
            if (File.Exists(activefile) && actfile.Extension == ".txt")
            {
                List<string> passline = File.ReadAllLines(activefile).ToList();
                ActiveEmployee active = new ActiveEmployee();
                PassiveEmployee passive = new PassiveEmployee();
                Console.WriteLine("File Size in Bytes: {0}", files.Length);

                foreach (String lines in passline)
                {

                    string[] str_entry = lines.Split(';');




                    active.ActiveName = str_entry[0];
                    active.Surname = str_entry[1];
                    active.Middlename = str_entry[2];

                    activeEmployees.Add(active);



                }
                activeEmployees.Sort();
                var numbersAndWords = activeEmployees.Zip(passiveEmployees, (w, z) => new { activeEmployees = w, passiveEmployees = z });
                foreach (var employee in numbersAndWords)
                {

                    Console.WriteLine($"{employee.activeEmployees.ActiveName} {employee.activeEmployees.Surname} {employee.activeEmployees.Middlename}");

                }
                activeEmployees.Add(new ActiveEmployee { ActiveName = "Jone", Surname = "Jacob", Middlename = "Wilsmort" });

                File.WriteAllLines(activefile, passline);
                List<string> outputs = new List<string>();


                foreach (var activepar in activeEmployees)
                {
                    outputs.Add($"{activepar.ActiveName}; {activepar.Surname}; {activepar.Middlename}");
                }

                File.WriteAllLines(activefile, outputs);





                Console.ReadLine();

            }
            string pasivefile = @"D:\Passive.txt";
            FileInfo passfile = new FileInfo(pasivefile);
            if (File.Exists(pasivefile) && passfile.Extension == ".txt")
            {
                List<string> passline = File.ReadAllLines(pasivefile).ToList();
                ActiveEmployee active = new ActiveEmployee();
                PassiveEmployee passive = new PassiveEmployee();
                Console.WriteLine("File Size in Bytes: {0}", files.Length);

                foreach (String lines in passline)
                {

                    string[] str_entry = lines.Split(';');

                    passive.PassiveName = str_entry[0];
                    passive.Adress = str_entry[1];
                    active.ActiveName = str_entry[2];
                    passive.PhysicFaceTwo = str_entry[3];
                    passive.PhysicFaceThree = str_entry[4];
                    activeEmployees.Add(active);
                    passiveEmployees.Add(passive);


                }
                passiveEmployees.Sort();
                var numbersAndWords = activeEmployees.Zip(passiveEmployees, (w, z) => new { activeEmployees = w, passiveEmployees = z });
                foreach (var employee in numbersAndWords)
                {

                    Console.WriteLine($"{employee.passiveEmployees.PassiveName} {employee.passiveEmployees.Adress} {employee.activeEmployees.ActiveName}");

                }
                activeEmployees.Add(new ActiveEmployee { ActiveName = "Jone"});
                passiveEmployees.Add(new PassiveEmployee { PassiveName = "June", Adress = "Brandson" });
                File.WriteAllLines(pasivefile, passline);
                List<string> outputs = new List<string>();



                foreach (var passivepar in passiveEmployees)
                {
                    outputs.Add($"{passivepar.PassiveName}; {passivepar.Adress}; {active.ActiveName}; {passivepar.PhysicFaceTwo}; {passivepar.PhysicFaceThree};");
                }


                outputs.Sort((a, b) => a.Length.CompareTo(b.Length));

                File.WriteAllLines(pasivefile, outputs);


            */



        }
       
    }
        
}
