using CodePace.GetWork.API.Plans.Domain.Model.Commands;
using CodePace.GetWork.API.Plans.Domain.Model.ValueObjects;

namespace CodePace.GetWork.API.Plans.Domain.Model.Aggregates;

public partial class Subscription
{
    public long Id { get;  set; }
    public DateTime StartDate { get;  set; }
    public DateTime EndDate { get;  set; }
    public float Cost { get;  set; }
    //public IdStudent StudentId { get; private set; }
}


public partial class Subscription
{
  
   
    public Subscription(float cost) 
    {
        Cost = cost;
        //StudentId = idStudent;
    }

    public Subscription(CreateSubscriptionCommand command)
    { 
        Cost = command.Cost;
        EndDate = DateTime.Now.AddMonths(1);
        StartDate = DateTime.Now;
    }
    
    
}