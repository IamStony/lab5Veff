using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesAPI.Services.Exceptions
{
	public class ErrorCodes
	{
		public const string INVALID_COURSEINSTANCEID          = "INVALID_COURSEINSTANCEID";
		public const string COURSE_ALREADY_HAS_A_MAIN_TEACHER = "COURSE_ALREADY_HAS_A_MAIN_TEACHER";
		public const string TEACHER_IS_NOT_FOUND_IN_PERSON    = "TEACHER IS NOT REGESTERED AS PERSON";
	}
}

