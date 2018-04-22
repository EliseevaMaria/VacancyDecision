using System;
using System.Windows;
using ViewModel.Windows.CreateEditEntity;

namespace VacationDecision.Windows.CreateEditEntity
{
    /// <summary>
    /// Interaction logic for CreateEditExpert.xaml
    /// </summary>
    public partial class CreateEditExpert: Window
    {
        public CreateEditExpert()
        {
            InitializeComponent();
        }

        private void Window_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            СreateEditExpertViewModel viewModel = this.DataContext as СreateEditExpertViewModel;
            if (viewModel == null)
                return;

            if (viewModel.Entity.ExpertId == 0)
                this.Title = "Create expert";
            else
                this.Title = "Edit expert";
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
