using CodePace.GetWork.API.CourseContest.Domain.Model.Commands;
using CodePace.GetWork.API.CourseContest.Domain.Model.Entities;
using CodePace.GetWork.API.CourseContest.Domain.Repositories;
using CodePace.GetWork.API.CourseContest.Domain.Services;
using CodePace.GetWork.API.Shared.Domain.Repositories;
using System;
using System.Threading.Tasks;
using CodePace.GetWork.API.CourseContest.Domain.Model.Aggregates;

namespace CodePace.GetWork.API.CourseContest.Application.Internal.CommandServices
{
    public class DetailCommandService(ICourseDetailRepository courseDetailRepository, IUnitOfWork unitOfWork)
        : IDetailCommandService
    {
        public async Task<CourseDetail?> Handle(CreateCourseDetailCommand command)
        {
            var courseDetail = new CourseDetail(
                command.ContestId, 
                command.description, 
                command.image, 
                command.image2, 
                command.image3, 
                command.introduction, 
                command.development, 
                command.test
                );
            await courseDetailRepository.AddAsync(courseDetail);
            await unitOfWork.CompleteAsync();
            return courseDetail;
        }

        public async Task<CourseDetail?> Handle(UpdateCourseDetailCommand command)
        {
            var courseDetail = await courseDetailRepository.FindByIdAsync(command.Id);
            if (courseDetail == null)
            {
                throw new ArgumentException("No course detail with the provided ID could be found.", nameof(UpdateCourseDetailCommand.Id));
            }

            courseDetail.UpdateDescription(command.description);
            courseDetail.UpdateImages(new Dictionary<string, string> { { "Image", command.image }, { "Image2", command.image2 }, { "Image3", command.image3 } });
            courseDetail.UpdateIntroduction(command.introduction);
            courseDetail.UpdateDevelopment(command.development);
            courseDetail.UpdateTest(command.test);

            await unitOfWork.CompleteAsync();
            return courseDetail;
        }

        public async Task DeleteCourseDetailAsync(int courseId)
        {
            var courseDetail = await courseDetailRepository.FindByIdAsync(courseId);
            if (courseDetail == null) throw new Exception("Course detail not found");
            courseDetailRepository.Remove(courseDetail);
            await unitOfWork.CompleteAsync();
        }
    }
}