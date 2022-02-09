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

                _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
                _mapper = mapper;
            }

            public async Task<Response<List<CategoryDto>>> GetAllAsync()
            {
                var categories = await _categoryCollection.Find(category => true).ToListAsync();

                return Response<List<CategoryDto>>.Success(_mapper.Map<List<CategoryDto>>(categories), 200);
            }

            public async Task<Response<CategoryDto>> CreateAsync(CategoryDto categoryDto)
            {
                var category = _mapper.Map<Category>(categoryDto);
                await _categoryCollection.InsertOneAsync(category);

                return Response<CategoryDto>.Success(_mapper.Map<CategoryDto>(category), 200);
            }

            public async Task<Response<CategoryDto>> GetByIdAsync(string id)
            {
                var category = await _categoryCollection.Find<Category>(x => x.id == id).FirstOrDefaultAsync();

                if (category == null)
                {
                    return Response<CategoryDto>.Fail("Category not found", 404);
                }

                return Response<CategoryDto>.Success(_mapper.Map<CategoryDto>(category), 200);
            }
        }
    }
