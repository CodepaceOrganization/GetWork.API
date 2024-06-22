using CodePace.GetWork.API.Profiles.Domain.Model.Aggregates;
using CodePace.GetWork.API.Profiles.Domain.Model.Commands;

namespace CodePace.GetWork.API.Profiles.Domain.Services;

public interface IProfileCommandService
{
    Task<Profile?> Handle(CreateProfileCommand command);
}