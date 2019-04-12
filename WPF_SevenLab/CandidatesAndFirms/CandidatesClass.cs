using System;

namespace FirstVersionProject_firstLab.CandidatesAndFirms
{
    public class CandidatesClass
    {
        public Candidate[] Candidates =
        {
            new Candidate("Егор","Борисов",
                Candidate.PropertyList.Wealthy | 
                Candidate.PropertyList.Smart | 
                Candidate.PropertyList.Greedy),
            new Candidate("Данил","Уфасов",
                Candidate.PropertyList.Wealthy | 
                Candidate.PropertyList.Kind | 
                Candidate.PropertyList.Lazy),
            new Candidate("Федор","Умков",
                Candidate.PropertyList.Kind | 
                Candidate.PropertyList.Wealthy | 
                Candidate.PropertyList.Wicked)
        };

        public void AddCandidete(Candidate candidate)
        {
            Array.Resize(ref Candidates, Candidates.Length+1);
            Candidates[Candidates.Length-1] = candidate;
        }
    }
}