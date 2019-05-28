using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using MainSolution.CandidatesAndFirms;
using MainSolution.Logic;

namespace MainSolution.Window
{
    public partial class ForCompanyWindow : System.Windows.Window
    {
        private readonly HeadHunter _headHunter = new HeadHunter();

        public ForCompanyWindow()
        {
            InitializeComponent();
            foreach (var candidate in _headHunter.Candidates)
            {
                EmployeeComboBox.Items.Add(candidate.Name);
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
                Candidate candidate = _headHunter.GetCandidates(EmployeeComboBox.SelectedItem.ToString());
                CandidateInfoTextBlock.Text = candidate.ToString();
                List<Company> companies = _headHunter.GetAvailableCompany(candidate);
                foreach (var company in companies)
                {
                    RatingListBox.Items.Add(company.Name);
                }
            }
            else
            {
                MessageBox.Show("Введите значения");
            }
        }
        private void RatingListBox_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Company company = _headHunter.GetCompany(RatingListBox.SelectedItem.ToString());
            CompanyInfoTextBlock.Text = company.ToString();
        }

        private void EmployeeComboBox_OnDropDownClosed(object sender, EventArgs e)
        {
           RatingListBox.Items.Clear();
           CompanyInfoTextBlock.Text = "";
           Candidate candidate = _headHunter.GetCandidates(EmployeeComboBox.SelectedItem.ToString());
           CandidateInfoTextBlock.Text = candidate.ToString();
        }
    }
}