using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using MainSolution.CandidatesAndFirms;
using MainSolution.Logic;
using MainSolution.Window;

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

        private void ForCompany_OnClick(object sender, RoutedEventArgs e)
        {
            Hide();
            var forCompanyWindow = new ForCompanyWindow();
            forCompanyWindow.Show();
        }

        private void ForEmployee_OnClick(object sender, RoutedEventArgs e)
        {
            Hide();
            var forEmployeeWindow = new ForEmployeeWindow();
            forEmployeeWindow.Show();
        }

        private void MainWindow_OnClosing(object sender, CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void CreateEmployee_OnClick(object sender, RoutedEventArgs e)
        {
            Hide();
            var newEmployeeWindow = new NewEmployeeWindow();
            newEmployeeWindow.Show();
        }

        private void CreateCompany_OnClick(object sender, RoutedEventArgs e)
        {
            Hide();
            var newCompanyWindow = new NewCompanyWindow();
            newCompanyWindow.Show();
        }
    }
}