using System.Collections.Generic;

namespace MainSolution.CandidatesAndFirms
{
    public class Firms
    {
        private readonly Firm[] _firms =
        {
            new Firm("ЕфимоваДолина", Candidate.Properties.Wealthy
                                      | Candidate.Properties.Smart, Firm.WorkingConditions.ComfortableOffice |
                                                                    Firm.WorkingConditions.ConvenientSchedule,
                Candidate.Properties.Lazy |
                Candidate.Properties.Wicked),
            new Firm("Фабрика Аляшка", Candidate.Properties.Smart
                                       | Candidate.Properties.Kind, Firm.WorkingConditions.BigSalary,
                Candidate.Properties.Wicked),
            new Firm("Завод Курым", Candidate.Properties.Wealthy,
                Firm.WorkingConditions.CloseToHome |
                Firm.WorkingConditions.BigSalary,
                Candidate.Properties.Greedy),
            new Firm("Аэропорт Пулков", Candidate.Properties.Kind
                                        | Candidate.Properties.Wealthy,
                Firm.WorkingConditions.ComfortableOffice |
                Firm.WorkingConditions.CloseToHome,
                Candidate.Properties.Lazy),
            new Firm("Школа №2", Candidate.Properties.Wealthy,
                Firm.WorkingConditions.BigSalary,
                Candidate.Properties.Wicked |
                Candidate.Properties.Greedy),
            new Firm("Шаурмечка", Candidate.Properties.Smart,
                Firm.WorkingConditions.CloseToHome,
                Candidate.Properties.Greedy |
                Candidate.Properties.Lazy)
        };

        public Firm[] GetFirms()
        {
            return _firms;
        }

        public List<Firm> SearchByCriterion(Candidate.Properties? properties)
        {
            var firms = new List<Firm>();

            foreach (var firm in _firms)
            {
                var tmpD = firm.GetDesiredProperties() & properties;

                if ((~properties & firm.GetUndesirableProperties()) == firm.GetUndesirableProperties()
                    && tmpD == firm.GetDesiredProperties())
                    firms.Add(firm);
            }

            return firms;
        }
    }
}