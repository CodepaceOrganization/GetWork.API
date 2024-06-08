namespace CodePace.GetWork.API.CourseContest.Domain.Model.ValueObjects;

public class CourseDate
{
    public DateTime Date { get; set; }

    public CourseDate(DateTime date)
    {
        Date = date;
    }
}