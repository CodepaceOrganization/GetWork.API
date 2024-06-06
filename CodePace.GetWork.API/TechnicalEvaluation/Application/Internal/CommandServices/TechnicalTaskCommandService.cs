using CodePace.GetWork.API.TechnicalEvaluation.Domain.Model.Commands;
using CodePace.GetWork.API.TechnicalEvaluation.Domain.Model.Entities;
using CodePace.GetWork.API.TechnicalEvaluation.Domain.Repositories;
using CodePace.GetWork.API.TechnicalEvaluation.Domain.Services;

namespace CodePace.GetWork.API.TechnicalEvaluation.Application.Internal.CommandServices;

public class TechnicalTaskCommandService(ITechnicalTaskRepository technicalTaskRepository): ITechnicalTaskCommandService
{
    public Task<TechnicalTask?> Handle(CreateTechnicalTaskCommand command)
    {
        throw new NotImplementedException();
    }

    public Task<TechnicalTask?> Handle(UpdateTaskProgressCommand command)
    {
        throw new NotImplementedException();
    }
}