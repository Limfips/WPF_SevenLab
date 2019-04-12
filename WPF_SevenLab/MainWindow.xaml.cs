using System.Windows;

namespace MainSolution
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void DisplaySearchFirmsGrid_OnClick(object sender, RoutedEventArgs e)
        {
            SearchFirmsGrid.Visibility = Visibility.Visible;
            MainGrid.Visibility = Visibility.Collapsed;
        }
        private void DisplaySearchWorkersGrid_OnClick(object sender, RoutedEventArgs e)
        {
            SearchWorkersGrid.Visibility = Visibility.Visible;
            MainGrid.Visibility = Visibility.Collapsed;
        }
        
        private void BackMenu_OnClick(object sender, RoutedEventArgs e)
        {
            if (SearchFirmsGrid.IsVisible)
            {
                SearchFirmsGrid.Visibility = Visibility.Collapsed;
            }
            if (SearchWorkersGrid.IsVisible)
            {
                SearchWorkersGrid.Visibility = Visibility.Collapsed;
            }
            MainGrid.Visibility = Visibility.Visible;
        }
    }
}