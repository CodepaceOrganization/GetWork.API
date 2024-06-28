using CodePace.GetWork.API.Tutors.Domain.Model.Queries;
using CodePace.GetWork.API.Tutors.Domain.Model.Entities;
using CodePace.GetWork.API.Tutors.Domain.Repositories;
using CodePace.GetWork.API.Tutors.Infrastructure.Persistence.EFC.Repositories;
using CodePace.GetWork.API.Tutors.Domain.Services;

namespace CodePace.GetWork.API.Tutors.Application.Internal.QueryServices
{
    public class TutorsQueryService : ITutorsQueryService
    {
        private readonly ITutorRepository _tutorRepository;

        public TutorsQueryService(ITutorRepository tutorRepository)
        {
            _tutorRepository = tutorRepository;
        }

        public async Task<IEnumerable<Tutor>> GetAllTutorsAsync(GetAllTutorsQuery query)
        {
            return await _tutorRepository.GetAllAsync();
        }

        public async Task<Tutor> GetTutorByIdAsync(GetTutorsByIdQuery query)
        {
            return await _tutorRepository.GetByIdAsync(query.Id);
        }
    }
}