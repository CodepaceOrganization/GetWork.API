using CodePace.GetWork.API.Tutors.Domain.Model.Entities;
using CodePace.GetWork.API.Tutors.Domain.Model.Queries;

namespace CodePace.GetWork.API.Tutors.Domain.Services
{
    public interface ITutorsQueryService
    {
        Task<IEnumerable<Tutor>> GetAllTutorsAsync(GetAllTutorsQuery query);
        Task<Tutor> GetTutorByIdAsync(GetTutorsByIdQuery query);
    }
}