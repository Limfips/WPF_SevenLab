using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using MainSolution.CandidatesAndFirms;
using MainSolution.Logic;

namespace MainSolution.Window
{
    public partial class ForEmployeeWindow : System.Windows.Window
    {
        private readonly Candidates _candidates = new Candidates(new WorkFile().GetCandidates());
        private List<Firm> _firms = new Companies().GetCompanies();
        public ForEmployeeWindow()
        {
            InitializeComponent();
            foreach (var employee in _candidates.GetCandidates())
            {
                EmployeeComboBox.Items.Add(employee.GetName());
            }
            foreach (var firm in _firms)
            {
                FirmComboBox.Items.Add(firm.GetCompanyName());
            }
        }

        private void SearchFirms_OnClick(object sender, RoutedEventArgs e)
        {
            RatingListBox.Items.Clear();
            if (FirmComboBox.SelectedIndex > -1 && EmployeeComboBox.SelectedIndex > -1)
            {
                Employee employee = _candidates.GetCandidates()[EmployeeComboBox.SelectedIndex];
                Firm firm = _firms[FirmComboBox.SelectedIndex];
                FirmInfoTextBlock.Text = $"Название: \n{firm.GetCompanyName()} \n" +
                                         $"Условия работы в фирме: \n{firm.GetPropertiesFirm()} \n" +
                                         $"Желательные свойства кандидата: \n{firm.GetDesiredEmployeeProperties()} \n" +
                                         $"Нежелательные свойства кандидата: \n{firm.GetUndesirableEmployeeProperties()}";
                var candidates = _candidates.GetRatingCandidates(firm);
                foreach (var candidate in candidates)
                {
                    if (candidate == employee)
                    {
                        TextBlock text = new TextBlock();
                        text.Text = candidate.GetName();
                        text.Foreground = Brushes.Green;
                        RatingListBox.Items.Add(text);
                    }
                    else
                    {
                        RatingListBox.Items.Add(candidate.GetName());
                    }
                }
            }
            else
            {
                MessageBox.Show("Введите значения");
            }
        }

        private void ForEmployeeWindow_OnClosing(object sender, CancelEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}