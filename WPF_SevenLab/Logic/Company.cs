using System;
using System.Text;

namespace MainSolution.Logic
{
    [Serializable]
    public class Company
    {
        private readonly string _name;
        private readonly PropertiesList? _companyProperties;
        private readonly Candidate.PropertiesList? _desiredCandidateProperties;
        private readonly Candidate.PropertiesList? _undesiredCandidateProperties;
        
        [Flags]
        public enum PropertiesList
        {
            ConvenientSchedule = 1, //Удобный график
            BigSalary = 2, //Большая зарплата
            ComfortableOffice = 4, //Комфортный офис

            TerribleWorkingConditions = 8, //Ужасные условия труда
            NegativeTeam = 16, //Напряжённая обстановка в офисе
            BadEquipment = 32 //Плохое оборудование
        }

        public Company(string name,PropertiesList? companyProperties, 
            Candidate.PropertiesList? desiredCandidateProperties, 
            Candidate.PropertiesList? undesiredCandidateProperties)
        {
            _name = name;
            _companyProperties = companyProperties;
            _desiredCandidateProperties = desiredCandidateProperties;
            _undesiredCandidateProperties = undesiredCandidateProperties;
        }

        public string Name
        {
            get { return _name; }
        }

        public PropertiesList? CompanyProperties
        {
            get { return _companyProperties; }
        }

        public Candidate.PropertiesList? DesiredCandidateProperties
        {
            get { return _desiredCandidateProperties; }
        }

        public Candidate.PropertiesList? UndesiredCandidateProperties
        {
            get { return _undesiredCandidateProperties; }
        }

        public override string ToString()
        {
            StringBuilder text = new StringBuilder()
                .Append("Название: " + '\n' + Name + '\n')
                .Append("Условия работы в фирме: " + '\n' + CompanyProperties + '\n')
                .Append(("Желательные свойства кандидата: " + '\n' + DesiredCandidateProperties + '\n'))
                .Append("Нежелательные свойства кандидата: " + '\n' + UndesiredCandidateProperties + '\n');
            return text.ToString();
        }
    }
}