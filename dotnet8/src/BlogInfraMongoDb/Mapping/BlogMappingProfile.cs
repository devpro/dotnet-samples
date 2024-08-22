﻿using AutoMapper;

namespace DotnetSamples.BlogInfraMongoDb.Mapping;

public class BlogMappingProfile : Profile
{
    public override string ProfileName
    {
        get { return "DotnetSamplesBlogInfraMongoDbMappingProfile"; }
    }

    public BlogMappingProfile()
    {
        CreateMap<Entities.Category, BlogDomain.Models.CategoryModel>()
            .ReverseMap();
    }
}
