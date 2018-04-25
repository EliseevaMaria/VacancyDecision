using System;
using System.Windows;
using ViewModel;

namespace VacationDecision.InteractionService
{
    public class MainViewService : ViewService
    {
        public override bool ProvideService(string serviceId, object parameter)
        {
            if (parameter == null)
                return false;

            switch (serviceId)
            {
                case ViewService.ServiceId.ShowErrorServiceId:
                    MessageBox.Show(parameter.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return true;
                case ViewService.ServiceId.ShowInformationServiceId:
                    MessageBox.Show(parameter.ToString(), "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    return true;
                case ViewService.ServiceId.ShowWarningServiceId:
                    MessageBox.Show(parameter.ToString(), "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return true;
            }

            return base.ProvideService(serviceId, parameter);
        }
    }
}
