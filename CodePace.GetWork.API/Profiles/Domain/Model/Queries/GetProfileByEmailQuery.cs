using CodePace.GetWork.API.Profiles.Domain.Model.ValueObjects;

namespace CodePace.GetWork.API.Profiles.Domain.Model.Queries;

public record GetProfileByEmailQuery(EmailAddress Email);