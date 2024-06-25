using CodePace.GetWork.API.TechnicalEvaluation.Domain.Model.Entities;
using CodePace.GetWork.API.TechnicalEvaluation.Domain.Model.Queries;
using CodePace.GetWork.API.TechnicalEvaluation.Domain.Repositories;
using CodePace.GetWork.API.TechnicalEvaluation.Domain.Services;

namespace CodePace.GetWork.API.TechnicalEvaluation.Application.Internal.QueryServices;

public class TaskProgressQueryService(ITaskProgressRepository taskProgressRepository): ITaskProgressQueryService
{
    public async Task<IEnumerable<TaskProgress>> Handle(GetAllTaskProgressByTechnicalTaskIdQuery query)
    {
        return await taskProgressRepository.FindTaskProgressByTechnicalTaskId(query.TechnicalTaskId);
    }

    public Task<IEnumerable<TaskProgress>> handle(GetAllTaskProgressByTechnicalTaskIdQuery query)
    {
        throw new NotImplementedException();
    }
}