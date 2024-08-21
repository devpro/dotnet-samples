﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DotnetSamples.BlogInfraMongoDb.Entities;

public class Category
{
    [BsonId]
    public ObjectId Id { get; set; }

    [BsonElement("name")]
    public string Name { get; set; } = string.Empty;
}
