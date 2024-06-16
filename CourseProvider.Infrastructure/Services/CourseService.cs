using CourseProvider.Infrastructure.Data.Contexts;
using CourseProvider.Infrastructure.Data.Entities;
using CourseProvider.Infrastructure.Models;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore;
using CourseProvider.Infrastructure.Factories;

namespace CourseProvider.Infrastructure.Services
{
    public interface ICourseService
    {
        Task<Course> CreateCourseAsync(CourseCreateRequest request);
        Task<Course> GetCourseByIdAsync(string id);
        Task<IEnumerable<Course>> GetCoursesAsync();
        Task<Course> UpdateCourseAsync(CourseUpdateRequest request);
        Task<bool> DeleteCourseAsync(string id);
    }

    public class CourseService(IDbContextFactory<DataContext> contextFactory) : ICourseService
    {
        private readonly IDbContextFactory<DataContext> _contextFactory = contextFactory;

        public async Task<Course> CreateCourseAsync(CourseCreateRequest request)
        {
            await using var context = _contextFactory.CreateDbContext();

            var courseEntity = CourseFactory.Create(request);
            context.Courses.Add(courseEntity);
            await context.SaveChangesAsync();

            return CourseFactory.Create(courseEntity);
        }

        public async Task<bool> DeleteCourseAsync(string id)
        {
            await using var context = _contextFactory.CreateDbContext();
            var courseEntity = await context.Courses.FirstOrDefaultAsync(x => x.Id == id);
            if (courseEntity == null) return false;

            context.Courses.Remove(courseEntity);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<Course> GetCourseByIdAsync(string id)
        {
            await using var context = _contextFactory.CreateDbContext();
            var courseEntity = await context.Courses.FirstOrDefaultAsync(x => x.Id == id);

            return courseEntity == null ? null! : CourseFactory.Create(courseEntity);
        }

        public async Task<IEnumerable<Course>> GetCoursesAsync()
        {
            await using var context = _contextFactory.CreateDbContext();
            var courseEntities = await context.Courses.ToListAsync();

            return courseEntities.Select(CourseFactory.Create);
        }

        public async Task<Course> UpdateCourseAsync(CourseUpdateRequest request)
        {
            await using var context = _contextFactory.CreateDbContext();
            var existingCourse = await context.Courses
                .Include(c => c.Authors)
                .Include(c => c.Prices)
                .Include(c => c.Content)
                .ThenInclude(c => c!.Items)  // Ensure we include ProgramDetails within Content
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (existingCourse == null) return null!;

            context.Entry(existingCourse).CurrentValues.SetValues(request);

            if (request.Authors != null)
            {
                existingCourse.Authors!.Clear();
                existingCourse.Authors.AddRange(request.Authors.Select(a => new AuthorEntity { Name = a.Name }));
            }

            if (request.Prices != null)
            {
                if (existingCourse.Prices == null)
                {
                    existingCourse.Prices = new PricesEntity();
                }
                existingCourse.Prices.Currency = request.Prices.Currency;
                existingCourse.Prices.Price = request.Prices.Price;
                existingCourse.Prices.Discount = request.Prices.Discount;
            }

            if (request.Content != null)
            {
                if (existingCourse.Content == null)
                {
                    existingCourse.Content = new ContentEntity();
                }
                else
                {
                    // Clear existing program details
                    existingCourse.Content.Items?.Clear();
                }

                context.Entry(existingCourse.Content).CurrentValues.SetValues(request.Content);

                if (request.Content.ProgramDetails != null)
                {
                    existingCourse.Content.Items?.AddRange(request.Content.ProgramDetails.Select(pd => new ProgramDetailItemEntity
                    {
                       
                        Title = pd.Title,
                        Description = pd.Description
                    }));
                }
            }

            await context.SaveChangesAsync();
            return CourseFactory.Create(existingCourse);
        }

    }
}