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
                Firm.WorkingConditions.BigSalary
            ),
            new Employee
            (
                "Бог",
                "Богов",
                Employee.Properties.Smart |
                Employee.Properties.Kind
            )
        };
        

        public List<Employee> GetCandidates()
        {
            return _candidates;
        }

//        public List<Employee> Search
//        (
//            Employee.Properties? desiredProperties,
//            Employee.Properties? undesirableProperties,
//            Firm.WorkingConditions? propertiesFirm
//        )
//        {
//            var candidates = new List<Employee>();    
//
//            
//            //ToDo Поработать над логикой  поиска работников
//            foreach (var candidate in _candidates)
//                if ((desiredProperties & candidate.GetPropertiesCandidate()) == desiredProperties &&
//                    (propertiesFirm & candidate.GetPropertiesFirm()) == candidate.GetPropertiesFirm() &&
//                    (~candidate.GetPropertiesCandidate() & undesirableProperties) == undesirableProperties)
//                    candidates.Add(candidate);
//
//            return candidates;
//        }
    }
}