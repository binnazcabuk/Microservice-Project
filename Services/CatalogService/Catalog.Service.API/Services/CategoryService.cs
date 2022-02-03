using AutoMapper;
using Catalog.Service.API.Dtos;
using Catalog.Service.API.Model;
using Catalog.Service.API.MongoDbSettings;
using MongoDB.Driver;
using Shared.BaseResponses;
using Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.Service.API.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;

        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, IDatabaseSettings databaseSettings)
        {

            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _mapper=mapper;
            _categoryCollection=database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
        }

        public async Task<BaseResponse> getAllAsync()
        {
            var categories = await _categoryCollection.Find(c => true).ToListAsync();

            return new BaseResponse<List<CategoryDto>>(_mapper.Map<List<CategoryDto>>(categories));

        }

        public async Task<BaseResponse> createAsync(CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);

            await _categoryCollection.InsertOneAsync(category);
            //    return Response<CategoryDto>.Success(_mapper.Map<CategoryDto>(category),200);

            return new BaseResponse<CategoryDto>(_mapper.Map<CategoryDto>(category));
        }

        public async Task<BaseResponse> getbyIdAsync(string id)
        {
            var category = await _categoryCollection.Find<Category>(c => c.id==id).FirstOrDefaultAsync();

            if (category==null)
            {
                return BaseErrorCode.ecUknownError.CreateResponse("Bilinmeyen bir hata oluştu.");
            }

            return new BaseResponse<CategoryDto>(_mapper.Map<CategoryDto>(category));
        }

    }
}
