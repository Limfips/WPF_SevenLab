using System.ComponentModel;
using System.Windows;
using MainSolution.CandidatesAndFirms;
using MainSolution.Logic;

namespace MainSolution.Window
{
    public partial class NewEmployeeWindow
    {
        private readonly HeadHunter _headHunter = new HeadHunter();
        public NewEmployeeWindow()
        {
            InitializeComponent();
            
        }

        private void NewEmployeeWindow_OnClosing(object sender, CancelEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void CreateNewEmployee_OnClick(object sender, RoutedEventArgs e)
        {
            if (FNameTextBox.Text != "" && SNameTextBox.Text != "")
            {
                Candidate.PropertiesList? properties = GetProperties();
                Company.PropertiesList? desiredFirmConditions = GetDesiredWorkingConditions();
                Company.PropertiesList? undesirableFirmConditions = GetUndesirableWorkingConditions();
                Candidate candidate = new Candidate(FNameTextBox.Text+" "+SNameTextBox.Text,properties,desiredFirmConditions,
                                                    undesirableFirmConditions);
                
                _headHunter.AddCandidate(candidate);
                _headHunter.HunterManager.SaveDataBaseCandidates(_headHunter.Candidates);
                MessageBox.Show("Ваша анкета отправлена");
            }
            else
            {
                MessageBox.Show("Заполните поля");
            }
        }

        private Candidate.PropertiesList? GetProperties()
        {
            Candidate.PropertiesList? properties = null;
            properties = SetProperties(SmartCheckBox.IsChecked,properties,Candidate.PropertiesList.Smart);
            properties = SetProperties(KindCheckBox.IsChecked,properties,Candidate.PropertiesList.Kind);
            properties = SetProperties(WealthyCheckBox.IsChecked,properties,Candidate.PropertiesList.Wealthy);
            properties = SetProperties(LazyCheckBox.IsChecked,properties,Candidate.PropertiesList.Lazy);
            properties = SetProperties(GreedyCheckBox.IsChecked,properties,Candidate.PropertiesList.Greedy);
            properties = SetProperties(WickedCheckBox.IsChecked,properties,Candidate.PropertiesList.Wicked);
            return properties;
        }

        private Candidate.PropertiesList? SetProperties
        (
            bool? isCheckBox,
            Candidate.PropertiesList? properties,
            Candidate.PropertiesList? addProperties
        )
        {
            if (isCheckBox == false) return properties;
            if (properties != null) return properties | addProperties;
            return addProperties;
        }
        private Company.PropertiesList? GetDesiredWorkingConditions()
        {
            Company.PropertiesList? desiredFirmConditions = null;
            
            desiredFirmConditions = SetWorkingConditions(ConvenientScheduleCheckBox.IsChecked,
                desiredFirmConditions,
                Company.PropertiesList.ConvenientSchedule);
            desiredFirmConditions = SetWorkingConditions(BigSalaryCheckBox.IsChecked,
                desiredFirmConditions,
                Company.PropertiesList.BigSalary);
            desiredFirmConditions = SetWorkingConditions(ComfortableOfficeCheckBox.IsChecked,
                desiredFirmConditions,
                Company.PropertiesList.ComfortableOffice);
            return desiredFirmConditions;
        }

        private Company.PropertiesList? GetUndesirableWorkingConditions()
        {
            Company.PropertiesList? undesirableFirmConditions = null;
            undesirableFirmConditions = SetWorkingConditions(TerribleWorkingConditionsCheckBox.IsChecked,
                undesirableFirmConditions,
                Company.PropertiesList.TerribleWorkingConditions);
            undesirableFirmConditions = SetWorkingConditions(NegativeTeamCheckBox.IsChecked,
                undesirableFirmConditions,
                Company.PropertiesList.NegativeTeam);
            undesirableFirmConditions = SetWorkingConditions(BadEquipmentCheckBox.IsChecked,
                undesirableFirmConditions,
                Company.PropertiesList.BadEquipment);
            return undesirableFirmConditions;
        }

        private Company.PropertiesList? SetWorkingConditions
        (
            bool? isCheckBox, 
            Company.PropertiesList? firmConditions,
            Company.PropertiesList? addFirmConditions
        )
        {
            if (isCheckBox == false ) return firmConditions;
            if (firmConditions != null) return firmConditions | addFirmConditions;
            return addFirmConditions;
        }
    }
}
