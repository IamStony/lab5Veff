using System;
using System.Linq;
using System.Net;
using System.Web.Http;
using CoursesAPI.Models;
using CoursesAPI.Services.DataAccess;
using CoursesAPI.Services.Exceptions;
using CoursesAPI.Services.Services;
using WebApi.OutputCache.V2;

namespace CoursesAPI.Controllers
{
	[RoutePrefix("api/courses")]
	public class CoursesController : ApiController
	{
		private readonly CoursesServiceProvider _service;

		public CoursesController()
		{
			_service = new CoursesServiceProvider(new UnitOfWork<AppDataContext>());
		}

		/// <summary>
		/// Does not require any authentication
		/// Gets 1 page of courses ( 10 items )
		/// Sets the cache livespan for 1 day
		/// </summary>
		/// <param name="semester">example 20153</param>
		/// <param name="page">example 1, 2 or 3</param>
		/// <returns></returns>
		[HttpGet]
		[AllowAnonymous]
		[CacheOutput(ClientTimeSpan = 86400, ServerTimeSpan = 86400)]
		public IHttpActionResult GetCoursesBySemester(string semester = null, int page = 1)
		{
			// TODO: figure out the requested language (if any!)
			// and pass it to the service provider!
			bool english = false;
			var lan = Request.Headers.AcceptLanguage.FirstOrDefault();
			if (lan != null)
			{
				// I Thought this was the most logical solution
				// Example : If there is a french or german exhance student
				// have their browser set to german or french then they would get
				// courses in English
				if (lan.ToString() != "is")
				{
					english = true;
				}

			}
			return Ok(_service.GetCourseInstancesBySemester(semester, page, english));
		}

		/// <summary>
		/// Adds a teacher to course
		/// You have to have valid Autorize token in header to be able to run this function
		/// </summary>
		/// <param name="id"> ID of course</param>
		/// <param name="model">Info about teacher</param>
		/// <returns></returns>
		[HttpPost]
		[Authorize]
		[Route("{id}/teachers")]
		public IHttpActionResult AddTeacher(int id, AddTeacherViewModel model)
		{
			//var result = _service.AddTeacherToCourse(id, model);
			//return Created("byID", result);
			
			return Ok("Inside AddTeacher - Requires authorization");
		}

		/// <summary>
		/// Returns a course by id
		/// You have to have valid Autorize token in header to be able to run this function
		/// Roles not required and DABS said it would be allright to return
		/// just some fake data
		/// </summary>
		/// <param name="id">ID of course</param>
		/// <returns></returns>
		[HttpGet]
		[Authorize]
		[Route("{id}", Name = "byID")]
		public IHttpActionResult GetCourseById(int id)
		{
			try
			{
				return Ok("Getting course by id - Requires authorization");
			}
			catch (AppObjectNotFoundException e)
			{
				return NotFound();
			}
		}

		/// <summary>
		/// Creates a new course and that invalidates the cache
		/// You have to have valid Autorize token in header to be able to run this function
		/// </summary>
		/// <returns></returns>
		[HttpPost]
		[Authorize]
		[InvalidateCacheOutput("GetCoursesBySemester")]
		public IHttpActionResult CreateNewCourse()
		{
			return StatusCode(HttpStatusCode.Created);
		}
	}
}
