using System;
using System.Collections.Generic;
using System.IO;
using MainSolution.CandidatesAndFirms;

namespace MainSolution.Logic
{
    public class WorkFile
    {
        private const string FilePath = "text.txt";

        public void StartWork()
        {
            var candidates = new Candidates().GetCandidates();
            
            if (!File.Exists(FilePath))
            {
                StreamWriter file = new StreamWriter(FilePath);
                foreach (var candidate in candidates)
                {
                    file.WriteLine(candidate.GetName() + "/"
                                   + candidate.GetPropertiesCandidate() + "/" 
                                   + candidate.GetDesiredFirmConditions() + "/"
                                   + candidate.GetUndesirableFirmConditions());
                }
                file.Close();
            }
        }

        public void AddEmployee(Employee employee)
        {
            FileStream fileStream = null;
            StreamWriter streamWriter = StreamWriter.Null;
            try
            {
                fileStream = new FileStream(FilePath, FileMode.Append, FileAccess.Write);
                streamWriter = new StreamWriter(fileStream);

                streamWriter.WriteLine(employee.GetName() + "/"
                                                          + employee.GetPropertiesCandidate() + "/"
                                                          + employee.GetDesiredFirmConditions() + "/"
                                                          + employee.GetUndesirableFirmConditions());
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                streamWriter.Close();
                if (fileStream != null) fileStream.Close();
            }
        }

        public List<Employee> GetCandidates()
        {
            var candidates = new List<Employee>();
            StreamReader file = StreamReader.Null;
            try
            {
                file = new StreamReader(FilePath);
                string fileLine;
                while ((fileLine = file.ReadLine()) != null) candidates.Add(GetEmployee(fileLine));

                return candidates;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                file.Close();
            }
        }

        private Employee GetEmployee(string fileLine)
        {
            try
            {
                Employee.Properties? employeeProperties = null;
                Firm.FirmConditions? desiredFirmConditions = null;
                Firm.FirmConditions? undesirableFirmConditions = null;
                var simSent = fileLine.Split('/');
                if (simSent[1] != "")
                {
                    employeeProperties = 
                        (Employee.Properties) Enum.Parse(typeof(Employee.Properties), simSent[1]);
                }
                if (simSent[2] != "")
                {
                    desiredFirmConditions = 
                        (Firm.FirmConditions) Enum.Parse(typeof(Firm.FirmConditions), simSent[2]);
                }
                if (simSent[3] != "")
                {
                    undesirableFirmConditions = 
                        (Firm.FirmConditions) Enum.Parse(typeof(Firm.FirmConditions), simSent[3]);
                }
                var nameSent = simSent[0].Split(' ');
                return new Employee(nameSent[1], nameSent[0],employeeProperties,
                                    desiredFirmConditions,undesirableFirmConditions);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}