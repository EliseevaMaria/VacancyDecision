using System;
using System.Windows.Controls;
using ViewModel.Tabs;

namespace VacationDecision.Tabs
{
    /// <summary>
    /// Interaction logic for ExpertEntityTab.xaml
    /// </summary>
    public partial class ExpertEntityTab : UserControl
    {
        private void ClearFilter_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.viewModel.ClearFilter();
        }

        private void Create_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.viewModel.CreateRecord();
        }

        private void Delete_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.viewModel.Delete();
        }

        public ExpertEntityTab()
        {
            InitializeComponent();
        }

        private void Filter_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.viewModel.Filter();
        }

        private ExpertsTabViewModel viewModel => this.DataContext as ExpertsTabViewModel;

        private void Update_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.viewModel.UpdateRecord();
        }
    }
}
