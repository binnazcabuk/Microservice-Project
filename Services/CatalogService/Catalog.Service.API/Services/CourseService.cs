using AutoMapper;
using Catalog.Service.API.Dtos;
using Catalog.Service.API.Model;
using Catalog.Service.API.MongoDbSettings;
using MongoDB.Driver;
using Shared.BaseResponses;
using Shared.Dtos;
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
      // private readonly Mass.IPublishEndpoint _publishEndpoint;

        public CourseService(IMapper mapper, IDatabaseSettings databaseSettings/*, Mass.IPublishEndpoint publishEndpoint*/)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);

            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _courseCollection = database.GetCollection<Course>(databaseSettings.CourseCollectionName);

            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _mapper = mapper;

           // _publishEndpoint = publishEndpoint;
        }

        public async Task<Response<List<CourseDto>>> GetAllAsync()
        {
            var courses = await _courseCollection.Find(course => true).ToListAsync();

            if (courses.Any())
            {
                foreach (var course in courses)
                {
                    course.category = await _categoryCollection.Find<Category>(x => x.id == course.categoryId).FirstAsync();
                }
            }
            else
            {
                courses = new List<Course>();
            }

            return Response<List<CourseDto>>.Success(_mapper.Map<List<CourseDto>>(courses), 200);
        }

        public async Task<Response<CourseDto>> GetByIdAsync(string id)
        {
            var course = await _courseCollection.Find<Course>(x => x.id == id).FirstOrDefaultAsync();

            if (course == null)
            {
                return Response<CourseDto>.Fail("Course not found", 404);
            }
            course.category = await _categoryCollection.Find<Category>(x => x.id == course.categoryId).FirstAsync();

            return Response<CourseDto>.Success(_mapper.Map<CourseDto>(course), 200);
        }

        public async Task<Response<List<CourseDto>>> GetAllByUserIdAsync(string userId)
        {
            var courses = await _courseCollection.Find<Course>(x => x.userId == userId).ToListAsync();

            if (courses.Any())
            {
                foreach (var course in courses)
                {
                    course.category = await _categoryCollection.Find<Category>(x => x.id == course.categoryId).FirstAsync();
                }
            }
            else
            {
                courses = new List<Course>();
            }

            return Response<List<CourseDto>>.Success(_mapper.Map<List<CourseDto>>(courses), 200);
        }

        public async Task<Response<CourseDto>> CreateAsync(CourseCreatedDto courseCreateDto)
        {
            var newCourse = _mapper.Map<Course>(courseCreateDto);

            newCourse.createdTime = DateTime.Now;
            await _courseCollection.InsertOneAsync(newCourse);

            return Response<CourseDto>.Success(_mapper.Map<CourseDto>(newCourse), 200);
        }

        public async Task<Response<NoContent>> UpdateAsync(CourseUpdatedDto courseUpdateDto)
        {
            var updateCourse = _mapper.Map<Course>(courseUpdateDto);

            var result = await _courseCollection.FindOneAndReplaceAsync(x => x.id == courseUpdateDto.id, updateCourse);

            if (result == null)
            {
                return Response<NoContent>.Fail("Course not found", 404);
            }

          //  await _publishEndpoint.Publish<CourseNameChangedEvent>(new CourseNameChangedEvent { CourseId = updateCourse.Id, UpdatedName = courseUpdateDto.Name });

            return Response<NoContent>.Success(204);
        }

        public async Task<Response<NoContent>> DeleteAsync(string id)
        {
            var result = await _courseCollection.DeleteOneAsync(x => x.id == id);

            if (result.DeletedCount > 0)
            {
                return Response<NoContent>.Success(204);
            }
            else
            {
                return Response<NoContent>.Fail("Course not found", 404);
            }
        }
    }


}
