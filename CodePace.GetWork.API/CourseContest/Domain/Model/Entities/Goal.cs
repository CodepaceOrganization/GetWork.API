using CodePace.GetWork.API.CourseContest.Domain.Model.Aggregates;

namespace CodePace.GetWork.API.CourseContest.Domain.Model.Entities;

public class Goal
{
    private string _value;
    
    protected internal Goal(
        int courseDetailId,
        string value)
    {
        CourseDetailId = courseDetailId;
        UpdateValue(value);
    }
    
    public int Id { get; set; }
    public string Value { get => _value; private set => UpdateValue(value); }
    public int CourseDetailId { get; set; }
    public CourseDetail CourseDetail { get; set; }
    
    public void UpdateValue(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentException("Value cannot be null or empty.", nameof(value));
        }

        _value = value;
    }
}