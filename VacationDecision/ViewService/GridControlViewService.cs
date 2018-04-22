using System;
using System.Windows;
using ViewModel.CustomControls;
using ViewModel.ViewService;

namespace VacationDecision.ViewService
{
    public abstract class GridControlViewService<T> : IViewService
    {
        protected abstract Window CreateEditWindow
        {
            get;
        }

        protected GridControlViewModel<T> GridControlViewModel
        {
            get;
        }

        public bool ProvideService(ServiceName serviceName)
        {
            return this.CreateEditWindow.ShowDialog() ?? false;
        }
    }
}
