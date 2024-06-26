using CodePace.GetWork.API.Plans.Domain.Model.Aggregates;
using CodePace.GetWork.API.Plans.Domain.Repositories;
using CodePace.GetWork.API.Shared.Domain.Repositories;
using CodePace.GetWork.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using CodePace.GetWork.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CodePace.GetWork.API.Plans.Infrastructure.Persistence.EFC;

public class SubscriptionRepository : BaseRepository<Subscription>, ISubscriptionRepository
{
    private readonly AppDbContext _context;

    public SubscriptionRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Subscription?> FindByIdAsync(long id)
    {
        return await _context.Subscriptions.FirstOrDefaultAsync(subscription => subscription.Id == id);
    }

    public async Task<IEnumerable<Subscription>> ListAsync()
    {
        return await _context.Subscriptions.ToListAsync();
    }
}