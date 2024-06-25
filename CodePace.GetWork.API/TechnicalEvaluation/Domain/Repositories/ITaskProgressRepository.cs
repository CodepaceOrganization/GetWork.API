using CodePace.GetWork.API.Shared.Domain.Repositories;
using CodePace.GetWork.API.TechnicalEvaluation.Domain.Model.Entities;

namespace CodePace.GetWork.API.TechnicalEvaluation.Domain.Repositories;

public interface ITaskProgressRepository: IBaseRepository<TaskProgress>
{
    Task<IEnumerable<TaskProgress>> FindTaskProgressByTechnicalTaskId(int technicalTaskId);
    Task UpdateTaskProgress(TaskProgress taskProgress);
}