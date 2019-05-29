using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using MainSolution.Logic;

namespace MainSolution.Window
{
    public partial class NewCompanyWindow : System.Windows.Window
    {
        private readonly HeadHunter _headHunter;
        HunterManager hunterManager;
        public NewCompanyWindow()
        {
            hunterManager = new HunterManager();
            List<Candidate> candidates = hunterManager.LoadDataBaseCandidates();
            List<Company> companies = hunterManager.LoadDataBaseCompanies();
            _headHunter  = new HeadHunter(candidates, companies);
            InitializeComponent();
        }
        private void NewCompanyWindow_OnClosing(object sender, CancelEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void CreateNewCompany_OnClick(object sender, RoutedEventArgs e)
        {
            if (FNameTextBox.Text != "")
            {
                Company.PropertiesList? properties = GetProperties();
                Candidate.PropertiesList? desiredFirmConditions = GetDesiredWorkingConditions();
                Candidate.PropertiesList? undesirableFirmConditions = GetUndesirableWorkingConditions();
                Company company = new Company(FNameTextBox.Text,properties,desiredFirmConditions,
                    undesirableFirmConditions);
                
                _headHunter.AddCompany(company);
                hunterManager.SaveDataBaseCompanies(_headHunter.Companies);
                MessageBox.Show("Вы разместили свою компанию");
            }
            else
            {
                MessageBox.Show("Заполните поля");
            }
        }
        private Company.PropertiesList? GetProperties()
        {
            Company.PropertiesList? properties = null;
            properties = SetProperties(ConvenientScheduleCheckBox.IsChecked,properties,
                Company.PropertiesList.ConvenientSchedule);
            properties = SetProperties(BigSalaryCheckBox.IsChecked,properties,
                Company.PropertiesList.BigSalary);
            properties = SetProperties(ComfortableOfficeCheckBox.IsChecked,properties,
                Company.PropertiesList.ComfortableOffice);
            properties = SetProperties(TerribleWorkingConditionsCheckBox.IsChecked,properties,
                Company.PropertiesList.TerribleWorkingConditions);
            properties = SetProperties(NegativeTeamCheckBox.IsChecked,properties,
                Company.PropertiesList.NegativeTeam);
            properties = SetProperties(BadEquipmentCheckBox.IsChecked,properties,
                Company.PropertiesList.BadEquipment);
            return properties;
        }

        private Company.PropertiesList? SetProperties
        (
            bool? isCheckBox,
            Company.PropertiesList? properties,
            Company.PropertiesList? addProperties
        )
        {
            if (isCheckBox == false) return properties;
            if (properties != null) return properties | addProperties;
            return addProperties;
        }
        private Candidate.PropertiesList? GetDesiredWorkingConditions()
        {
            Candidate.PropertiesList? desiredFirmConditions = null;
            
            desiredFirmConditions = SetWorkingConditions(SmartCheckBox.IsChecked,
                desiredFirmConditions,
                Candidate.PropertiesList.Smart);
            desiredFirmConditions = SetWorkingConditions(KindCheckBox.IsChecked,
                desiredFirmConditions,
                Candidate.PropertiesList.Kind);
            desiredFirmConditions = SetWorkingConditions(WealthyCheckBox.IsChecked,
                desiredFirmConditions,
                Candidate.PropertiesList.Wealthy);
            return desiredFirmConditions;
        }

        private Candidate.PropertiesList? GetUndesirableWorkingConditions()
        {
            Candidate.PropertiesList? undesirableFirmConditions = null;
            undesirableFirmConditions = SetWorkingConditions(LazyCheckBox.IsChecked,
                undesirableFirmConditions,
                Candidate.PropertiesList.Lazy);
            undesirableFirmConditions = SetWorkingConditions(GreedyCheckBox.IsChecked,
                undesirableFirmConditions,
                Candidate.PropertiesList.Greedy);
            undesirableFirmConditions = SetWorkingConditions(WickedCheckBox.IsChecked,
                undesirableFirmConditions,
                Candidate.PropertiesList.Wicked);
            return undesirableFirmConditions;
        }

        private Candidate.PropertiesList? SetWorkingConditions
        (
            bool? isCheckBox, 
            Candidate.PropertiesList? candidatePropertiesList,
            Candidate.PropertiesList? addFirmConditions
        )
        {
            if (isCheckBox == false ) return candidatePropertiesList;
            if (candidatePropertiesList != null) return candidatePropertiesList | addFirmConditions;
            return addFirmConditions;
        }
        
    }
}
