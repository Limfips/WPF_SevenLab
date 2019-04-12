namespace FirstVersionProject_firstLab.CandidatesAndFirms
{
    public class Firms
    {
        public  Firm[] _firms =
        {
            new Firm("ЕфимоваДолина",Candidate.PropertyList.Wealthy 
                                     | Candidate.PropertyList.Smart,Firm.ConditionsList.ComfortableOffice |
                                                                        Firm.ConditionsList.ConvenientSchedule,
                                                                    Candidate.PropertyList.Lazy |
                                                                    Candidate.PropertyList.Wicked),
            new Firm("Фабрика Аляшка",Candidate.PropertyList.Smart
                                     | Candidate.PropertyList.Kind,    Firm.ConditionsList.BigSalary,
                                        Candidate.PropertyList.Wicked),
            new Firm("Завод Курым",Candidate.PropertyList.Wealthy,
                                                            Firm.ConditionsList.CloseToHome |
                                                                    Firm.ConditionsList.BigSalary,
                                                            Candidate.PropertyList.Greedy),
            new Firm("Аэропорт Пулков",Candidate.PropertyList.Kind 
                                     | Candidate.PropertyList.Wealthy,
                                                            Firm.ConditionsList.ComfortableOffice |
                                                                      Firm.ConditionsList.CloseToHome,
                                                            Candidate.PropertyList.Lazy),
            new Firm("Школа №2",Candidate.PropertyList.Wealthy,
                                                                        Firm.ConditionsList.BigSalary,
                                                                        Candidate.PropertyList.Wicked |
                                                                        Candidate.PropertyList.Greedy),
            new Firm("Шаурмечка",Candidate.PropertyList.Smart,
                                                                        Firm.ConditionsList.CloseToHome,
                                                                        Candidate.PropertyList.Greedy |
                                                                        Candidate.PropertyList.Lazy)
        };
    }
}