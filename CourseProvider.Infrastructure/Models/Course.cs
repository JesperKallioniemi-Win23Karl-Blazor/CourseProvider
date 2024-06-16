namespace CourseProvider.Infrastructure.Models;

public class Course
{
        public string? Id { get; set; }
        public string? ImageUri { get; set; }
        public string? ImageHeaderUri { get; set; }
        public bool IsBestseller { get; set; }
        public bool IsDigital { get; set; }
        public string[]? Categories { get; set; }
        public string? Title { get; set; }
        public string? Ingress { get; set; }
        public decimal StarRating { get; set; }
        public string? Reviews { get; set; }
        public string? LikesInProcent { get; set; }
        public string? Likes { get; set; }
        public string? Hours { get; set; }
        public virtual List<Author>? Authors { get; set; }
        public virtual Prices? Prices { get; set; }
        public virtual Content? Content { get; set; }
        public virtual ProgramDetailItem? ProgramDetails { get; set; }
    }

    public class Author
    {
        public string? Name { get; set; }
    }

    public class Content
    {
        public string? Description { get; set; }
        public string[]? Includes { get; set; }
        public string[]? Learn { get; set; }
    }

    public class Prices
    {
        public string? Currency { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
    }

    public class ProgramDetailItem
    {
        public string? Title_1 { get; set; }
        public string? Description_1 { get; set; }
        public string? Title_2 { get; set; }
        public string? Description_2 { get; set; }
        public string? Title_3 { get; set; }
        public string? Description_3 { get; set; }
    }

