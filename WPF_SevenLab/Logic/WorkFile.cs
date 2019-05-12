using System;
using System.Collections.Generic;
using System.IO;
using MainSolution.CandidatesAndFirms;

namespace MainSolution.Logic
{
    public class WorkFile
    {
        private const string FilePath = "text.txt";

        public WorkFile(List<Employee> candidates)
        {
            if (!File.Exists(FilePath))
            {
                StreamWriter file = new StreamWriter(FilePath);
                foreach (var candidate in candidates)
                {
                    file.WriteLine("&" + candidate.GetName() + "/"
                                   + candidate.GetPropertiesCandidate() + "/" 
                                   + candidate.GetWorkingConditions() + "&");
                }
                file.Close();
            }
        }
        public void AddEmployee(Employee employee)
        {
            FileStream fs = new FileStream(FilePath, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            
                sw.WriteLine("&" + employee.GetName() + "/"
                             + employee.GetPropertiesCandidate() + "/" 
                             + employee.GetWorkingConditions() + "&");
            sw.Close();
            fs.Close();
        }

        public List<Employee> GetListEmployee()
        {
            var candidates = new List<Employee>();
            
            var file = new StreamReader(FilePath);
            string fileLine;
            while ((fileLine = file.ReadLine()) != null) candidates.Add(GetEmployee(fileLine));
            
            return candidates;
        }

        //ToDo Еще не готово)))) Нужно думать
        private Employee GetEmployee(string fileLine)
        {
            try
            {
                var simSent = fileLine.Split('/');
                return new Employee("","");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}