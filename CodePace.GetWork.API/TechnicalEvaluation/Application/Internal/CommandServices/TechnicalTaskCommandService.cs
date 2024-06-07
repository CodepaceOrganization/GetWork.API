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
        var technicalTask = new TechnicalTask(command.Description, Enum.Parse<EDificultyStatus>(command.Difficulty));
        await technicalTaskRepository.AddAsync(technicalTask);
        await unitOfWork.CompleteAsync();
        return technicalTask;
    }

    public async Task<TechnicalTask?> Handle(UpdateTaskProgressCommand command)
    {
        var technicalTask = await technicalTaskRepository.FindByIdAsync(command.TechnicalTaskId);
        if (technicalTask is null) throw new Exception("Technical Task not found");
        technicalTask.TaskProgress.UpdateProgress(Enum.Parse<EProgress>(command.Progress));
        await unitOfWork.CompleteAsync();
        return technicalTask;
    }

    public async Task<IEnumerable<TechnicalTask>>? Handle(AssignTechnicalTaskToUser command)
    {
        var technicalTasks = await technicalTaskRepository.FindTechnicalsTaskByTechnicalTestId(command.TechnicalTestId);
        if (technicalTasks is null) throw new Exception("Technical Tasks not found");
        var enumerable = technicalTasks.ToList();
        foreach (var task in enumerable)
        {
            task.TaskProgress.UpdateUserId(command.UserId);
        }
        await unitOfWork.CompleteAsync();
        return enumerable;
    }
}