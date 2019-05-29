using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;

namespace MainSolution.Logic
{
    public class HunterManager
    {
        private const string FilePathDataBaseCandidates = "Candidates.dat";
        private const string FilePathDataBaseCompanies = "Companies.dat";

        private readonly BinaryFormatter _formatter;


        public HunterManager()
        {
            _formatter = new BinaryFormatter();
        }

        /// <summary>
        /// Загрузить список кандидатов
        /// </summary>
        /// <returns>список кандидатов</returns>
        public List<Candidate> LoadDataBaseCandidates()
        {
            try
            {
                FileStream fs = new FileStream(FilePathDataBaseCandidates,
                    FileMode.OpenOrCreate);
                List<Candidate> candidates = (List<Candidate>) _formatter.Deserialize(fs);
                fs.Close();
                return candidates;
            }
            catch (SerializationException exception)
            {
                //MessageBox.Show(exception.Message);
                return new List<Candidate>();
            }
            catch (IOException exception)
            {
                //MessageBox.Show(exception.Message);
                return new List<Candidate>();
            }
        }
        
        /// <summary>
        /// Сохранить список кандидатов
        /// </summary>
        public void SaveDataBaseCandidates(List<Candidate> candidates)
        {
            try
            {
                FileStream fs = new FileStream(FilePathDataBaseCandidates,
                    FileMode.OpenOrCreate);
                _formatter.Serialize(fs, candidates);
                fs.Close();
            }
            catch (SerializationException exception)
            {
                //MessageBox.Show(exception.Message);
            }
            catch (IOException exception)
            {
                //MessageBox.Show(exception.Message);
            }
        }
        
        /// <summary>
        /// Удалить список кандидатов
        /// </summary>
        public void DeleteDataBaseCandidates()
        {
            try
            {
                File.Delete(FilePathDataBaseCandidates);
            }
            catch (IOException exception)
            {
                //MessageBox.Show(exception.Message);
            }
        }
        
        /// <summary>
        /// Загрузить список компаний
        /// </summary>
        /// <returns>список компаний</returns>
        public List<Company> LoadDataBaseCompanies() 
        {
            try
            {
                FileStream fs = new FileStream(FilePathDataBaseCompanies,
                    FileMode.OpenOrCreate);
                List<Company> companies = (List<Company>)_formatter.Deserialize(fs);
                fs.Close();
                return companies;
            }
            catch (SerializationException exception)
            {
                //MessageBox.Show(exception.Message);
                return new List<Company>();
            } 
            catch (IOException exception)
            {
                //MessageBox.Show(exception.Message);
                return new List<Company>();
            } 
        }
        
        /// <summary>
        /// Сохранить список компаний
        /// </summary>
        public void SaveDataBaseCompanies(List<Company> companies)
        {
            try
            {
                FileStream fs = new FileStream(FilePathDataBaseCompanies,
                    FileMode.OpenOrCreate);
                _formatter.Serialize(fs, companies);
                fs.Close();
            }
            catch (SerializationException exception)
            {
                //MessageBox.Show(exception.Message);
            }
            catch (IOException exception)
            {
                //MessageBox.Show(exception.Message);
            }    
        }
        
        /// <summary>
        /// Удалить список кандидатов
        /// </summary>
        public void DelateDataBaseCompanies()
        {
            try
            {
                File.Delete(FilePathDataBaseCompanies);
            }
            catch (IOException exception)
            {
                //MessageBox.Show(exception.Message);
            }
        }
    }
}