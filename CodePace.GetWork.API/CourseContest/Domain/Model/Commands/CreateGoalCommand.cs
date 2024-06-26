namespace CodePace.GetWork.API.CourseContest.Domain.Model.Commands;

public record CreateGoalCommand(
    int CourseDetailId,
    string Value
    ){}