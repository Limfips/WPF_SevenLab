using System;

namespace MainSolution.CandidatesAndFirms
{
    public class Firm
    {
        [Flags]
        public enum FirmConditions
        {
            ConvenientSchedule = 1, //Удобный график
            BigSalary = 2, //Большая зарплата
            ComfortableOffice = 4, //Комфортный офис

            TerribleWorkingConditions = 8, //Ужасные условия труда
            NegativeTeam = 16, //Напряжённая обстановка в офисе
            BadEquipment = 32 //Плохое оборудование
        }

        
        private readonly string _companyName;
        private readonly FirmConditions? _propertiesFirm; //Свойства фирмы
        private readonly Employee.Properties? _desiredEmployeeProperties; //желаемые свойства работника
        private readonly Employee.Properties? _undesirableEmployeeProperties; //нежелательные свойства работника

        public Firm
        (
            string companyName,
            Employee.Properties? desiredEmployeeProperties = null,
            FirmConditions? propertiesFirm = null,
            Employee.Properties? undesirableEmployeeProperties = null
        )
        {
            _companyName = companyName;
            _desiredEmployeeProperties = desiredEmployeeProperties;
            _propertiesFirm = propertiesFirm;
            _undesirableEmployeeProperties = undesirableEmployeeProperties;
        }

        public string GetCompanyName()
        {
            return _companyName;
        }

        public Employee.Properties? GetDesiredEmployeeProperties()
        {
            return _desiredEmployeeProperties;
        }

        public Employee.Properties? GetUndesirableEmployeeProperties()
        {
            return _undesirableEmployeeProperties;
        }

        public FirmConditions? GetPropertiesFirm()
        {
            return _propertiesFirm;
        }
    }
}