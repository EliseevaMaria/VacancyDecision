using System;
using System.Windows;
using ViewModel.Windows.CreateEditEntity;

namespace VacationDecision.Windows.CreateEditEntity
{
    /// <summary>
    /// Interaction logic for CreateEditVector.xaml
    /// </summary>
    public partial class CreateEditVector : Window
    {
        public CreateEditVector()
        {
            InitializeComponent();
        }

        private void Window_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            СreateEditVectorViewModel viewModel = this.DataContext as СreateEditVectorViewModel;
            if (viewModel == null)
                return;

            if (viewModel.Entity.Id == 0)
                this.Title = "Create vector";
            else
                this.Title = "Edit vector";
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
