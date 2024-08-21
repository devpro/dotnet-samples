using AutoMapper;
using MongoDB.Bson;

namespace DotnetSamples.BlogInfraMongoDb.Mapping;

public class ObjectIdToStringConverter : ITypeConverter<ObjectId, string>
{
    public string Convert(ObjectId source, string destination, ResolutionContext context)
    {
        if (source == ObjectId.Empty)
        {
            return string.Empty;
        }

        return source.ToString();
    }
}
