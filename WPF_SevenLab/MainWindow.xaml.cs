using System.Windows;
using MainSolution.CandidatesAndFirms;
using MainSolution.Logic;

namespace MainSolution
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DisplaySearchFirmsGrid_OnClick(object sender, RoutedEventArgs e)
        {
            SearchFirmsGrid.Visibility = Visibility.Visible;
            MainGrid.Visibility = Visibility.Collapsed;
        }

        private void DisplaySearchWorkersGrid_OnClick(object sender, RoutedEventArgs e)
        {
            SearchWorkersGrid.Visibility = Visibility.Visible;
            MainGrid.Visibility = Visibility.Collapsed;
        }

        private void BackMenu_OnClick(object sender, RoutedEventArgs e)
        {
            if (SearchFirmsGrid.IsVisible) SearchFirmsGrid.Visibility = Visibility.Collapsed;
            if (SearchWorkersGrid.IsVisible) SearchWorkersGrid.Visibility = Visibility.Collapsed;
            MainGrid.Visibility = Visibility.Visible;
        }

        // Обработка стандартных кнопок закончена. Далее идет работа в анкетах

        private void SearchFirms_OnClick(object sender, RoutedEventArgs e)
        {
            FirmsListBox.Items.Clear();
            Candidate.Properties? properties = null;
            var request = new CRequest(new AddSmart());
            properties = request.ExecuteOperation(properties, SmartCheckBox.IsChecked);
            request.SetInquiry(new AddKind());
            properties = request.ExecuteOperation(properties, KindCheckBox.IsChecked);
            request.SetInquiry(new AddWealthy());
            properties = request.ExecuteOperation(properties, WealthyCheckBox.IsChecked);
            request.SetInquiry(new AddLazy());
            properties = request.ExecuteOperation(properties, LazyCheckBox.IsChecked);
            request.SetInquiry(new AddGreedy());
            properties = request.ExecuteOperation(properties, GreedyCheckBox.IsChecked);
            request.SetInquiry(new AddWicked());
            properties = request.ExecuteOperation(properties, WickedCheckBox.IsChecked);
            var candidate = new Candidate(FNameTextBox.Text, SNameTextBox.Text, properties);
            var firms = new Firms().SearchByCriterion(candidate.GetProperties());

            foreach (var firm in firms) FirmsListBox.Items.Add(firm.GetCompanyName());
        }

        private void SearchCandidates_OnClick(object sender, RoutedEventArgs e)
        {
            CandidatesListBox.Items.Clear();
            Firm.WorkingConditions? workingConditions = null;
            
            var requestF = new FRequest(new AddConvenientSchedule());
            workingConditions = requestF.ExecuteOperation(workingConditions, 
                                                            ConvenientScheduleCheckBox.IsChecked);
            requestF.SetInquiry(new AddBigSalary());
            workingConditions = requestF.ExecuteOperation(workingConditions, 
                                                            BigSalaryCheckBox.IsChecked);
            requestF.SetInquiry(new AddCloseToHome());
            workingConditions = requestF.ExecuteOperation(workingConditions, 
                                                            CloseToHomeCheckBox.IsChecked);
            requestF.SetInquiry(new AddComfortableOffice());
            workingConditions = requestF.ExecuteOperation(workingConditions, 
                                                            ComfortableOfficeCheckBox.IsChecked);
            
            Candidate.Properties? propertiesD = null;
            Candidate.Properties? propertiesUd = null;
            var requestC = new CRequest(new AddSmart());
            propertiesD = requestC.ExecuteOperation(propertiesD, FSmartCheckBox.IsChecked);
            requestC.SetInquiry(new AddKind());
            propertiesD = requestC.ExecuteOperation(propertiesD, FKindCheckBox.IsChecked);
            requestC.SetInquiry(new AddWealthy());
            propertiesD = requestC.ExecuteOperation(propertiesD, FWealthyCheckBox.IsChecked);
            requestC.SetInquiry(new AddLazy());
            propertiesUd = requestC.ExecuteOperation(propertiesUd, FLazyCheckBox.IsChecked);
            requestC.SetInquiry(new AddGreedy());
            propertiesUd = requestC.ExecuteOperation(propertiesUd, FGreedyCheckBox.IsChecked);
            requestC.SetInquiry(new AddWicked());
            propertiesUd = requestC.ExecuteOperation(propertiesUd, FWickedCheckBox.IsChecked);
            
            var candidates = new CandidatesClass().SearchByCriterion(propertiesD,propertiesUd,workingConditions);  
            
            foreach (var candidate in candidates) CandidatesListBox.Items.Add(candidate.GetName());

        }
    }
}