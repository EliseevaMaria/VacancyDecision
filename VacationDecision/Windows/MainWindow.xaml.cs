using System;
using System.Windows;
using System.Windows.Controls;
using VacationDecision.InteractionService;
using VacationDecision.Tabs;
using ViewModel;
using ViewModel.Tabs;

namespace VacationDecision
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel(new EntityTabViewService());
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 0)
                return;

            var selectedTab = e.AddedItems[0] as TabItem;
            var viewModel = this.DataContext as MainWindowViewModel;
            if (viewModel == null || selectedTab == null)
                return;

            switch (selectedTab.Header)
            {
                case "Experts":
                    break;
                case "Alternatives":
                    break;
                case "Criteria":
                    break;
                case "Marks":
                    var marksTab = selectedTab.Content as MarkEntityTab;
                    var marksTabViewModel = marksTab.DataContext as MarksTabViewModel;
                    var markFieldsViewModel = marksTabViewModel.MarkFieldsViewModel;
                    markFieldsViewModel.RefreshComboboxLists();
                    break;
                case "Vector":
                    var vectorsTab = selectedTab.Content as VectorEntityTab;
                    var vectorsTabViewModel = vectorsTab.DataContext as VectorsTabViewModel;
                    var vectorFieldsViewModel = vectorsTabViewModel.VectorFieldsViewModel;
                    vectorFieldsViewModel.RefreshComboboxLists();
                    break;
                case "Compare":
                    var comparisonTab = selectedTab.Content as ComparisonTab;
                    var comparisonTabViewModel = comparisonTab.DataContext as ComparisonTabViewModel;
                    break;
                case "Collective compare":
                    var collectiveComparisonTab = selectedTab.Content as CollectiveComparisonTab;
                    var collectiveComparisonTabViewModel = collectiveComparisonTab.DataContext as CollectiveComparisonTabViewModel;
                    break;
                default:
                    throw new Exception();
            }
        }
    }
}
