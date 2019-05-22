using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using MainSolution.Logic;

namespace MainSolution.CandidatesAndFirms
{
    public class Candidates
    {
        private  readonly List<Employee> _candidates = new List<Employee>
        {
            new Employee
            (
                "Данил",
                "Уфасов",
                Employee.Properties.Wealthy |
                Employee.Properties.Kind |
                Employee.Properties.Lazy
            ),
            new Employee
            (
                "Федор",
                "Умков",
                Employee.Properties.Kind |
                Employee.Properties.Wealthy |
                Employee.Properties.Wicked
            ),
            new Employee
            (
                "Бог",
                "Богов",
                Employee.Properties.Smart |
                Employee.Properties.Lazy,
                Firm.FirmConditions.BigSalary
            ),
            new Employee
            (
                "Бог",
                "Богов",
                Employee.Properties.Smart |
                Employee.Properties.Kind
            )
        };
        public Candidates(){}

        public Candidates(List<Employee> candidates)
        {
            _candidates = candidates;
        }

        public List<Employee> GetCandidates()
        {
            return _candidates;
        }
        
        public List<Employee> GetRatingCandidates(Firm firm)
        {
            var suitableСandidates = new List<Employee>();
            var possibleСandidates = new List<Employee>();
            var unsuitableСandidates = new List<Employee>();
            foreach (var candidate in _candidates)
            {
                var tempD = candidate.GetPropertiesCandidate() & firm.GetDesiredEmployeeProperties();
                var tempU = candidate.GetPropertiesCandidate() & firm.GetUndesirableEmployeeProperties();

                
                if (tempD == firm.GetDesiredEmployeeProperties() && 
                    (~candidate.GetPropertiesCandidate() & 
                     firm.GetUndesirableEmployeeProperties()) == firm.GetUndesirableEmployeeProperties())
                    //Если есть все нужные качества для фирмы и нет нежелательных
                {
                    suitableСandidates.Add(candidate);
                }else if (tempU < firm.GetUndesirableEmployeeProperties() && tempD > 0)
                    //Наличие некоторых нужных и не все отрицательные
                {
                    possibleСandidates.Add(candidate);
                }
                else
                    //Ну тут вообще ужасно)))
                {
                    unsuitableСandidates.Add(candidate);
                }
            }
            
            var ratingCandidates = new List<Employee>();
            ratingCandidates.AddRange(suitableСandidates);
            ratingCandidates.AddRange(possibleСandidates);
            ratingCandidates.AddRange(unsuitableСandidates);
            return ratingCandidates;
        }
    }
}