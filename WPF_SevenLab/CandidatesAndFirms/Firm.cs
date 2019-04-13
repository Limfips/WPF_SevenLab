using System;

namespace MainSolution.CandidatesAndFirms
{
    public class Firm
    {
        [Flags]
        public enum WorkingConditions
        {
            ConvenientSchedule = 1,
            BigSalary = 2,
            CloseToHome = 4,
            ComfortableOffice = 8
        }

        private readonly string _companyName;
        private readonly Candidate.Properties _desiredProperties;
        private readonly Candidate.Properties _undesirableProperties;
        private readonly WorkingConditions? _workingConditions;

        public Firm(string companyName, Candidate.Properties desiredProperties,
            WorkingConditions? workingConditions, Candidate.Properties undesirableProperties)
        {
            _companyName = companyName;
            _desiredProperties = desiredProperties;
            _workingConditions = workingConditions;
            _undesirableProperties = undesirableProperties;
        }

        public string GetCompanyName()
        {
            return _companyName;
        }

        public Candidate.Properties GetDesiredProperties()
        {
            return _desiredProperties;
        }

        public Candidate.Properties GetUndesirableProperties()
        {
            return _undesirableProperties;
        }

        public WorkingConditions? GetWorkingConditions()
        {
            return _workingConditions;
        }
    }
}