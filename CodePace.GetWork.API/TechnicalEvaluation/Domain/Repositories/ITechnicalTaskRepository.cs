using CodePace.GetWork.API.Shared.Domain.Repositories;
using CodePace.GetWork.API.TechnicalEvaluation.Domain.Model.Entities;

namespace CodePace.GetWork.API.TechnicalEvaluation.Domain.Repositories;

public interface ITechnicalTaskRepository: IBaseRepository<TechnicalTask>
{
    Task<IEnumerable<TechnicalTask>> FindTechnicalsTaskByTechnicalTestId(int technicalTestId);
    public Task<TaskProgress?> FindTaskProgress(int technicalTaskId, int userId);
    public Task AddTaskProgress(TaskProgress taskProgress);
    public Task UpdateTaskProgress(int id, TaskProgress taskProgress);
    public Task<IEnumerable<TechnicalTask>> GetAllTechnicalTaskByUserId(int userId, int technicalTestId);
}