using MainSolution.CandidatesAndFirms;

namespace MainSolution.Logic
{
    public interface IInquiryFirm
    {
        Firm.WorkingConditions FAlgorithm();
    }
    public class AddConvenientSchedule : IInquiryFirm
    {
        public Firm.WorkingConditions FAlgorithm()
        {
            return Firm.WorkingConditions.ConvenientSchedule;
        }
    }
    public class AddBigSalary : IInquiryFirm
    {
        public Firm.WorkingConditions FAlgorithm()
        {
            return Firm.WorkingConditions.BigSalary;
        }
    }
    public class AddCloseToHome : IInquiryFirm
    {
        public Firm.WorkingConditions FAlgorithm()
        {
            return Firm.WorkingConditions.CloseToHome;
        }
    }
    public class AddComfortableOffice : IInquiryFirm
    {
        public Firm.WorkingConditions FAlgorithm()
        {
            return Firm.WorkingConditions.ComfortableOffice;
        }
    }
    public class FRequest
    {
        private IInquiryFirm _inquiryFirm;

        public FRequest(IInquiryFirm inquiryFirm)
        {
            _inquiryFirm = inquiryFirm;
        }

        public void SetInquiry(IInquiryFirm inquiryFirm)
        {
            _inquiryFirm = inquiryFirm;
        }

        public Firm.WorkingConditions? ExecuteOperation(Firm.WorkingConditions? conditions, bool? isCheckBox)
        {
            if (isCheckBox != true) return conditions;
            if (conditions != null) return conditions | _inquiryFirm.FAlgorithm();
            return _inquiryFirm.FAlgorithm();
        }
    }
}