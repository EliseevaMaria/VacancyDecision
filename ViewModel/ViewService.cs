using System;

namespace ViewModel
{
    public abstract class ViewService
    {
        public virtual bool ProvideService(string serviceId)
        {
            return false;
        }

        public virtual bool ProvideService(string serviceId, object parameter)
        {
            return false;
        }

        public static class ServiceId
        {
            public const string OpenAlternativeEditWindowServiceId = nameof(ServiceId.OpenAlternativeEditWindowServiceId);

            public const string OpenCriterionEditWindowServiceId = nameof(ServiceId.OpenCriterionEditWindowServiceId);

            public const string OpenExpertEditWindowServiceId = nameof(ServiceId.OpenExpertEditWindowServiceId);

            public const string OpenMarkEditWindowServiceId = nameof(ServiceId.OpenMarkEditWindowServiceId);

            public const string OpenVectorEditWindowServiceId = nameof(ServiceId.OpenVectorEditWindowServiceId);

            public const string ShowInformationServiceId = nameof(ServiceId.ShowInformationServiceId);

            public const string ShowWarningServiceId = nameof(ServiceId.ShowWarningServiceId);

            public const string ShowErrorServiceId = nameof(ServiceId.ShowErrorServiceId);
        }
    }
}
