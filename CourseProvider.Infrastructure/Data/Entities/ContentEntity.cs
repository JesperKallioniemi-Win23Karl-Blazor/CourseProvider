namespace CourseProvider.Infrastructure.Data.Entities;

public class ContentEntity
{
    public string? Description { get; set; }
    public string[]? Includes { get; set; }
    public string[]? Learn { get; set; }

    public virtual List<ProgramDetailItemEntity>? Items { get; set; }
}
