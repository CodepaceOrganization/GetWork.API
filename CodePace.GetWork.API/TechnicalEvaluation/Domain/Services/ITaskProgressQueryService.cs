using CodePace.GetWork.API.TechnicalEvaluation.Domain.Model.Entities;
using CodePace.GetWork.API.TechnicalEvaluation.Domain.Model.Queries;

namespace CodePace.GetWork.API.TechnicalEvaluation.Domain.Services;

public interface ITaskProgressQueryService
{
    public Task<IEnumerable<TaskProgress>> handle(GetAllTaskProgressByTechnicalTaskIdQuery query);
}