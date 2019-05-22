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
                Firm.FirmConditions.ComfortableOffice |
                Firm.FirmConditions.ConvenientSchedule,
                Employee.Properties.Lazy |
                Employee.Properties.Wicked
            ),
            new Firm
            (
                "Фабрика Аляшка",
                Employee.Properties.Smart |
                Employee.Properties.Kind,
                Firm.FirmConditions.BigSalary,
                Employee.Properties.Wicked
            ),
            new Firm
            (
                "Завод Курым",
                Employee.Properties.Wealthy,
                Firm.FirmConditions.BigSalary,
                Employee.Properties.Greedy
            ),
            new Firm
            (
                "Аэропорт Пулков",
                Employee.Properties.Kind |
                Employee.Properties.Wealthy,
                Firm.FirmConditions.ComfortableOffice,
                Employee.Properties.Lazy
            ),
            new Firm
            (
                "Школа №2",
                Employee.Properties.Wealthy,
                Firm.FirmConditions.BigSalary,
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
        public List<Firm> GetRatingFirms(Employee employee)
        {
            var suitableCompanies = new List<Firm>();
            var possibleCompanies= new List<Firm>();
            var unsuitableCompanies = new List<Firm>();
            foreach (var company in _companies)
            {
                var tempD = company.GetPropertiesFirm() & employee.GetDesiredFirmConditions();
                var tempU = company.GetPropertiesFirm() & employee.GetUndesirableFirmConditions();

                
                if (tempD == employee.GetDesiredFirmConditions() && 
                    (~company.GetPropertiesFirm() & 
                     employee.GetUndesirableFirmConditions()) == employee.GetUndesirableFirmConditions())
                    //Если есть все нужные качества для кандидата и нет нежелательных
                {
                    suitableCompanies.Add(company);
                }else if (tempU < employee.GetUndesirableFirmConditions() && tempD > 0)
                    //Наличие некоторых нужных и не все отрицательные
                {
                    possibleCompanies.Add(company);
                }
                else
                    //Ну тут вообще ужасно)))
                {
                    unsuitableCompanies.Add(company);
                }
            }
            
            var ratingCandidates = new List<Firm>();
            ratingCandidates.AddRange(suitableCompanies);
            ratingCandidates.AddRange(possibleCompanies);
            ratingCandidates.AddRange(unsuitableCompanies);
            return ratingCandidates;
        }

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