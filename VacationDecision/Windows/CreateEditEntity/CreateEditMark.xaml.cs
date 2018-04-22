using System;
using System.Windows;
using ViewModel.Windows.CreateEditEntity;

namespace VacationDecision.Windows.CreateEditEntity
{
    /// <summary>
    /// Interaction logic for CreateEditMark.xaml
    /// </summary>
    public partial class CreateEditMark : Window
    {
        public CreateEditMark()
        {
            InitializeComponent();
        }

        private void Window_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            СreateEditMarkViewModel viewModel = this.DataContext as СreateEditMarkViewModel;
            if (viewModel == null)
                return;

            if (viewModel.Entity.MarkId == 0)
                this.Title = "Create mark";
            else
                this.Title = "Edit mark";
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
