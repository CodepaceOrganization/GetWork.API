namespace CodePace.GetWork.API.CourseContest.Domain.Model.ValueObjects;

public class Contest
{
    public string Name { get; set; }
    public DateTime ContestDate { get; set; }

    public Contest(string name, DateTime contestDate)
    {
        Name = name;
        ContestDate = contestDate;
    }
}