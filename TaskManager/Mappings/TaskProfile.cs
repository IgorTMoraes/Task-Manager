using AutoMapper;
using TaskManager.Models;
using TaskManager.ViewModels;
using static TaskManager.ViewModels.TaskViewModel;

namespace TaskManager.Mappings
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            // Mapeia CreateTaskViewModel -> TaskModel (entrada)
            // ViewModel → Model (para criação)
            CreateMap<CreateTaskViewModel, TaskModel>();

            // Mapeia TaskModel -> TaskResponseViewModel (retorno)
            // Model → ViewModel (para resposta)
            CreateMap<TaskModel, TaskResponseViewModel>();
        }
    }
}
