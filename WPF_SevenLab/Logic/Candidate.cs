using System;
using System.Text;

namespace MainSolution.Logic
{
    [Serializable]
    public class Candidate
    {
        private readonly string _name;
        private readonly PropertiesList? _candidateProperties;
        private readonly Company.PropertiesList? _desiredCompanyProperties;
        private readonly Company.PropertiesList? _undesiredCompanyProperties;
        
        [Flags]
        public enum PropertiesList
        {
            Smart = 1, //Умный
            Kind = 2, //Добрый
            Wealthy = 4, //Cостоятельный

            Lazy = 8, //Kенивый
            Greedy = 16, //Жадный
            Wicked = 32 //Безнравственный
        }

        public Candidate(string name, PropertiesList? candidateProperties,
            Company.PropertiesList? desiredCompanyProperties, Company.PropertiesList? undesiredCompanyProperties)
        {
            _name = name;
            _candidateProperties = candidateProperties;
            _desiredCompanyProperties = desiredCompanyProperties;
            _undesiredCompanyProperties = undesiredCompanyProperties;
        }

        public string Name
        {
            get { return _name; }
        }

        public PropertiesList? CandidateProperties
        {
            get { return _candidateProperties; }
        }

        public Company.PropertiesList? DesiredCompanyProperties
        {
            get { return _desiredCompanyProperties; }
        }

        public Company.PropertiesList? UndesiredCompanyProperties
        {
            get { return _undesiredCompanyProperties; }
        }

        public override string ToString()
        {
            StringBuilder text = new StringBuilder()
                .Append("Имя: " + '\n' + Name + '\n')
                .Append("Свойства кандидата: " + '\n' + CandidateProperties + '\n')
                .Append("Желательные свойства фирмы: " + '\n' + DesiredCompanyProperties + '\n')
                .Append("Нежелательные свойства фирмы: " + '\n' + UndesiredCompanyProperties + '\n');
            return text.ToString();
        }
    }
}