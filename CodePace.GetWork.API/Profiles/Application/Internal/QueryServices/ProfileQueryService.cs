using CodePace.GetWork.API.Profiles.Domain.Model.Aggregates;
using CodePace.GetWork.API.Profiles.Domain.Model.Queries;
using CodePace.GetWork.API.Profiles.Domain.Repositories;
using CodePace.GetWork.API.Profiles.Domain.Services;

namespace CodePace.GetWork.API.Profiles.Application.Internal.QueryServices;

public class ProfileQueryService(IProfileRepository profileRepository) : IProfileQueryService
{
    public async Task<IEnumerable<Profile>> Handle(GetAllProfilesQuery query)
    {
        return await profileRepository.ListAsync();
    }

    public async Task<Profile?> Handle(GetProfileByEmailQuery query)
    {
        return await profileRepository.FindProfileByEmailAsync(query.Email);
    }

    public async Task<Profile?> Handle(GetProfileByIdQuery query)
    {
        return await profileRepository.FindByIdAsync(query.ProfileId);
    }
}