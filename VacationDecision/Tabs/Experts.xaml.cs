using System;
using System.Windows.Controls;
using Model.Entity;
using VacationDecision.Windows.CreateEditEntity;
using ViewModel.Tabs;
using ViewModel.Windows.CreateEditEntity;

namespace VacationDecision.Tabs
{
    /// <summary>
    /// Interaction logic for Experts.xaml
    /// </summary>
    public partial class Experts : UserControl
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

        public Experts()
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
