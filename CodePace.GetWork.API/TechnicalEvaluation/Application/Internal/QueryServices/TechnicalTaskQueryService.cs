using CodePace.GetWork.API.TechnicalEvaluation.Domain.Model.Entities;
using CodePace.GetWork.API.TechnicalEvaluation.Domain.Model.Queries;
using CodePace.GetWork.API.TechnicalEvaluation.Domain.Repositories;
using CodePace.GetWork.API.TechnicalEvaluation.Domain.Services;

namespace CodePace.GetWork.API.TechnicalEvaluation.Application.Internal.QueryServices;

public class TechnicalTaskQueryService(ITechnicalTaskRepository technicalTaskRepository): ITechnicalTaskQueryService
{
    public Task<IEnumerable<TechnicalTask>> Handle(GetAllTechnicalTaskByTechnicalTestIdQuery query)
    {
        throw new NotImplementedException();
        //return await Task<TechnicalTask> technicalTaskRepository.FindByTechnicalTestIdAsync(query.TechnicalTestId);
    }
}