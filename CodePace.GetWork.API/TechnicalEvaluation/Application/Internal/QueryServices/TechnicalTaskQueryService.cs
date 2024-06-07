using CodePace.GetWork.API.TechnicalEvaluation.Domain.Model.Entities;
using CodePace.GetWork.API.TechnicalEvaluation.Domain.Model.Queries;
using CodePace.GetWork.API.TechnicalEvaluation.Domain.Repositories;
using CodePace.GetWork.API.TechnicalEvaluation.Domain.Services;

namespace CodePace.GetWork.API.TechnicalEvaluation.Application.Internal.QueryServices;

public class TechnicalTaskQueryService(ITechnicalTaskRepository technicalTaskRepository): ITechnicalTaskQueryService
{
    public async Task<IEnumerable<TechnicalTask>> Handle(GetAllTechnicalTaskByTechnicalTestIdQuery query)
    {
        return await technicalTaskRepository.FindTechnicalsTaskByTechnicalTestId(query.TechnicalTestId);
    }
}