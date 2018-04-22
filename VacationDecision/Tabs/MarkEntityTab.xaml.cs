using System;
using System.Windows.Controls;
using ViewModel.Tabs;

namespace VacationDecision.Tabs
{
    /// <summary>
    /// Interaction logic for MarkEntityTab.xaml
    /// </summary>
    public partial class MarkEntityTab : UserControl
    {
        public MarkEntityTab()
        {
            InitializeComponent();
        }

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

        private void Filter_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.viewModel.Filter();
        }

        private MarksTabViewModel viewModel => this.DataContext as MarksTabViewModel;

        private void Update_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.viewModel.UpdateRecord();
        }
    }
}
