using AutoMapper;
using TaskManager.Models;
using TaskManager.ViewModels;
using static TaskManager.ViewModels.AnotationViewModel;

namespace TaskManager.Mappings
{
    public class AnotationProfile : Profile
    {
        public AnotationProfile()
        {
            // Mapeia CreateAnotationViewModel -> AnotationModel (entrada)
            // ViewModel → Model (para criação)
            CreateMap<CreateAnotationViewModel, AnotationModel>();

            // Mapeia AnotationModel -> AnotationResponseViewModel (retorno)
            // Model → ViewModel (para resposta)
            CreateMap<AnotationModel, AnotationResponseViewModel>();
        }
    }
}
