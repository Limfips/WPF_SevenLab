using System;

namespace MainSolution.CandidatesAndFirms
{
    public class Candidate
    {
        //properties
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

        
        private readonly string _fName;
        private readonly string _sName;
        private readonly Properties? _propertiesCandidate;
        private readonly Firm.WorkingConditions? _propertiesFirm;

        public Candidate(string fName, string sName,
            Properties? propertiesCandidate, Firm.WorkingConditions? propertiesFirm = null)
        {
            _fName = fName;
            _sName = sName;
            _propertiesCandidate = propertiesCandidate;
            _propertiesFirm = propertiesFirm;
        }

        public string GetName()
        {
            return _sName + " " + _fName;
        }

        public Properties? GetPropertiesCandidate()
        {
            return _propertiesCandidate;
        }
        
        public Firm.WorkingConditions? GetPropertiesFirm()
        {
            return _propertiesFirm;
        }
    }
}