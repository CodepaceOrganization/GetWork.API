using CodePace.GetWork.API.Profiles.Domain.Model.Aggregates;
using CodePace.GetWork.API.Profiles.Domain.Model.ValueObjects;
using CodePace.GetWork.API.Profiles.Domain.Repositories;
using CodePace.GetWork.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using CodePace.GetWork.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CodePace.GetWork.API.Profiles.Infrastructure.Persistence.EFC.Repositories;

public class ProfileRepository(AppDbContext context) : BaseRepository<Profile>(context), IProfileRepository
{
    public Task<Profile?> FindProfileByEmailAsync(EmailAddress email)
    {
        return Context.Set<Profile>().Where(p => p.Email == email).FirstOrDefaultAsync();
    }
}