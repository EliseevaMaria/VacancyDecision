using System;
using System.Linq;
using System.Windows.Controls;
using Model.Entity;
using ViewModel.CustomControls;

namespace VacationDecision.CustomControls
{
    /// <summary>
    /// Interaction logic for EntityDataGrid.xaml
    /// </summary>
    public partial class EntityDataGrid : UserControl
    {
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var dataGrid = sender as DataGrid;
            var collection = dataGrid?.ItemsSource;
            if (collection == null)
                return;

            Type collectionType = collection.GetType();
            Type itemType = collectionType.GetGenericArguments().Single();

            var item = dataGrid.SelectedItem;
            switch (itemType.Name)
            {
                case nameof(Alternative):
                    var alternative = item as Alternative;
                    (this.DataContext as GridControlViewModel<Alternative>).SelectedRecord = alternative;
                    break;
                case nameof(Criterion):
                    var criterion = item as Criterion;
                    (this.DataContext as GridControlViewModel<Criterion>).SelectedRecord = criterion;
                    break;
                case nameof(Expert):
                    var expert = item as Expert;
                    (this.DataContext as GridControlViewModel<Expert>).SelectedRecord = expert;
                    break;
                case nameof(Mark):
                    var mark = item as Mark;
                    (this.DataContext as GridControlViewModel<Mark>).SelectedRecord = mark;
                    break;
                case nameof(Vector):
                    var vector = item as Vector;
                    (this.DataContext as GridControlViewModel<Vector>).SelectedRecord = vector;
                    break;
            }
        }
        
        public EntityDataGrid()
        {
            InitializeComponent();
        }

        private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "Id")
                e.Cancel = true;
        }
    }
}
