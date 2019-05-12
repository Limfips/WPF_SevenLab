using System.ComponentModel;
using System.Windows;
using MainSolution.CandidatesAndFirms;
using MainSolution.Logic;

namespace MainSolution.Window
{
    public partial class ForCompanyWindow : System.Windows.Window
    {
        public ForCompanyWindow()
        {
            InitializeComponent();
        }

//        private void SearchCandidates_OnClick(object sender, RoutedEventArgs e)
//        {
//            CandidatesListBox.Items.Clear();
//            Firm.WorkingConditions? workingConditions = null;
//
//            var requestF = new FRequest(new AddConvenientSchedule());
//            workingConditions = requestF.ExecuteOperation(workingConditions,
//                ConvenientScheduleCheckBox.IsChecked);
//            requestF.SetInquiry(new AddBigSalary());
//            workingConditions = requestF.ExecuteOperation(workingConditions,
//                BigSalaryCheckBox.IsChecked);
//            requestF.SetInquiry(new AddCloseToHome());
//            workingConditions = requestF.ExecuteOperation(workingConditions,
//                CloseToHomeCheckBox.IsChecked);
//            requestF.SetInquiry(new AddComfortableOffice());
//            workingConditions = requestF.ExecuteOperation(workingConditions,
//                ComfortableOfficeCheckBox.IsChecked);
//
//            Employee.Properties? propertiesD = null;
//            Employee.Properties? propertiesUd = null;
//            var requestC = new CRequest(new AddSmart());
//            propertiesD = requestC.ExecuteOperation(propertiesD, FSmartCheckBox.IsChecked);
//            requestC.SetInquiry(new AddKind());
//            propertiesD = requestC.ExecuteOperation(propertiesD, FKindCheckBox.IsChecked);
//            requestC.SetInquiry(new AddWealthy());
//            propertiesD = requestC.ExecuteOperation(propertiesD, FWealthyCheckBox.IsChecked);
//            requestC.SetInquiry(new AddLazy());
//            propertiesUd = requestC.ExecuteOperation(propertiesUd, FLazyCheckBox.IsChecked);
//            requestC.SetInquiry(new AddGreedy());
//            propertiesUd = requestC.ExecuteOperation(propertiesUd, FGreedyCheckBox.IsChecked);
//            requestC.SetInquiry(new AddWicked());
//            propertiesUd = requestC.ExecuteOperation(propertiesUd, FWickedCheckBox.IsChecked);
//
//            var candidates = new Candidates().Search(propertiesD, propertiesUd, workingConditions);
//
//            foreach (var candidate in candidates) CandidatesListBox.Items.Add(candidate.GetName());
//        }

        private void BackMenu_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ForCompanyWindow_OnClosing(object sender, CancelEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}