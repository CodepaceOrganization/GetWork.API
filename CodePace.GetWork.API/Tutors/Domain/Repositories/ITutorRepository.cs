using CodePace.GetWork.API.Tutors.Domain.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodePace.GetWork.API.Tutors.Domain.Repositories
{
    public interface ITutorRepository
    {
        Task<List<Tutor>> GetAllAsync();
        Task<Tutor> GetByIdAsync(int id);
        Task AddAsync(Tutor tutorEntity);
        Task UpdateAsync(Tutor tutorEntity);
        Task DeleteAsync(Tutor tutorEntity);
    }
}