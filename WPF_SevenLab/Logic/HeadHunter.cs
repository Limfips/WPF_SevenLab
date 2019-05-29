using System;
using System.Collections.Generic;
using System.Text;

namespace MainSolution.Logic
{
    public class HeadHunter
    {
        private List<Candidate> _candidates;
        private List<Company> _companies;

        public HeadHunter() : this(new List<Candidate>(), new List<Company>())
        {
            
        }

        public HeadHunter(List<Candidate> candidates, List<Company> companies)
        {
            _candidates = candidates;
            _companies = companies;
        }

        public void AddCandidate(Candidate candidate)
        {
            _candidates.Add(candidate);
        }

        public void RemoveCandidate(Candidate candidate)
        {
            _candidates.Remove(candidate);
        }

        public void AddCompany(Company company)
        {
            _companies.Add(company);
        }

        public void RemoveCompany(Company company)
        {
            
            _companies.Remove(company);
        }
        
        public void RemoveCompanyByName(string name)
        {
            
//            _companies.Find(company => company.Name == name);
            for (int i = 0; i < _companies.Count; i++)
            {
                if (_companies[i].Name.Equals(name))
                {
                    _companies.RemoveAt(i);
                }
            }
        }

        public List<Candidate> Candidates
        {
            get { return _candidates; }
            set { _candidates = value; }
        }

        public List<Company> Companies
        {
            get { return _companies; }
            set {     _companies = value; }
        }

        public Candidate GetCandidates(string name)
        {
            return _candidates.Find(candidate => candidate.Name == name);
        }
        
        public Company GetCompany(string name)
        {
            return _companies.Find(company => company.Name == name);
        }

        /// <summary>
        /// Получить список подходящих кандитатов
        /// </summary>
        /// <param name="company">компания проводящая поиск</param>
        /// <returns>список подходящих кандитатов</returns>
        public List<Candidate> GetAvailableCandidates(Company company)
        {
            var suitableСandidates = new List<Candidate>();
            var possibleСandidates = new List<Candidate>();
            var unsuitableСandidates = new List<Candidate>();

            foreach (var candidate in _candidates)
            {
                var tempD = candidate.CandidateProperties & company.DesiredCandidateProperties;
                var tempU = candidate.CandidateProperties & company.UndesiredCandidateProperties;

                if (tempD == company.DesiredCandidateProperties &&
                    (~candidate.CandidateProperties &
                     company.UndesiredCandidateProperties) == company.UndesiredCandidateProperties)
                    //Если есть все нужные качества для фирмы и нет нежелательных
                {
                    suitableСandidates.Add(candidate);
                }
                else if (tempU < company.UndesiredCandidateProperties && tempD > 0)
                    //Наличие некоторых нужных и не все отрицательные
                {
                    possibleСandidates.Add(candidate);
                }
                else
                    //Ну тут вообще ужасно)))
                {
                    unsuitableСandidates.Add(candidate);
                }
            }

            var ratingCandidates = new List<Candidate>();
            ratingCandidates.AddRange(suitableСandidates);
            ratingCandidates.AddRange(possibleСandidates);
            ratingCandidates.AddRange(unsuitableСandidates);
            return ratingCandidates;
        }

        /// <summary>
        /// Получить список подходящих компаний
        /// </summary>
        /// <param name="candidate">кандидат проводящая поиск</param>
        /// <returns>список подходящих компаний</returns>
        public List<Company> GetAvailableCompany(Candidate candidate)
        {
            var suitableCompanies = new List<Company>();
            var possibleCompanies = new List<Company>();
            var unsuitableCompanies = new List<Company>();
            foreach (var company in _companies)
            {
                var tempD = company.CompanyProperties & candidate.DesiredCompanyProperties;
                var tempU = company.CompanyProperties & candidate.UndesiredCompanyProperties;


                if (tempD == candidate.DesiredCompanyProperties &&
                    (~company.CompanyProperties &
                     candidate.UndesiredCompanyProperties) == candidate.UndesiredCompanyProperties)
                    //Если есть все нужные качества для кандидата и нет нежелательных
                {
                    suitableCompanies.Add(company);
                }
                else if (tempU < candidate.UndesiredCompanyProperties && tempD > 0)
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

            var ratingCompany = new List<Company>();
            ratingCompany.AddRange(suitableCompanies);
            ratingCompany.AddRange(possibleCompanies);
            ratingCompany.AddRange(unsuitableCompanies);    
            
            return ratingCompany;
        }
    }
}