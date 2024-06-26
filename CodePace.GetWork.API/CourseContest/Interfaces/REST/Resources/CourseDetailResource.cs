﻿namespace CodePace.GetWork.API.CourseContest.Interfaces.REST.Resources;

public record CourseDetailResource(
    int Id,
    string Description,
    string Image,
    string Image2,
    string Image3,
    string Introduction,
    string Development,
    string Test);