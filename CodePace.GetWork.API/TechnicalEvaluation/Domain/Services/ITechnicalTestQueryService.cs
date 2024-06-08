using CodePace.GetWork.API.TechnicalEvaluation.Domain.Model.Aggregates;
using CodePace.GetWork.API.TechnicalEvaluation.Domain.Model.Queries;

namespace CodePace.GetWork.API.TechnicalEvaluation.Domain.Services;

public interface ITechnicalTestQueryService
{
    public Task<IEnumerable<TechnicalTest>> Handle(GetAllTechnicalTestsQuery query);
    public Task<IEnumerable<TechnicalTest>?> Handle(GetAllTechnicalTaskByTestTypeQuery query);

}