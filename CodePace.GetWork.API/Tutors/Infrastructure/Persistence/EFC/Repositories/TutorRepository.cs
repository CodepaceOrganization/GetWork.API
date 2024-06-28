using CodePace.GetWork.API.Tutors.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;
using CodePace.GetWork.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using CodePace.GetWork.API.Tutors.Domain.Repositories;

namespace CodePace.GetWork.API.Tutors.Infrastructure.Persistence.EFC.Repositories
{
    public class TutorRepository : ITutorRepository
    {
        private readonly AppDbContext _context;

        public TutorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Tutor>> GetAllAsync()
        {
            return await _context.Set<Tutor>().ToListAsync();
        }

        public async Task<Tutor> GetByIdAsync(int id)
        {
            return await _context.Set<Tutor>().FindAsync(id);
        }

        public async Task AddAsync(Tutor tutorEntity)
        {
            await _context.Set<Tutor>().AddAsync(tutorEntity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Tutor tutorEntity)
        {
            _context.Set<Tutor>().Update(tutorEntity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Tutor tutorEntity)
        {
            _context.Set<Tutor>().Remove(tutorEntity);
            await _context.SaveChangesAsync();
        }
    }
}