using System.Linq;
using System.Web.Http;
using CoursesAPI.Models;
using CoursesAPI.Services.DataAccess;
using CoursesAPI.Services.Services;

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

		[HttpGet]
		[AllowAnonymous]
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
		/// </summary>
		/// <param name="id"></param>
		/// <param name="model"></param>
		/// <returns></returns>
		[HttpPost]
		[Route("{id}/teachers")]
		public IHttpActionResult AddTeacher(int id, AddTeacherViewModel model)
		{
			var result = _service.AddTeacherToCourse(id, model);
			return Created("TODO", result);
		}
	}
}
