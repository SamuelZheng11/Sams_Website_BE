using MongoDB.Driver;
using Sams_Website_BE.Dto;

namespace Sams_Website_BE.Repository
{
    public class EducationRepository 
    {
        private const string collectionName = "Education";
        private readonly IMongoCollection<EducationDto> _dbCollection;
        private FilterDefinitionBuilder<EducationDto> _filterBuilder = Builders<EducationDto>.Filter;

        public EducationRepository()
        {
            var mongoClient = new MongoClient("mongodb://localhost:27017");
            var database = mongoClient.GetDatabase("SamsWebsiteDB");
            _dbCollection = database.GetCollection<EducationDto>(collectionName);
        }

        public async Task<IReadOnlyCollection<EducationDto>> GetAllAsync()
        {
            return await _dbCollection.Find(_filterBuilder.Empty).ToListAsync();
        }

        public async Task<EducationDto> GetAsync(Guid id)
        {
            FilterDefinition<EducationDto> filter = _filterBuilder.Eq(e => e.Id, id);
            return await _dbCollection.Find(filter).FirstOrDefaultAsync();
        }
    }
}