using AutoMapper;
using MongoDB.Bson;

namespace DotnetSamples.BlogInfraMongoDb.Mapping;

public class StringToObjectIdConverter : ITypeConverter<string, ObjectId>
{
    public ObjectId Convert(string source, ObjectId destination, ResolutionContext context)
    {
        if (string.IsNullOrEmpty(source) || !ObjectId.TryParse(source, out var output))
        {
            return ObjectId.Empty;
        }

        return output;
    }
}
