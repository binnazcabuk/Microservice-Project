using AutoMapper;
using Catalog.Service.API.Dtos;
using Catalog.Service.API.Model;
using Catalog.Service.API.MongoDbSettings;
using MongoDB.Driver;
using Shared.BaseResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Service.API.Services
{
    public class CourseService: ICourseService
    {
        private readonly IMongoCollection<Course> _courseCollection;
        private readonly IMongoCollection<Category> _categoryCollection;

        private readonly IMapper _mapper;

        public CourseService(IMapper mapper,IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _courseCollection=database.GetCollection<Course>(databaseSettings.CourseCollectionName);
            _categoryCollection=database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _mapper=mapper;
        }


        public async Task<BaseResponse> getAllAsync()
        {
            //mongodb de join işlemi olmadığı için categorydto tektek eklenir.

            var courses = await _courseCollection.Find(c => true).ToListAsync();
            if (courses.Any())
            {
                foreach (var course in courses)
                {
                    course.category=await _categoryCollection.Find<Category>(x => x.id==course.categoryId).FirstAsync();
                   // course.category=await _categoryCollection.Find(x => x.id==course.categoryId).FirstAsync();
                }
            }
            else
            {
                courses=new List<Course>();
            }
            return new BaseResponse<List<CourseDto>>(_mapper.Map<List<CourseDto>>(courses));

        }

        public async Task<BaseResponse> getByIdAsync(string id)
        {
            var course = await _courseCollection.Find(x => x.id==id).FirstOrDefaultAsync();

            if (course==null)
            {
                return BaseErrorCode.ecUknownError.CreateResponse("Not found course");
            }

            course.category=await _categoryCollection.Find(x => x.id==course.categoryId).FirstAsync();
            return new BaseResponse<CourseDto>(_mapper.Map<CourseDto>(course));
        }

        public async Task<BaseResponse> getAllByUserIdAsync(string id)
        {
            var courses = await _courseCollection.Find(x => x.userId==id).ToListAsync();

            if (courses.Any())
            {
                foreach (var course in courses)
                {
                    course.category=await _categoryCollection.Find<Category>(x => x.id==course.categoryId).FirstAsync();
                    // course.category=await _categoryCollection.Find(x => x.id==course.categoryId).FirstAsync();
                }
            }
            else
            {
                courses=new List<Course>();
            }
           
            return new BaseResponse<CourseDto>(_mapper.Map<CourseDto>(courses));
        }

        public async Task<BaseResponse> createAsync(CourseCreatedDto courseDto)
        {
            var newCourse = _mapper.Map<Course>(courseDto);
            newCourse.createdTime=DateTime.Now;
            await _courseCollection.InsertOneAsync(newCourse);

            return new BaseResponse<CourseDto>(_mapper.Map<CourseDto>(newCourse));
        }

        public async Task<BaseResponse> updateAsync(CourseUpdatedDto updatedDto)
        {

            var updatedCourse = _mapper.Map<Course>(updatedDto);
            var result = await _courseCollection.FindOneAndReplaceAsync<Course>(x => x.id==updatedDto.id, updatedCourse);

            if (result==null)
            {
                return BaseErrorCode.ecUknownError.CreateResponse("Course not found");
            }

            return new BaseResponse();
        }

        public async Task<BaseResponse>deleteAsync(string id)
        {
            var result = await _courseCollection.DeleteOneAsync(x => x.id==id);

            if (result.DeletedCount>0)
            {
                return new BaseResponse();
            }
            else
            {
                return new BaseResponse<string>("Course not fpund");
            }
        }
    }

    
}
