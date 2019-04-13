using System;
using System.Collections.Generic;

namespace MainSolution.CandidatesAndFirms
{
    public class CandidatesClass
    {
        private Candidate[] _candidates =
        {
            new Candidate("Егор", "Борисов",
                Candidate.Properties.Wealthy |
                Candidate.Properties.Smart |
                Candidate.Properties.Greedy),
            new Candidate("Данил", "Уфасов",
                Candidate.Properties.Wealthy |
                Candidate.Properties.Kind |
                Candidate.Properties.Lazy),
            new Candidate("Федор", "Умков",
                Candidate.Properties.Kind |
                Candidate.Properties.Wealthy |
                Candidate.Properties.Wicked),
            new Candidate("Бог","Богов", Candidate.Properties.Smart |
                                                                    Candidate.Properties.Lazy,
                                                                    Firm.WorkingConditions.BigSalary), 
            new Candidate("Бог","Богов", Candidate.Properties.Smart |
                                                                    Candidate.Properties.Kind)
        };
        
        public Candidate[] GetCandidates()
        {
            return _candidates;
        }

        public List<Candidate> SearchByCriterion(Candidate.Properties? propertiesD, 
                                                    Candidate.Properties? propertiesUd,
                                                    Firm.WorkingConditions? workingConditions)
        {
            var candidates = new List<Candidate>();

            foreach (var candidate in _candidates)
            {
                var tmpD = propertiesD & candidate.GetProperties();
                var tmpWc = workingConditions & candidate.GetWorkingConditions();
                if (tmpD == propertiesD && tmpWc == candidate.GetWorkingConditions() &&
                    (~candidate.GetProperties() & propertiesUd) == propertiesUd)
                {
                    candidates.Add(candidate);
                }
            }

            return candidates;
        }
    }
}