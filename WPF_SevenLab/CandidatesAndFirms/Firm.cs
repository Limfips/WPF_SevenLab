using System;

namespace MainSolution.CandidatesAndFirms
{
    public class Firm
    {
        [Flags]
        public enum WorkingConditions
        {
            ConvenientSchedule = 1, //Удобный график 00000001+00000010 = 00000011
            BigSalary = 2, //Большая зарплата      00000010
            ComfortableOffice = 4, //Комфортный офис 00000100

            TerribleWorkingConditions = 8, //Ужасные условия труда
            NegativeTeam = 16, //Напряжённая обстановка в офисе
            BadEquipment = 32 //Плохое оборудование
        }

        private readonly string _companyName;
        private readonly WorkingConditions? _propertiesFirm; //Свойства фирмы
        private readonly Employee.Properties? _desiredProperties; //желаемые свойства работника
        private readonly Employee.Properties? _undesirableProperties; //нежелательные свойства работника

        public Firm
        (
            string companyName,
            Employee.Properties? desiredProperties = null,
            WorkingConditions? propertiesFirm = null,
            Employee.Properties? undesirableProperties = null
        )
        {
            _companyName = companyName;
            _desiredProperties = desiredProperties;
            _propertiesFirm = propertiesFirm;
            _undesirableProperties = undesirableProperties;
        }

        public string GetCompanyName()
        {
            return _companyName;
        }

        public Employee.Properties? GetDesiredProperties()
        {
            return _desiredProperties;
        }

        public Employee.Properties? GetUndesirableProperties()
        {
            return _undesirableProperties;
        }

        public WorkingConditions? GetPropertiesFirm()
        {
            return _propertiesFirm;
        }
    }
}