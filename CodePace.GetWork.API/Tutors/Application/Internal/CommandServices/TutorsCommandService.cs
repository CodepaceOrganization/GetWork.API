using CodePace.GetWork.API.Tutors.Domain.Model.Commands;
using CodePace.GetWork.API.Tutors.Domain.Model.Entities;
using CodePace.GetWork.API.Tutors.Infrastructure.Persistence.EFC.Repositories;
using CodePace.GetWork.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using CodePace.GetWork.API.Tutors.Domain.Services;

using CodePace.GetWork.API.Tutors.Domain.Model.Queries;
using CodePace.GetWork.API.Tutors.Domain.Repositories;

namespace CodePace.GetWork.API.Tutors.Application.Internal.CommandServices
{
    public class TutorsCommandService : ITutorsCommandService
    {
        private readonly ITutorRepository _tutorRepository;
        private readonly UnitOfWork _unitOfWork;

        public TutorsCommandService(ITutorRepository tutorRepository, UnitOfWork unitOfWork)
        {
            _tutorRepository = tutorRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Tutor> CreateTutorAsync(CreateTutorsCommand command)

        {
            var tutor = new Tutor
            {
                Name = command.Name,
                Description = command.Description,
                Image = command.Image,
                Times = command.Times
            };
            await _tutorRepository.AddAsync(tutor);
            await _unitOfWork.CompleteAsync();

            return tutor;
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