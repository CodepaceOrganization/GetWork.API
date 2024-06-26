
namespace CodePace.GetWork.API.contest.Domain.Model.Entities;

public class ImageAssetContest : Asset
{
    public string? ImageUri { get; set; } 

    public override bool Readable()
    {
        return Status == "publicado";
    }

    public override bool Viewable()
    {
        return Type == "imagen";
    }

    public override string GetContent()
{
    if (ImageUri == null)
    {
        throw new InvalidOperationException("ImageUri no puede ser nulo");
    }

    return ImageUri;
}
}