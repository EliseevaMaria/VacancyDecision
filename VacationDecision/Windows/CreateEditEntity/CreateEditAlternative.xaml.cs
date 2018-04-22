using System;
using System.Windows;
using ViewModel.Windows.CreateEditEntity;

namespace VacationDecision.Windows.CreateEditEntity
{
    /// <summary>
    /// Interaction logic for CreateEditAlternative.xaml
    /// </summary>
    public partial class CreateEditAlternative : Window
    {
        public CreateEditAlternative()
        {
            InitializeComponent();
        }

        private void Window_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            СreateEditAlternativeViewModel viewModel = this.DataContext as СreateEditAlternativeViewModel;
            if (viewModel == null)
                return;

            if (viewModel.Entity.AlternativeId == 0)
                this.Title = "Create alternative";
            else
                this.Title = "Edit alternative";
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
