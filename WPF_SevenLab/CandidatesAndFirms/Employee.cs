using System;

namespace MainSolution.CandidatesAndFirms
{
    public class Employee
    {
        //properties
        [Flags]
        public enum Properties
        {
            Smart = 1, //Умный
            Kind = 2, //Добрый
            Wealthy = 4, //Cостоятельный

            Lazy = 8, //Kенивый
            Greedy = 16, //Жадный
            Wicked = 32 //Безнравственный
        }

        
        private readonly string _fName;
        private readonly string _sName;
        private readonly Properties? _propertiesCandidate; //Персональные качества
        private readonly Firm.WorkingConditions? _workingConditions; //Требования от работы

        public Employee
        (
            string fName,
            string sName,
            Properties? propertiesCandidate = null,
            Firm.WorkingConditions? propertiesFirm = null
        )
        {
            _fName = fName;
            _sName = sName;
            _propertiesCandidate = propertiesCandidate;
            _workingConditions = propertiesFirm;
        }

        public string GetName()
        {
            return _sName + " " + _fName;
        }

        public Properties? GetPropertiesCandidate()
        {
            return _propertiesCandidate;
        }

        public Firm.WorkingConditions? GetWorkingConditions()
        {
            return _workingConditions;
        }
    }
}