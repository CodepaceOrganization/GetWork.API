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
        Console.WriteLine("Update Task Progress");
        Console.WriteLine(command.UserId);
        var technicalTaskProgress = await technicalTaskRepository.FindTaskProgress(command.TechnicalTaskId, command.UserId);
        Console.WriteLine(technicalTaskProgress);
        if (technicalTaskProgress is null) throw new Exception("Technical Task not found");
        technicalTaskProgress.UpdateProgress(Enum.Parse<EProgress>(command.Progress));
        await technicalTaskRepository.UpdateTaskProgress(command.TechnicalTaskId,technicalTaskProgress);
        await unitOfWork.CompleteAsync();
        return technicalTaskProgress.TechnicalTask;
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