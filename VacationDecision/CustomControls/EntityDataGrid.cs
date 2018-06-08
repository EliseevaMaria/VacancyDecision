using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Model.Entity;
using ViewModel.CustomControls;

namespace VacationDecision.CustomControls
{
    public class EntityDataGrid : DataGrid, IDisposable
    {
        public void Dispose()
        {
            this.DataContextChanged -= SetItemsSourceFromDataContext;
        }

        public EntityDataGrid()
        {
            this.AutoGenerateColumns = true;
            this.CanUserAddRows = false;
            this.CanUserDeleteRows = false;
            this.IsReadOnly = true;
            this.Margin = new Thickness(10);
            this.SelectionMode = DataGridSelectionMode.Single;

            this.DataContextChanged += SetItemsSourceFromDataContext;
        }

        private void SetItemsSourceFromDataContext(object sender, DependencyPropertyChangedEventArgs e)
        {
            Type dataContextType = this.DataContext.GetType();
            Type[] nestesTypes = dataContextType.GenericTypeArguments;
            if (nestesTypes.FirstOrDefault()?.BaseType != typeof(BaseEntity)
                && nestesTypes.FirstOrDefault()?.BaseType != typeof(BaseNamedEntity))
                return;

            if (BindingOperations.GetBinding(this, DataGrid.ItemsSourceProperty) == null)
            {
                var itemsSourceBinding = new Binding()
                {
                    Mode = BindingMode.OneWay,
                    Path = new PropertyPath("RecordList"),
                    UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
                };
                this.SetBinding(DataGrid.ItemsSourceProperty, itemsSourceBinding);
            }

            if (BindingOperations.GetBinding(this, DataGrid.SelectedItemProperty) == null)
            {
                var selectedItemBinding = new Binding()
                {
                    Mode = BindingMode.TwoWay,
                    Path = new PropertyPath("SelectedRecord"),
                    UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
                };
                this.SetBinding(DataGrid.SelectedItemProperty, selectedItemBinding);
            }
        }

        protected override void OnAutoGeneratingColumn(DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName.Contains("Id"))
                e.Cancel = true;
            base.OnAutoGeneratingColumn(e);
        }

        protected override void OnSelectionChanged(SelectionChangedEventArgs e)
        {
            var collection = this.ItemsSource;
            if (collection == null)
                return;

            Type collectionType = collection.GetType();
            Type itemType = collectionType.GetGenericArguments().Single();

            var item = this.SelectedItem;
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
                case nameof(Model.Entity.Vector):
                    var vector = item as Model.Entity.Vector;
                    (this.DataContext as GridControlViewModel<Model.Entity.Vector>).SelectedRecord = vector;
                    break;
                default:
                    throw new Exception();
            }

            base.OnSelectionChanged(e);
        }
    }
}
