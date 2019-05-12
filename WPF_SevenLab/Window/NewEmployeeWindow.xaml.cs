using System.ComponentModel;
using System.Windows;
using MainSolution.CandidatesAndFirms;
using MainSolution.Logic;

namespace MainSolution.Window
{
    public partial class NewEmployeeWindow
    {
        private readonly WorkFile _workFile = new WorkFile(new Candidates().GetCandidates());
        public NewEmployeeWindow()
        {
            InitializeComponent();
        }

        private void NewEmployeeWindow_OnClosing(object sender, CancelEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
        }
        private void BackMenu_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CreateNewEmployeeButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (FNameTextBox.Text != "" && SNameTextBox.Text != "")
            {
                Employee.Properties? properties = GetProperties();
                Firm.WorkingConditions? workingConditions = GetWorkingConditions();
                Employee employee = new Employee(FNameTextBox.Text,SNameTextBox.Text,properties,workingConditions);
                
                _workFile.AddEmployee(employee);
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
        private Firm.WorkingConditions? GetWorkingConditions()
        {
            Firm.WorkingConditions? workingConditions = null;
            workingConditions = SetWorkingConditions(ConvenientScheduleCheckBox.IsChecked,
                                                     workingConditions,
                                 Firm.WorkingConditions.ConvenientSchedule);
            workingConditions = SetWorkingConditions(BigSalaryCheckBox.IsChecked,
                workingConditions,
                Firm.WorkingConditions.BigSalary);
            workingConditions = SetWorkingConditions(ComfortableOfficeCheckBox.IsChecked,
                workingConditions,
                Firm.WorkingConditions.ComfortableOffice);
            workingConditions = SetWorkingConditions(TerribleWorkingConditionsCheckBox.IsChecked,
                workingConditions,
                Firm.WorkingConditions.TerribleWorkingConditions);
            workingConditions = SetWorkingConditions(AbnegativeTeamCheckBox.IsChecked,
                workingConditions,
                Firm.WorkingConditions.NegativeTeam);
            workingConditions = SetWorkingConditions(BadEquipmentCheckBox.IsChecked,
                workingConditions,
                Firm.WorkingConditions.BadEquipment);
            return workingConditions;
        }
        private Firm.WorkingConditions? SetWorkingConditions
        (
            bool? isCheckBox, 
            Firm.WorkingConditions? workingConditions,
            Firm.WorkingConditions addWorkingConditions
        )
        {
            if (isCheckBox == false ) return workingConditions;
            if (workingConditions != null) return workingConditions | addWorkingConditions;
            return addWorkingConditions;
        }
    }
}
