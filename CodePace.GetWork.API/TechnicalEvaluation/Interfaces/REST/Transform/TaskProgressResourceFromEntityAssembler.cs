using CodePace.GetWork.API.TechnicalEvaluation.Domain.Model.Entities;
using CodePace.GetWork.API.TechnicalEvaluation.Interfaces.REST.Resources;

namespace CodePace.GetWork.API.TechnicalEvaluation.Interfaces.REST.Transform;

public static class TaskProgressResourceFromEntityAssembler
{
    /*public static TaskProgressResource ToResourceFromEntity(TaskProgress entity)
    {
        Console.WriteLine("Category Name is " + entity.Progress);
        return new TaskProgressResource(
            entity.Id, 
            entity.UserId, 
            entity.TechnicalTaskId, 
            TechnicalTaskResourceFromEntityAssembler.ToResourceFromEntity(entity.TechnicalTask), entity.Progress);
    }*/
}