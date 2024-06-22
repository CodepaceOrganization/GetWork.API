using CodePace.GetWork.API.Profiles.Domain.Model.Aggregates;
using CodePace.GetWork.API.Profiles.Domain.Model.ValueObjects;
using CodePace.GetWork.API.Shared.Domain.Repositories;

namespace CodePace.GetWork.API.Profiles.Domain.Repositories;

public interface IProfileRepository : IBaseRepository<Profile>
{
    Task<Profile?> FindProfileByEmailAsync(EmailAddress email);
}