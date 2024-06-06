using CodePace.GetWork.API.Shared.Domain.Repositories;
using CodePace.GetWork.API.TechnicalEvaluation.Domain.Model.Entities;

namespace CodePace.GetWork.API.TechnicalEvaluation.Domain.Repositories;

public interface ITechnicalTaskRepository: IBaseRepository<TechnicalTask>
{
    Task<IEnumerable<TechnicalTask>> FindTechnicalsTestByTechnicalTestId(int id);
    Task<TechnicalTask?> FindByIdAndUserIdAsync(int id, int userId);
}