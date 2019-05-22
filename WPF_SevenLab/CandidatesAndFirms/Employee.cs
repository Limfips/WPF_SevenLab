using System;

namespace MainSolution.CandidatesAndFirms
{
    public class Employee
    {
        //properties
        [Flags]
        public enum Properties
        {
            Smart = 1, //Умный
            Kind = 2, //Добрый
            Wealthy = 4, //Cостоятельный

            Lazy = 8, //Kенивый
            Greedy = 16, //Жадный
            Wicked = 32 //Безнравственный
        }

        
        private readonly string _fName;
        private readonly string _sName;
        private readonly Properties? _propertiesCandidate; //Персональные качества
        private readonly Firm.FirmConditions? _desiredFirmConditions; //желаемые условия работы
        private readonly Firm.FirmConditions? _undesirableFirmConditions; //нежелательные условия работы

        public Employee
        (
            string fName,
            string sName,
            Properties? propertiesCandidate = null,
            Firm.FirmConditions? desiredFirmConditions = null,
            Firm.FirmConditions? undesirableFirmConditions = null
        )
        {
            _fName = fName;
            _sName = sName;
            _propertiesCandidate = propertiesCandidate;
            _desiredFirmConditions = desiredFirmConditions;
            _undesirableFirmConditions = undesirableFirmConditions;
        }

        public string GetName()
        {
            return _sName + " " + _fName;
        }

        public Properties? GetPropertiesCandidate()
        {
            return _propertiesCandidate;
        }

        public Firm.FirmConditions? GetDesiredFirmConditions()
        {
            return _desiredFirmConditions;
        }
        public Firm.FirmConditions? GetUndesirableFirmConditions()
        {
            return _undesirableFirmConditions;
        }
    }
}