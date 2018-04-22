using System;
using System.Windows.Controls;
using ViewModel.Tabs;

namespace VacationDecision.Tabs
{
    /// <summary>
    /// Interaction logic for VectorEntityTab.xaml
    /// </summary>
    public partial class VectorEntityTab : UserControl
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

        private void Filter_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.viewModel.Filter();
        }

        private VectorsTabViewModel viewModel => this.DataContext as VectorsTabViewModel;

        private void Update_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.viewModel.UpdateRecord();
        }

        public VectorEntityTab()
        {
            InitializeComponent();
        }
    }
}
