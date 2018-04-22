using System;
using VacationDecision.Windows.CreateEditEntity;
using ViewModel;
using ViewModel.Windows.CreateEditEntity;

namespace VacationDecision.InteractionService
{
    public sealed class EntityTabViewService : MainViewService
    {
        private bool OpenAlternativeEditWindow(СreateEditAlternativeViewModel createEditViewModel)
        {
            if (createEditViewModel == null)
                return false;

            var window = new CreateEditAlternative
            {
                DataContext = createEditViewModel
            };
            return window.ShowDialog() ?? false;
        }

        private bool OpenCriterionCreateRecordWindow(СreateEditCriterionViewModel createEditViewModel)
        {
            if (createEditViewModel == null)
                return false;

            var window = new CreateEditCriterion
            {
                DataContext = createEditViewModel
            };
            return window.ShowDialog() ?? false;
        }

        private bool OpenExpertCreateRecordWindow(СreateEditExpertViewModel createEditViewModel)
        {
            if (createEditViewModel == null)
                return false;

            var window = new CreateEditExpert
            {
                DataContext = createEditViewModel
            };
            return window.ShowDialog() ?? false;
        }

        private bool OpenMarkCreateRecordWindow(СreateEditMarkViewModel createEditViewModel)
        {
            if (createEditViewModel == null)
                return false;

            var window = new CreateEditMark
            {
                DataContext = createEditViewModel
            };
            return window.ShowDialog() ?? false;
        }

        private bool OpenVectorCreateRecordWindow(СreateEditVectorViewModel createEditViewModel)
        {
            if (createEditViewModel == null)
                return false;

            var window = new CreateEditVector
            {
                DataContext = createEditViewModel
            };
            return window.ShowDialog() ?? false;
        }

        public override bool ProvideService(string serviceId, object parameter)
        {
            if (parameter == null)
                return false;

            switch (serviceId)
            {
                case ViewService.ServiceId.OpenAlternativeEditWindowServiceId:
                    var alternativeCreateEditViewModel = parameter as СreateEditAlternativeViewModel;
                    return this.OpenAlternativeEditWindow(alternativeCreateEditViewModel);

                case ViewService.ServiceId.OpenCriterionEditWindowServiceId:
                    var criterionCreateEditViewModel = parameter as СreateEditCriterionViewModel;
                    return this.OpenCriterionCreateRecordWindow(criterionCreateEditViewModel);

                case ViewService.ServiceId.OpenExpertEditWindowServiceId:
                    var expertCreateEditViewModel = parameter as СreateEditExpertViewModel;
                    return this.OpenExpertCreateRecordWindow(expertCreateEditViewModel);

                case ViewService.ServiceId.OpenMarkEditWindowServiceId:
                    var markCreateEditViewModel = parameter as СreateEditMarkViewModel;
                    return this.OpenMarkCreateRecordWindow(markCreateEditViewModel);

                case ViewService.ServiceId.OpenVectorEditWindowServiceId:
                    var vectorCreateEditViewModel = parameter as СreateEditVectorViewModel;
                    return this.OpenVectorCreateRecordWindow(vectorCreateEditViewModel);
            }

            return base.ProvideService(serviceId, parameter);
        }
    }
}
