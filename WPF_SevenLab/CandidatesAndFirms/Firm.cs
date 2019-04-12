using System;

namespace FirstVersionProject_firstLab.CandidatesAndFirms
{
    public class Firm
    {
        public string CompanyName { get; }
        private Candidate[] _candidates;
        public Candidate.PropertyList DesiredPropertyList { get; }
        public Candidate.PropertyList UndesirablePropertyList { get; }
        public ConditionsList? Conditions { get; }

        public Firm(string companyName, Candidate.PropertyList desiredPropertyList, 
                    ConditionsList? conditions, Candidate.PropertyList undesirablePropertyList, 
                    Candidate[] candidates = null)
        {
            CompanyName = companyName;
            _candidates = candidates;
            DesiredPropertyList = desiredPropertyList;
            Conditions = conditions;
            UndesirablePropertyList = undesirablePropertyList;
        }
        [Flags]
        public enum ConditionsList
        {
            ConvenientSchedule = 1,
            BigSalary = 2,
            CloseToHome = 4,
            ComfortableOffice = 8
        }
    }
}