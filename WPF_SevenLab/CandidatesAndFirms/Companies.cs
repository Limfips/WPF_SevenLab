using System.Collections.Generic;

namespace MainSolution.CandidatesAndFirms
{
    public class Companies
    {
        private readonly List<Firm> _companies = new List<Firm>
        {
            new Firm
            (
                "ЕфимоваДолина",
                Employee.Properties.Wealthy |
                Employee.Properties.Smart,
                Firm.WorkingConditions.ComfortableOffice |
                Firm.WorkingConditions.ConvenientSchedule,
                Employee.Properties.Lazy |
                Employee.Properties.Wicked
            ),
            new Firm
            (
                "Фабрика Аляшка",
                Employee.Properties.Smart |
                Employee.Properties.Kind,
                Firm.WorkingConditions.BigSalary,
                Employee.Properties.Wicked
            ),
            new Firm
            (
                "Завод Курым",
                Employee.Properties.Wealthy,
                Firm.WorkingConditions.BigSalary,
                Employee.Properties.Greedy
            ),
            new Firm
            (
                "Аэропорт Пулков",
                Employee.Properties.Kind |
                Employee.Properties.Wealthy,
                Firm.WorkingConditions.ComfortableOffice,
                Employee.Properties.Lazy
            ),
            new Firm
            (
                "Школа №2",
                Employee.Properties.Wealthy,
                Firm.WorkingConditions.BigSalary,
                Employee.Properties.Wicked |
                Employee.Properties.Greedy),
            new Firm("Шаурмечка",
                Employee.Properties.Smart,null,
                Employee.Properties.Greedy |
                Employee.Properties.Lazy
            )
        };


        public List<Firm> GetCompanies()
        {
            return _companies;
        }


        //ToDo Поработать над логикой  поиска фирм
//        public List<Firm> Search
//        (
//            Employee.Properties? propertiesCandidate
//        )
//        {
//            var firms = new List<Firm>();
//
//            foreach (var firm in _companies)
//                if ((~propertiesCandidate & firm.GetUndesirableProperties()) == firm.GetUndesirableProperties() &&
//                    (firm.GetDesiredProperties() & propertiesCandidate) == firm.GetDesiredProperties())
//                    firms.Add(firm);
//
//            return firms;
//        }

        public void AddFirm(Firm firm)
        {
            _companies.Add(firm);
        }

        public void RemoveFirm(Firm firm)
        {
            _companies.Remove(firm);
        }
    }
}