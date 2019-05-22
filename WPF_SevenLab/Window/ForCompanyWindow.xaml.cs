using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using MainSolution.CandidatesAndFirms;
using MainSolution.Logic;

namespace MainSolution.Window
{
    public partial class ForCompanyWindow : System.Windows.Window
    {
        private readonly Candidates _candidates = new Candidates(new WorkFile().GetCandidates());

        public ForCompanyWindow()
        {
            InitializeComponent();
            foreach (var employee in _candidates.GetCandidates())
            {
                EmployeeComboBox.Items.Add(employee.GetName());
            }
        }

        private void ForCompanyWindow_OnClosing(object sender, CancelEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void SearchWorkers_OnClick(object sender, RoutedEventArgs e)
        {
            RatingListBox.Items.Clear();
            if (EmployeeComboBox.SelectedIndex > -1)
            {
                Employee employee = _candidates.GetCandidates()[EmployeeComboBox.SelectedIndex];
                EmployeeInfoTextBlock.Text = $"Имя: \n{employee.GetName()} \n" +
                            $"Качества: \n{employee.GetPropertiesCandidate()} \n" +
                            $"Желательные свойства фирмы: \n{employee.GetDesiredFirmConditions()} \n" +
                            $"Нежелательные свойства фирмы: \n{employee.GetUndesirableFirmConditions()}";
                var firms = new Companies().GetRatingFirms(employee);
                foreach (var firm in firms)
                {
                    RatingListBox.Items.Add(firm.GetCompanyName());
                }
            }
            else
            {
                MessageBox.Show("Введите значения");
            }
        }
    }
}