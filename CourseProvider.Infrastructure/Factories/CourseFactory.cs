using CourseProvider.Infrastructure.Data.Entities;
using CourseProvider.Infrastructure.Models;

namespace CourseProvider.Infrastructure.Factories;

public static class CourseFactory
{
    public static CourseEntity Create(CourseCreateRequest request)
    {
        return new CourseEntity
        {
            ImageUri = request.ImageUri,
            ImageHeaderUri = request.ImageHeaderUri,
            IsBestseller = request.IsBestseller,
            IsDigital = request.IsDigital,
            Categories = request.Categories,
            Title = request.Title,
            Ingress = request.Ingress,
            StarRating = request.StarRating,
            Reviews = request.Reviews,
            LikesInProcent = request.LikesInProcent,
            Likes = request.Likes,
            Hours = request.Hours,
            Authors = request.Authors?.Select(a => new AuthorEntity
            {
                Name = a.Name
            }).ToList(),
            Prices = request.Prices == null ? null : new PricesEntity
            {
                Currency = request.Prices.Currency,
                Price = request.Prices.Price,
                Discount = request.Prices.Discount
            },
            Content = request.Content == null ? null : new ContentEntity
            {
                Description = request.Content.Description,
                Includes = request.Content.Includes,
                Learn = request.Content.Learn,
            },
            ProgramDetails = request.ProgramDetails == null ? null : new ProgramDetailItemEntity
            {
                Title_1 = request.ProgramDetails.Title_1,
                Description_1 = request.ProgramDetails.Description_1,
                Title_2 = request.ProgramDetails.Title_2,
                Description_2 = request.ProgramDetails.Description_2,
                Title_3 = request.ProgramDetails.Title_3,
                Description_3 = request.ProgramDetails.Description_3,
            }
        };
    }

    public static CourseEntity Update(CourseUpdateRequest request)
    {
        return new CourseEntity
        {
            Id = request.Id!,
            ImageUri = request.ImageUri,
            ImageHeaderUri = request.ImageHeaderUri,
            IsBestseller = request.IsBestseller,
            IsDigital = request.IsDigital,
            Categories = request.Categories,
            Title = request.Title,
            Ingress = request.Ingress,
            StarRating = request.StarRating,
            Reviews = request.Reviews,
            LikesInProcent = request.LikesInProcent,
            Likes = request.Likes,
            Hours = request.Hours,
            Authors = request.Authors?.Select(a => new AuthorEntity
            {
                Name = a.Name
            }).ToList(),
            Prices = request.Prices == null ? null : new PricesEntity
            {
                Currency = request.Prices.Currency,
                Price = request.Prices.Price,
                Discount = request.Prices.Discount
            },
            Content = request.Content == null ? null : new ContentEntity
            {
                Description = request.Content.Description,
                Includes = request.Content.Includes,
                Learn = request.Content.Learn,
            },
            ProgramDetails = request.ProgramDetails == null ? null : new ProgramDetailItemEntity
            {
                Title_1 = request.ProgramDetails.Title_1,
                Description_1 = request.ProgramDetails.Description_1,
                Title_2 = request.ProgramDetails.Title_2,
                Description_2 = request.ProgramDetails.Description_2,
                Title_3 = request.ProgramDetails.Title_3,
                Description_3 = request.ProgramDetails.Description_3,
            }
        };
    }

    public static Course Create(CourseEntity entity)
    {
        return new Course
        {
            Id = entity.Id,
            ImageUri = entity.ImageUri,
            ImageHeaderUri = entity.ImageHeaderUri,
            IsBestseller = entity.IsBestseller,
            IsDigital = entity.IsDigital,
            Categories = entity.Categories,
            Title = entity.Title,
            Ingress = entity.Ingress,
            StarRating = entity.StarRating,
            Reviews = entity.Reviews,
            LikesInProcent = entity.LikesInProcent,
            Likes = entity.Likes,
            Hours = entity.Hours,
            Authors = entity.Authors?.Select(a => new Author
            {
                Name = a.Name
            }).ToList(),
            Prices = entity.Prices == null ? null : new Prices
            {
                Currency = entity.Prices.Currency,
                Price = entity.Prices.Price,
                Discount = entity.Prices.Discount
            },
            Content = entity.Content == null ? null : new Content
            {
                Description = entity.Content.Description,
                Includes = entity.Content.Includes,
                Learn = entity.Content.Learn,
            },
            ProgramDetails = entity.ProgramDetails == null ? null : new ProgramDetailItem
            {
                Title_1 = entity.ProgramDetails.Title_1,
                Description_1 = entity.ProgramDetails.Description_1,
                Title_2 = entity.ProgramDetails.Title_2,
                Description_2 = entity.ProgramDetails.Description_2,
                Title_3 = entity.ProgramDetails.Title_3,
                Description_3 = entity.ProgramDetails.Description_3,
            }
        };
    }
}