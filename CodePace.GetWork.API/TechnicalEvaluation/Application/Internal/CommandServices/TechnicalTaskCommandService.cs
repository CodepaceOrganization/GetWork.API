using CodePace.GetWork.API.Shared.Domain.Repositories;
using CodePace.GetWork.API.TechnicalEvaluation.Domain.Model.Commands;
using CodePace.GetWork.API.TechnicalEvaluation.Domain.Model.Entities;
using CodePace.GetWork.API.TechnicalEvaluation.Domain.Model.ValueObjects;
using CodePace.GetWork.API.TechnicalEvaluation.Domain.Repositories;
using CodePace.GetWork.API.TechnicalEvaluation.Domain.Services;

namespace CodePace.GetWork.API.TechnicalEvaluation.Application.Internal.CommandServices;

public class TechnicalTaskCommandService(ITechnicalTaskRepository technicalTaskRepository, IUnitOfWork unitOfWork): ITechnicalTaskCommandService
{
    public async Task<TechnicalTask?> Handle(CreateTechnicalTaskCommand command)
    {
        var technicalTask = new TechnicalTask(new UserId(command.UserId), command.Description, Enum.Parse<EDificultyStatus>(command.Difficulty));
        await technicalTaskRepository.AddAsync(technicalTask);
        await unitOfWork.CompleteAsync();
        return technicalTask;
    }

    public async Task<TechnicalTask?> Handle(UpdateTaskProgressCommand command)
    {
        var technicalTask = await technicalTaskRepository.FindByIdAndUserIdAsync(command.TechicalTaskId, command.UserId);
        if (technicalTask is null) throw new Exception("Technical Task not found");
        technicalTask.UpdateProgress(Enum.Parse<EProgress>(command.Progress));
        await unitOfWork.CompleteAsync();
        return technicalTask;
    }
}