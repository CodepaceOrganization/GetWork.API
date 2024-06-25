using CodePace.GetWork.API.Profiles.Domain.Model.Aggregates;
using CodePace.GetWork.API.Profiles.Domain.Model.Queries;

namespace CodePace.GetWork.API.Profiles.Domain.Services;

public interface IProfileQueryService
{
    Task<IEnumerable<Profile>> Handle(GetAllProfilesQuery query);
    Task<Profile?> Handle(GetProfileByEmailQuery query);
    Task<Profile?> Handle(GetProfileByIdQuery query);
}