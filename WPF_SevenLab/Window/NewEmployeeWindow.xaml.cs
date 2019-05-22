using System.ComponentModel;
using System.Windows;
using MainSolution.CandidatesAndFirms;
using MainSolution.Logic;

namespace MainSolution.Window
{
    public partial class NewEmployeeWindow
    {
        private readonly WorkFile _workFile = new WorkFile();
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
                Employee.Properties? properties = GetProperties();
                Firm.FirmConditions? desiredFirmConditions = GetDesiredWorkingConditions();
                Firm.FirmConditions? undesirableFirmConditions = GetUndesirableWorkingConditions();
                Employee employee = new Employee(FNameTextBox.Text,SNameTextBox.Text,
                                                    properties,desiredFirmConditions,
                                                    undesirableFirmConditions);
                
                _workFile.AddEmployee(employee);
                MessageBox.Show("Ваша анкета отправлена");
            }
            else
            {
                MessageBox.Show("Заполните поля");
            }
        }

        private Employee.Properties? GetProperties()
        {
            Employee.Properties? properties = null;
            properties = SetProperties(SmartCheckBox.IsChecked,properties,Employee.Properties.Smart);
            properties = SetProperties(KindCheckBox.IsChecked,properties,Employee.Properties.Kind);
            properties = SetProperties(WealthyCheckBox.IsChecked,properties,Employee.Properties.Wealthy);
            properties = SetProperties(LazyCheckBox.IsChecked,properties,Employee.Properties.Lazy);
            properties = SetProperties(GreedyCheckBox.IsChecked,properties,Employee.Properties.Greedy);
            properties = SetProperties(WickedCheckBox.IsChecked,properties,Employee.Properties.Wicked);
            return properties;
        }

        private Employee.Properties? SetProperties
        (
            bool? isCheckBox,
            Employee.Properties? properties,
            Employee.Properties addProperties
        )
        {
            if (isCheckBox == false) return properties;
            if (properties != null) return properties | addProperties;
            return addProperties;
        }
        private Firm.FirmConditions? GetDesiredWorkingConditions()
        {
            Firm.FirmConditions? desiredFirmConditions = null;
            
            desiredFirmConditions = SetWorkingConditions(ConvenientScheduleCheckBox.IsChecked,
                desiredFirmConditions,
                                 Firm.FirmConditions.ConvenientSchedule);
            desiredFirmConditions = SetWorkingConditions(BigSalaryCheckBox.IsChecked,
                desiredFirmConditions,
                Firm.FirmConditions.BigSalary);
            desiredFirmConditions = SetWorkingConditions(ComfortableOfficeCheckBox.IsChecked,
                desiredFirmConditions,
                Firm.FirmConditions.ComfortableOffice);
            return desiredFirmConditions;
        }

        private Firm.FirmConditions? GetUndesirableWorkingConditions()
        {
            Firm.FirmConditions? undesirableFirmConditions = null;
            undesirableFirmConditions = SetWorkingConditions(TerribleWorkingConditionsCheckBox.IsChecked,
                undesirableFirmConditions,
                Firm.FirmConditions.TerribleWorkingConditions);
            undesirableFirmConditions = SetWorkingConditions(NegativeTeamCheckBox.IsChecked,
                undesirableFirmConditions,
                Firm.FirmConditions.NegativeTeam);
            undesirableFirmConditions = SetWorkingConditions(BadEquipmentCheckBox.IsChecked,
                undesirableFirmConditions,
                Firm.FirmConditions.BadEquipment);
            return undesirableFirmConditions;
        }

        private Firm.FirmConditions? SetWorkingConditions
        (
            bool? isCheckBox, 
            Firm.FirmConditions? firmConditions,
            Firm.FirmConditions addFirmConditions
        )
        {
            if (isCheckBox == false ) return firmConditions;
            if (firmConditions != null) return firmConditions | addFirmConditions;
            return addFirmConditions;
        }
    }
}
