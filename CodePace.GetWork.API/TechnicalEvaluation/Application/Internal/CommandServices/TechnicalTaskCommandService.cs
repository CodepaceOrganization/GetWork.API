using CodePace.GetWork.API.Shared.Domain.Repositories;
using CodePace.GetWork.API.TechnicalEvaluation.Domain.Model.Aggregates;
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
        var technicalTask = new TechnicalTask(command.Description, Enum.Parse<EDificultyStatus>(command.Difficulty), command.TechnicalTestId);
        await technicalTaskRepository.AddAsync(technicalTask);
        await unitOfWork.CompleteAsync();
        return technicalTask;
    }

    public async Task<TechnicalTask?> Handle(UpdateTaskProgressCommand command)
    {
        var technicalTask = await technicalTaskRepository.FindByIdAsync(command.TechnicalTaskId);
        if (technicalTask is null) throw new Exception("Technical Task not found");
        technicalTask.TaskProgress.UpdateProgress(Enum.Parse<EProgress>(command.Progress));
        await technicalTaskRepository.UpdateTaskProgress(command.TechnicalTaskId,technicalTask.TaskProgress);
        await unitOfWork.CompleteAsync();
        return technicalTask;
    }
    
    public async Task<IEnumerable<TechnicalTask>>? Handle(AssignTechnicalTaskToUserCommand command)
    {
        try
        {
            await unitOfWork.BeginTransactionAsync();
            var technicalTasks = await technicalTaskRepository.FindTechnicalsTaskByTechnicalTestId(command.TechnicalTestId);

            foreach (var technicalTask in technicalTasks)
            {
                var existingTaskProgress = await technicalTaskRepository.FindTaskProgress(technicalTask.Id, command.UserId);
                if (existingTaskProgress != null)
                {
                    await unitOfWork.RollbackTransactionAsync();
                    return new List<TechnicalTask>();
                }

                var taskProgress = new TaskProgress
                {
                    UserId = command.UserId,
                    TechnicalTaskId = technicalTask.Id
                };
                await technicalTaskRepository.AddTaskProgress(taskProgress);
            }

            await unitOfWork.CommitTransactionAsync();
            return technicalTasks;
        }
        catch
        {
            await unitOfWork.RollbackTransactionAsync();
            throw;
        }
    }
}