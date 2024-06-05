namespace CodePace.GetWork.API.contest.Domain.Model.Commands;

public record CreateCourseToContestCommand(int CourseId, string Title, string Date, string Image);
