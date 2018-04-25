using System;
using System.Windows;
using System.Windows.Controls;
using Model.Entity;
using ViewModel.Tabs;

namespace VacationDecision.Tabs
{
    /// <summary>
    /// Interaction logic for ComparisonTab.xaml
    /// </summary>
    public partial class ComparisonTab : UserControl
    {
        public ComparisonTab()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.viewModel.StartFromBeginning();
        }

        private void UserControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            this.viewModel = e.NewValue as ComparisonTabViewModel;
        }

        private ComparisonTabViewModel viewModel;

        private void Alternative1_Click(object sender, RoutedEventArgs e)
        {
            var alternative = this.viewModel.Alternative1;
            if (alternative == null)
                return;

            this.viewModel.MakeChoice(alternative);
        }

        private void Alternative2_Click(object sender, RoutedEventArgs e)
        {
            var alternative = this.viewModel.Alternative2;
            if (alternative == null)
                return;

            this.viewModel.MakeChoice(alternative);
        }

        private void ContinueComparison_Click(object sender, RoutedEventArgs e)
        {
            this.viewModel.ContinueComparison();
        }
    }
}
