using System;
using System.Windows;
using Model.Entity;
using VacationDecision.Windows.CreateEditEntity;
using ViewModel.Windows.CreateEditEntity;

namespace VacationDecision.ViewService
{
    public class ExpertGridControlViewService : GridControlViewService<Expert>
    {
        protected override Window CreateEditWindow
        {
            get;
        }

        public ExpertGridControlViewService(BaseCreateEditViewModel<Expert> CreateEditViewModel)
        {
            this.CreateEditWindow = new CreateEditExpert
            {
                DataContext = this.GridControlViewModel.CreateEditViewModel
            };
        }
    }
}
