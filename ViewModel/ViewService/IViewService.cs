using System;

namespace ViewModel.ViewService
{
    public interface IViewService
    {
        bool ProvideService(ServiceName serviceName);
    }
}
