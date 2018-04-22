using System;
using System.Windows;
using ViewModel.Windows.CreateEditEntity;

namespace VacationDecision.Windows.CreateEditEntity
{
    /// <summary>
    /// Interaction logic for CreateEditExpert.xaml
    /// </summary>
    public partial class CreateEditCriterion : Window
    {
        public CreateEditCriterion()
        {
            InitializeComponent();
        }

        private void Window_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            СreateEditCriterionViewModel viewModel = this.DataContext as СreateEditCriterionViewModel;
            if (viewModel == null)
                return;

            if (viewModel.Entity.CriterionId == 0)
                this.Title = "Create criterion";
            else
                this.Title = "Edit criterion";
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
