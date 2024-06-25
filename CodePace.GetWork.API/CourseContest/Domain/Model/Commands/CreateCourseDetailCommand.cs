using CodePace.GetWork.API.CourseContest.Domain.Model.Entities;

namespace CodePace.GetWork.API.CourseContest.Domain.Model.Commands;

public record CreateCourseDetailCommand(
    int ContestId, 
    string description, 
    string image, 
    string image2, 
    string image3, 
    string introduction, 
    string development, 
    string test){}