using CodePace.GetWork.API.TechnicalEvaluation.Domain.Model.Commands;
using CodePace.GetWork.API.TechnicalEvaluation.Domain.Model.Entities;

namespace CodePace.GetWork.API.TechnicalEvaluation.Domain.Services;

public interface ITechnicalTaskCommandService
{
    public Task<TechnicalTask?> Handle(CreateTechnicalTaskCommand command);
    public Task<TechnicalTask?> Handle(UpdateTaskProgressCommand command);
    public Task<IEnumerable<TechnicalTask>>? Handle(AssignTechnicalTaskToUser command);
}