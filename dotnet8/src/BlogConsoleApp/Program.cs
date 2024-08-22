Console.WriteLine("Hello, World!");

using var dbContext = new BlogDbContext(new DbContextOptionsBuilder<BlogDbContext>()
        .UseMongoDB("mongodb://localhost:27017/?readPreference=primary&appname=BlogBlazorApp&directConnection=true&ssl=false", "blog_blazor")
        .Options);

var mapper = new MapperConfiguration(x =>
    {
        x.AddProfile(new BlogMappingProfile());
        x.CreateMap<MongoDB.Bson.ObjectId, string>().ConvertUsing<ObjectIdToStringConverter>();
        x.CreateMap<string, MongoDB.Bson.ObjectId>().ConvertUsing<StringToObjectIdConverter>();
        x.AllowNullCollections = true;
    }).CreateMapper();

var repository = new BlogRepository(dbContext, mapper);

_ = await repository.SaveCategoryAsync(new CategoryModel { Name = $"Temp {DateTime.Now.Microsecond}" });

var categories = await repository.GetCategoriesAsync();
Console.WriteLine($"Number of categories found: {categories.Count}");
