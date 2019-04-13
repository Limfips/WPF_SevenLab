using MainSolution.CandidatesAndFirms;

namespace MainSolution.Logic
{
    public interface IInquiryCandidate
    {
        Candidate.Properties CAlgorithm();
    }

    public class AddSmart : IInquiryCandidate
    {
        public Candidate.Properties CAlgorithm()
        {
            return Candidate.Properties.Smart;
        }
    }

    public class AddKind : IInquiryCandidate
    {
        public Candidate.Properties CAlgorithm()
        {
            return Candidate.Properties.Kind;
        }
    }

    public class AddWealthy : IInquiryCandidate
    {
        public Candidate.Properties CAlgorithm()
        {
            return Candidate.Properties.Wealthy;
        }
    }

    public class AddLazy : IInquiryCandidate
    {
        public Candidate.Properties CAlgorithm()
        {
            return Candidate.Properties.Lazy;
        }
    }

    public class AddGreedy : IInquiryCandidate
    {
        public Candidate.Properties CAlgorithm()
        {
            return Candidate.Properties.Greedy;
        }
    }

    public class AddWicked : IInquiryCandidate
    {
        public Candidate.Properties CAlgorithm()
        {
            return Candidate.Properties.Wicked;
        }
    }

    public class CRequest
    {
        private IInquiryCandidate _inquiryCandidate;

        public CRequest(IInquiryCandidate inquiryCandidate)
        {
            _inquiryCandidate = inquiryCandidate;
        }

        public void SetInquiry(IInquiryCandidate inquiryCandidate)
        {
            _inquiryCandidate = inquiryCandidate;
        }

        public Candidate.Properties? ExecuteOperation(Candidate.Properties? properties, bool? isCheckBox)
        {
            if (isCheckBox != true) return properties;
            if (properties != null) return properties | _inquiryCandidate.CAlgorithm();
            return _inquiryCandidate.CAlgorithm();
        }
    }
}