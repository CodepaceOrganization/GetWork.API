namespace CodePace.GetWork.API.contest.Domain.Model.Entities;

public record GetWorkAssetIdentifier(Guid Identifier)
{
    public GetWorkAssetIdentifier() : this(Guid.NewGuid())
    {
    }
};