using System.ComponentModel;
using System.Windows;
using MainSolution.CandidatesAndFirms;
using MainSolution.Logic;

namespace MainSolution.Window
{
    public partial class ForEmployeeWindow : System.Windows.Window
    {
        public ForEmployeeWindow()
        {
            InitializeComponent();
        }

//        private void SearchFirms_OnClick(object sender, RoutedEventArgs e)
//        {
//            FirmsListBox.Items.Clear();
//            Employee.Properties? properties = null;
//            var request = new CRequest(new AddSmart());
//            properties = request.ExecuteOperation(properties, SmartCheckBox.IsChecked);
//            request.SetInquiry(new AddKind());
//            properties = request.ExecuteOperation(properties, KindCheckBox.IsChecked);
//            request.SetInquiry(new AddWealthy());
//            properties = request.ExecuteOperation(properties, WealthyCheckBox.IsChecked);
//            request.SetInquiry(new AddLazy());
//            properties = request.ExecuteOperation(properties, LazyCheckBox.IsChecked);
//            request.SetInquiry(new AddGreedy());
//            properties = request.ExecuteOperation(properties, GreedyCheckBox.IsChecked);
//            request.SetInquiry(new AddWicked());
//            properties = request.ExecuteOperation(properties, WickedCheckBox.IsChecked);
//            var candidate = new Employee(FNameTextBox.Text, SNameTextBox.Text, properties);
//            var firms = new Companies().Search(candidate.GetPropertiesCandidate());
//
//            foreach (var firm in firms) FirmsListBox.Items.Add(firm.GetCompanyName());
//        }

        private void BackMenu_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ForEmployeeWindow_OnClosing(object sender, CancelEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}