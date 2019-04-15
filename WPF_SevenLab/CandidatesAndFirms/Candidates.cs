using System;
using System.Collections.Generic;

namespace MainSolution.CandidatesAndFirms
{
    public class Candidates
    {
        private readonly Candidate[] _candidates =
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

        public List<Candidate> SearchByCriterion(Candidate.Properties? desiredProperties, 
                                                    Candidate.Properties? undesirableProperties,
                                                    Firm.WorkingConditions? propertiesFirm)
        {
            var candidates = new List<Candidate>();

            foreach (var candidate in _candidates)
            {
                if ((desiredProperties & candidate.GetPropertiesCandidate()) == desiredProperties &&
                    (propertiesFirm & candidate.GetPropertiesFirm()) == candidate.GetPropertiesFirm() &&
                    (~candidate.GetPropertiesCandidate() & undesirableProperties) == undesirableProperties)
                {
                    candidates.Add(candidate);
                }
            }

            return candidates;
        }
    }
}