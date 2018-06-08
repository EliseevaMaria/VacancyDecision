using System;
using System.Windows;
using System.Windows.Controls;
using ViewModel.Tabs;

namespace VacationDecision.Tabs
{
    /// <summary>
    /// Interaction logic for CollectiveComparisonTab.xaml
    /// </summary>
    public partial class CollectiveComparisonTab : UserControl
    {
        public CollectiveComparisonTab()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.viewModel.SelectedExpertComparisonViewModel.StartFromBeginning();
        }

        private void UserControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            this.viewModel = e.NewValue as CollectiveComparisonTabViewModel;
        }

        private CollectiveComparisonTabViewModel viewModel;

        private void Alternative1_Click(object sender, RoutedEventArgs e)
        {
            var alternative = this.viewModel.SelectedExpertComparisonViewModel.Alternative1;
            if (alternative == null)
                return;

            this.viewModel.SelectedExpertComparisonViewModel.MakeChoice(alternative);
        }

        private void Alternative2_Click(object sender, RoutedEventArgs e)
        {
            var alternative = this.viewModel.SelectedExpertComparisonViewModel.Alternative2;
            if (alternative == null)
                return;

            this.viewModel.SelectedExpertComparisonViewModel.MakeChoice(alternative);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.viewModel.RefreshAll();
        }
    }
}
