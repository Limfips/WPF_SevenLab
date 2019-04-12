using System;

namespace FirstVersionProject_firstLab.CandidatesAndFirms
{
    public class Candidate
    {
        //properties
        public string FName { get; }
        private string _sName;
        public PropertyList? Properties { get; }

        public Candidate(string fName, string sName, 
            PropertyList? properties)
        {
            FName = fName;
            _sName = sName;
            Properties = properties;
        }
        [Flags]
        public enum PropertyList
        {
            Smart = 1,
            Kind = 2,
            Wealthy = 4,
            Lazy = 8,
            Greedy = 16,
            Wicked = 32
        }
    }
}