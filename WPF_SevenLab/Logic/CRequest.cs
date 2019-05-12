using MainSolution.CandidatesAndFirms;

namespace MainSolution.Logic
{
    public interface IInquiryCandidate
    {
        Employee.Properties CAlgorithm();
    }

    public class AddSmart : IInquiryCandidate
    {
        public Employee.Properties CAlgorithm()
        {
            return Employee.Properties.Smart;
        }
    }

    public class AddKind : IInquiryCandidate
    {
        public Employee.Properties CAlgorithm()
        {
            return Employee.Properties.Kind;
        }
    }

    public class AddWealthy : IInquiryCandidate
    {
        public Employee.Properties CAlgorithm()
        {
            return Employee.Properties.Wealthy;
        }
    }

    public class AddLazy : IInquiryCandidate
    {
        public Employee.Properties CAlgorithm()
        {
            return Employee.Properties.Lazy;
        }
    }

    public class AddGreedy : IInquiryCandidate
    {
        public Employee.Properties CAlgorithm()
        {
            return Employee.Properties.Greedy;
        }
    }

    public class AddWicked : IInquiryCandidate
    {
        public Employee.Properties CAlgorithm()
        {
            return Employee.Properties.Wicked;
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

        public Employee.Properties? ExecuteOperation(Employee.Properties? properties, bool? isCheckBox)
        {
            if (isCheckBox != true) return properties;
            if (properties != null) return properties | _inquiryCandidate.CAlgorithm();
            return _inquiryCandidate.CAlgorithm();
        }
    }
}