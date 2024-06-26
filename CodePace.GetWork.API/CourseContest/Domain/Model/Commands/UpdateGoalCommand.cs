namespace CodePace.GetWork.API.CourseContest.Domain.Model.Commands;

public record UpdateGoalCommand(
    int Id,
    string Value
    );