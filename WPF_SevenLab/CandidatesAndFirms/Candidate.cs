using System;

namespace MainSolution.CandidatesAndFirms
{
    public class Candidate
    {
        [Flags]
        public enum Properties
        {
            Smart = 1,
            Kind = 2,
            Wealthy = 4,

            Lazy = 8,
            Greedy = 16,
            Wicked = 32
        }

        //properties
        private readonly string _fName;
        private readonly Properties? _properties;
        private readonly string _sName;
        private readonly Firm.WorkingConditions? _workingConditions;

        public Candidate(string fName, string sName,
            Properties? properties, Firm.WorkingConditions? workingConditions = null)
        {
            _fName = fName;
            _sName = sName;
            _properties = properties;
            _workingConditions = workingConditions;
        }

        public string GetName()
        {
            return _sName + " " + _fName;
        }

        public Properties? GetProperties()
        {
            return _properties;
        }
        
        public Firm.WorkingConditions? GetWorkingConditions()
        {
            return _workingConditions;
        }
    }
}