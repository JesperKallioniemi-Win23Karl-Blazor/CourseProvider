using CourseProvider.Infrastructure.Services;

namespace CourseProvider.Infrastructure.GraphQL.Mutations;

public class CourseMutation(ICourseService courseService)
{
    private readonly ICourseService _courseService = courseService;
}
