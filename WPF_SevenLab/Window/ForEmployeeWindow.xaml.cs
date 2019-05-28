using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using MainSolution.CandidatesAndFirms;
using MainSolution.Logic;

namespace MainSolution.Window
{
    public partial class ForEmployeeWindow : System.Windows.Window
    {
        private readonly HeadHunter _headHunter = new HeadHunter();
        public ForEmployeeWindow()
        {
            InitializeComponent();
            foreach (var company in _headHunter.Companies)
            {
                CompaniesComboBox.Items.Add(company.Name);
            }
        }

        private void SearchFirms_OnClick(object sender, RoutedEventArgs e)
        {
            RatingListBox.Items.Clear();
            if (CompaniesComboBox.SelectedIndex > -1)
            {
                Company company = _headHunter.GetCompany(CompaniesComboBox.SelectedItem.ToString());
                CompanyInfoTextBlock.Text = company.ToString();
                
                var candidates = _headHunter.GetAvailableCandidates(company);
                foreach (var employee in candidates)
                {
                    RatingListBox.Items.Add(employee.Name);
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

        private void RatingListBox_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Candidate candidate = _headHunter.GetCandidates(RatingListBox.SelectedItem.ToString());
            CandidateInfoTextBlock.Text = candidate.ToString();
        }

        private void CompaniesComboBox_OnDropDownClosed(object sender, EventArgs e)
        {
            RatingListBox.Items.Clear();
            CandidateInfoTextBlock.Text = "";
            Company company = _headHunter.GetCompany(CompaniesComboBox.SelectedItem.ToString());
            CompanyInfoTextBlock.Text = company.ToString();
        }
    }
}