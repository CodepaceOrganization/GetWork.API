using System;

namespace CodePace.GetWork.API.contest.Domain.Model.Entities;

public abstract class Asset
{
    public int Id { get; set; }
    public GetWorkAssetIdentifier AssetIdentifier { get; set; }
    public string Status { get; set; }
    public string Type { get; set; }

    public abstract bool Readable();
    public abstract bool Viewable();
    public abstract string GetContent();
    
}